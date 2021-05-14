using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Text.RegularExpressions;
using System.Net;
using System.IO;
using System.Reflection;

namespace 串口调试工具
{
    public partial class CheckUpdate : Form
    {
        Thread CheckVersionThread;
        Thread DownloadThread;
        string page = "";
        string my_url = "";

        const string LastVersion = "您当前使用的为最新版本!";
        const string HaveNewVersion = "检测到新版本,是否下载?";
        const string Downloading = "正在下载...";
        const string DownloadSuccess = "下载成功!";
        const string DownloadFailed = "下载失败!";

        public CheckUpdate()
        {
            InitializeComponent();
        }

        private void CheckUpdate_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (CheckVersionThread != null)
                {
                    if (CheckVersionThread.IsAlive)
                    {
                        CheckVersionThread.Abort();
                    }
                }
                if (DownloadThread != null)
                {
                    if (DownloadThread.IsAlive)
                    {
                        e.Cancel = true;
                    }
                }
            }
            catch { }
        }

        private void CheckUpdate_Load(object sender, EventArgs e)
        {
            this.Size = new Size(229, 144);
            Cancel_Button.Location = new Point((panel1.Size.Width - Cancel_Button.Size.Width) / 2, 75);
            Cancel_Button.Select();
            CheckVersionThread = new Thread(new ThreadStart(Compare));
            CheckVersionThread.Start();
        }

        private void Compare()
        {
            try
            {
                string my_version_str = Assembly.GetExecutingAssembly().GetName().Version.ToString();
                page = GetWebPage("http://chenlidong0815.blog.163.com/blog/static/31766830201042102434785/");
                if (page == "")
                {
                    SetTitle("无法获取最新版本信息!");
                    return;
                }
                string get_version_str = page.Substring(page.IndexOf("最新版本号: ") + 7, 30);
                get_version_str = get_version_str.Remove(get_version_str.IndexOf("&"));
                if (my_version_str == get_version_str)
                {
                    SetTitle(LastVersion);
                }
                else
                {
                    SetTitle(HaveNewVersion);
                }
            }
            catch { }
        }

        public static string GetWebPage(string uri_str)
        {
            try
            {
                Uri uri = new Uri(uri_str);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
                request.Timeout = 5000;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = new StreamReader(receiveStream, Encoding.Default);
                string SourceCode = readStream.ReadToEnd();
                response.Close();
                receiveStream.Close();
                readStream.Close();
                return SourceCode;
            }
            catch
            {
                return "";
            }
        }

        delegate void SetTextCallback(string text);

        private void SetTitle(string text)
        {
            if (Title.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetTitle);
                this.Invoke(d, text);
            }
            else
            {
                Title.Text = text;
            }
        }

        private void XunLeiDownload_LinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Regex regex = new Regex("下载地址1([\\s\\S]*?)下载地址1");
            Match mc = regex.Match(page);
            if (mc.Success)
            {
                string temp = mc.Value.Substring(mc.Value.IndexOf("http://"), mc.Value.Length - mc.Value.IndexOf("http://"));
                my_url = temp.Remove(temp.IndexOf("&quot"));
                Clipboard.Clear();
                Clipboard.SetDataObject(my_url);
            }
        }

        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OK_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NO_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void YES_Button_Click(object sender, EventArgs e)
        {
            Title.Text = "正在下载...";
            YES_Button.Visible = false;
            NO_Button.Visible = false;
            XunLeiDownload_LinkLabel.Visible = false;
            Cancel_Button.Visible = true;

            progressBar1.Size = new Size(panel1.Size.Width - 20, 15);
            progressBar1.Location = new Point((panel1.Size.Width - progressBar1.Size.Width) / 2, 35);
            Percent_Label.Location = new Point((panel1.Size.Width - Percent_Label.Size.Width) / 2, 53);
            Percent_Label.Text = "0%";
            progressBar1.Visible = true;
            Percent_Label.Visible = true;

            Regex regex = new Regex("下载地址1([\\s\\S]*?)下载地址1");
            Match mc = regex.Match(page);
            if (mc.Success)
            {
                string temp = mc.Value.Substring(mc.Value.IndexOf("http://"), mc.Value.Length - mc.Value.IndexOf("http://"));
                my_url = temp.Remove(temp.IndexOf("&quot"));
                DownloadThread = new Thread(new ThreadStart(DownloadFile));
                DownloadThread.Start();
            }
        }

        public void DownloadFile()
        {
            try
            {
                System.Net.HttpWebRequest Myrq = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(my_url);
                System.Net.HttpWebResponse myrp = (System.Net.HttpWebResponse)Myrq.GetResponse();
                long totalBytes = myrp.ContentLength;
                System.IO.Stream st = myrp.GetResponseStream();
                string file_name = my_url.Substring(my_url.LastIndexOf('/') + 1, my_url.Length - my_url.LastIndexOf('/') - 1);
                System.IO.Stream so = new System.IO.FileStream(file_name, System.IO.FileMode.Create);
                long totalDownloadedByte = 0;
                byte[] by = new byte[1024];
                int osize = st.Read(by, 0, (int)by.Length);
                while (osize > 0)
                {
                    totalDownloadedByte = osize + totalDownloadedByte;
                    System.Windows.Forms.Application.DoEvents();
                    so.Write(by, 0, osize);
                    SetProgressBar((int)totalBytes, (int)totalDownloadedByte);
                    SetPercent_Label(100 * totalDownloadedByte / totalBytes + "%");
                    osize = st.Read(by, 0, (int)by.Length);
                }
                so.Close();
                st.Close();
                SetTitle(DownloadSuccess);
                SetPercent_Label("100%");
                MessageBox.Show("最新版串口调试工具已成功下载到:\r\n" + Environment.CurrentDirectory + "\\" + file_name, DownloadSuccess);
            }
            catch (System.Exception ex)
            {
                SetTitle(DownloadFailed);
                MessageBox.Show(ex.ToString(), DownloadFailed);
            }
        }

        delegate void SetProgressBarCallback(int max, int value);

        private void SetProgressBar(int max, int value)
        {
            if (progressBar1.InvokeRequired)
            {
                SetProgressBarCallback d = new SetProgressBarCallback(SetProgressBar);
                this.Invoke(d, new object[] { max, value });
            }
            else
            {
                progressBar1.Maximum = max;
                progressBar1.Value = value;
            }
        }

        private void SetPercent_Label(string text)
        {
            if (Percent_Label.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetPercent_Label);
                this.Invoke(d, text);
            }
            else
            {
                Percent_Label.Text = text;
            }
        }

        private void Title_TextChanged(object sender, EventArgs e)
        {
            if (Title.Text == LastVersion)
            {
                Cancel_Button.Visible = false;
                OK_Button.Location = Cancel_Button.Location;
                OK_Button.Size = Cancel_Button.Size;
                OK_Button.Select();
                OK_Button.Visible = true;
            }
            else if (Title.Text == HaveNewVersion)
            {
                Cancel_Button.Visible = false;
                YES_Button.Location = new Point(Cancel_Button.Location.X - 20, Cancel_Button.Location.Y);
                NO_Button.Location = new Point(Cancel_Button.Location.X + Cancel_Button.Size.Width - NO_Button.Size.Width + 20, Cancel_Button.Location.Y);
                YES_Button.Select();
                XunLeiDownload_LinkLabel.Location = new Point((panel1.Size.Width - XunLeiDownload_LinkLabel.Size.Width) / 2, 40);
                YES_Button.Visible = true;
                NO_Button.Visible = true;
                XunLeiDownload_LinkLabel.Visible = true;
            }
            else if (Title.Text == DownloadSuccess)
            {
                Cancel_Button.Visible = false;
                OK_Button.Location = Cancel_Button.Location;
                OK_Button.Size = Cancel_Button.Size;
                OK_Button.Select();
                OK_Button.Visible = true;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void OK_Button_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Cancel_Button_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
