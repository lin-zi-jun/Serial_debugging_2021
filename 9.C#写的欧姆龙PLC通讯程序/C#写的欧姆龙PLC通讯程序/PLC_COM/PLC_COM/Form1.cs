using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Threading;

namespace PLC_COM
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();                         //关闭窗体
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            radioButton1.Checked = true;
            serialPort1.PortName = comboBox1.Text;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(serialPort1.IsOpen == false)
            {
                serialPort1.Open();
                button5.Text = "关闭串口";
                pictureBox2.Image = PLC_COM.Properties.Resources.low;
            }
            else
            {
                serialPort1.Close();
                button5.Text = "打开串口";
                pictureBox2.Image = PLC_COM.Properties.Resources.high;
            }
        }
        #region 读取数据,功能演示只读取一个字的数据
        private void button2_Click(object sender, EventArgs e)    //读取数据
        {
            string SendStr = "";
            string ReadData = "";
            string Addr = "0000";                          //数据地址
            string RTUaddr = "00";                         //PLC 站号
            Addr = textBox1.Text.Trim();
            RTUaddr = comboBox2.Text.Trim();

            if(serialPort1.IsOpen==false)
            {
                MessageBox.Show("请打开串口！");
                return;
            }

            SendStr = "@" + RTUaddr + "RD" + Addr + "0001";   //只读取一个地址的数据，修改最后的数，可一次读取多个数据
            SendStr = SendStr + FCS(SendStr) + "*" + '\r';
            ReadData = COM2CPM2A(SendStr);
            textBox2.Text = ReadData.Trim().Substring(7,4);
        }
        #endregion 

        #region 写数据 DM
        private void button3_Click(object sender, EventArgs e)
        {
            string SendStr = "";
            string WriteData = "";
            string SendData = "";

            string Addr = "";                            //数据地址
            string RTUaddr = "";                           //PLC 站号

            Addr = textBox1.Text.ToString().Trim();
            RTUaddr = comboBox2.Text.Trim();
            SendData = textBox2.Text.Trim();

            if (serialPort1.IsOpen == false)
            {
                MessageBox.Show("请打开串口！");
                return;
            }
            SendStr = "@" + RTUaddr + "WD" + Addr +  SendData;  //只读取一个地址的数据，修改最后的数，可一次读取多个数据
            SendStr = SendStr + FCS(SendStr) + "*" + '\r';
            WriteData = COM2CPM2A(SendStr);
        }

        #endregion

        private string COM2CPM2A(string Value2)
        {
            string weibu="";
            char[] SendBuffer = new char[50];
            char[] ReadBuffer = new char[50];

            for (int i = 0; i < 50;i++ )
            {
                ReadBuffer[i] =' ';
            }

            SendBuffer = Value2.ToCharArray();

            serialPort1.Write(SendBuffer,0,SendBuffer.Length);
            Thread.Sleep(10);
            do
            {
                Thread.Sleep(5);
            } while (serialPort1.BytesToRead < 11);                                //等待接收所有的数据

            Thread.Sleep(20);
            serialPort1.Read(ReadBuffer, 0, serialPort1.BytesToRead);
            
            string instring =new string(ReadBuffer) ;
            weibu = instring.Substring(5,2);
            switch(weibu)
            {
                case "00":
                //MsgBox "正常完成", , "提示信息"
                    MessageBox.Show( "正常完成！");
                    break;
                case "01":
                //MsgBox "在RUN模式下不可执行", , "提示信息"
                    MessageBox.Show("在RUN模式下不可执行！");
                    break;
                case "02":
                    MessageBox.Show( "在MONITOR模式下不可执行");
                    break;
                case "04":
                    MessageBox.Show( "地址越界");
                    break;
                case "0B":
                    MessageBox.Show("在PROGRAM模式下不可执行");
                    break;
                case "13":
                    MessageBox.Show( "FCS错误");
                    break;
                case "14":
                    MessageBox.Show ("格式错误");
                    break;
                case "15":
                    MessageBox.Show ("入口号数据错误");
                    break;
                case "16":
                    MessageBox.Show ("命令不支持");
                    break;
                case "18":
                    MessageBox.Show ("帧长度错误");
                    break;
                case "19":
                    MessageBox.Show ("不可执行");
                    break;
                case "23":
                   MessageBox.Show ("用户存储区写保护");
                    break;
                case "A3":
                    MessageBox.Show("由于数据传送中FCS错误而终止");
                    break;
                case "A4":
                    MessageBox.Show("由于数据传送中格式错误而终止");
                    break;
                case "A5":
                   MessageBox.Show( "由于数据传送中入口号数据错误而终止");
                    break;
                case "A8":
                    MessageBox.Show( "由于数据传送中帧长错误而终止");
                    break;
                default:
                   MessageBox.Show( "未知错误");
                    break;
              }
              return instring;
          }
          #region 设置PLC运行模式 监视模式
          private void radioButton_Enter(object sender, EventArgs e)
        {
            string SendStr = "";
            string ReadStr = "";
            string RunModel = "";

            RunModel = "03";
            if (serialPort1.IsOpen == false)
            {
                MessageBox.Show("请打开串口！");
                return;
            }
            if(radioButton1.Focused)
            {
                RunModel = "03";
            }
            else if (radioButton2.Focused)
            {
                RunModel = "02";
            }
            else if (radioButton3.Focused)
            {
                RunModel = "00";
            }
            SendStr = "@" + comboBox2.Text.Trim() + "SC" + RunModel; ;
            SendStr = SendStr + FCS(SendStr) + "*" + "\r";
            ReadStr = COM2CPM2A(SendStr);

        }
          #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            string SendStr = "";
            string ReadStr = "";
            if (serialPort1.IsOpen == false)
            {
                MessageBox.Show("请打开串口！");
                return;
            }
            SendStr = "@" + comboBox2.Text.Trim() + "TS" + "LSLLHD";
            SendStr = SendStr + FCS(SendStr) + "*" + "\r";
            ReadStr = CPM2A(SendStr);
            if (ReadStr == SendStr)
            {
                MessageBox.Show("与PLC通讯正常！");
            }
            else
            {
                MessageBox.Show("通讯异常！" + ReadStr);
            }
        }

        private string FCS(String Value)
        {
            int i, f;
            byte[] x;
            f = 0;
            for (i = 0; i < Value.Length; i++)
            {
                x = ASCIIEncoding.ASCII.GetBytes(Value.Substring(i, 1));
                f = f ^ (int)x[0];
            }

            return f.ToString("X");
        }
        private string CPM2A(string inStr)               //无消息提示发送函数
        {
            char[] SendBuffer;
            char[] ReadBuffer;
            int length = 0;

            SendBuffer = inStr.ToCharArray();
            serialPort1.Write(SendBuffer, 0, SendBuffer.Length);
            do
            {
                Thread.Sleep(5);
            } while (serialPort1.BytesToRead < 11);                                //等待接收所有的数据
       
            Thread.Sleep(20);
            length = serialPort1.BytesToRead;
            ReadBuffer = new char[length];
            serialPort1.Read(ReadBuffer, 0, length);
            string instring = new string(ReadBuffer);
            return instring;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string SendStr = "";
            string ReadStr = "";
            string RunModel = "";
            if (serialPort1.IsOpen == false)
            {
                MessageBox.Show("请打开串口！");
                return;
            }
            SendStr = "@" + comboBox2.Text.Trim() + "MS";
            SendStr = SendStr + FCS(SendStr) + "*" + "\r";
            ReadStr = CPM2A(SendStr);
            RunModel = ReadStr.Substring(7,2);
            if (RunModel == "00")
            {
                radioButton3.Focus();
            }
            else if(RunModel == "02")
            {
                radioButton1.Focus();
            }
            else if (RunModel == "03")
            {
                radioButton2.Focus();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string SendStr = "";
            string ReadStr = "";
            string ReadData = "";
            string AddrWord = "";
            string AddrBit = "";
            int bitx = 0;                     //字中查询的位的位置
            int datax =0 ;                    //返回的数据
            if (serialPort1.IsOpen == false)
            {
                MessageBox.Show("请打开串口！");
                return;
            }
            AddrWord = textBox3.Text.Substring(0,4);
            AddrBit =  textBox3.Text.Substring(4,2);
            SendStr = "@" + comboBox2.Text.Trim() + "RR" + AddrWord + "0001";
            SendStr = SendStr + FCS(SendStr) + "*" + "\r";
            ReadStr = CPM2A(SendStr);
            ReadData = ReadStr.Substring(7, 4);
            bitx =  Convert.ToInt16(AddrBit);
            datax = Convert.ToInt16(ReadData);
            datax = (datax >> bitx) & 0x01;
            if (datax == 1)
            {
                pictureBox1.Image = PLC_COM.Properties.Resources.high;
            }
            else
            {
                pictureBox1.Image = PLC_COM.Properties.Resources.low;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string SendStr = "";
            string ReadStr = "";
            if (serialPort1.IsOpen == false)
            {
                MessageBox.Show("请打开串口！");
                return;
            }
            SendStr = "@" + comboBox2.Text.Trim() + "KS" + "CIO " + textBox3.Text.Trim();
            SendStr = SendStr + FCS(SendStr) + "*" + "\r";
            ReadStr = COM2CPM2A(SendStr);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string SendStr = "";
            string ReadStr = "";
            string ReadData = "";
            if (serialPort1.IsOpen == false)
            {
                MessageBox.Show("请打开串口！");
                return;
            }
            SendStr = "@" + comboBox2.Text.Trim() + "KR" + "CIO " + textBox3.Text.Trim();
            SendStr = SendStr + FCS(SendStr) + "*" + "\r";
            ReadStr = COM2CPM2A(SendStr);
        }
    }
}