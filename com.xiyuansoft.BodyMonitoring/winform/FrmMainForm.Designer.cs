namespace com.xiyuansoft.BodyMonitoring.winform
{
    partial class FrmMainForm
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.PersonnelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EquSetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.用户ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ParsetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查询统计ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.monitorDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.StarttoolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.StoptoolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 301);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(665, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(164, 17);
            this.toolStripStatusLabel1.Text = "封闭式房间单人生命监测系统";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PersonnelToolStripMenuItem,
            this.EquSetToolStripMenuItem,
            this.用户ToolStripMenuItem,
            this.查询统计ToolStripMenuItem,
            this.ExitToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(665, 25);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // PersonnelToolStripMenuItem
            // 
            this.PersonnelToolStripMenuItem.Name = "PersonnelToolStripMenuItem";
            this.PersonnelToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.PersonnelToolStripMenuItem.Text = "人员管理";
            this.PersonnelToolStripMenuItem.Click += new System.EventHandler(this.PersonnelToolStripMenuItem_Click);
            // 
            // EquSetToolStripMenuItem
            // 
            this.EquSetToolStripMenuItem.Name = "EquSetToolStripMenuItem";
            this.EquSetToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.EquSetToolStripMenuItem.Text = "设备管理";
            this.EquSetToolStripMenuItem.Click += new System.EventHandler(this.EquSetToolStripMenuItem_Click);
            // 
            // 用户ToolStripMenuItem
            // 
            this.用户ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PasswordToolStripMenuItem,
            this.UserToolStripMenuItem,
            this.ParsetToolStripMenuItem});
            this.用户ToolStripMenuItem.Name = "用户ToolStripMenuItem";
            this.用户ToolStripMenuItem.ShowShortcutKeys = false;
            this.用户ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.用户ToolStripMenuItem.Text = "系统管理";
            // 
            // PasswordToolStripMenuItem
            // 
            this.PasswordToolStripMenuItem.Name = "PasswordToolStripMenuItem";
            this.PasswordToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.PasswordToolStripMenuItem.Text = "修改密码";
            this.PasswordToolStripMenuItem.Visible = false;
            // 
            // UserToolStripMenuItem
            // 
            this.UserToolStripMenuItem.Name = "UserToolStripMenuItem";
            this.UserToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.UserToolStripMenuItem.Text = "用户管理";
            this.UserToolStripMenuItem.Visible = false;
            // 
            // ParsetToolStripMenuItem
            // 
            this.ParsetToolStripMenuItem.Name = "ParsetToolStripMenuItem";
            this.ParsetToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.ParsetToolStripMenuItem.Text = "参数设置";
            this.ParsetToolStripMenuItem.Click += new System.EventHandler(this.ParsetToolStripMenuItem_Click);
            // 
            // 查询统计ToolStripMenuItem
            // 
            this.查询统计ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.monitorDataToolStripMenuItem});
            this.查询统计ToolStripMenuItem.Name = "查询统计ToolStripMenuItem";
            this.查询统计ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.查询统计ToolStripMenuItem.Text = "查询统计";
            // 
            // monitorDataToolStripMenuItem
            // 
            this.monitorDataToolStripMenuItem.Name = "monitorDataToolStripMenuItem";
            this.monitorDataToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.monitorDataToolStripMenuItem.Text = "监测数据";
            this.monitorDataToolStripMenuItem.Click += new System.EventHandler(this.monitorDataToolStripMenuItem_Click);
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.ExitToolStripMenuItem.Text = "退出";
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StarttoolStripButton1,
            this.StoptoolStripButton2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 25);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(665, 25);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // StarttoolStripButton1
            // 
            this.StarttoolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.StarttoolStripButton1.Image = global::com.xiyuansoft.BodyMonitoring.Properties.Resources.PlayHS;
            this.StarttoolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.StarttoolStripButton1.Name = "StarttoolStripButton1";
            this.StarttoolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.StarttoolStripButton1.Text = "toolStripButton1";
            this.StarttoolStripButton1.Click += new System.EventHandler(this.StarttoolStripButton1_Click);
            // 
            // StoptoolStripButton2
            // 
            this.StoptoolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.StoptoolStripButton2.Image = global::com.xiyuansoft.BodyMonitoring.Properties.Resources.StopHS;
            this.StoptoolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.StoptoolStripButton2.Name = "StoptoolStripButton2";
            this.StoptoolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.StoptoolStripButton2.Text = "toolStripButton2";
            this.StoptoolStripButton2.Click += new System.EventHandler(this.StoptoolStripButton2_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoScroll = true;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(22, 66);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(463, 106);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // timer1
            // 
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FrmMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(665, 323);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "FrmMainForm";
            this.Text = "FrmMainForm";
            this.Load += new System.EventHandler(this.FrmMainForm_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 用户ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PasswordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem UserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ParsetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PersonnelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EquSetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查询统计ToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton StarttoolStripButton1;
        private System.Windows.Forms.ToolStripButton StoptoolStripButton2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStripMenuItem monitorDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Timer timer1;
    }
}