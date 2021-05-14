using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO.Ports;
using ZedGraph;
using System.Threading;
using System.Collections;

namespace DC_POWER
{
    public partial class Mainform : Form
    {
        private const float VOLTAGE_MAX = 30.00f, CURRENT_MAX = 4.000f;
		public enum MODE
		{
			MODE_VOLTAGE = 0x00,
			MODE_CURRENT = 0x01,
		}
		private MODE currentMode = MODE.MODE_VOLTAGE;
        //与下位机通讯相关
        public enum COM_CMD
        {
            //M2S: master to slave cmd, S2M: slave to master
            USART_M2S_Output  = 0x01,  //输出控制（默认关）
            USART_M2S_Mode    = 0x02,  //输出模式切换（默认电压模式）
            USART_M2S_SetVal  = 0x03,  //Master2Slave设置期望值：[1-4]:电压; [5-8]:电流
            USART_M2S_Cal     = 0x04,  //进入校准模式(只在下位机开机前几秒内能够进入校准模式)
            USART_M2S_StepAdd = 0x05,  //步进加
            USART_M2S_StepSub = 0x06,  //步进减
            USART_M2S_FAN     = 0x07,  //风扇控制:[1]0关;1开;2自动（默认）
            USART_M2S_STATE   = 0x08,  //实时数据发送状态：[1]1发送数据 0停止发送
            USART_M2S_GetVal  = 0x09,  //获取前一次的设定值
            USART_S2M_PreVal  = 0x0A,  //Slave2Master返回前一次的设定值:[1-4]:电压值; [5-8]:电流值
            USART_S2M_RealVal = 0x0B,  //Slave2Master返回的实际值:[1-4]:电压值; [5-8]:电流值
            USART_S2M_RealTemp= 0x0C,  //Slave2Master返回温度值：[1-4]:当前温度值
        }
        private const byte USART_FRAMEHEAD = 0xAA, USART_FRAMETAIL = 0x55, USART_FRAMECTRL = 0xA5;

        private long m_TotalRxLostPackages = 0; //记录总的丢包数
        private long m_RxPackageDataCount = 0;  //记录接收到的一帧的字节数
        private const int m_MaxPackageSize = 4096;   //一帧最大的字节数
        private byte[] m_pRxBuf = new byte[m_MaxPackageSize]; //接收缓存

        float voltageSet = 0.0f, currentSet = 0.0f, voltageGet = 0.0f, currentGet = 0.0f;

        //绘图相关
        public struct CurveStruct
        {
            public PointPairList pointList;//曲线数据
            public Color         lineColor;//曲线颜色
            public SymbolType    lineStyle;//线型
            public string        curveName;//名称
            public LineItem      curve;    //曲线
            public float         scaleFactor;//比例系数
            public byte          lineWidth; //线宽
        }
        private Hashtable curveHashTable = new Hashtable();//用来保存所有的曲线        
        private GraphPane mGraphPane;
        private long tickStart = 0;
        double currentTime;
        //double previousTime = 0;
        CurveStruct mCurveStructVolSet = new CurveStruct();
        CurveStruct mCurveStructVolGet = new CurveStruct();
        CurveStruct mCurveStructCurSet = new CurveStruct();
        CurveStruct mCurveStructCurGet = new CurveStruct();

        //线程相关
        private Queue<byte> receiveByteQueue = new Queue<byte>();//串口缓存队列
        private Thread _dataParseThread = null;   //解析串口接收数据线程
        private bool _runDataParseThread = false; //决定接收线程是否退出


        public Mainform()
        {
            InitializeComponent();
        }

