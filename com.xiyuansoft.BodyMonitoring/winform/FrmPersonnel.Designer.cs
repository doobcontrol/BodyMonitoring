namespace com.xiyuansoft.BodyMonitoring.winform
{
    partial class FrmPersonnel
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.tsbNewPolice = new System.Windows.Forms.ToolStripButton();
            this.tsbEditPolice = new System.Windows.Forms.ToolStripButton();
            this.tsbDelPolice = new System.Windows.Forms.ToolStripButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbNewPersonnel = new System.Windows.Forms.ToolStripButton();
            this.tsbEditPersonnel = new System.Windows.Forms.ToolStripButton();
            this.tsbDelPersonnel = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmiSelect = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 379);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(751, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            this.splitContainer1.Panel1.Controls.Add(this.toolStrip2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer1.Panel2.Controls.Add(this.toolStrip1);
            this.splitContainer1.Size = new System.Drawing.Size(751, 354);
            this.splitContainer1.SplitterDistance = 274;
            this.splitContainer1.TabIndex = 2;
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(55, 102);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(121, 97);
            this.treeView1.TabIndex = 1;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNewPolice,
            this.tsbEditPolice,
            this.tsbDelPolice});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(274, 25);
            this.toolStrip2.TabIndex = 2;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // tsbNewPolice
            // 
            this.tsbNewPolice.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbNewPolice.Image = global::com.xiyuansoft.BodyMonitoring.Properties.Resources.File_New_icon;
            this.tsbNewPolice.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNewPolice.Name = "tsbNewPolice";
            this.tsbNewPolice.Size = new System.Drawing.Size(23, 22);
            this.tsbNewPolice.Text = "toolStripButton1";
            this.tsbNewPolice.ToolTipText = "选择\'监区列表\'新增监区，选择具体监区新增所属干警";
            this.tsbNewPolice.Click += new System.EventHandler(this.tsbNewPolice_Click);
            // 
            // tsbEditPolice
            // 
            this.tsbEditPolice.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbEditPolice.Image = global::com.xiyuansoft.BodyMonitoring.Properties.Resources.EditInformationHS;
            this.tsbEditPolice.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEditPolice.Name = "tsbEditPolice";
            this.tsbEditPolice.Size = new System.Drawing.Size(23, 22);
            this.tsbEditPolice.Text = "toolStripButton2";
            this.tsbEditPolice.ToolTipText = "修改选定的节点";
            this.tsbEditPolice.Click += new System.EventHandler(this.tsbEditPolice_Click);
            // 
            // tsbDelPolice
            // 
            this.tsbDelPolice.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbDelPolice.Image = global::com.xiyuansoft.BodyMonitoring.Properties.Resources.delete_icon;
            this.tsbDelPolice.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDelPolice.Name = "tsbDelPolice";
            this.tsbDelPolice.Size = new System.Drawing.Size(23, 22);
            this.tsbDelPolice.Text = "toolStripButton3";
            this.tsbDelPolice.ToolTipText = "删除选定的节点";
            this.tsbDelPolice.Click += new System.EventHandler(this.tsbDelPolice_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(76, 102);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(240, 150);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNewPersonnel,
            this.tsbEditPersonnel,
            this.tsbDelPersonnel});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(473, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbNewPersonnel
            // 
            this.tsbNewPersonnel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbNewPersonnel.Image = global::com.xiyuansoft.BodyMonitoring.Properties.Resources.File_New_icon;
            this.tsbNewPersonnel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNewPersonnel.Name = "tsbNewPersonnel";
            this.tsbNewPersonnel.Size = new System.Drawing.Size(23, 22);
            this.tsbNewPersonnel.Text = "toolStripButton1";
            this.tsbNewPersonnel.ToolTipText = "新增当前选择的干警所负责的被监测对象人员";
            this.tsbNewPersonnel.Click += new System.EventHandler(this.tsbNewPersonnel_Click);
            // 
            // tsbEditPersonnel
            // 
            this.tsbEditPersonnel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbEditPersonnel.Image = global::com.xiyuansoft.BodyMonitoring.Properties.Resources.EditInformationHS;
            this.tsbEditPersonnel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEditPersonnel.Name = "tsbEditPersonnel";
            this.tsbEditPersonnel.Size = new System.Drawing.Size(23, 22);
            this.tsbEditPersonnel.Text = "toolStripButton2";
            this.tsbEditPersonnel.ToolTipText = "修改人员信息";
            this.tsbEditPersonnel.Click += new System.EventHandler(this.tsbEditPersonnel_Click);
            // 
            // tsbDelPersonnel
            // 
            this.tsbDelPersonnel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbDelPersonnel.Image = global::com.xiyuansoft.BodyMonitoring.Properties.Resources.delete_icon;
            this.tsbDelPersonnel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDelPersonnel.Name = "tsbDelPersonnel";
            this.tsbDelPersonnel.Size = new System.Drawing.Size(23, 22);
            this.tsbDelPersonnel.Text = "toolStripButton3";
            this.tsbDelPersonnel.ToolTipText = "删除人员";
            this.tsbDelPersonnel.Click += new System.EventHandler(this.tsbDelPersonnel_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSelect,
            this.tsmiExit});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(751, 25);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmiSelect
            // 
            this.tsmiSelect.Enabled = false;
            this.tsmiSelect.Name = "tsmiSelect";
            this.tsmiSelect.Size = new System.Drawing.Size(44, 21);
            this.tsmiSelect.Text = "选择";
            this.tsmiSelect.Visible = false;
            this.tsmiSelect.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // tsmiExit
            // 
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.Size = new System.Drawing.Size(44, 21);
            this.tsmiExit.Text = "退出";
            this.tsmiExit.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // FrmPersonnel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 401);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "FrmPersonnel";
            this.Text = "FrmPersonnel";
            this.Load += new System.EventHandler(this.FrmPersonnel_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton tsbNewPolice;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ToolStripButton tsbEditPolice;
        private System.Windows.Forms.ToolStripButton tsbDelPolice;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripButton tsbNewPersonnel;
        private System.Windows.Forms.ToolStripButton tsbEditPersonnel;
        private System.Windows.Forms.ToolStripButton tsbDelPersonnel;
        private System.Windows.Forms.ToolStripMenuItem tsmiSelect;
        private System.Windows.Forms.ToolStripMenuItem tsmiExit;
    }
}