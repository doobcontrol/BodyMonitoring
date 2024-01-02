namespace com.xiyuansoft.BodyMonitoring.winform
{
    partial class FrmParset
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbComParity = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbComStop = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbComData = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbComBaud = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbComPort = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.nudBreatheMin = new System.Windows.Forms.NumericUpDown();
            this.nudBreatheMax = new System.Windows.Forms.NumericUpDown();
            this.nudHeartRateMin = new System.Windows.Forms.NumericUpDown();
            this.nudHeartRateMax = new System.Windows.Forms.NumericUpDown();
            this.ckbWarningOpen = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.nudModeBreath = new System.Windows.Forms.NumericUpDown();
            this.nudModeHartrate = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBreatheMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBreatheMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeartRateMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeartRateMax)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudModeBreath)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudModeHartrate)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cmbComParity);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cmbComStop);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmbComData);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbComBaud);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbComPort);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(261, 153);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "串口设置";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "较验位：";
            // 
            // cmbComParity
            // 
            this.cmbComParity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbComParity.FormattingEnabled = true;
            this.cmbComParity.Location = new System.Drawing.Point(68, 124);
            this.cmbComParity.Name = "cmbComParity";
            this.cmbComParity.Size = new System.Drawing.Size(122, 20);
            this.cmbComParity.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "停止位：";
            // 
            // cmbComStop
            // 
            this.cmbComStop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbComStop.FormattingEnabled = true;
            this.cmbComStop.Location = new System.Drawing.Point(68, 98);
            this.cmbComStop.Name = "cmbComStop";
            this.cmbComStop.Size = new System.Drawing.Size(122, 20);
            this.cmbComStop.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "数据位：";
            // 
            // cmbComData
            // 
            this.cmbComData.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbComData.FormattingEnabled = true;
            this.cmbComData.Location = new System.Drawing.Point(68, 72);
            this.cmbComData.Name = "cmbComData";
            this.cmbComData.Size = new System.Drawing.Size(122, 20);
            this.cmbComData.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "波特率：";
            // 
            // cmbComBaud
            // 
            this.cmbComBaud.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbComBaud.FormattingEnabled = true;
            this.cmbComBaud.Location = new System.Drawing.Point(68, 46);
            this.cmbComBaud.Name = "cmbComBaud";
            this.cmbComBaud.Size = new System.Drawing.Size(122, 20);
            this.cmbComBaud.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "串口号：";
            // 
            // cmbComPort
            // 
            this.cmbComPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbComPort.FormattingEnabled = true;
            this.cmbComPort.Location = new System.Drawing.Point(68, 20);
            this.cmbComPort.Name = "cmbComPort";
            this.cmbComPort.Size = new System.Drawing.Size(122, 20);
            this.cmbComPort.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.nudBreatheMin);
            this.groupBox2.Controls.Add(this.nudBreatheMax);
            this.groupBox2.Controls.Add(this.nudHeartRateMin);
            this.groupBox2.Controls.Add(this.nudHeartRateMax);
            this.groupBox2.Controls.Add(this.ckbWarningOpen);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(279, 17);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(261, 148);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "心率和呼吸预警值";
            // 
            // nudBreatheMin
            // 
            this.nudBreatheMin.Location = new System.Drawing.Point(89, 99);
            this.nudBreatheMin.Name = "nudBreatheMin";
            this.nudBreatheMin.Size = new System.Drawing.Size(120, 21);
            this.nudBreatheMin.TabIndex = 20;
            // 
            // nudBreatheMax
            // 
            this.nudBreatheMax.Location = new System.Drawing.Point(89, 73);
            this.nudBreatheMax.Name = "nudBreatheMax";
            this.nudBreatheMax.Size = new System.Drawing.Size(120, 21);
            this.nudBreatheMax.TabIndex = 19;
            // 
            // nudHeartRateMin
            // 
            this.nudHeartRateMin.Location = new System.Drawing.Point(89, 50);
            this.nudHeartRateMin.Name = "nudHeartRateMin";
            this.nudHeartRateMin.Size = new System.Drawing.Size(120, 21);
            this.nudHeartRateMin.TabIndex = 18;
            // 
            // nudHeartRateMax
            // 
            this.nudHeartRateMax.Location = new System.Drawing.Point(89, 23);
            this.nudHeartRateMax.Name = "nudHeartRateMax";
            this.nudHeartRateMax.Size = new System.Drawing.Size(120, 21);
            this.nudHeartRateMax.TabIndex = 14;
            // 
            // ckbWarningOpen
            // 
            this.ckbWarningOpen.AutoSize = true;
            this.ckbWarningOpen.Location = new System.Drawing.Point(68, 126);
            this.ckbWarningOpen.Name = "ckbWarningOpen";
            this.ckbWarningOpen.Size = new System.Drawing.Size(72, 16);
            this.ckbWarningOpen.TabIndex = 2;
            this.ckbWarningOpen.Text = "预警开启";
            this.ckbWarningOpen.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 103);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 12);
            this.label9.TabIndex = 17;
            this.label9.Text = "呼吸最低值：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 77);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 12);
            this.label8.TabIndex = 15;
            this.label8.Text = "呼吸最高值：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 51);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 12);
            this.label7.TabIndex = 13;
            this.label7.Text = "心率最低值：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 12);
            this.label6.TabIndex = 11;
            this.label6.Text = "心率最高值：";
            // 
            // btnCancel
            // 
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(381, 258);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "退出";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOk.Location = new System.Drawing.Point(462, 258);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 12;
            this.btnOk.Text = "保存";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.nudModeBreath);
            this.groupBox3.Controls.Add(this.nudModeHartrate);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Location = new System.Drawing.Point(12, 171);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(261, 74);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "情绪波动值";
            // 
            // nudModeBreath
            // 
            this.nudModeBreath.Location = new System.Drawing.Point(89, 42);
            this.nudModeBreath.Name = "nudModeBreath";
            this.nudModeBreath.Size = new System.Drawing.Size(120, 21);
            this.nudModeBreath.TabIndex = 23;
            // 
            // nudModeHartrate
            // 
            this.nudModeHartrate.Location = new System.Drawing.Point(89, 15);
            this.nudModeHartrate.Name = "nudModeHartrate";
            this.nudModeHartrate.Size = new System.Drawing.Size(120, 21);
            this.nudModeHartrate.TabIndex = 21;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 46);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 12);
            this.label10.TabIndex = 22;
            this.label10.Text = "呼吸：";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 17);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 12);
            this.label11.TabIndex = 20;
            this.label11.Text = "心率：";
            // 
            // FrmParset
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 289);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmParset";
            this.Text = "FrmParset";
            this.Load += new System.EventHandler(this.FrmParset_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBreatheMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBreatheMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeartRateMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeartRateMax)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudModeBreath)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudModeHartrate)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbComPort;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbComParity;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbComStop;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbComData;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbComBaud;
        private System.Windows.Forms.CheckBox ckbWarningOpen;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.NumericUpDown nudBreatheMin;
        private System.Windows.Forms.NumericUpDown nudBreatheMax;
        private System.Windows.Forms.NumericUpDown nudHeartRateMin;
        private System.Windows.Forms.NumericUpDown nudHeartRateMax;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.NumericUpDown nudModeBreath;
        private System.Windows.Forms.NumericUpDown nudModeHartrate;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;

    }
}