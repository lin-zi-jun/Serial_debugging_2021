﻿namespace 串口调试工具
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.AboutSoftware_Button = new System.Windows.Forms.ToolStripButton();
            this.CheckUpdate_Button = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.OpenClosePort_Button = new System.Windows.Forms.Button();
            this.DataBits_ComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BaudRate_ComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Parity_ComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.RTS_CheckBox = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.DTR_CheckBox = new System.Windows.Forms.CheckBox();
            this.PortName_ComboBox = new System.Windows.Forms.ComboBox();
            this.StopBits_ComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.Light = new System.Windows.Forms.Label();
            this.Com_Status = new System.Windows.Forms.Label();
            this.ReceiveCount_Label = new System.Windows.Forms.Label();
            this.BaudRate_Label = new System.Windows.Forms.Label();
            this.SendCount_Label = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.Receive_TextBox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Wrap_CheckBox = new System.Windows.Forms.CheckBox();
            this.Clearn_Button = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.HexDisplay_CheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.Send_Button = new System.Windows.Forms.Button();
            this.HexSend_CheckBox = new System.Windows.Forms.CheckBox();
            this.SendHex_TextBox = new System.Windows.Forms.TextBox();
            this.SendString_TextBox = new System.Windows.Forms.TextBox();
            this.Cycle_NumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.AutoSend_CheckBox = new System.Windows.Forms.CheckBox();
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.MainMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.toolStrip1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Cycle_NumericUpDown)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AboutSoftware_Button,
            this.CheckUpdate_Button});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(629, 25);
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // AboutSoftware_Button
            // 
            this.AboutSoftware_Button.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.AboutSoftware_Button.Image = ((System.Drawing.Image)(resources.GetObject("AboutSoftware_Button.Image")));
            this.AboutSoftware_Button.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AboutSoftware_Button.Name = "AboutSoftware_Button";
            this.AboutSoftware_Button.Size = new System.Drawing.Size(60, 22);
            this.AboutSoftware_Button.Text = "软件信息";
            this.AboutSoftware_Button.Click += new System.EventHandler(this.AboutSoftware_Button_Click);
            // 
            // CheckUpdate_Button
            // 
            this.CheckUpdate_Button.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.CheckUpdate_Button.Image = ((System.Drawing.Image)(resources.GetObject("CheckUpdate_Button.Image")));
            this.CheckUpdate_Button.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CheckUpdate_Button.Name = "CheckUpdate_Button";
            this.CheckUpdate_Button.Size = new System.Drawing.Size(60, 22);
            this.CheckUpdate_Button.Text = "检查更新";
            this.CheckUpdate_Button.Click += new System.EventHandler(this.CheckUpdate_Button_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer1.Size = new System.Drawing.Size(629, 361);
            this.splitContainer1.SplitterDistance = 138;
            this.splitContainer1.TabIndex = 8;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.AutoScroll = true;
            this.splitContainer2.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.AutoScroll = true;
            this.splitContainer2.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer2.Size = new System.Drawing.Size(138, 361);
            this.splitContainer2.SplitterDistance = 245;
            this.splitContainer2.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.SkyBlue;
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(136, 243);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.Controls.Add(this.OpenClosePort_Button);
            this.panel2.Controls.Add(this.DataBits_ComboBox);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.BaudRate_ComboBox);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.Parity_ComboBox);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.RTS_CheckBox);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.DTR_CheckBox);
            this.panel2.Controls.Add(this.PortName_ComboBox);
            this.panel2.Controls.Add(this.StopBits_ComboBox);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 17);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(130, 223);
            this.panel2.TabIndex = 14;
            // 
            // OpenClosePort_Button
            // 
            this.OpenClosePort_Button.Location = new System.Drawing.Point(28, 141);
            this.OpenClosePort_Button.Name = "OpenClosePort_Button";
            this.OpenClosePort_Button.Size = new System.Drawing.Size(75, 23);
            this.OpenClosePort_Button.TabIndex = 2;
            this.OpenClosePort_Button.Text = "打开串口";
            this.OpenClosePort_Button.UseVisualStyleBackColor = true;
            this.OpenClosePort_Button.Click += new System.EventHandler(this.OpenClosePort_Button_Click);
            // 
            // DataBits_ComboBox
            // 
            this.DataBits_ComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::串口调试工具.Properties.Settings.Default, "DataBits", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DataBits_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DataBits_ComboBox.FormattingEnabled = true;
            this.DataBits_ComboBox.Items.AddRange(new object[] {
            "5",
            "6",
            "7",
            "8"});
            this.DataBits_ComboBox.Location = new System.Drawing.Point(59, 47);
            this.DataBits_ComboBox.Name = "DataBits_ComboBox";
            this.DataBits_ComboBox.Size = new System.Drawing.Size(60, 20);
            this.DataBits_ComboBox.TabIndex = 13;
            this.DataBits_ComboBox.Text = global::串口调试工具.Properties.Settings.Default.DataBits;
            this.DataBits_ComboBox.TextChanged += new System.EventHandler(this.DataBits_ComboBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "串口号:";
            // 
            // BaudRate_ComboBox
            // 
            this.BaudRate_ComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::串口调试工具.Properties.Settings.Default, "BaudRate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.BaudRate_ComboBox.FormattingEnabled = true;
            this.BaudRate_ComboBox.Items.AddRange(new object[] {
            "110",
            "300",
            "600",
            "1200",
            "2400",
            "4800",
            "9600",
            "14400",
            "19200",
            "38400",
            "56000",
            "57600",
            "115200",
            "128000",
            "230400",
            "256000"});
            this.BaudRate_ComboBox.Location = new System.Drawing.Point(59, 25);
            this.BaudRate_ComboBox.Name = "BaudRate_ComboBox";
            this.BaudRate_ComboBox.Size = new System.Drawing.Size(60, 20);
            this.BaudRate_ComboBox.TabIndex = 10;
            this.BaudRate_ComboBox.Text = global::串口调试工具.Properties.Settings.Default.BaudRate;
            this.BaudRate_ComboBox.TextChanged += new System.EventHandler(this.BaudRate_ComboBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "波特率:";
            // 
            // Parity_ComboBox
            // 
            this.Parity_ComboBox.AutoCompleteCustomSource.AddRange(new string[] {
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.Parity_ComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::串口调试工具.Properties.Settings.Default, "Parity", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Parity_ComboBox.DisplayMember = "4";
            this.Parity_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Parity_ComboBox.FormattingEnabled = true;
            this.Parity_ComboBox.ImeMode = System.Windows.Forms.ImeMode.Close;
            this.Parity_ComboBox.Items.AddRange(new object[] {
            "None",
            "Odd",
            "Even",
            "Mark",
            "Space"});
            this.Parity_ComboBox.Location = new System.Drawing.Point(59, 91);
            this.Parity_ComboBox.Name = "Parity_ComboBox";
            this.Parity_ComboBox.Size = new System.Drawing.Size(60, 20);
            this.Parity_ComboBox.TabIndex = 12;
            this.Parity_ComboBox.Text = global::串口调试工具.Properties.Settings.Default.Parity;
            this.Parity_ComboBox.TextChanged += new System.EventHandler(this.Parity_ComboBox_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "数据位:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "停止位:";
            // 
            // RTS_CheckBox
            // 
            this.RTS_CheckBox.AutoSize = true;
            this.RTS_CheckBox.Checked = global::串口调试工具.Properties.Settings.Default.RTS;
            this.RTS_CheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::串口调试工具.Properties.Settings.Default, "RTS", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.RTS_CheckBox.Location = new System.Drawing.Point(73, 119);
            this.RTS_CheckBox.Name = "RTS_CheckBox";
            this.RTS_CheckBox.Size = new System.Drawing.Size(42, 16);
            this.RTS_CheckBox.TabIndex = 7;
            this.RTS_CheckBox.Text = "RTS";
            this.RTS_CheckBox.UseVisualStyleBackColor = true;
            this.RTS_CheckBox.CheckedChanged += new System.EventHandler(this.RTS_CheckBox_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "校验位:";
            // 
            // DTR_CheckBox
            // 
            this.DTR_CheckBox.AutoSize = true;
            this.DTR_CheckBox.Checked = global::串口调试工具.Properties.Settings.Default.DTR;
            this.DTR_CheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::串口调试工具.Properties.Settings.Default, "DTR", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DTR_CheckBox.Location = new System.Drawing.Point(25, 119);
            this.DTR_CheckBox.Name = "DTR_CheckBox";
            this.DTR_CheckBox.Size = new System.Drawing.Size(42, 16);
            this.DTR_CheckBox.TabIndex = 6;
            this.DTR_CheckBox.Text = "DTR";
            this.DTR_CheckBox.UseVisualStyleBackColor = true;
            this.DTR_CheckBox.CheckedChanged += new System.EventHandler(this.DTR_CheckBox_CheckedChanged);
            // 
            // PortName_ComboBox
            // 
            this.PortName_ComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::串口调试工具.Properties.Settings.Default, "PortName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.PortName_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PortName_ComboBox.FormattingEnabled = true;
            this.PortName_ComboBox.Location = new System.Drawing.Point(59, 6);
            this.PortName_ComboBox.Name = "PortName_ComboBox";
            this.PortName_ComboBox.Size = new System.Drawing.Size(60, 20);
            this.PortName_ComboBox.TabIndex = 8;
            this.PortName_ComboBox.Text = global::串口调试工具.Properties.Settings.Default.PortName;
            this.PortName_ComboBox.TextChanged += new System.EventHandler(this.PortName_ComboBox_TextChanged);
            // 
            // StopBits_ComboBox
            // 
            this.StopBits_ComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::串口调试工具.Properties.Settings.Default, "StopBits", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.StopBits_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.StopBits_ComboBox.FormattingEnabled = true;
            this.StopBits_ComboBox.ImeMode = System.Windows.Forms.ImeMode.Close;
            this.StopBits_ComboBox.Items.AddRange(new object[] {
            "0",
            "1",
            "1.5",
            "2"});
            this.StopBits_ComboBox.Location = new System.Drawing.Point(59, 69);
            this.StopBits_ComboBox.Name = "StopBits_ComboBox";
            this.StopBits_ComboBox.Size = new System.Drawing.Size(60, 20);
            this.StopBits_ComboBox.TabIndex = 9;
            this.StopBits_ComboBox.Text = global::串口调试工具.Properties.Settings.Default.StopBits;
            this.StopBits_ComboBox.TextChanged += new System.EventHandler(this.StopBits_ComboBox_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel3);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(136, 110);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.AutoScroll = true;
            this.panel3.BackColor = System.Drawing.Color.SkyBlue;
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.Light);
            this.panel3.Controls.Add(this.Com_Status);
            this.panel3.Controls.Add(this.ReceiveCount_Label);
            this.panel3.Controls.Add(this.BaudRate_Label);
            this.panel3.Controls.Add(this.SendCount_Label);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 17);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(130, 90);
            this.panel3.TabIndex = 8;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(26, 65);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 12);
            this.label9.TabIndex = 4;
            this.label9.Text = "接收计数:";
            // 
            // Light
            // 
            this.Light.AutoSize = true;
            this.Light.ForeColor = System.Drawing.Color.DarkGray;
            this.Light.Location = new System.Drawing.Point(16, 6);
            this.Light.Name = "Light";
            this.Light.Size = new System.Drawing.Size(17, 12);
            this.Light.TabIndex = 7;
            this.Light.Text = "●";
            // 
            // Com_Status
            // 
            this.Com_Status.AutoSize = true;
            this.Com_Status.Location = new System.Drawing.Point(42, 6);
            this.Com_Status.Name = "Com_Status";
            this.Com_Status.Size = new System.Drawing.Size(65, 12);
            this.Com_Status.TabIndex = 1;
            this.Com_Status.Text = "COM1已关闭";
            // 
            // ReceiveCount_Label
            // 
            this.ReceiveCount_Label.AutoSize = true;
            this.ReceiveCount_Label.Location = new System.Drawing.Point(88, 65);
            this.ReceiveCount_Label.Name = "ReceiveCount_Label";
            this.ReceiveCount_Label.Size = new System.Drawing.Size(11, 12);
            this.ReceiveCount_Label.TabIndex = 6;
            this.ReceiveCount_Label.Text = "0";
            // 
            // BaudRate_Label
            // 
            this.BaudRate_Label.AutoSize = true;
            this.BaudRate_Label.Location = new System.Drawing.Point(54, 22);
            this.BaudRate_Label.Name = "BaudRate_Label";
            this.BaudRate_Label.Size = new System.Drawing.Size(29, 12);
            this.BaudRate_Label.TabIndex = 2;
            this.BaudRate_Label.Text = "9600";
            // 
            // SendCount_Label
            // 
            this.SendCount_Label.AutoSize = true;
            this.SendCount_Label.Location = new System.Drawing.Point(88, 43);
            this.SendCount_Label.Name = "SendCount_Label";
            this.SendCount_Label.Size = new System.Drawing.Size(11, 12);
            this.SendCount_Label.TabIndex = 5;
            this.SendCount_Label.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(26, 43);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 12);
            this.label8.TabIndex = 3;
            this.label8.Text = "发送计数:";
            // 
            // splitContainer3
            // 
            this.splitContainer3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.Receive_TextBox);
            this.splitContainer3.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.groupBox3);
            this.splitContainer3.Size = new System.Drawing.Size(487, 361);
            this.splitContainer3.SplitterDistance = 245;
            this.splitContainer3.TabIndex = 0;
            // 
            // Receive_TextBox
            // 
            this.Receive_TextBox.BackColor = System.Drawing.Color.White;
            this.Receive_TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::串口调试工具.Properties.Settings.Default, "TextFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Receive_TextBox.DataBindings.Add(new System.Windows.Forms.Binding("WordWrap", global::串口调试工具.Properties.Settings.Default, "Wrap", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Receive_TextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Receive_TextBox.Font = global::串口调试工具.Properties.Settings.Default.TextFont;
            this.Receive_TextBox.Location = new System.Drawing.Point(0, 0);
            this.Receive_TextBox.MaxLength = 327;
            this.Receive_TextBox.Multiline = true;
            this.Receive_TextBox.Name = "Receive_TextBox";
            this.Receive_TextBox.ReadOnly = true;
            this.Receive_TextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.Receive_TextBox.Size = new System.Drawing.Size(485, 213);
            this.Receive_TextBox.TabIndex = 2;
            this.Receive_TextBox.WordWrap = global::串口调试工具.Properties.Settings.Default.Wrap;
            this.Receive_TextBox.TextChanged += new System.EventHandler(this.Receive_TextBox_TextChanged);
            this.Receive_TextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Receive_TextBox_KeyPress);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.SkyBlue;
            this.panel1.Controls.Add(this.Wrap_CheckBox);
            this.panel1.Controls.Add(this.Clearn_Button);
            this.panel1.Controls.Add(this.linkLabel1);
            this.panel1.Controls.Add(this.HexDisplay_CheckBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 213);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(485, 30);
            this.panel1.TabIndex = 3;
            // 
            // Wrap_CheckBox
            // 
            this.Wrap_CheckBox.AutoSize = true;
            this.Wrap_CheckBox.Checked = global::串口调试工具.Properties.Settings.Default.Wrap;
            this.Wrap_CheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::串口调试工具.Properties.Settings.Default, "Wrap", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Wrap_CheckBox.Location = new System.Drawing.Point(96, 7);
            this.Wrap_CheckBox.Name = "Wrap_CheckBox";
            this.Wrap_CheckBox.Size = new System.Drawing.Size(72, 16);
            this.Wrap_CheckBox.TabIndex = 11;
            this.Wrap_CheckBox.Text = "自动换行";
            this.Wrap_CheckBox.UseVisualStyleBackColor = true;
            // 
            // Clearn_Button
            // 
            this.Clearn_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Clearn_Button.Location = new System.Drawing.Point(419, 5);
            this.Clearn_Button.Name = "Clearn_Button";
            this.Clearn_Button.Size = new System.Drawing.Size(55, 20);
            this.Clearn_Button.TabIndex = 10;
            this.Clearn_Button.Text = "清空";
            this.Clearn_Button.UseVisualStyleBackColor = true;
            this.Clearn_Button.Click += new System.EventHandler(this.Clearn_Button_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(349, 9);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(53, 12);
            this.linkLabel1.TabIndex = 9;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "更改字体";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // HexDisplay_CheckBox
            // 
            this.HexDisplay_CheckBox.AutoSize = true;
            this.HexDisplay_CheckBox.Checked = global::串口调试工具.Properties.Settings.Default.HexStyle;
            this.HexDisplay_CheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::串口调试工具.Properties.Settings.Default, "HexStyle", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.HexDisplay_CheckBox.Location = new System.Drawing.Point(5, 7);
            this.HexDisplay_CheckBox.Name = "HexDisplay_CheckBox";
            this.HexDisplay_CheckBox.Size = new System.Drawing.Size(90, 16);
            this.HexDisplay_CheckBox.TabIndex = 4;
            this.HexDisplay_CheckBox.Text = "HEX格式显示";
            this.HexDisplay_CheckBox.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.SkyBlue;
            this.groupBox3.Controls.Add(this.panel4);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(485, 110);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "发送区";
            // 
            // panel4
            // 
            this.panel4.AutoScroll = true;
            this.panel4.Controls.Add(this.Send_Button);
            this.panel4.Controls.Add(this.HexSend_CheckBox);
            this.panel4.Controls.Add(this.SendHex_TextBox);
            this.panel4.Controls.Add(this.SendString_TextBox);
            this.panel4.Controls.Add(this.Cycle_NumericUpDown);
            this.panel4.Controls.Add(this.label10);
            this.panel4.Controls.Add(this.AutoSend_CheckBox);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 17);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(479, 90);
            this.panel4.TabIndex = 12;
            // 
            // Send_Button
            // 
            this.Send_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Send_Button.Location = new System.Drawing.Point(416, 29);
            this.Send_Button.Name = "Send_Button";
            this.Send_Button.Size = new System.Drawing.Size(55, 23);
            this.Send_Button.TabIndex = 6;
            this.Send_Button.Text = "发送";
            this.Send_Button.UseVisualStyleBackColor = true;
            this.Send_Button.Click += new System.EventHandler(this.Send_Button_Click);
            // 
            // HexSend_CheckBox
            // 
            this.HexSend_CheckBox.AutoSize = true;
            this.HexSend_CheckBox.Checked = global::串口调试工具.Properties.Settings.Default.HexSend_Checked;
            this.HexSend_CheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::串口调试工具.Properties.Settings.Default, "HexSend_Checked", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.HexSend_CheckBox.Location = new System.Drawing.Point(13, 33);
            this.HexSend_CheckBox.Name = "HexSend_CheckBox";
            this.HexSend_CheckBox.Size = new System.Drawing.Size(90, 16);
            this.HexSend_CheckBox.TabIndex = 10;
            this.HexSend_CheckBox.Text = "HEX格式发送";
            this.HexSend_CheckBox.UseVisualStyleBackColor = true;
            this.HexSend_CheckBox.CheckedChanged += new System.EventHandler(this.HexSend_CheckBox_CheckedChanged);
            // 
            // SendHex_TextBox
            // 
            this.SendHex_TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::串口调试工具.Properties.Settings.Default, "SendHex_Text", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.SendHex_TextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.SendHex_TextBox.ForeColor = System.Drawing.Color.Black;
            this.SendHex_TextBox.Location = new System.Drawing.Point(0, 21);
            this.SendHex_TextBox.Name = "SendHex_TextBox";
            this.SendHex_TextBox.Size = new System.Drawing.Size(479, 21);
            this.SendHex_TextBox.TabIndex = 11;
            this.SendHex_TextBox.Text = global::串口调试工具.Properties.Settings.Default.SendHex_Text;
            this.SendHex_TextBox.Visible = false;
            this.SendHex_TextBox.Leave += new System.EventHandler(this.SendHex_TextBox_Leave);
            // 
            // SendString_TextBox
            // 
            this.SendString_TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::串口调试工具.Properties.Settings.Default, "SendString_Text", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.SendString_TextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.SendString_TextBox.ForeColor = System.Drawing.Color.Black;
            this.SendString_TextBox.Location = new System.Drawing.Point(0, 0);
            this.SendString_TextBox.Name = "SendString_TextBox";
            this.SendString_TextBox.Size = new System.Drawing.Size(479, 21);
            this.SendString_TextBox.TabIndex = 5;
            this.SendString_TextBox.Text = global::串口调试工具.Properties.Settings.Default.SendString_Text;
            this.SendString_TextBox.Visible = false;
            // 
            // Cycle_NumericUpDown
            // 
            this.Cycle_NumericUpDown.Location = new System.Drawing.Point(124, 57);
            this.Cycle_NumericUpDown.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.Cycle_NumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Cycle_NumericUpDown.Name = "Cycle_NumericUpDown";
            this.Cycle_NumericUpDown.Size = new System.Drawing.Size(59, 21);
            this.Cycle_NumericUpDown.TabIndex = 9;
            this.Cycle_NumericUpDown.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(91, 62);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(113, 12);
            this.label10.TabIndex = 8;
            this.label10.Text = "周期:           ms";
            // 
            // AutoSend_CheckBox
            // 
            this.AutoSend_CheckBox.AutoSize = true;
            this.AutoSend_CheckBox.Location = new System.Drawing.Point(13, 61);
            this.AutoSend_CheckBox.Name = "AutoSend_CheckBox";
            this.AutoSend_CheckBox.Size = new System.Drawing.Size(72, 16);
            this.AutoSend_CheckBox.TabIndex = 7;
            this.AutoSend_CheckBox.Text = "自动发送";
            this.AutoSend_CheckBox.UseVisualStyleBackColor = true;
            this.AutoSend_CheckBox.CheckedChanged += new System.EventHandler(this.AutoSend_CheckBox_CheckedChanged);
            // 
            // serialPort
            // 
            this.serialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort_DataReceived);
            // 
            // fontDialog1
            // 
            this.fontDialog1.Color = System.Drawing.SystemColors.ControlText;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MainMessage});
            this.statusStrip1.Location = new System.Drawing.Point(0, 386);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(629, 22);
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // MainMessage
            // 
            this.MainMessage.Name = "MainMessage";
            this.MainMessage.Size = new System.Drawing.Size(32, 17);
            this.MainMessage.Text = "就绪";
            this.MainMessage.TextChanged += new System.EventHandler(this.MainMessage_TextChanged);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 408);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "串口调试软件V1.0";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Cycle_NumericUpDown)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton AboutSoftware_Button;
        private System.Windows.Forms.ToolStripButton CheckUpdate_Button;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox DataBits_ComboBox;
        private System.Windows.Forms.ComboBox BaudRate_ComboBox;
        private System.Windows.Forms.ComboBox Parity_ComboBox;
        private System.Windows.Forms.Button OpenClosePort_Button;
        private System.Windows.Forms.CheckBox RTS_CheckBox;
        private System.Windows.Forms.CheckBox DTR_CheckBox;
        private System.Windows.Forms.ComboBox StopBits_ComboBox;
        private System.Windows.Forms.ComboBox PortName_ComboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label ReceiveCount_Label;
        private System.Windows.Forms.Label SendCount_Label;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label BaudRate_Label;
        private System.Windows.Forms.Label Com_Status;
        private System.Windows.Forms.Label Light;
        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.TextBox Receive_TextBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Clearn_Button;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.CheckBox HexDisplay_CheckBox;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel MainMessage;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox SendHex_TextBox;
        private System.Windows.Forms.CheckBox HexSend_CheckBox;
        private System.Windows.Forms.NumericUpDown Cycle_NumericUpDown;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox AutoSend_CheckBox;
        private System.Windows.Forms.TextBox SendString_TextBox;
        private System.Windows.Forms.Button Send_Button;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.CheckBox Wrap_CheckBox;
    }
}

