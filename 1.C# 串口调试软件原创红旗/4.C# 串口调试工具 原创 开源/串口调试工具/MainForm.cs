using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.IO.Ports;
using System.Threading;

namespace 串口调试工具
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            Init();
        }

        private void Compare()
        {
            try
            {
                string my_version_str = Assembly.GetExecutingAssembly().GetName().Version.ToString();
                string page = CheckUpdate.GetWebPage("http://chenlidong0815.blog.163.com/blog/static/31766830201042102434785/");
                if (page == "")
                {
                    return;
                }
                string get_version_str = page.Substring(page.IndexOf("最新版本号: ") + 7, 30);
                get_version_str = get_version_str.Remove(get_version_str.IndexOf("&"));
                if (my_version_str != get_version_str)
                {
                    ShowCheckUpdate();
                }
            }
            catch { }
        }

        delegate void ShowCheckUpdateCallback();

        private void ShowCheckUpdate()
        {
            try
            {
                if (this.InvokeRequired)
                {
                    ShowCheckUpdateCallback d = new ShowCheckUpdateCallback(ShowCheckUpdate);
                    this.Invoke(d);
                }
                else
                {
                    CheckUpdate_Button_Click(null, null);
                }
            }
            catch { }
        }

        private void Init()
        {
            GetPortName();
            if (PortName_ComboBox.Text == "")
            {
                PortName_ComboBox.Text = "COM1";
            }
            if (DataBits_ComboBox.Text == "")
            {
                DataBits_ComboBox.Text = "8";
            }
            if (StopBits_ComboBox.Text == "")
            {
                StopBits_ComboBox.Text = "1";
            }
            if (Parity_ComboBox.Text == "")
            {
                Parity_ComboBox.Text = "None";
            }
            Thread CheckVersionThread = new Thread(new ThreadStart(Compare));
            CheckVersionThread.Start();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Save();
            Environment.Exit(0);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Version version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
          //  this.Text = AssemblyTitle + "V" + version.Major + "." + version.Minor + "---红旗开发";
            OpenSerialPort();
            SetSendTextBox();
        }

        private void GetPortName()
        {
            string[] portNames = System.IO.Ports.SerialPort.GetPortNames();
            foreach (string name in portNames)
            {
                PortName_ComboBox.Items.Add(name);
            }
            this.PortName_ComboBox.Text = global::串口调试工具.Properties.Settings.Default.PortName;
        }

        private string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        private void AboutSoftware_Button_Click(object sender, EventArgs e)
        {
            AboutSoftware aboutSoftware = new AboutSoftware();
            aboutSoftware.Show();
        }

        private void CheckUpdate_Button_Click(object sender, EventArgs e)
        {
            CheckUpdate checkUpdate = new CheckUpdate();
            checkUpdate.Show();
        }

        private void PortName_ComboBox_TextChanged(object sender, EventArgs e)
        {
            if (serialPort.IsOpen)
            {
                CloseSerialPort();
                serialPort.PortName = PortName_ComboBox.Text;
                OpenSerialPort();
            }
            else
            {
                serialPort.PortName = PortName_ComboBox.Text;
            }
        }

        private void BaudRate_ComboBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                serialPort.BaudRate = Convert.ToInt32(BaudRate_ComboBox.Text);
            }
            catch 
            {
                MainMessage.Text = "波特率配置错误!";
            }
            BaudRate_Label.Text = serialPort.BaudRate.ToString();
        }

        private void DataBits_ComboBox_TextChanged(object sender, EventArgs e)
        {
            serialPort.DataBits = Convert.ToInt32(DataBits_ComboBox.Text);
        }

        private void StopBits_ComboBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (StopBits_ComboBox.Text == "0")
                    serialPort.StopBits = StopBits.None;
                else if (StopBits_ComboBox.Text == "1")
                    serialPort.StopBits = StopBits.One;
                else if (StopBits_ComboBox.Text == "2")
                    serialPort.StopBits = StopBits.OnePointFive;
                else if (StopBits_ComboBox.Text == "3")
                    serialPort.StopBits = StopBits.Two;
            }
            catch
            {
                MainMessage.Text = "停止位配置错误!";
            }
        }

        private void Parity_ComboBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Parity_ComboBox.Text == "None")
                    serialPort.Parity = Parity.None;
                else if (Parity_ComboBox.Text == "Odd")
                    serialPort.Parity = Parity.Odd;
                else if (Parity_ComboBox.Text == "Even")
                    serialPort.Parity = Parity.Even;
                else if (Parity_ComboBox.Text == "Mark")
                    serialPort.Parity = Parity.Mark;
                else if (Parity_ComboBox.Text == "Space")
                    serialPort.Parity = Parity.Space;
            }
            catch
            {
                MainMessage.Text = "校验位配置错误!";
            }
        }

        private void DTR_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            serialPort.DtrEnable = DTR_CheckBox.Checked;
        }

        private void RTS_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            serialPort.RtsEnable = RTS_CheckBox.Checked;
        }

        private void LoadConfig()
        {
            PortName_ComboBox_TextChanged(null, null);
            BaudRate_ComboBox_TextChanged(null, null);
            DataBits_ComboBox_TextChanged(null, null);
            StopBits_ComboBox_TextChanged(null, null);
            Parity_ComboBox_TextChanged(null, null);
            DTR_CheckBox_CheckedChanged(null, null);
            RTS_CheckBox_CheckedChanged(null, null);
        }

        private void SetOpen()
        {
            OpenClosePort_Button.Text = "关闭串口";
            Light.ForeColor = Color.Lime;
            Com_Status.Text = serialPort.PortName + "已打开";
            BaudRate_Label.Text = serialPort.BaudRate.ToString();
        }

        private void SetClose()
        {
            OpenClosePort_Button.Text = "打开串口";
            Light.ForeColor = Color.DarkGray;
            Com_Status.Text = serialPort.PortName + "已关闭";
            BaudRate_Label.Text = serialPort.BaudRate.ToString();
        }

        private void OpenSerialPort()
        {
            if (serialPort.IsOpen)
            {
                return;
            }
            try
            {
                LoadConfig();
                serialPort.DataReceived -= serialPort_DataReceived;
                serialPort.DataReceived += serialPort_DataReceived;
                serialPort.Encoding = Encoding.Default;
                serialPort.Open();
                if (serialPort.IsOpen)
                {
                    SetOpen();
                }
                else
                {
                    SetClose();
                }
            }
            catch
            {
                MainMessage.Text = "打开串口失败!";
            }
        }

        private void CloseSerialPort()
        {
            if (!serialPort.IsOpen)
            {
                return;
            }
            try
            {
                serialPort.DataReceived -= serialPort_DataReceived;
                while (SerialPortIsReceiving)
                {
                    Application.DoEvents();
                }
                serialPort.Close();
                if (serialPort.IsOpen)
                {
                    SetOpen();
                }
                else
                {
                    SetClose();
                }
            }
            catch
            {
                MainMessage.Text = "关闭串口失败!";
            }
        }

        private void OpenClosePort_Button_Click(object sender, EventArgs e)
        {
            if (OpenClosePort_Button.Text == "打开串口")
            {
                OpenSerialPort();
            }
            else
            {
                CloseSerialPort();
            }
        }

        bool SerialPortIsReceiving = false;
        int ReceiveCount = 0;
        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPortIsReceiving = true;

            try
            {
                if (HexDisplay_CheckBox.Checked)
                {
                    byte[] b = new byte[serialPort.BytesToRead];
                    ReceiveCount += b.Length;
                    serialPort.Read(b, 0, b.Length);
                    string str = "";
                    for (int i = 0; i < b.Length; i++)
                    {
                        str += string.Format("{0:X2} ", b[i]);
                    }
                    AppendTextBox(str);
                    str = null;
                }
                else
                {
                    ReceiveCount += serialPort.BytesToRead;
                    AppendTextBox(serialPort.ReadExisting());
                }
                SetReceiveCountLabel(ReceiveCount.ToString());
            }
            catch { }

            SerialPortIsReceiving = false;
        }

        delegate void SetTextCallback(string text);

        private void AppendTextBox(string text)
        {
            try
            {
                if (Receive_TextBox.InvokeRequired)
                {
                    SetTextCallback d = new SetTextCallback(AppendTextBox);
                    this.Invoke(d, text);
                }
                else
                {
                    Receive_TextBox.SuspendLayout();
                    if (text.Length == 1 && text[0] == (char)0x08)
                    {
                        if (Receive_TextBox.Text.Length > 0)
                        {
                            Receive_TextBox.SelectionStart = Receive_TextBox.Text.Length - 1;
                            Receive_TextBox.SelectionLength = 1;
                            Receive_TextBox.SelectedText = "";
                        }
                    }
                    else
                    {
                        Receive_TextBox.AppendText(text);
                    }
                    if (Receive_TextBox.Text.Length > 100000)
                    {
                        Receive_TextBox.Text = Receive_TextBox.Text.Substring(50000, Receive_TextBox.Text.Length - 50000);
                    }
                    Receive_TextBox.ResumeLayout(false);
                }
            }
            catch { }
        }

        private void SetReceiveCountLabel(string text)
        {
            try
            {
                if (ReceiveCount_Label.InvokeRequired)
                {
                    SetTextCallback d = new SetTextCallback(SetReceiveCountLabel);
                    this.Invoke(d, text);
                }
                else
                {
                    ReceiveCount_Label.Text = text;
                }
            }
            catch { }
        }

        private void Clearn_Button_Click(object sender, EventArgs e)
        {
            Receive_TextBox.Clear();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                Receive_TextBox.Font = fontDialog1.Font;
            }
        }

        int SendCount = 0;
        private void Receive_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                byte[] byte_arr = new byte[1];
                char[] char_arr = new char[1];
                char_arr[0] = e.KeyChar;
                byte_arr = Encoding.Default.GetBytes(char_arr, 0, 1);
                serialPort.Write(byte_arr, 0, byte_arr.Length);
                SendCount += byte_arr.Length;
                SendCount_Label.Text = SendCount.ToString();
            }
            catch { }
        }

        private void SetSendTextBox()
        {
            if (HexSend_CheckBox.Checked)
            {
                SendHex_TextBox.Visible = true;
                SendHex_TextBox.Enabled = true;
                SendString_TextBox.Visible = false;
                SendString_TextBox.Enabled = false;
            }
            else
            {
                SendHex_TextBox.Visible = false;
                SendHex_TextBox.Enabled = false;
                SendString_TextBox.Visible = true;
                SendString_TextBox.Enabled = true;
            }
        }

        private void HexSend_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            SetSendTextBox();
        }

        private void SendHex_TextBox_Leave(object sender, EventArgs e)
        {
            int temp = 0;
            string str = "";
            SendHex_TextBox.Text += " ";
            for (int i = 0; i < SendHex_TextBox.Text.Length; i++)
            {
                if (SendHex_TextBox.Text[i] == ' ')
                {
                    if (temp == 1)//单个字符
                    {
                        temp = 0;
                        str += "0" + SendHex_TextBox.Text.Substring(i - 1, 1) + " ";
                    }
                }
                else
                {
                    temp++;
                    if (temp == 2)
                    {
                        temp = 0;
                        str += SendHex_TextBox.Text.Substring(i - 1, 2) + " ";
                    }
                }
            }
            SendHex_TextBox.Text = str;
            string error = "";
            for (int i = 0; i < SendHex_TextBox.Text.Length; i += 3)
            {
                try
                {
                    byte b = Convert.ToByte(SendHex_TextBox.Text.Substring(i, 2), 16);
                }
                catch
                {
                    error += (i / 3 + 1) + ",";
                }
            }
            this.MainMessage.Text = "发送数据框第" + error.Substring(0, error.Length - 1) + "个数据错误!";
        }

        private void SerialPortSend()
        {
            if (!serialPort.IsOpen)
            {
                MainMessage.Text = "串口未打开,无法发送数据!";
                return;
            }
            try
            {
                byte[] byte_arr;
                if (HexSend_CheckBox.Checked)
                {
                    byte_arr = new byte[SendHex_TextBox.Text.Length / 3];
                    for (int i = 0; i < SendHex_TextBox.Text.Length; i += 3)
                    {
                        try
                        {
                            byte_arr[i / 3] = Convert.ToByte(SendHex_TextBox.Text.Substring(i, 2), 16);
                        }
                        catch
                        {

                        }
                    }
                }
                else
                {
                    string s = SendString_TextBox.Text;
                    byte_arr = Encoding.Default.GetBytes(s);
                }
                serialPort.Write(byte_arr, 0, byte_arr.Length);
                SendCount += byte_arr.Length;
                SendCount_Label.Text = SendCount.ToString();
            }
            catch
            {
                MainMessage.Text = "发送失败!";
            }
        }

        private void Send_Button_Click(object sender, EventArgs e)
        {
            SerialPortSend();
        }

        private void AutoSend_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (AutoSend_CheckBox.Checked)
            {
                timer1.Interval = (int)Cycle_NumericUpDown.Value;
                timer1.Start();
            }
            else
            {
                timer1.Stop();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            SerialPortSend();
            timer1.Interval = (int)Cycle_NumericUpDown.Value;
        }

        private void MainMessage_TextChanged(object sender, EventArgs e)
        {
            if (MainMessage.Text == "就绪")
            {
                return;
            }
            else
            {
                MainMessage.ForeColor = Color.Red;
                timer2.Start();
                timer2.Interval = 2000;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            MainMessage.Text = "就绪";
            MainMessage.ForeColor = Color.Black;
            timer2.Stop();
        }

        private void Receive_TextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
