namespace DC_POWER
{
    partial class Mainform
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Mainform));
            this.ribbon1 = new System.Windows.Forms.Ribbon();
            this.ribbonTab1 = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel1 = new System.Windows.Forms.RibbonPanel();
            this.ribbonComboBoxCom1 = new System.Windows.Forms.RibbonComboBox();
            this.ribbonComboBoxBaud1 = new System.Windows.Forms.RibbonComboBox();
            this.ribbonLabelBaud2400 = new System.Windows.Forms.RibbonLabel();
            this.ribbonLabelBaud9600 = new System.Windows.Forms.RibbonLabel();
            this.ribbonLabelBaud38400 = new System.Windows.Forms.RibbonLabel();
            this.ribbonLabelBaud115200 = new System.Windows.Forms.RibbonLabel();
            this.ribbonSeparator1 = new System.Windows.Forms.RibbonSeparator();
            this.ribbonButtonOpenCom1 = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel2 = new System.Windows.Forms.RibbonPanel();
            this.ribbonComboBoxCom2 = new System.Windows.Forms.RibbonComboBox();
            this.ribbonComboBoxBaud2 = new System.Windows.Forms.RibbonComboBox();
            this.ribbonLabelBaud2400_2 = new System.Windows.Forms.RibbonLabel();
            this.ribbonLabelBaud9600_2 = new System.Windows.Forms.RibbonLabel();
            this.ribbonLabelBaud38400_2 = new System.Windows.Forms.RibbonLabel();
            this.ribbonLabelBaud115200_2 = new System.Windows.Forms.RibbonLabel();
            this.ribbonSeparator2 = new System.Windows.Forms.RibbonSeparator();
            this.ribbonButtonOpenCom2 = new System.Windows.Forms.RibbonButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.glassButtonStepAdd = new EnhancedGlassButton.GlassButton();
            this.glassButtonStepSub = new EnhancedGlassButton.GlassButton();
            this.glassButtonCAL = new EnhancedGlassButton.GlassButton();
            this.thermometerTemp = new Manometers.Thermometer();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.thermometerCurrent = new Manometers.Thermometer();
            this.thermometerVoltage = new Manometers.Thermometer();
            this.slideButtonMode = new DC_POWER.SlideButton();
            this.labelMode = new System.Windows.Forms.Label();
            this.slideButtonOutput = new DC_POWER.SlideButton();
            this.labelOutput = new System.Windows.Forms.Label();
            this.knob_Current = new AuSharp.Knob();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbDigitalMeter_Voltage_Get = new LBSoft.IndustrialCtrls.Meters.LBDigitalMeter();
            this.lbDigitalMeter_Current_Get = new LBSoft.IndustrialCtrls.Meters.LBDigitalMeter();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbDigitalMeter_Voltage_Set = new LBSoft.IndustrialCtrls.Meters.LBDigitalMeter();
            this.lbDigitalMeter_Current_Set = new LBSoft.IndustrialCtrls.Meters.LBDigitalMeter();
            this.knob_Voltage = new AuSharp.Knob();
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.serialPort2 = new System.IO.Ports.SerialPort(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ribbon1
            // 
            this.ribbon1.Font = new System.Drawing.Font("Microsoft YaHei", 9F);
            this.ribbon1.Location = new System.Drawing.Point(0, 0);
            this.ribbon1.Minimized = false;
            this.ribbon1.Name = "ribbon1";
            // 
            // 
            // 
            this.ribbon1.OrbDropDown.BorderRoundness = 8;
            this.ribbon1.OrbDropDown.Location = new System.Drawing.Point(0, 0);
            this.ribbon1.OrbDropDown.Name = "";
            this.ribbon1.OrbDropDown.Size = new System.Drawing.Size(527, 447);
            this.ribbon1.OrbDropDown.TabIndex = 0;
            this.ribbon1.OrbImage = null;
            this.ribbon1.OrbStyle = System.Windows.Forms.RibbonOrbStyle.Office_2010;
            this.ribbon1.RibbonTabFont = new System.Drawing.Font("Trebuchet MS", 9F);
            this.ribbon1.Size = new System.Drawing.Size(884, 120);
            this.ribbon1.TabIndex = 0;
            this.ribbon1.Tabs.Add(this.ribbonTab1);
            this.ribbon1.TabsMargin = new System.Windows.Forms.Padding(12, 0, 20, 0);
            this.ribbon1.Text = "ribbon1";
            this.ribbon1.ThemeColor = System.Windows.Forms.RibbonTheme.Green;
            // 
            // ribbonTab1
            // 
            this.ribbonTab1.Panels.Add(this.ribbonPanel1);
            this.ribbonTab1.Panels.Add(this.ribbonPanel2);
            this.ribbonTab1.Text = "串口设置";
            // 
            // ribbonPanel1
            // 
            this.ribbonPanel1.Items.Add(this.ribbonComboBoxCom1);
            this.ribbonPanel1.Items.Add(this.ribbonComboBoxBaud1);
            this.ribbonPanel1.Items.Add(this.ribbonSeparator1);
            this.ribbonPanel1.Items.Add(this.ribbonButtonOpenCom1);
            this.ribbonPanel1.Text = "通讯接口1";
            // 
            // ribbonComboBoxCom1
            // 
            this.ribbonComboBoxCom1.Text = "串口号";
            this.ribbonComboBoxCom1.TextBoxText = "";
            // 
            // ribbonComboBoxBaud1
            // 
            this.ribbonComboBoxBaud1.DropDownItems.Add(this.ribbonLabelBaud2400);
            this.ribbonComboBoxBaud1.DropDownItems.Add(this.ribbonLabelBaud9600);
            this.ribbonComboBoxBaud1.DropDownItems.Add(this.ribbonLabelBaud38400);
            this.ribbonComboBoxBaud1.DropDownItems.Add(this.ribbonLabelBaud115200);
            this.ribbonComboBoxBaud1.Text = "波特率";
            this.ribbonComboBoxBaud1.TextBoxText = "115200";
            // 
            // ribbonLabelBaud2400
            // 
            this.ribbonLabelBaud2400.Text = "2400";
            // 
            // ribbonLabelBaud9600
            // 
            this.ribbonLabelBaud9600.Text = "9600";
            // 
            // ribbonLabelBaud38400
            // 
            this.ribbonLabelBaud38400.Text = "38400";
            // 
            // ribbonLabelBaud115200
            // 
            this.ribbonLabelBaud115200.Text = "115200";
            // 
            // ribbonButtonOpenCom1
            // 
            this.ribbonButtonOpenCom1.Image = global::DC_POWER.Properties.Resources.standby;
            this.ribbonButtonOpenCom1.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButtonOpenCom1.SmallImage")));
            this.ribbonButtonOpenCom1.Text = "打开串口";
            this.ribbonButtonOpenCom1.Click += new System.EventHandler(this.ribbonButtonOpenCom1_Click);
            // 
            // ribbonPanel2
            // 
            this.ribbonPanel2.Items.Add(this.ribbonComboBoxCom2);
            this.ribbonPanel2.Items.Add(this.ribbonComboBoxBaud2);
            this.ribbonPanel2.Items.Add(this.ribbonSeparator2);
            this.ribbonPanel2.Items.Add(this.ribbonButtonOpenCom2);
            this.ribbonPanel2.Text = "通讯接口2";
            // 
            // ribbonComboBoxCom2
            // 
            this.ribbonComboBoxCom2.Text = "串口号";
            this.ribbonComboBoxCom2.TextBoxText = "";
            // 
            // ribbonComboBoxBaud2
            // 
            this.ribbonComboBoxBaud2.DropDownItems.Add(this.ribbonLabelBaud2400_2);
            this.ribbonComboBoxBaud2.DropDownItems.Add(this.ribbonLabelBaud9600_2);
            this.ribbonComboBoxBaud2.DropDownItems.Add(this.ribbonLabelBaud38400_2);
            this.ribbonComboBoxBaud2.DropDownItems.Add(this.ribbonLabelBaud115200_2);
            this.ribbonComboBoxBaud2.Text = "波特率";
            this.ribbonComboBoxBaud2.TextBoxText = "115200";
            // 
            // ribbonLabelBaud2400_2
            // 
            this.ribbonLabelBaud2400_2.Text = "2400";
            // 
            // ribbonLabelBaud9600_2
            // 
            this.ribbonLabelBaud9600_2.Text = "9600";
            // 
            // ribbonLabelBaud38400_2
            // 
            this.ribbonLabelBaud38400_2.Text = "38400";
            // 
            // ribbonLabelBaud115200_2
            // 
            this.ribbonLabelBaud115200_2.Text = "115200";
            // 
            // ribbonButtonOpenCom2
            // 
            this.ribbonButtonOpenCom2.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButtonOpenCom2.Image")));
            this.ribbonButtonOpenCom2.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButtonOpenCom2.SmallImage")));
            this.ribbonButtonOpenCom2.Text = "打开串口";
            this.ribbonButtonOpenCom2.Click += new System.EventHandler(this.ribbonButtonOpenCom2_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 120);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel1.Controls.Add(this.glassButtonStepAdd);
            this.splitContainer1.Panel1.Controls.Add(this.glassButtonStepSub);
            this.splitContainer1.Panel1.Controls.Add(this.glassButtonCAL);
            this.splitContainer1.Panel1.Controls.Add(this.thermometerTemp);
            this.splitContainer1.Panel1.Controls.Add(this.label8);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.thermometerCurrent);
            this.splitContainer1.Panel1.Controls.Add(this.thermometerVoltage);
            this.splitContainer1.Panel1.Controls.Add(this.slideButtonMode);
            this.splitContainer1.Panel1.Controls.Add(this.labelMode);
            this.splitContainer1.Panel1.Controls.Add(this.slideButtonOutput);
            this.splitContainer1.Panel1.Controls.Add(this.labelOutput);
            this.splitContainer1.Panel1.Controls.Add(this.knob_Current);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel1.Controls.Add(this.knob_Voltage);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel2.Controls.Add(this.zedGraphControl1);
            this.splitContainer1.Size = new System.Drawing.Size(884, 592);
            this.splitContainer1.SplitterDistance = 292;
            this.splitContainer1.TabIndex = 1;
            // 
            // glassButtonStepAdd
            // 
            this.glassButtonStepAdd.Location = new System.Drawing.Point(797, 146);
            this.glassButtonStepAdd.Name = "glassButtonStepAdd";
            this.glassButtonStepAdd.Size = new System.Drawing.Size(75, 38);
            this.glassButtonStepAdd.TabIndex = 6;
            this.glassButtonStepAdd.Text = "++";
            this.glassButtonStepAdd.Click += new System.EventHandler(this.glassButtonStepAdd_Click);
            // 
            // glassButtonStepSub
            // 
            this.glassButtonStepSub.Location = new System.Drawing.Point(797, 249);
            this.glassButtonStepSub.Name = "glassButtonStepSub";
            this.glassButtonStepSub.Size = new System.Drawing.Size(75, 38);
            this.glassButtonStepSub.TabIndex = 7;
            this.glassButtonStepSub.Text = "--";
            this.glassButtonStepSub.Click += new System.EventHandler(this.glassButtonStepSub_Click);
            // 
            // glassButtonCAL
            // 
            this.glassButtonCAL.AlternativeFocusBorderColor = System.Drawing.Color.Maroon;
            this.glassButtonCAL.AnimateGlow = true;
            this.glassButtonCAL.Location = new System.Drawing.Point(797, 191);
            this.glassButtonCAL.Name = "glassButtonCAL";
            this.glassButtonCAL.Size = new System.Drawing.Size(75, 51);
            this.glassButtonCAL.TabIndex = 5;
            this.glassButtonCAL.Text = "校准";
            this.glassButtonCAL.Click += new System.EventHandler(this.glassButtonCAL_Click);
            // 
            // thermometerTemp
            // 
            this.thermometerTemp.BackColor = System.Drawing.Color.Green;
            this.thermometerTemp.BarsBetweenNumbers = 10;
            this.thermometerTemp.BorderWidth = 4;
            this.thermometerTemp.Font = new System.Drawing.Font("Calibri", 11F);
            this.thermometerTemp.Interval = 10F;
            this.thermometerTemp.Location = new System.Drawing.Point(749, 3);
            this.thermometerTemp.Max = 60F;
            this.thermometerTemp.Min = 20F;
            this.thermometerTemp.Name = "thermometerTemp";
            this.thermometerTemp.NumberSpacing = 70;
            this.thermometerTemp.Size = new System.Drawing.Size(130, 130);
            this.thermometerTemp.StoredMax = 30F;
            this.thermometerTemp.TabIndex = 36;
            this.thermometerTemp.TextUnit = "C";
            this.thermometerTemp.Value = 30F;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("SimSun", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(29, 250);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 24);
            this.label8.TabIndex = 35;
            this.label8.Text = "R T";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("SimSun", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(29, 203);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 24);
            this.label5.TabIndex = 34;
            this.label5.Text = "SET";
            // 
            // thermometerCurrent
            // 
            this.thermometerCurrent.BackColor = System.Drawing.Color.MediumBlue;
            this.thermometerCurrent.BarsBetweenNumbers = 10;
            this.thermometerCurrent.Font = new System.Drawing.Font("Calibri", 11F);
            this.thermometerCurrent.Interval = 1F;
            this.thermometerCurrent.Location = new System.Drawing.Point(287, 4);
            this.thermometerCurrent.Max = 4F;
            this.thermometerCurrent.Min = 0F;
            this.thermometerCurrent.Name = "thermometerCurrent";
            this.thermometerCurrent.NumberSpacing = 70;
            this.thermometerCurrent.Size = new System.Drawing.Size(180, 180);
            this.thermometerCurrent.StoredMax = 0F;
            this.thermometerCurrent.TabIndex = 33;
            this.thermometerCurrent.TextUnit = "A";
            this.thermometerCurrent.Value = 0F;
            // 
            // thermometerVoltage
            // 
            this.thermometerVoltage.BackColor = System.Drawing.Color.OrangeRed;
            this.thermometerVoltage.BarsBetweenNumbers = 10;
            this.thermometerVoltage.Font = new System.Drawing.Font("Calibri", 11F);
            this.thermometerVoltage.Interval = 5F;
            this.thermometerVoltage.Location = new System.Drawing.Point(57, 4);
            this.thermometerVoltage.Max = 30F;
            this.thermometerVoltage.Min = 0F;
            this.thermometerVoltage.Name = "thermometerVoltage";
            this.thermometerVoltage.NumberSpacing = 50;
            this.thermometerVoltage.Size = new System.Drawing.Size(180, 180);
            this.thermometerVoltage.StartAngle = 240;
            this.thermometerVoltage.StoredMax = 5F;
            this.thermometerVoltage.TabIndex = 32;
            this.thermometerVoltage.TextUnit = "V";
            this.thermometerVoltage.Value = 0F;
            // 
            // slideButtonMode
            // 
            this.slideButtonMode.BackColor = System.Drawing.Color.Transparent;
            this.slideButtonMode.Checked = false;
            this.slideButtonMode.CheckStyleX = DC_POWER.CheckStyle.style3;
            this.slideButtonMode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.slideButtonMode.Location = new System.Drawing.Point(660, 184);
            this.slideButtonMode.Name = "slideButtonMode";
            this.slideButtonMode.Size = new System.Drawing.Size(87, 27);
            this.slideButtonMode.TabIndex = 3;
            this.slideButtonMode.Click += new System.EventHandler(this.slideButtonMode_Click);
            // 
            // labelMode
            // 
            this.labelMode.AutoSize = true;
            this.labelMode.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelMode.Location = new System.Drawing.Point(664, 164);
            this.labelMode.Name = "labelMode";
            this.labelMode.Size = new System.Drawing.Size(79, 19);
            this.labelMode.TabIndex = 30;
            this.labelMode.Text = "Mode: V";
            // 
            // slideButtonOutput
            // 
            this.slideButtonOutput.BackColor = System.Drawing.Color.Transparent;
            this.slideButtonOutput.Checked = false;
            this.slideButtonOutput.CheckStyleX = DC_POWER.CheckStyle.style4;
            this.slideButtonOutput.Cursor = System.Windows.Forms.Cursors.Hand;
            this.slideButtonOutput.Location = new System.Drawing.Point(660, 247);
            this.slideButtonOutput.Name = "slideButtonOutput";
            this.slideButtonOutput.Size = new System.Drawing.Size(87, 27);
            this.slideButtonOutput.TabIndex = 4;
            this.slideButtonOutput.Click += new System.EventHandler(this.slideButtonOutput_Click);
            // 
            // labelOutput
            // 
            this.labelOutput.AutoSize = true;
            this.labelOutput.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelOutput.Location = new System.Drawing.Point(669, 227);
            this.labelOutput.Name = "labelOutput";
            this.labelOutput.Size = new System.Drawing.Size(39, 19);
            this.labelOutput.TabIndex = 28;
            this.labelOutput.Text = "OFF";
            // 
            // knob_Current
            // 
            this.knob_Current.Font = new System.Drawing.Font("SimSun", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.knob_Current.KnobColor = System.Drawing.Color.Blue;
            this.knob_Current.KnobRadius = 40;
            this.knob_Current.Location = new System.Drawing.Point(512, 157);
            this.knob_Current.MarkerColor = System.Drawing.Color.Black;
            this.knob_Current.MarkerWidth = 4;
            this.knob_Current.Maximum = 400;
            this.knob_Current.Name = "knob_Current";
            this.knob_Current.Size = new System.Drawing.Size(113, 117);
            this.knob_Current.TabIndex = 2;
            this.knob_Current.Text = "Current";
            this.knob_Current.TickColor = System.Drawing.Color.Black;
            this.knob_Current.ValueChanged += new System.EventHandler(this.knob_Current_ValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lbDigitalMeter_Voltage_Get);
            this.groupBox1.Controls.Add(this.lbDigitalMeter_Current_Get);
            this.groupBox1.Location = new System.Drawing.Point(81, 237);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox1.Size = new System.Drawing.Size(371, 50);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("SimSun", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(343, 9);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label4.Size = new System.Drawing.Size(34, 35);
            this.label4.TabIndex = 27;
            this.label4.Text = "A";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("SimSun", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(100, 9);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(34, 35);
            this.label2.TabIndex = 7;
            this.label2.Text = "V";
            // 
            // lbDigitalMeter_Voltage_Get
            // 
            this.lbDigitalMeter_Voltage_Get.BackColor = System.Drawing.Color.White;
            this.lbDigitalMeter_Voltage_Get.ForeColor = System.Drawing.Color.Red;
            this.lbDigitalMeter_Voltage_Get.Format = "00.00";
            this.lbDigitalMeter_Voltage_Get.Location = new System.Drawing.Point(6, 9);
            this.lbDigitalMeter_Voltage_Get.Name = "lbDigitalMeter_Voltage_Get";
            this.lbDigitalMeter_Voltage_Get.Renderer = null;
            this.lbDigitalMeter_Voltage_Get.Signed = false;
            this.lbDigitalMeter_Voltage_Get.Size = new System.Drawing.Size(88, 35);
            this.lbDigitalMeter_Voltage_Get.TabIndex = 3;
            this.lbDigitalMeter_Voltage_Get.Value = 0D;
            // 
            // lbDigitalMeter_Current_Get
            // 
            this.lbDigitalMeter_Current_Get.BackColor = System.Drawing.Color.White;
            this.lbDigitalMeter_Current_Get.ForeColor = System.Drawing.Color.Blue;
            this.lbDigitalMeter_Current_Get.Format = "0.000";
            this.lbDigitalMeter_Current_Get.Location = new System.Drawing.Point(252, 9);
            this.lbDigitalMeter_Current_Get.Name = "lbDigitalMeter_Current_Get";
            this.lbDigitalMeter_Current_Get.Renderer = null;
            this.lbDigitalMeter_Current_Get.Signed = false;
            this.lbDigitalMeter_Current_Get.Size = new System.Drawing.Size(88, 35);
            this.lbDigitalMeter_Current_Get.TabIndex = 5;
            this.lbDigitalMeter_Current_Get.Value = 0D;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.lbDigitalMeter_Voltage_Set);
            this.groupBox2.Controls.Add(this.lbDigitalMeter_Current_Set);
            this.groupBox2.Location = new System.Drawing.Point(81, 187);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox2.Size = new System.Drawing.Size(371, 50);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("SimSun", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.DarkBlue;
            this.label3.Location = new System.Drawing.Point(343, 11);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(34, 35);
            this.label3.TabIndex = 26;
            this.label3.Text = "A";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("SimSun", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.DarkRed;
            this.label1.Location = new System.Drawing.Point(100, 11);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(34, 35);
            this.label1.TabIndex = 6;
            this.label1.Text = "V";
            // 
            // lbDigitalMeter_Voltage_Set
            // 
            this.lbDigitalMeter_Voltage_Set.BackColor = System.Drawing.Color.White;
            this.lbDigitalMeter_Voltage_Set.ForeColor = System.Drawing.Color.DarkRed;
            this.lbDigitalMeter_Voltage_Set.Format = "00.00";
            this.lbDigitalMeter_Voltage_Set.Location = new System.Drawing.Point(6, 11);
            this.lbDigitalMeter_Voltage_Set.Name = "lbDigitalMeter_Voltage_Set";
            this.lbDigitalMeter_Voltage_Set.Renderer = null;
            this.lbDigitalMeter_Voltage_Set.Signed = false;
            this.lbDigitalMeter_Voltage_Set.Size = new System.Drawing.Size(88, 35);
            this.lbDigitalMeter_Voltage_Set.TabIndex = 3;
            this.lbDigitalMeter_Voltage_Set.Value = 0D;
            // 
            // lbDigitalMeter_Current_Set
            // 
            this.lbDigitalMeter_Current_Set.BackColor = System.Drawing.Color.White;
            this.lbDigitalMeter_Current_Set.ForeColor = System.Drawing.Color.DarkBlue;
            this.lbDigitalMeter_Current_Set.Format = "0.000";
            this.lbDigitalMeter_Current_Set.Location = new System.Drawing.Point(252, 11);
            this.lbDigitalMeter_Current_Set.Name = "lbDigitalMeter_Current_Set";
            this.lbDigitalMeter_Current_Set.Renderer = null;
            this.lbDigitalMeter_Current_Set.Signed = false;
            this.lbDigitalMeter_Current_Set.Size = new System.Drawing.Size(88, 35);
            this.lbDigitalMeter_Current_Set.TabIndex = 5;
            this.lbDigitalMeter_Current_Set.Value = 0D;
            // 
            // knob_Voltage
            // 
            this.knob_Voltage.Font = new System.Drawing.Font("SimSun", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.knob_Voltage.KnobColor = System.Drawing.Color.Red;
            this.knob_Voltage.KnobRadius = 40;
            this.knob_Voltage.Location = new System.Drawing.Point(512, 18);
            this.knob_Voltage.MarkerColor = System.Drawing.Color.Black;
            this.knob_Voltage.MarkerWidth = 4;
            this.knob_Voltage.Maximum = 300;
            this.knob_Voltage.Name = "knob_Voltage";
            this.knob_Voltage.Size = new System.Drawing.Size(113, 115);
            this.knob_Voltage.TabIndex = 22;
            this.knob_Voltage.Text = "Voltage";
            this.knob_Voltage.TickColor = System.Drawing.Color.Black;
            this.knob_Voltage.ValueChanged += new System.EventHandler(this.knob_Voltage_ValueChanged);
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zedGraphControl1.Location = new System.Drawing.Point(0, 0);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0D;
            this.zedGraphControl1.ScrollMaxX = 0D;
            this.zedGraphControl1.ScrollMaxY = 0D;
            this.zedGraphControl1.ScrollMaxY2 = 0D;
            this.zedGraphControl1.ScrollMinX = 0D;
            this.zedGraphControl1.ScrollMinY = 0D;
            this.zedGraphControl1.ScrollMinY2 = 0D;
            this.zedGraphControl1.Size = new System.Drawing.Size(884, 296);
            this.zedGraphControl1.TabIndex = 8;
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // Mainform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 712);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.ribbon1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Mainform";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DC_POWER";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Mainform_FormClosing);
            this.Load += new System.EventHandler(this.Mainform_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Ribbon ribbon1;
        private System.Windows.Forms.RibbonTab ribbonTab1;
        private System.Windows.Forms.RibbonPanel ribbonPanel1;
        private System.Windows.Forms.RibbonPanel ribbonPanel2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private LBSoft.IndustrialCtrls.Meters.LBDigitalMeter lbDigitalMeter_Voltage_Get;
        private LBSoft.IndustrialCtrls.Meters.LBDigitalMeter lbDigitalMeter_Current_Get;
        private AuSharp.Knob knob_Voltage;
        private ZedGraph.ZedGraphControl zedGraphControl1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private AuSharp.Knob knob_Current;
        private System.Windows.Forms.RibbonComboBox ribbonComboBoxCom1;
        private System.Windows.Forms.RibbonComboBox ribbonComboBoxBaud1;
        private System.Windows.Forms.RibbonButton ribbonButtonOpenCom1;
        private System.Windows.Forms.RibbonLabel ribbonLabelBaud2400;
        private System.Windows.Forms.RibbonLabel ribbonLabelBaud9600;
        private System.Windows.Forms.RibbonLabel ribbonLabelBaud38400;
        private System.Windows.Forms.RibbonLabel ribbonLabelBaud115200;
        private System.Windows.Forms.RibbonSeparator ribbonSeparator1;
        private System.Windows.Forms.RibbonComboBox ribbonComboBoxCom2;
        private System.Windows.Forms.RibbonComboBox ribbonComboBoxBaud2;
        private System.Windows.Forms.RibbonSeparator ribbonSeparator2;
        private System.Windows.Forms.RibbonButton ribbonButtonOpenCom2;
        private System.Windows.Forms.RibbonLabel ribbonLabelBaud2400_2;
        private System.Windows.Forms.RibbonLabel ribbonLabelBaud9600_2;
        private System.Windows.Forms.RibbonLabel ribbonLabelBaud38400_2;
        private System.Windows.Forms.RibbonLabel ribbonLabelBaud115200_2;
        private System.IO.Ports.SerialPort serialPort1;
        private System.IO.Ports.SerialPort serialPort2;
        private System.Windows.Forms.Label labelOutput;
        private SlideButton slideButtonOutput;
        private SlideButton slideButtonMode;
        private System.Windows.Forms.Label labelMode;
        private Manometers.Thermometer thermometerVoltage;
        private Manometers.Thermometer thermometerCurrent;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private LBSoft.IndustrialCtrls.Meters.LBDigitalMeter lbDigitalMeter_Voltage_Set;
        private LBSoft.IndustrialCtrls.Meters.LBDigitalMeter lbDigitalMeter_Current_Set;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private Manometers.Thermometer thermometerTemp;
        private EnhancedGlassButton.GlassButton glassButtonCAL;
        private EnhancedGlassButton.GlassButton glassButtonStepAdd;
        private EnhancedGlassButton.GlassButton glassButtonStepSub;
        
    }
}

