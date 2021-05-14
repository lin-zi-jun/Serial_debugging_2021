using System;
using System.IO;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Xml;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Threading;


using MyNodeLink;


namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private Int32 SendLength,RcveLength,RcveOffset,RcveMode;
        private byte RcveTemp;
        private MyNodeLink.Link<byte> NodeList;
        private Bitmap RTGBuffer;
        private Graphics RTG;
        private Pen RTGPen;

        public Form1()
        {
            InitializeComponent();
        }
        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cbx = sender as ComboBox;
            if (cbx != null)
            {
                serialPort_config(1);
            }
        }
        private void checkBox_MouseUp(object sender, MouseEventArgs e)
        {
            CheckBox cbx = sender as CheckBox;
            if (cbx.Checked == true)
            {
                cbx.Checked = false;
            }
            else
            {
                cbx.Checked = true;
            }
        }
        private void serialPort_config(int rw)
        {
            string strFilename = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "serialPort.xml");
            if (rw == 0)
            {
                if (File.Exists(strFilename))
                {
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(strFilename);
                    XmlNode xn = xmlDoc.SelectSingleNode("Node1");
                    XmlNodeList xnl = xn.ChildNodes;
                    foreach (XmlNode xnf in xnl)
                    {
                        XmlElement xe = (XmlElement)xnf;
                        switch (xe.Name)
                        {
                            case "PortName": comboBox1.SelectedIndex = Convert.ToInt32(xe.GetAttribute("Index")); break;
                            case "BaudRate": comboBox2.SelectedIndex = Convert.ToInt32(xe.GetAttribute("Index")); break;
                            case "Parity": comboBox3.SelectedIndex = Convert.ToInt32(xe.GetAttribute("Index")); break;
                            case "DataBits": comboBox4.SelectedIndex = Convert.ToInt32(xe.GetAttribute("Index")); break;
                            case "StopBits": comboBox5.SelectedIndex = Convert.ToInt32(xe.GetAttribute("Index")); break;
                        }
                    }

                }
            }
            else
            {
                XmlTextWriter xmlWriternew = new XmlTextWriter(strFilename, Encoding.Default);
                xmlWriternew.Formatting = Formatting.Indented;
                xmlWriternew.WriteStartDocument();
                xmlWriternew.WriteStartElement("Node1");        
                xmlWriternew.WriteStartElement("PortName");
                xmlWriternew.WriteAttributeString("Index", comboBox1.SelectedIndex.ToString());
                xmlWriternew.WriteAttributeString("Text", comboBox1.Text);
                xmlWriternew.WriteEndElement();
                xmlWriternew.WriteStartElement("BaudRate");
                xmlWriternew.WriteAttributeString("Index", comboBox2.SelectedIndex.ToString());
                xmlWriternew.WriteAttributeString("Text", comboBox2.Text);
                xmlWriternew.WriteEndElement();
                xmlWriternew.WriteStartElement("Parity");
                xmlWriternew.WriteAttributeString("Index", comboBox3.SelectedIndex.ToString());
                xmlWriternew.WriteAttributeString("Text", comboBox3.Text);
                xmlWriternew.WriteEndElement();
                xmlWriternew.WriteStartElement("DataBits");
                xmlWriternew.WriteAttributeString("Index", comboBox4.SelectedIndex.ToString());
                xmlWriternew.WriteAttributeString("Text", comboBox4.Text);
                xmlWriternew.WriteEndElement();
                xmlWriternew.WriteStartElement("StopBits");
                xmlWriternew.WriteAttributeString("Index", comboBox5.SelectedIndex.ToString());
                xmlWriternew.WriteAttributeString("Text", comboBox5.Text);
                xmlWriternew.WriteEndElement();
                xmlWriternew.WriteEndElement();
                xmlWriternew.Close();
            }
            serialPort1_state();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 6;
            comboBox3.SelectedIndex = 0;
            comboBox4.SelectedIndex = 0;
            comboBox5.SelectedIndex = 0;

            comboBox1.SelectedIndexChanged += new System.EventHandler(comboBox_SelectedIndexChanged);
            comboBox2.SelectedIndexChanged += new System.EventHandler(comboBox_SelectedIndexChanged);
            comboBox3.SelectedIndexChanged += new System.EventHandler(comboBox_SelectedIndexChanged);
            comboBox4.SelectedIndexChanged += new System.EventHandler(comboBox_SelectedIndexChanged);
            comboBox5.SelectedIndexChanged += new System.EventHandler(comboBox_SelectedIndexChanged);

            checkBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(checkBox_MouseUp);
            checkBox2.MouseUp += new System.Windows.Forms.MouseEventHandler(checkBox_MouseUp);
            checkBox3.MouseUp += new System.Windows.Forms.MouseEventHandler(checkBox_MouseUp);
           
            serialPort_config(0);
            SendLength = 0;
            RcveLength = 0;
            RcveOffset = 0;
            RcveMode = 0;
            NodeList=new MyNodeLink.Link<byte>(pictureBox1.Width);
            RTGBuffer = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            RTG = Graphics.FromImage(RTGBuffer);
            RTG.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            RTGPen = new Pen(Color.Red);
        }
        delegate void SetricrichTextBox1Callback(string str);
        private void SetrichTextBox1(string str)
        {
            richTextBox1.AppendText(str);
            richTextBox1.Focus();
        }
        private void serialPort1_state()
        {
            toolStripStatusLabel3.Text = comboBox1.Text + "(" + comboBox2.Text+"," + comboBox3.Text+"," + comboBox4.Text+"," + comboBox5.Text + ")";
            if (serialPort1.IsOpen == true)
            {
                toolStripStatusLabel3.Text += "Opened";
            }
            else
            {
                toolStripStatusLabel3.Text += "Closed";    
            }
        }
        private void ReceivedToGraphics()
        {
            RTG.Clear(Color.Black);
            byte[] buffer = NodeList.GetList();
            for (int i = 0; i < NodeList.listcount; i++)
            {
                RTG.DrawLine(RTGPen, i, buffer[i], i + 1, buffer[i + 1]);
            }
            pictureBox1.BackgroundImage = RTGBuffer;
            pictureBox1.Refresh();
        }
        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            byte[] buffer = new byte[serialPort1.ReadBufferSize];
            StringBuilder MyStringBuilder = new StringBuilder(serialPort1.ReadBufferSize*2);

            if (button1.Text == "打开串口")
            {
                return;
            }
            int length = serialPort1.Read(buffer, RcveOffset, buffer.Length - 1);

            if (checkBox2.Checked == true)
            {
                if( RcveMode == 1)
                {
                    for (int i = 0; i < length; i++)
                    {
                        NodeList.Append(buffer[i]);
                    }
                   this.Invoke(new Action(ReceivedToGraphics));
                }
                else if (checkBox1.Checked == true)
                {
                    RcveOffset = 0;
                    for (int i = 0; i < length; i++)
                    {
                        MyStringBuilder.Append(String.Format("{0:X2}", Convert.ToInt32(buffer[i])) + " ");
                    }
                    this.Invoke(new SetricrichTextBox1Callback(SetrichTextBox1), MyStringBuilder.ToString());
                }
                else
                {
                    byte[] hz = new byte[2];
                    int j = 0;

                    if (RcveOffset == 1)
                    {
                        buffer[0] = RcveTemp;
                        length += 1;
                    }
                    for (int i = 0; i < length; i++)
                    {
                        if (buffer[i] < 0x80)
                        {
                            if (buffer[i] == '\n')
                            {
                                MyStringBuilder.Append("\r\n");
                            }
                            else
                            {
                                MyStringBuilder.Append(Convert.ToChar(buffer[i]));
                            }
                            j = 0;
                        }
                        else if (j == 0)
                        {
                            hz[0] = buffer[i];
                            j = 1;

                        }
                        else
                        {
                            hz[1] = buffer[i];
                            MyStringBuilder.Append(System.Text.Encoding.Default.GetString(hz));
                            j = 0;
                        }
                    }
                    if (j == 1)
                    {
                        RcveOffset = 1;
                        RcveTemp = buffer[length - 1];
                    }
                    else
                    {
                        RcveOffset = 0;
                    }
                    this.Invoke(new SetricrichTextBox1Callback(SetrichTextBox1), MyStringBuilder.ToString());
                } 
                
            }
            RcveLength += length;
            toolStripStatusLabel2.Text = "接收" + " " + RcveLength.ToString("d");
        }
        private void ConsoleSerialPort(int n)
        {
            if (n == 0)
            {

                ovalShape1.FillColor = Color.Black;//Color.Transparent;
                comboBox1.Enabled = true;
                comboBox2.Enabled = true;
                comboBox3.Enabled = true;
                comboBox4.Enabled = true;
                comboBox5.Enabled = true;
                button4.Enabled = false;
                button7.Enabled = false;
                button1.Text = "打开串口";
                Application.DoEvents();
                serialPort1.Close();
            }
            else
            {
                serialPort1.Open();
                ovalShape1.FillColor = Color.Red;
                comboBox1.Enabled = false;
                comboBox2.Enabled = false;
                comboBox3.Enabled = false;
                comboBox4.Enabled = false;
                comboBox5.Enabled = false;
                button4.Enabled = true;
                button7.Enabled = true;
                button1.Text = "关闭串口";
            }
            serialPort1_state();
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct DEV_BROADCAST_HDR
        {
            public Int32 dbch_size;
            public Int32 dbch_devicetype;
            public Int32 dbch_reserved;
        }
        [StructLayout(LayoutKind.Sequential)]
        protected struct DEV_BROADCAST_PORT_Fixed
        {
            public uint dbcp_size;
            public uint dbcp_devicetype;
            public uint dbcp_reserved;
        }
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0219)
            {
                if (m.WParam.ToInt32() == 0x8004)
                {
                    DEV_BROADCAST_HDR dbhd = (DEV_BROADCAST_HDR)Marshal.PtrToStructure(m.LParam, typeof(DEV_BROADCAST_HDR));
                    string portName = Marshal.PtrToStringUni((IntPtr)(m.LParam.ToInt32() + Marshal.SizeOf(typeof(DEV_BROADCAST_PORT_Fixed))));
                    
                    if (dbhd.dbch_devicetype == 0x00000003)
                    {
                        if (portName == serialPort1.PortName)
                        {
                            if (button1.Text == "关闭串口")
                            {
                                ConsoleSerialPort(0);
                                MessageBox.Show("串口拨出", "串口调试助手", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
            }
            base.WndProc(ref m);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "txt files(*.txt)|*.txt";   // All files(*.*)|*.*
            saveFileDialog1.RestoreDirectory = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string localFileName = saveFileDialog1.FileName;
                StreamWriter sw = new StreamWriter(localFileName);
                sw.Write(richTextBox1.Text);
                sw.Close();
            }
        }
        //发送区1
        private void serialPort1_DataSend()
        {
            if (checkBox3.Checked == true)
            {
                string SendText = textBox1.Text.Replace(" ", "");
                byte[] SendBuffer = new byte[SendText.Length / 2];
                int Length = 0;
                for (int i = 0; i < SendText.Length / 2; i++)
                {
                    if (Regex.IsMatch(SendText.Substring(i * 2, 2), @"[0-9a-fA-F]{2,}$"))
                    {
                        SendBuffer[Length++] = Convert.ToByte(SendText.Substring(i * 2, 2), 16);
                    }
                    else
                    {
                        MessageBox.Show("字符格式:" + SendText.Substring(i * 2, 2), "串口调试助手", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    }
                }
                serialPort1.Write(SendBuffer, 0, Length);
                SendLength += Length;
            }
            else
            {
                byte[] SendBuffer = System.Text.Encoding.Default.GetBytes(textBox1.Text);
                serialPort1.Write(SendBuffer, 0, SendBuffer.Length);
                SendLength += SendBuffer.Length;
            }
            toolStripStatusLabel1.Text = "发送" + " " + SendLength.ToString("d");
        }
        //发送区2
        private void serialPort2_DataSend()
        {
            if (checkBox3.Checked == true)
            {
                string SendText = textBox2.Text.Replace(" ", "");
                byte[] SendBuffer = new byte[SendText.Length / 2];
                int Length = 0;
                for (int i = 0; i < SendText.Length / 2; i++)
                {
                    if (Regex.IsMatch(SendText.Substring(i * 2, 2), @"[0-9a-fA-F]{2,}$"))
                    {
                        SendBuffer[Length++] = Convert.ToByte(SendText.Substring(i * 2, 2), 16);
                    }
                    else
                    {
                        MessageBox.Show("字符格式:" + SendText.Substring(i * 2, 2), "串口调试助手", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    }
                }
                serialPort1.Write(SendBuffer, 0, Length);
                SendLength += Length;
            }
            else
            {
                byte[] SendBuffer = System.Text.Encoding.Default.GetBytes(textBox2.Text);
                serialPort1.Write(SendBuffer, 0, SendBuffer.Length);
                SendLength += SendBuffer.Length;
            }
            toolStripStatusLabel1.Text = "发送" + " " + SendLength.ToString("d");
        }
        private void button2_MouseUp(object sender, MouseEventArgs e)
        {
            RcveOffset = 0;
            richTextBox1.Text = "";
            NodeList = new MyNodeLink.Link<byte>(pictureBox1.Width);
        }
        private void button6_MouseUp(object sender, MouseEventArgs e)
        {
            SendLength = 0;
            RcveLength = 0;
            toolStripStatusLabel1.Text = "发送" + " " + SendLength.ToString("d");
            toolStripStatusLabel2.Text = "接收" + " " + RcveLength.ToString("d");
        }
        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            RcveMode = tabControl1.SelectedIndex;
            if (RcveMode == 1)
            {
                checkBox1.Enabled = false;
            }
            else
            {
                checkBox1.Enabled = true;
            }
        }
        private void button5_MouseUp(object sender, MouseEventArgs e)
        {
            textBox1.Text = "";  
        }
        private void button8_MouseUp(object sender, MouseEventArgs e)
        {
            textBox2.Text = "";
        }
        //发送按钮1
        private void button4_MouseUp(object sender, MouseEventArgs e)
        {
            serialPort1_DataSend();
        }
        //发送按钮2
        private void button7_MouseUp(object sender, MouseEventArgs e)
        {
            serialPort2_DataSend();
        }

        private void button1_MouseUp(object sender, MouseEventArgs e)
        {
            if (serialPort1.IsOpen == true)
            {
                ConsoleSerialPort(0);
            }
            else
            {
                serialPort1.PortName = comboBox1.Text;
                serialPort1.BaudRate = Convert.ToInt32(comboBox2.Text);
                switch (comboBox3.Text)
                {
                    case "None":
                        serialPort1.Parity = System.IO.Ports.Parity.None;
                        break;
                    case "Even":
                        serialPort1.Parity = System.IO.Ports.Parity.Even;
                        break;
                    case "Odd":
                        serialPort1.Parity = System.IO.Ports.Parity.Odd;
                        break;
                }
                serialPort1.DataBits = Convert.ToInt32(comboBox4.Text);
                switch (comboBox5.Text)
                {
                    case "One":
                        serialPort1.StopBits = System.IO.Ports.StopBits.One;
                        break;
                    case "Two":
                        serialPort1.StopBits = System.IO.Ports.StopBits.Two;
                        break;
                    case "OnePointFive":
                        serialPort1.StopBits = System.IO.Ports.StopBits.OnePointFive;
                        break;
                }
                try
                {
                    ConsoleSerialPort(1);
                }
                catch (Exception ex) 
                {
                    MessageBox.Show(ex.Message, "串口调试助手", MessageBoxButtons.OK, MessageBoxIcon.Warning);      
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void ovalShape1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}

namespace MyNodeLink
{
    class Node<T>
    {
        public T data;
        public Node<T> next;

        public Node(T d)
        {
            this.data = d;
            this.next = null;
        }
    }
    class Link<T>
    {
        Node<T> head;
        private int L_length;
        private int L_count;

        private T L_remove;

        public Link()
        {
            count = 0;
            length = 0;
        }
        public Link(int len)
        {
            count = 0;
            length = len;
        }
        public int length
        {
            get { return L_length; }
            set { L_length = value; }
        }
        public int count
        {
            get {return L_count;}
            private set { L_count = value; }
        }
        public int listcount
        {
            get 
            {
                if (count == length)
                {
                    return count;
                }
                else
                {
                    return count - 1;
                }
            }
            private set {  }
        }
        public T remove
        {
            get { return L_remove; }
            private set { L_remove = value; }
        }
        public void Append(T d)
        {
            if (count <= length)
            {   
                Node<T> p = new Node<T>(d);
                if (head == null)
                {
                    head = p;
                    count++;
                    return;
                }
                if (count == length)
                {
                    remove = head.data;
                    head = head.next;
                }
                else
                {
                    count++;
                }
                Node<T> last = head;
                while (last.next != null)
                {
                    last = last.next;
                }
                last.next = p;
            }
        }
        public T[] GetList()
        {
            if (count > 0)
            {
                T[] buffer;
                int i;
                if (count == length)
                {
                    buffer = new T[count+1];
                    buffer[0] = remove;
                    i = 1;
                }
                else
                {
                    buffer = new T[count];
                    i = 0;
                }
                Node<T> temp = head;
                while (temp != null)
                {                    
                    buffer[i++] = temp.data;
                    temp = temp.next;
                }
                return buffer; 
            }
            return null;
        }
        public void Print()
        {
            Node<T> temp = head;
            while (temp != null)
            {
                MessageBox.Show(temp.data.ToString());
                temp = temp.next;
            }
        }
    }
}