        private void Mainform_Load(object sender, EventArgs e)
        {
            //初始化串口列表，添加本地可用串口号            
            if (SerialPort.GetPortNames().Length != 0)
            {
                foreach (string vPortName in SerialPort.GetPortNames())
                {
                    RibbonLabel item = new RibbonLabel();
                    item.Text = vPortName;
                    ribbonComboBoxCom1.DropDownItems.Add(item);
                    ribbonComboBoxCom2.DropDownItems.Add(item);
                }
                ribbonComboBoxCom1.TextBoxText = SerialPort.GetPortNames()[0];
                ribbonComboBoxCom2.TextBoxText = SerialPort.GetPortNames()[0];
            }
            mGraphPane = zedGraphControl1.GraphPane;
            mGraphPane.Title.Text = "DC_POWER";
            //添加两个Y轴，分别显示电压、电流
            mGraphPane.XAxis.Title.Text  = "time";
            mGraphPane.YAxis.Title.Text  = "Voltage";
            mGraphPane.Y2Axis.Title.Text = "Current";
            mGraphPane.Y2Axis.IsVisible = true;
            mGraphPane.YAxis.Scale.FontSpec.FontColor = Color.Red;
            mGraphPane.YAxis.Title.FontSpec.FontColor = Color.Red;
            mGraphPane.Y2Axis.Scale.FontSpec.FontColor = Color.Blue;
            mGraphPane.Y2Axis.Title.FontSpec.FontColor = Color.Blue;


            knob_Voltage.Enabled = false;
            knob_Current.Enabled = false;
            slideButtonMode.Enabled = false;
            slideButtonOutput.Enabled = false;
            glassButtonStepAdd.Enabled = false;
            glassButtonCAL.Enabled = false;
            glassButtonStepSub.Enabled = false;
        }
        private void Mainform_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                ribbonButtonOpenCom1_Click(sender, e);
            }
            if (serialPort2.IsOpen)
            {
                ribbonButtonOpenCom2_Click(sender, e);
            }
        }
        
        private void ResetGraphPane()
        {            
            mGraphPane.XAxis.Scale.Min = 0;      //X轴最小值0
            mGraphPane.XAxis.Scale.Max = 30;     //X轴最大30
            mGraphPane.XAxis.Scale.MinorStep = 1;//X轴小步长1,也就是小间隔
            mGraphPane.XAxis.Scale.MajorStep = 5;//X轴大步长为5，也就是显示文字的大间隔
            mGraphPane.YAxis.Scale.Min = 0;      //电压轴最小值0
            mGraphPane.YAxis.Scale.Max = VOLTAGE_MAX;//电压最大值
            mGraphPane.Y2Axis.Scale.Min = 0;      //电流轴最小值0
            mGraphPane.Y2Axis.Scale.Max = CURRENT_MAX;//电流最大值
            //清除原有曲线
            if (mGraphPane.CurveList.Count != 0)
            {
                mGraphPane.CurveList.Clear();
                mGraphPane.GraphObjList.Clear();
                curveHashTable.Clear();
            }
            //更新X和Y轴的范围
            zedGraphControl1.AxisChange();
            //更新图表
            zedGraphControl1.Invalidate();

            //添加四条新的曲线：电压设定曲线、电压实际曲线、电流设定曲线、实际电流曲线
            mCurveStructVolSet.curveName = "SET_V";
            mCurveStructVolSet.pointList = new PointPairList();
            mCurveStructVolSet.lineColor = Color.Brown;
            mCurveStructVolSet.lineStyle = SymbolType.None;
            mCurveStructVolSet.lineWidth = 2;
            mCurveStructVolSet.scaleFactor = 1;// 360.0f / 4000.0f;
            mCurveStructVolSet.curve = mGraphPane.AddCurve(
                mCurveStructVolSet.curveName,
                mCurveStructVolSet.pointList, 
                mCurveStructVolSet.lineColor,
                mCurveStructVolSet.lineStyle);
            mCurveStructVolSet.curve.Line.Width = mCurveStructVolSet.lineWidth;
            curveHashTable.Add("SET_V", mCurveStructVolSet);

            mCurveStructVolGet.curveName = "GET_V";
            mCurveStructVolGet.pointList = new PointPairList();
            mCurveStructVolGet.lineColor = Color.Red;
            mCurveStructVolGet.lineStyle = SymbolType.None;
            mCurveStructVolGet.lineWidth = 2;
            mCurveStructVolGet.scaleFactor = 1;// 360.0f / 4000.0f;
            mCurveStructVolGet.curve = mGraphPane.AddCurve(
                mCurveStructVolGet.curveName,
                mCurveStructVolGet.pointList, 
                mCurveStructVolGet.lineColor, 
                mCurveStructVolGet.lineStyle);
            mCurveStructVolGet.curve.Line.Width = mCurveStructVolGet.lineWidth;
            curveHashTable.Add("GET_V", mCurveStructVolGet);

            mCurveStructCurSet.curveName = "SET_I";
            mCurveStructCurSet.pointList = new PointPairList();
            mCurveStructCurSet.lineColor = Color.DarkBlue;
            mCurveStructCurSet.lineStyle = SymbolType.None;
            mCurveStructCurSet.lineWidth = 2;
            mCurveStructCurSet.scaleFactor = 1;// 360.0f / 4000.0f;
            mCurveStructCurSet.curve = mGraphPane.AddCurve(
                mCurveStructCurSet.curveName,
                mCurveStructCurSet.pointList,
                mCurveStructCurSet.lineColor, 
                mCurveStructCurSet.lineStyle);
            mCurveStructCurSet.curve.Line.Width = mCurveStructCurSet.lineWidth;
            curveHashTable.Add("SET_I", mCurveStructCurSet);
            mCurveStructCurSet.curve.IsY2Axis = true;

            mCurveStructCurGet.curveName = "GET_I";
            mCurveStructCurGet.pointList = new PointPairList();
            mCurveStructCurGet.lineColor = Color.Blue;
            mCurveStructCurGet.lineStyle = SymbolType.None;
            mCurveStructCurGet.lineWidth = 2;
            mCurveStructCurGet.scaleFactor = 1;// 360.0f / 4000.0f;
            mCurveStructCurGet.curve = mGraphPane.AddCurve(
                mCurveStructCurGet.curveName, 
                mCurveStructCurGet.pointList,
                mCurveStructCurGet.lineColor, 
                mCurveStructCurGet.lineStyle);
            mCurveStructCurGet.curve.Line.Width = mCurveStructCurGet.lineWidth;
            curveHashTable.Add("GET_I", mCurveStructCurGet);
            mCurveStructCurGet.curve.IsY2Axis = true;
        }
        private void PrepareReceiveData()
        {
            _dataParseThread = new Thread(new ThreadStart(DataParseThreadFunc));
            _runDataParseThread = true;

        }
        private void StartReciveData()
        {
            PrepareReceiveData();
            if (_dataParseThread != null)
            {
                _dataParseThread.Start();
            }
        }
        private void StopReceiveData()
        {
            _runDataParseThread = false;
            if (_dataParseThread != null)
            {
                _dataParseThread.Abort();
                _dataParseThread = null;
            }
        }
		
        private void knob_Voltage_ValueChanged(object sender, EventArgs e)
        {
            thermometerVoltage.Value = (float)knob_Voltage.Value / 10.0f;
            lbDigitalMeter_Voltage_Set.Value = (float)knob_Voltage.Value / 10.0f;
            float voltage = (float)lbDigitalMeter_Voltage_Set.Value;
            float current = (float)lbDigitalMeter_Current_Set.Value;
			byte[] data = new byte[9];
			data[0] = (byte)COM_CMD.USART_M2S_SetVal;
			for(int iter = 0; iter < 4; iter++)
			{
				data[1+iter] = BitConverter.GetBytes(voltage)[iter];
				data[5+iter] = BitConverter.GetBytes(current)[iter];
			}
            PackData2Frame(data);
        }
        private void knob_Current_ValueChanged(object sender, EventArgs e)
        {
            thermometerCurrent.Value = (float)knob_Current.Value / 100.0f;
            lbDigitalMeter_Current_Set.Value = (float)knob_Current.Value / 100.0f;
            float voltage = (float)lbDigitalMeter_Voltage_Set.Value;
            float current = (float)lbDigitalMeter_Current_Set.Value;
            byte[] data = new byte[9];
            data[0] = (byte)COM_CMD.USART_M2S_SetVal;
            for (int iter = 0; iter < 4; iter++)
            {
                data[1 + iter] = BitConverter.GetBytes(voltage)[iter];
                data[5 + iter] = BitConverter.GetBytes(current)[iter];
            }
            PackData2Frame(data);
        }        
		private void slideButtonOutput_Click(object sender, EventArgs e)
        {
            if (labelOutput.Text == "OFF")
            {
                labelOutput.Text = "ON";
                PackData2Frame(new byte[] { (byte)COM_CMD.USART_M2S_Output});//开输出
                Thread.Sleep(10);
                PackData2Frame(new byte[] { (byte)COM_CMD.USART_M2S_STATE, 0x01 });//开始发送数据
                //开始接收数据
                tickStart = Environment.TickCount;
                StartReciveData();
            }
            else
            {
                labelOutput.Text = "OFF";
                PackData2Frame(new byte[] { (byte)COM_CMD.USART_M2S_Output });//关输出
                Thread.Sleep(10);
                PackData2Frame(new byte[] { (byte)COM_CMD.USART_M2S_STATE, 0x00 });//停止发送数据
                //停止接收数据
                StopReceiveData();
            }
        }
        private void slideButtonMode_Click(object sender, EventArgs e)
        {
			if(currentMode == MODE.MODE_VOLTAGE)
			{
                labelMode.Text = "Mode: A";
				currentMode = MODE.MODE_CURRENT;
				PackData2Frame(new byte[] { (byte)COM_CMD.USART_M2S_Mode, 0x01});//电流模式
            }
            else
            {
                labelMode.Text = "Mode: V";
				currentMode = MODE.MODE_VOLTAGE;
				PackData2Frame(new byte[] { (byte)COM_CMD.USART_M2S_Mode, 0x00});//电压模式
			}					
        }

        private void ribbonButtonOpenCom1_Click(object sender, EventArgs e)
        {
            try
            {
                if (ribbonButtonOpenCom1.Text == "打开串口")
                {
                    serialPort1.PortName = ribbonComboBoxCom1.TextBoxText;
                    serialPort1.BaudRate = int.Parse(ribbonComboBoxBaud1.TextBoxText);
                    serialPort1.StopBits = System.IO.Ports.StopBits.One;
                    serialPort1.Parity = System.IO.Ports.Parity.None;
                    serialPort1.DataBits = 8;

                    serialPort1.Open();
                    //成功打开后 设置按钮相应的状态
                    ribbonButtonOpenCom1.Text = "关闭串口";
                    ribbonButtonOpenCom1.Image = Image.FromFile(Application.StartupPath + "\\ICON\\shutdown.ico");

                    ribbonComboBoxCom1.Enabled = false;
                    ribbonComboBoxBaud1.Enabled = false;

                    //复位各表盘的数值
                    thermometerVoltage.Value = 0;
                    thermometerCurrent.Value = 0;
                    thermometerTemp.Value = 30;
                    lbDigitalMeter_Voltage_Set.Value = 0;
                    lbDigitalMeter_Current_Set.Value = 0;
                    lbDigitalMeter_Voltage_Get.Value = 0;
                    lbDigitalMeter_Current_Get.Value = 0;
                    knob_Voltage.Value = 0;
                    knob_Current.Value = 0;
                    slideButtonMode.Checked = false;
                    slideButtonOutput.Checked = false;
                    //重新设置坐标，清空原有曲线后添加电压、电流设定曲线
                    ResetGraphPane();

                    knob_Voltage.Enabled = true;
                    knob_Current.Enabled = true;
                    slideButtonMode.Enabled = true;
                    slideButtonOutput.Enabled = true;
                    glassButtonStepAdd.Enabled = true;
                    glassButtonCAL.Enabled = true;
                    glassButtonStepSub.Enabled = true;

                    //获取下位机前一次电压、电流的设定值
                    byte[] data = new byte[] { (byte)COM_CMD.USART_M2S_GetVal };
                    PackData2Frame(data);
                }
                else
                {
                    //关闭下位机输出
                    PackData2Frame(new byte[] { (byte)COM_CMD.USART_M2S_STATE, 0x00 });//停止发送数据
                    PackData2Frame(new byte[] { (byte)COM_CMD.USART_M2S_Output, 0x00 });//关输出
                    Thread.Sleep(200);

                    serialPort1.Close();
                    ribbonButtonOpenCom1.Text = "打开串口";
                    ribbonButtonOpenCom1.Image = Image.FromFile(Application.StartupPath + "\\icon\\standby.ico");
                    ribbonComboBoxCom1.Enabled = true;
                    ribbonComboBoxBaud1.Enabled = true;

                    //停止接收数据
                    StopReceiveData();

                    knob_Voltage.Enabled = false;
                    knob_Current.Enabled = false;
                    slideButtonMode.Enabled = false;
                    slideButtonOutput.Enabled = false;
                    glassButtonStepAdd.Enabled = false;
                    glassButtonCAL.Enabled = false;
                    glassButtonStepSub.Enabled = false;

                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }

        }

        float voltage = 0, current = 0, temp = 0;
        byte[] tmpArray = new byte[4];
        private void DataParseThreadFunc()
        {
            while (_runDataParseThread)
            {
                lock (this)
                {
                    if (receiveByteQueue.Count > 0)
                    {
                        if (AnalyzePackage(receiveByteQueue.Dequeue()))
                        {
                            currentTime = (Environment.TickCount - tickStart) / 1000.0;// +previousTime;
                            
                            switch (m_pRxBuf[0])
                            {
                                case (byte)COM_CMD.USART_S2M_PreVal://前一次设置的电压、电流
                                    tmpArray[0] = m_pRxBuf[1];
                                    tmpArray[1] = m_pRxBuf[2];
                                    tmpArray[2] = m_pRxBuf[3];
                                    tmpArray[3] = m_pRxBuf[4];
                                    voltage = BitConverter.ToSingle(tmpArray, 0); 
                                    tmpArray[0] = m_pRxBuf[5];
                                    tmpArray[1] = m_pRxBuf[6];
                                    tmpArray[2] = m_pRxBuf[7];
                                    tmpArray[3] = m_pRxBuf[8];
                                    current = BitConverter.ToSingle(tmpArray, 0);
                                    knob_Voltage.Value = (int)(voltage*10);
                                    knob_Current.Value = (int)(current*100);
                                    break;
                                case (byte)COM_CMD.USART_S2M_RealVal://实时电压、电流数据
                                    tmpArray[0] = m_pRxBuf[1];
                                    tmpArray[1] = m_pRxBuf[2];
                                    tmpArray[2] = m_pRxBuf[3];
                                    tmpArray[3] = m_pRxBuf[4];
                                    voltage = BitConverter.ToSingle(tmpArray, 0);
                                    tmpArray[0] = m_pRxBuf[5];
                                    tmpArray[1] = m_pRxBuf[6];
                                    tmpArray[2] = m_pRxBuf[7];
                                    tmpArray[3] = m_pRxBuf[8];
                                    current = BitConverter.ToSingle(tmpArray, 0);
                                    
                                    mCurveStructVolSet.pointList.Add(currentTime, (float)lbDigitalMeter_Voltage_Set.Value);
                                    mCurveStructVolGet.pointList.Add(currentTime, voltage);
                                    mCurveStructCurSet.pointList.Add(currentTime, (float)lbDigitalMeter_Current_Set.Value);
                                    mCurveStructCurGet.pointList.Add(currentTime, current);
                                    lbDigitalMeter_Voltage_Get.Value = (double)voltage;
                                    lbDigitalMeter_Current_Get.Value = (double)current;
                                    thermometerVoltage.Value = voltage;
                                    thermometerCurrent.Value = current;
                                    break;
                                case (byte)COM_CMD.USART_S2M_RealTemp://当前温度
                                    tmpArray[0] = m_pRxBuf[1];
                                    tmpArray[1] = m_pRxBuf[2];
                                    tmpArray[2] = m_pRxBuf[3];
                                    tmpArray[3] = m_pRxBuf[4];
                                    temp = BitConverter.ToSingle(tmpArray, 0);
                                    thermometerTemp.Value = temp;
                                    if (temp <= 40.0)
                                    {
                                        thermometerTemp.BackColor = Color.Green;
                                    }
                                    else if (temp <= 50)
                                    {
                                        thermometerTemp.BackColor = Color.Brown;
                                    }
                                    else
                                    {
                                        thermometerTemp.BackColor = Color.Red;
                                    }
                                    break;
                            }
                            
                            Scale xScale = zedGraphControl1.GraphPane.XAxis.Scale;
                            if (currentTime > xScale.Max - xScale.MajorStep)
                            {
                                xScale.Max = currentTime + xScale.MajorStep;
                                xScale.Min = xScale.Max - 30.0;
                            }

                            //更新X和Y轴的范围
                            zedGraphControl1.AxisChange();
                            //更新图表
                            zedGraphControl1.Invalidate();
                        }
                    }
                }
            }
        }

		
        private byte USART_LastByte = 0;
        private bool USART_BeginFlag = false;
        private bool USART_CtrlFlag = false;
        private long USART_RevOffset = 0;
        private byte CheckSum = 0;
        private bool AnalyzePackage(byte data)
        {
            if (((data == USART_FRAMEHEAD) && (USART_LastByte == USART_FRAMEHEAD)) || (USART_RevOffset > m_MaxPackageSize))
            {
                if (USART_RevOffset < 6 && USART_RevOffset > 0)
                {
                    m_TotalRxLostPackages++;
                }
                //RESET
                USART_RevOffset = 0;
                USART_BeginFlag = true;
                USART_LastByte = data;
                return false;
            }
            if ((data == USART_FRAMETAIL) && (USART_LastByte == USART_FRAMETAIL) && USART_BeginFlag)
            {
                USART_RevOffset--;//得到除去头尾和控制符的数据的个数
                m_RxPackageDataCount = USART_RevOffset - 1;
                CheckSum -= USART_FRAMETAIL;
                CheckSum -= m_pRxBuf[m_RxPackageDataCount];
                USART_LastByte = data;
                USART_BeginFlag = false;
                if (CheckSum == m_pRxBuf[m_RxPackageDataCount])
                {
                    CheckSum = 0;
                    return true;
                }
                m_TotalRxLostPackages++;

                CheckSum = 0;
                return false;
            }
            USART_LastByte = data;
            if (USART_BeginFlag)
            {
                if (USART_CtrlFlag)
                {
                    m_pRxBuf[USART_RevOffset++] = data;
                    CheckSum += data;
                    USART_CtrlFlag = false;
                    USART_LastByte = USART_FRAMECTRL;
                }
                else if (data == USART_FRAMECTRL)
                {
                    USART_CtrlFlag = true;
                }
                else
                {
                    m_pRxBuf[USART_RevOffset++] = data;
                    CheckSum += data;
                }
            }
            return false;
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            Thread.Sleep(5);
            try
            {
                byte[] byteArray = new byte[serialPort1.ReadBufferSize];
                int len = serialPort1.Read(byteArray, 0, byteArray.Length);

                lock (this)
                {
                    for (int i = 0; i < len; i++)
                    {
                        receiveByteQueue.Enqueue(byteArray[i]);
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("serialPort1_DataReceived" + error.ToString());
            }
        }

        private void PackData2Frame(params byte[] byteArray)
        {
            if (serialPort1.IsOpen)
            {
                byte[] tmpByteArray = new byte[100];
                byte len = 0;
                tmpByteArray[0] = USART_FRAMEHEAD;
                tmpByteArray[1] = USART_FRAMEHEAD;
                CheckSum = 0;
                len = 2;
                foreach (byte tmp in byteArray)
                {
                    if (tmp == USART_FRAMECTRL || tmp == USART_FRAMEHEAD || tmp == USART_FRAMETAIL)
                    {
                        tmpByteArray[len] = USART_FRAMECTRL;
                        len++;
                    }
                    tmpByteArray[len] = tmp;
                    CheckSum += tmp;
                    len++;
                }
                if (CheckSum == USART_FRAMECTRL || CheckSum == USART_FRAMEHEAD || CheckSum == USART_FRAMETAIL)
                {
                    tmpByteArray[len] = USART_FRAMECTRL;
                    len++;
                }
                tmpByteArray[len] = CheckSum;
                len++;

                tmpByteArray[len] = USART_FRAMETAIL;
                len++;
                tmpByteArray[len] = USART_FRAMETAIL;
                len++;
                serialPort1.Write(tmpByteArray, 0, len);
            }
        }

        private void ribbonButtonOpenCom2_Click(object sender, EventArgs e)
        {

            try
            {
                if (ribbonButtonOpenCom2.Text == "打开串口")
                {
                    serialPort2.PortName = ribbonComboBoxCom2.TextBoxText;
                    serialPort2.BaudRate = int.Parse(ribbonComboBoxBaud2.TextBoxText);
                    serialPort2.StopBits = System.IO.Ports.StopBits.One;
                    serialPort2.Parity = System.IO.Ports.Parity.None;
                    serialPort2.DataBits = 8;

                    serialPort2.Open();
                    //成功打开后 设置按钮相应的状态
                    ribbonButtonOpenCom2.Text = "关闭串口";
                    ribbonButtonOpenCom2.Image = Image.FromFile(Application.StartupPath + "\\ICON\\shutdown.ico");

                    ribbonComboBoxCom2.Enabled = false;
                    ribbonComboBoxBaud2.Enabled = false;
                }
                else
                {
                    serialPort2.Close();
                    ribbonButtonOpenCom2.Text = "打开串口";
                    ribbonButtonOpenCom2.Image = Image.FromFile(Application.StartupPath + "\\icon\\standby.ico");
                    ribbonComboBoxCom2.Enabled = true;
                    ribbonComboBoxBaud2.Enabled = true;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        private void glassButtonCAL_Click(object sender, EventArgs e)
        {
            PackData2Frame(new byte[] { (byte)COM_CMD.USART_M2S_Cal});
        }

        private void glassButtonStepAdd_Click(object sender, EventArgs e)
        {
            PackData2Frame(new byte[] { (byte)COM_CMD.USART_M2S_StepAdd });

        }

        private void glassButtonStepSub_Click(object sender, EventArgs e)
        {
            PackData2Frame(new byte[] { (byte)COM_CMD.USART_M2S_StepSub });
        }

        

    }
}

        
