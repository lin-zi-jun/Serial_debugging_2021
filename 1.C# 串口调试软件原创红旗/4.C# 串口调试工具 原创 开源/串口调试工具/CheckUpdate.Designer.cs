namespace 串口调试工具
{
    partial class CheckUpdate
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.Cancel_Button = new System.Windows.Forms.Button();
            this.OK_Button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.Title = new System.Windows.Forms.Label();
            this.YES_Button = new System.Windows.Forms.Button();
            this.Percent_Label = new System.Windows.Forms.Label();
            this.NO_Button = new System.Windows.Forms.Button();
            this.XunLeiDownload_LinkLabel = new System.Windows.Forms.LinkLabel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Cancel_Button);
            this.panel1.Controls.Add(this.OK_Button);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.progressBar1);
            this.panel1.Controls.Add(this.Title);
            this.panel1.Controls.Add(this.YES_Button);
            this.panel1.Controls.Add(this.Percent_Label);
            this.panel1.Controls.Add(this.NO_Button);
            this.panel1.Controls.Add(this.XunLeiDownload_LinkLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(356, 262);
            this.panel1.TabIndex = 8;
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.Location = new System.Drawing.Point(287, 236);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(57, 23);
            this.Cancel_Button.TabIndex = 9;
            this.Cancel_Button.Text = "取消";
            this.Cancel_Button.UseVisualStyleBackColor = true;
            this.Cancel_Button.Visible = false;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click_1);
            // 
            // OK_Button
            // 
            this.OK_Button.Location = new System.Drawing.Point(224, 236);
            this.OK_Button.Name = "OK_Button";
            this.OK_Button.Size = new System.Drawing.Size(57, 23);
            this.OK_Button.TabIndex = 8;
            this.OK_Button.Text = "确定";
            this.OK_Button.UseVisualStyleBackColor = true;
            this.OK_Button.Visible = false;
            this.OK_Button.Click += new System.EventHandler(this.OK_Button_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 127);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "正在升级中.......";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 142);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(332, 23);
            this.progressBar1.TabIndex = 2;
            this.progressBar1.Visible = false;
            // 
            // Title
            // 
            this.Title.BackColor = System.Drawing.Color.DodgerBlue;
            this.Title.Dock = System.Windows.Forms.DockStyle.Top;
            this.Title.Font = new System.Drawing.Font("方正兰亭超细黑简体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Title.ForeColor = System.Drawing.Color.White;
            this.Title.Location = new System.Drawing.Point(0, 0);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(356, 103);
            this.Title.TabIndex = 6;
            this.Title.Text = "正在检查最新版本软件...";
            this.Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Title.TextChanged += new System.EventHandler(this.Title_TextChanged);
            // 
            // YES_Button
            // 
            this.YES_Button.Location = new System.Drawing.Point(12, 171);
            this.YES_Button.Name = "YES_Button";
            this.YES_Button.Size = new System.Drawing.Size(57, 23);
            this.YES_Button.TabIndex = 1;
            this.YES_Button.Text = "是";
            this.YES_Button.UseVisualStyleBackColor = true;
            this.YES_Button.Visible = false;
            this.YES_Button.Click += new System.EventHandler(this.YES_Button_Click);
            // 
            // Percent_Label
            // 
            this.Percent_Label.Location = new System.Drawing.Point(315, 168);
            this.Percent_Label.Name = "Percent_Label";
            this.Percent_Label.Size = new System.Drawing.Size(29, 12);
            this.Percent_Label.TabIndex = 3;
            this.Percent_Label.Text = "100%";
            this.Percent_Label.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.Percent_Label.Visible = false;
            // 
            // NO_Button
            // 
            this.NO_Button.Location = new System.Drawing.Point(75, 171);
            this.NO_Button.Name = "NO_Button";
            this.NO_Button.Size = new System.Drawing.Size(57, 23);
            this.NO_Button.TabIndex = 2;
            this.NO_Button.Text = "否";
            this.NO_Button.UseVisualStyleBackColor = true;
            this.NO_Button.Visible = false;
            this.NO_Button.Click += new System.EventHandler(this.NO_Button_Click);
            // 
            // XunLeiDownload_LinkLabel
            // 
            this.XunLeiDownload_LinkLabel.AutoSize = true;
            this.XunLeiDownload_LinkLabel.LinkColor = System.Drawing.Color.Red;
            this.XunLeiDownload_LinkLabel.Location = new System.Drawing.Point(3, 250);
            this.XunLeiDownload_LinkLabel.Name = "XunLeiDownload_LinkLabel";
            this.XunLeiDownload_LinkLabel.Size = new System.Drawing.Size(53, 12);
            this.XunLeiDownload_LinkLabel.TabIndex = 3;
            this.XunLeiDownload_LinkLabel.TabStop = true;
            this.XunLeiDownload_LinkLabel.Text = "迅雷下载";
            this.XunLeiDownload_LinkLabel.Visible = false;
            this.XunLeiDownload_LinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.XunLeiDownload_LinkLabel_LinkClicked);
            // 
            // CheckUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 262);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CheckUpdate";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "软件升级";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CheckUpdate_FormClosing);
            this.Load += new System.EventHandler(this.CheckUpdate_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Button YES_Button;
        private System.Windows.Forms.Label Percent_Label;
        private System.Windows.Forms.Button NO_Button;
        private System.Windows.Forms.LinkLabel XunLeiDownload_LinkLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Cancel_Button;
        private System.Windows.Forms.Button OK_Button;

    }
}