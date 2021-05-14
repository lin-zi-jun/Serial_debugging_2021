using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading;

namespace 上位机服务器
{
    public partial class Form1 : Form
    {
        static int MAXSIZE = 100;
        delegate void addDelegate();
        delegate void addData(int a, int length);
        addDelegate d;
        Thread[] threadMsg = new Thread[MAXSIZE];
        Thread threadWatch = null;//负责 调用套接字， 执行 监听请求的线程
        struct canshu
        {
            //public string Ip;
            public int counter;
        }
        public void add()
        {
            if (InvokeRequired)
            {
                Invoke(d); //使用代理
            }
            else
            {
                Controls.Add(new TextBox());//...直接调用
            }
        }

        //负责监听 客户端段 连接请求的  套接字
        Socket HostSocket = null;
        IPAddress serverIp;
        Int32 portNo = 6000;
        string GetDate=System.DateTime.Now.ToString("yyyyMMdd");
        string OriginalDataFolder = null;
        string SGYDataFolder = null;
        public Form1()
        {
            try
            {
                InitializeComponent();
                TextBox.CheckForIllegalCrossThreadCalls = false;//关闭跨线程修改控件检查

                IPAddress[] iplist = Dns.GetHostAddresses(Dns.GetHostName());
                for (int i = iplist.Length - 1; i >= 0; i--)
                {
                    if (iplist[i].AddressFamily == AddressFamily.InterNetwork)
                    {
                        serverIp = iplist[i];
                        break;
                    }
                }

                OriginalDataFolder = GetDate + "\\OriginalData";
                SGYDataFolder = GetDate + "\\sgy";
                if (!Directory.Exists(OriginalDataFolder))//创建原始数据文件夹
                    System.IO.Directory.CreateDirectory(OriginalDataFolder);
                if (!Directory.Exists(SGYDataFolder))//创建sgy格式文件夹
                    System.IO.Directory.CreateDirectory(SGYDataFolder);
                MessageBox.Show("文件夹创建成功.");

                txtIP.Text = Convert.ToString(serverIp);
                txtPort.Text = Convert.ToString(6000);
                txtIP.Enabled = false;
                txtPort.Enabled = false;
                txtStatus3.Text = "点击启动服务器即可.";
                txtStatus2.Text = "服务器已建立，可启动服务器.";
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.ToString());
            }
        }
        Dictionary<int, Socket> dictsocket= new Dictionary<int, Socket>();

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (btnStart.Text == "启动服务器")
            {
                if (HostSocket == null)
                {
                    HostSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    //将 监听套接字  绑定到 对应的IP和端口
                    HostSocket.Bind(new IPEndPoint(serverIp, portNo));
                }
                //设置 监听队列 长度为10(同时能够处理 10个连接请求)
                HostSocket.Listen(50);
                //开始接受客户端连接请求
                //HostSocket.BeginAccept(new AsyncCallback(ClientAccepted), HostSocket);
                isWatch = true;
                threadWatch = new Thread(ClientAccepted0);
                threadWatch.IsBackground = true;
                threadWatch.Start();

                txtStatus3.Text = "原始数据在OriginalData目录下，转换的SGY格式在sgy目录下.";
                txtStatus2.Text = "服务器已启动，开始接收数据";
                btnStart.Text = "关闭服务器";
            }
            else
            {
                try
                {
                    int[] a = new int[MAXSIZE];
                    int counter = 0;
                    isWatch = false;
                    foreach (int conn in dictsocket.Keys)//关闭线程
                    {
                        isRec[conn] = false;
                        if (threadMsg[conn].IsAlive) threadMsg[conn].Abort();
                        //从list中移除选中的选项
                        listBox1.Items.Clear();
                        //从tab中移除
                        tabControl1.TabPages.Clear();//;
                        //从dictionary中移除选中项
                        dictsocket[conn].Close();
                        //dictsocket.Remove(conn);
                        a[conn] = conn;
                        counter = conn;
                    }
                    for (int k = 1; k <= counter; k++)
                    {
                        if (a[k] == k)
                        {
                            dictsocket.Remove(k);
                        }
                    }
                    //关闭客户端Socket,清理资源
                    if (threadWatch.IsAlive)//关闭监听线程
                        threadWatch.Abort();
                    HostSocket.Close();
                    HostSocket = null;
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    clientCounter = 0;

                    txtStatus3.Text = "点击启动服务器即可.";
                    txtStatus2.Text = "服务器停止监听.";
                    btnStart.Text = "启动服务器";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("关闭无效！" + ex.ToString());
                }
            }
        }

        uint clientCounter = 0;//已连接的客户端计数
        int dictCounter = 0;//dictionary里的有效成员计数  dictCounter作为dictionary的唯一标识
        Socket[] clientarry = new Socket[MAXSIZE];
        
        public void ClientAccepted(IAsyncResult ar)
        {
            if (HostSocket == null) 
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
            else
            {
                var sokWatch = ar.AsyncState as Socket;
                //这就是客户端的Socket实例，我们后续可以将其保存起来
                var client = sokWatch.EndAccept(ar);

                dictCounter++;//从1开始标识
                clientarry[dictCounter] = client;

                //将client保存到dictionary
                dictsocket.Add(dictCounter, client);

                //将client显示在listbox中
                listBox1.Items.Add(dictCounter + ":" + client.RemoteEndPoint);

                //将连接的客户端创建tabpage 
                d = new addDelegate(CreatTabpage);
                Thread t = new Thread(new ThreadStart(add));
                t.Start();

                //成功连接的客户端数量显示在状态栏
                clientCounter++;
                txtStatus2.Text = "建立连接." + clientCounter;

                //接收客户端的消息
                threadMsg[dictCounter] = new Thread(ReceiveMessage0);
                canshu aa = new canshu();
                isRec[dictCounter] = true;
                aa.counter = dictCounter;
                threadMsg[dictCounter].IsBackground = true;
                threadMsg[dictCounter].Start((object)aa);

                //准备接受下一个客户端请求
                sokWatch.BeginAccept(new AsyncCallback(ClientAccepted), sokWatch);
            }
        }

        bool isWatch = true;
        public void ClientAccepted0()
        {
            while (isWatch)
            {
                if (!isWatch)
                    GC.WaitForPendingFinalizers();
                else
                {
                    //这就是客户端的Socket实例，我们后续可以将其保存起来
                    var client = HostSocket.Accept();

                    dictCounter++;//从1开始标识
                    clientarry[dictCounter] = client;

                    //将client保存到dictionary
                    dictsocket.Add(dictCounter, client);

                    //将client显示在listbox中
                    listBox1.Items.Add(dictCounter + ":" + client.RemoteEndPoint);

                    //将连接的客户端创建tabpage 
                    d = new addDelegate(CreatTabpage);
                    Thread t = new Thread(new ThreadStart(add));
                    t.Start();

                    //成功连接的客户端数量显示在状态栏
                    clientCounter++;
                    txtStatus2.Text = "建立连接." + clientCounter;

                    //接收客户端的消息
                    threadMsg[dictCounter] = new Thread(ReceiveMessage0);
                    canshu aa = new canshu();
                    isRec[dictCounter] = true;
                    aa.counter = dictCounter;
                    threadMsg[dictCounter].IsBackground = true;
                    threadMsg[dictCounter].Start((object)aa);

                }
            }
        }
        System.Windows.Forms.TabPage[] pagearry = new System.Windows.Forms.TabPage[MAXSIZE];
        TextBox[] boxarry = new TextBox[MAXSIZE];
        ToolStripStatusLabel[] statuslabelarry = new ToolStripStatusLabel[MAXSIZE];
        ToolStrip[] toolstriparry = new ToolStrip[MAXSIZE];
        Button[] buttonarry = new Button[MAXSIZE];
        //创建tabpage
        public void CreatTabpage() 
        {
            //创建button
            Button buttontemp=new Button();
            buttontemp.Text = "清空数据";
            canshu aa=new canshu();
            aa.counter=dictCounter;
            EventArgs e=new EventArgs();
            buttontemp.Click += new EventHandler(buttontemp_Click);
            buttonarry[dictCounter] = buttontemp;

            //创建状态栏
            ToolStripStatusLabel Labeltemp = new ToolStripStatusLabel();
            Labeltemp.Name = "label" + dictCounter;
            Labeltemp.Text = "label"+dictCounter;
            Labeltemp.Size = new System.Drawing.Size(20, 30);
            Labeltemp.Spring = true;
            statuslabelarry[dictCounter] = Labeltemp;

            //创建状态栏
            ToolStrip striptemp = new ToolStrip();
            //statustemp.Location = new System.Drawing.Point(500, 309);
            striptemp.Dock = System.Windows.Forms.DockStyle.Bottom;
            striptemp.Name = "status"+dictCounter;
            striptemp.Size = new System.Drawing.Size(20, 30);
            striptemp.Items.Add(statuslabelarry[dictCounter]);
            toolstriparry[dictCounter] = striptemp;
            

            //创建窗口
            TextBox boxtemp = new TextBox();
            boxtemp.Location = new System.Drawing.Point(100,3);
            boxtemp.Name = "textBox"+dictCounter;
            boxtemp.Multiline = true;
            boxtemp.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            boxtemp.Size = new System.Drawing.Size(100, 70);
            //boxtemp.TabIndex = dictCounter;
            boxtemp.Text = "this is textbox"+dictCounter;
            boxtemp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            //boxtemp.Dock = System.Windows.Forms.DockStyle.Fill;
            boxarry[dictCounter] = boxtemp;

            //创建tab页面
            TabPage pagetemp = new System.Windows.Forms.TabPage();
            //pagetemp.Size = new System.Drawing.Size(300, 100);    
            pagetemp.Name = "tabPage"+dictCounter;
            pagetemp.Text = dictCounter + ":" + clientarry[dictCounter].RemoteEndPoint.ToString();
            pagetemp.UseVisualStyleBackColor = true;
            pagetemp.AutoScroll = true;
            pagetemp.Controls.Add(boxarry[dictCounter]);//添加textbox
            pagetemp.Controls.Add(toolstriparry[dictCounter]);//添加状态栏
            pagetemp.Controls.Add(buttonarry[dictCounter]);//添加button
            pagearry[dictCounter] = pagetemp;
            
            tabControl1.Controls.Add(pagearry[dictCounter]);//添加tabpage
            tabControl1.Controls.SetChildIndex(pagearry[dictCounter], dictCounter);
           
            //显示刚连接的窗口
            tabControl1.SelectTab("tabpage" + dictCounter);

        }

        void buttontemp_Click(object sender, EventArgs e)
        {
            string end = ":";
            int length = tabControl1.SelectedTab.Text.IndexOf(end);
            int a = int.Parse(tabControl1.SelectedTab.Text.Substring(0, length));
            //点击客户端显示相对应的tab
            boxarry[a].Text = null;
            lengthSum[a] = 0;
        }

        int[] lengthSum = new int[MAXSIZE];//单个客户端的收到数据的总字节长度
        bool[] isRec = new bool[MAXSIZE];//客户端接收数据线程标识
        bool[] FlagEnd = new bool[MAXSIZE];//接收数据结束标识
        bool[] FlagConverter = new bool[MAXSIZE];//开始转换标识
        string[] SaveTime = new string[MAXSIZE];//保存的时间
        int ccflag = 0;
        public void ReceiveMessage0(object o)
        {
            canshu aa=(canshu)o;
            SaveTime[aa.counter] = System.DateTime.Now.ToString("HHmmss");
            while (isRec[aa.counter])
            {
                if (!dictsocket[dictCounter].Connected)
                {
                    isRec[aa.counter] = false;
                    //从list中移除选中的选项
                    listBox1.Items.Remove(aa.counter + ":" + clientarry[aa.counter].RemoteEndPoint);
                    //从tab中移除
                    tabControl1.TabPages.Remove(pagearry[aa.counter]);
                    //从dictionary中移除选中项
                    dictsocket[aa.counter].Close();
                    dictsocket.Remove(aa.counter);

                    clientCounter--;
                    txtStatus2.Text = "建立连接." + clientCounter;
                }
                else
                {
                    try
                    {
                        byte[] arrMsg = new byte[1024 * 1024];
                        //接收 对应 客户端发来的消息
                        int length = dictsocket[aa.counter].Receive(arrMsg);
                        ccflag++;
                        //保存原始数据
                        FlagEnd[aa.counter]=SaveTxt(OriginalDataFolder+"\\"+SaveTime[aa.counter] + "." + aa.counter, arrMsg, length,aa.counter);
                        if (FlagEnd[aa.counter]) //结束标识
                        {


                            SaveTime[aa.counter] = System.DateTime.Now.ToString("HHmmss");
                        }

                        lengthSum[aa.counter] += length;
                        //将接收到的消息数组里真实消息转成字符串
                        string strMsg = System.Text.Encoding.Default.GetString(arrMsg, 0, length);
                        //通过委托 显示消息到 窗体的文本框
                        
                        boxarry[aa.counter].AppendText(strMsg);

                        statuslabelarry[aa.counter].Text = "接收了" + lengthSum[aa.counter] + "字节.";
                    }
                    catch
                    {
                        if (isRec[aa.counter])
                        {
                            isRec[aa.counter] = false;
                            //从list中移除选中的选项
                            listBox1.Items.Remove(aa.counter + ":" + dictsocket[aa.counter].RemoteEndPoint);
                            //从tab中移除
                            tabControl1.TabPages.Remove(pagearry[aa.counter]);
                            //从dictionary中移除选中项
                            dictsocket[aa.counter].Close();
                            dictsocket.Remove(aa.counter);

                            clientCounter--;
                            txtStatus2.Text = "建立连接." + clientCounter;
                        }
                    }
                }
            }
        }

        //int SavaLeng = 0;
        public bool SaveTxt(string sFileName, byte[] sContent,Int32 slength,int cc)
        {

            try
            {
                if (!System.IO.File.Exists(sFileName))//如果不存在则创建文件
                {
                    FileStream fs;
                    fs = File.Create(sFileName);
                    fs.Close();
                }

                FileStream fsTxtWrite = new FileStream(sFileName, FileMode.Append);
                fsTxtWrite.Write(sContent, 0, slength);
                //SavaLeng+=slength;
                fsTxtWrite.Close();

                //MessageBox.Show(slength.ToString() +":s-2:" +sContent[slength - 2].ToString() +" s-1:" +sContent[slength - 1].ToString());
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); 
            }

            if (sContent[slength - 4] == 0x0d && sContent[slength - 3] == 0x0a)
            {
                MessageBox.Show("一个文件接收完成."+ccflag);
                ccflag = 0;
                FileStream rs = File.Open(sFileName, FileMode.Open);
                ushort nso_num = (ushort)(rs.Length / 4);
                byte[] readtmp = new byte[nso_num * 4];
                rs.Read(readtmp, 0, nso_num * 4);
                rs.Close();
                UInt16 a= CRC16.Get_Crc16(readtmp, nso_num * 4-4);
               // MessageBox.Show(Convert.ToString(nso_num * 4));
                if (a == (sContent[slength - 2] << 8 | sContent[slength - 1]))
                {
                    FlagConverter[cc] = true;
                    //转换成sgy
                    if (SGY_Change.Change(sFileName, SGYDataFolder + "\\" + SaveTime[cc] + ".sgy"))//保存的sgy格式数据//取原始数据
                        MessageBox.Show("通道" + cc + "转换完成.");
                    else MessageBox.Show("通道" + cc + "转换失败.");
                    MessageBox.Show("完成CRC验证——无错.");
                }
                else 
                {
                    FlagConverter[cc] = false;
                    MessageBox.Show("完成CRC验证——出错.");
                }
                return true;
            }
            else return false;
        } 

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (btnSave.Text == "保存文件")
            {
                if (string.IsNullOrEmpty(txtSave.Text))
                {
                    MessageBox.Show("请输入文件名！");
                }
                else
                {

                }
            }
            else 
            {
                btnSave.Text = "保存文件";
            }
            
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSend.Text))
            {
                MessageBox.Show("发送字节为空.");
            }
            else 
            {
                if (listBox1.SelectedIndex != -1)
                {
                    string end = ":";
                    int length = listBox1.Text.IndexOf(end);
                    int a = int.Parse(listBox1.Text.Substring(0, length));
                    //检测客户端Socket的状态
                    if (dictsocket[a].Connected)
                    {
                        dictsocket[a].Send(Encoding.ASCII.GetBytes(txtSend.Text.Trim()));
                    }
                }
                else 
                {
                    MessageBox.Show("请选择客户端.");
                }
            }
        }

        private void btnSendAll_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSend.Text))
            {
                foreach (int conn in dictsocket.Keys)
                    try
                    {
                        //检测客户端Socket的状态
                        if (dictsocket[conn].Connected)
                        {
                            dictsocket[conn].Send(Encoding.ASCII.GetBytes(txtSend.Text.Trim()));
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
            }
            else 
            {
                MessageBox.Show("请输入发送的数据.");
            }
        }

        int SaveIndex = -1;
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SaveIndex != listBox1.SelectedIndex && listBox1.SelectedIndex != -1)
            {
                SaveIndex = listBox1.SelectedIndex;

                string end = ":";
                int length = listBox1.Text.IndexOf(end);
                int a = int.Parse(listBox1.Text.Substring(0,length));
                //点击客户端显示相对应的tab
                tabControl1.SelectTab("tabpage" + a);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(listBox1.Text))
            {
                try
                {
                    //从dictionary中移除选中项
                    string end = ":";
                    int length = listBox1.Text.IndexOf(end);
                    int a = int.Parse(listBox1.Text.Substring(0,length));

                    isRec[a] = false;
                    if (threadMsg[a].IsAlive) threadMsg[a].Abort();
                    //dictsocket[a].Dispose();
                    dictsocket[a].Close();
                    dictsocket.Remove(a);

                    //从list中移除选中的选项
                    listBox1.Items.Remove(listBox1.Text);
                    //从tab中移除
                   // tabControl1.Controls.RemoveByKey("tabpage" + a);
                    tabControl1.TabPages.Remove(pagearry[a]);
                    clientCounter--;
                    txtStatus2.Text = "建立连接." + clientCounter;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else 
            {
                MessageBox.Show("请选择要移除的对象.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (int conn in dictsocket.Keys)
            {
                if (SGY_Change.Change(OriginalDataFolder + "\\" + SaveTime[conn] + "." + conn,//取原始数据
                    SGYDataFolder + "\\" + SaveTime[conn] + ".sgy"))//保存的sgy格式数据
                    MessageBox.Show("通道" + conn + "转换完成.");
                else MessageBox.Show("通道" + conn + "转换失败.");
            }
        }

        //定时器显示当前时间
        private void timer1_Tick(object sender, EventArgs e)
        {
            txtNowTime.Text = "当前时间:" + System.DateTime.Now.ToString(" HH:mm:ss  yyyy-MM-dd");
        }
    }
}
