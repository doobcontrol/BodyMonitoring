namespace com.xiyuansoft.BodyMonitoring.winform
{
    partial class FrmPersonnelEdit
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPersonnelName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbPersonnelSex = new System.Windows.Forms.ComboBox();
            this.txtPersonnelCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpPersonnelBirth = new System.Windows.Forms.DateTimePicker();
            this.lblArea = new System.Windows.Forms.Label();
            this.lblPolice = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnSelectPhoto = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(232, 319);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOk.Location = new System.Drawing.Point(313, 319);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 16;
            this.btnOk.Text = "保存";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 18;
            this.label1.Text = "姓名：";
            // 
            // txtPersonnelName
            // 
            this.txtPersonnelName.Location = new System.Drawing.Point(59, 55);
            this.txtPersonnelName.Name = "txtPersonnelName";
            this.txtPersonnelName.Size = new System.Drawing.Size(100, 21);
            this.txtPersonnelName.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(190, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 20;
            this.label2.Text = "性别：";
            // 
            // cmbPersonnelSex
            // 
            this.cmbPersonnelSex.FormattingEnabled = true;
            this.cmbPersonnelSex.Location = new System.Drawing.Point(267, 55);
            this.cmbPersonnelSex.Name = "cmbPersonnelSex";
            this.cmbPersonnelSex.Size = new System.Drawing.Size(121, 20);
            this.cmbPersonnelSex.TabIndex = 21;
            // 
            // txtPersonnelCode
            // 
            this.txtPersonnelCode.Location = new System.Drawing.Point(59, 82);
            this.txtPersonnelCode.Name = "txtPersonnelCode";
            this.txtPersonnelCode.Size = new System.Drawing.Size(100, 21);
            this.txtPersonnelCode.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 22;
            this.label3.Text = "编码：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(190, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 12);
            this.label4.TabIndex = 24;
            this.label4.Text = "出生日期 ：";
            // 
            // dtpPersonnelBirth
            // 
            this.dtpPersonnelBirth.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpPersonnelBirth.Location = new System.Drawing.Point(267, 82);
            this.dtpPersonnelBirth.Name = "dtpPersonnelBirth";
            this.dtpPersonnelBirth.Size = new System.Drawing.Size(121, 21);
            this.dtpPersonnelBirth.TabIndex = 25;
            // 
            // lblArea
            // 
            this.lblArea.AutoSize = true;
            this.lblArea.Location = new System.Drawing.Point(11, 9);
            this.lblArea.Name = "lblArea";
            this.lblArea.Size = new System.Drawing.Size(65, 12);
            this.lblArea.TabIndex = 26;
            this.lblArea.Text = "所属监区：";
            // 
            // lblPolice
            // 
            this.lblPolice.AutoSize = true;
            this.lblPolice.Location = new System.Drawing.Point(12, 30);
            this.lblPolice.Name = "lblPolice";
            this.lblPolice.Size = new System.Drawing.Size(65, 12);
            this.lblPolice.TabIndex = 27;
            this.lblPolice.Text = "责任干警：";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::com.xiyuansoft.BodyMonitoring.Properties.Resources.defaultphoto;
            this.pictureBox1.Location = new System.Drawing.Point(14, 128);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(196, 214);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 28;
            this.pictureBox1.TabStop = false;
            // 
            // btnSelectPhoto
            // 
            this.btnSelectPhoto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelectPhoto.Location = new System.Drawing.Point(232, 128);
            this.btnSelectPhoto.Name = "btnSelectPhoto";
            this.btnSelectPhoto.Size = new System.Drawing.Size(75, 23);
            this.btnSelectPhoto.TabIndex = 29;
            this.btnSelectPhoto.Text = "选择照片";
            this.btnSelectPhoto.UseVisualStyleBackColor = true;
            this.btnSelectPhoto.Click += new System.EventHandler(this.btnSelectPhoto_Click);
            // 
            // FrmPersonnelEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 354);
            this.Controls.Add(this.btnSelectPhoto);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblPolice);
            this.Controls.Add(this.lblArea);
            this.Controls.Add(this.dtpPersonnelBirth);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPersonnelCode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbPersonnelSex);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPersonnelName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Name = "FrmPersonnelEdit";
            this.Text = "FrmPersonnelEdit";
            this.Load += new System.EventHandler(this.FrmPersonnelEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPersonnelName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbPersonnelSex;
        private System.Windows.Forms.TextBox txtPersonnelCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpPersonnelBirth;
        private System.Windows.Forms.Label lblArea;
        private System.Windows.Forms.Label lblPolice;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnSelectPhoto;
    }
}