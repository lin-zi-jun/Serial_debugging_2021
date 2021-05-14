using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ZedGraph;
using Microsoft.Win32;
//using System.Windows.Forms.Clipboard;
namespace WindowsApplication1
{
    public partial class Form1 : Form
    {
        //GraphPane myPane = zgc.GraphPane;
        byte[] buff = new byte[30];
        Boolean isopen=false;
        int counter = 0;
        PointPairList list = new PointPairList();

       // LineItem curve;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {


                if (isopen == false)
                {
                    serialPort1.BaudRate = Convert.ToInt32(comboBox2.Text);
                    serialPort1.PortName = comboBox1.Text;
                    serialPort1.Open();
                    serialPort1.Write("s");
                    if (Convert.ToUInt16(serialPort1.ReadLine()) != 1820)
                    {
                        MessageBox.Show("没找到设备");
                        return;
                    }
                    button1.Text = "停止采集";

                    isopen = true;
                    serialPort1.Write("i");
                    label3.Text = "器件ID：" + serialPort1.ReadLine();
                    serialPort1.Write("j");
                    switch (Convert.ToInt16(serialPort1.ReadLine()))
                    {
                        case 127:
                            label2.Text = "12位精度";
                            break;
                        case 31:
                            label2.Text = "9位精度";
                            break;
                        case 63:
                            label2.Text = "10位精度";
                            break;
                        case 95:
                            label2.Text = "11位精度";
                            break;
                        default:
                            label2.Text = "未知精度";
                            break;


                    }
                    timer1.Interval = Convert.ToInt32(Convert.ToDouble(trackBar1.Value / 4) * 1000);
                    timer1.Start();
                }
                else
                {
                    timer1.Stop();
                    serialPort1.Close();
                    serialPort1.Dispose();
                    button1.Text = "开始采集";
                    isopen = false;
                }
            }
            catch (System.TimeoutException)
            {
                MessageBox.Show("没找到设备");
                timer1.Stop();
                    serialPort1.Close();
                    serialPort1.Dispose();
                    button1.Text = "开始采集";
                    isopen = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                timer1.Stop();
                serialPort1.Close();
                serialPort1.Dispose();
                button1.Text = "开始采集";
                isopen = false;
            }
        }

       

        private void timer1_Tick(object sender, EventArgs e)
        {
            GraphPane myPane = zgc.GraphPane;
            counter = counter+1;
            label4.Text ="数据个数："+ counter.ToString();
            serialPort1.Write("o");
            double k = Convert.ToDouble(serialPort1.ReadLine());
            double wendu = k * 0.0001;
            if (radioButton1.Checked == true)
            {
                textBox1.Text = DateTime.Now.ToString() + " " + wendu.ToString() + System.Environment.NewLine + textBox1.Text;
            }
            else
            {
                textBox1.Text = textBox1.Text + DateTime.Now.ToString() + " " + wendu.ToString() + System.Environment.NewLine;
            }

          //zgc.GraphPane.XAxis.Scale.MaxAuto = true;
            label1.Text = "即时温度："+wendu.ToString()+"℃";

            double x = counter;
            double y = wendu;
            list.Add(x, y);
            zgc.AxisChange();
            zgc.Refresh();
            zgc.IsShowPointValues = true;
            if (counter > (myPane.XAxis.Scale.Max - myPane.XAxis.Scale.Min))
            {
                myPane.XAxis.Scale.Min = counter - (myPane.XAxis.Scale.Max - myPane.XAxis.Scale.Min);
                myPane.XAxis.Scale.Max = counter;
                
            }


        }
        private void button3_Click(object sender, EventArgs e)
        {
            GraphPane myPane = zgc.GraphPane;
            counter = 0;
            list.Clear();
            zgc.Refresh();
            textBox1.Clear();
            label4.Text = "数据个数：" + counter.ToString();
            myPane.XAxis.Scale.Max = 100;
            myPane.XAxis.Scale.Min = 0;

           
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            GraphPane myPane = zgc.GraphPane;
           comboBox2.Text= Convert.ToString(Registry.GetValue(@"HKEY_CURRENT_USER\ds18b20数据采集仪", "baud", ""));
           comboBox1.Text = Convert.ToString(Registry.GetValue(@"HKEY_CURRENT_USER\ds18b20数据采集仪", "comm", ""));



           myPane.Title.Text = "温度实时曲线图";
           myPane.XAxis.Title.Text = "个数";
           myPane.YAxis.Title.Text = "温度（摄氏）";

           // Build a PointPairList with points based on Sine wave


           // Hide the legend
           myPane.Legend.IsVisible = false;

           // Add a curve
           LineItem curve = myPane.AddCurve("label", list, Color.Red, SymbolType.Circle);
           curve.Line.Width = 2F;
           curve.Symbol.Fill = new Fill(Color.White);
           curve.Symbol.Size = 5;
           myPane.XAxis.Scale.Max = 100;
           myPane.XAxis.Scale.Min= 0;
           myPane.YAxis.Scale.Max = 50;
           myPane.YAxis.Scale.Min = 0;

           // Make the XAxis start with the first label at 50
          // myPane.XAxis.Scale.BaseTic = 50;

           // Fill the axis background with a gradient
           myPane.Chart.Fill = new Fill(Color.White, Color.SteelBlue, 23.0F);

           // Calculate the Axis Scale Ranges
           zgc.AxisChange();




        }

        private void button4_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.IO.FileStream objfile;
            saveFileDialog1.ShowDialog();
            objfile=System.IO.File.Create(@saveFileDialog1.FileName);
            objfile.Close();
            objfile.Dispose();
            System.IO.StreamWriter objfil = new System.IO.StreamWriter(@saveFileDialog1.FileName);
            objfil.Write(textBox1.Text);
            objfil.Close();
            objfil.Dispose();


        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Registry.CurrentUser.CreateSubKey("ds18b20数据采集仪");
            Registry.SetValue(@"HKEY_CURRENT_USER\ds18b20数据采集仪","baud",comboBox2.Text);
            Registry.SetValue(@"HKEY_CURRENT_USER\ds18b20数据采集仪", "comm", comboBox1.Text);


}

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label5.Text = Convert.ToString(Convert.ToDouble(trackBar1.Value) / 4) + "秒";
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            GraphPane myPane = zgc.GraphPane;
            myPane.YAxis.Scale.Min = vScrollBar1.Value;
            vScrollBar3.Minimum = vScrollBar1.Value + 2;
            zgc.AxisChange();
                   zgc.Refresh();
        }

        private void vScrollBar3_Scroll(object sender, ScrollEventArgs e)
        {
            GraphPane myPane = zgc.GraphPane;
            myPane.YAxis.Scale.Max = vScrollBar3.Value;
            vScrollBar1.Maximum = vScrollBar3.Value - 2;
            zgc.AxisChange();
            zgc.Refresh();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            serialPort1.Dispose();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
           Clipboard.SetDataObject(label1.Text, true);
           MessageBox.Show("复制成功！");

        }



        private void hScrollBar2_Scroll(object sender, ScrollEventArgs e)
        {
             GraphPane myPane = zgc.GraphPane;

                // hScrollBar2.Minimum = Convert.ToUInt16(myPane.XAxis.Scale.Min) + 2;
                 myPane.XAxis.Scale.Max = hScrollBar2.Value;
                 zgc.AxisChange();
                 zgc.Refresh();
             }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
       



    
    }
}


