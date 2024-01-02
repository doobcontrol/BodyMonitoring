using com.xiyuansoft.BodyMonitoring.bormodel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace com.xiyuansoft.BodyMonitoring.winform
{
    public partial class FrmEquEdit : Form
    {
        public bool isNew;
        public DataRow EquRow;

        public FrmEquEdit()
        {
            InitializeComponent();

            this.Icon = global::com.xiyuansoft.BodyMonitoring.Properties.Resources.defaultWinIcon;
            this.Text = "设备编辑";

            UIHelper.SetDialogForm(this);
        }

        private void FrmEquEdit_Load(object sender, EventArgs e)
        {
            if (!isNew)
            {
                txtEquID.Text = EquRow[Equ.fEquID].ToString();
                txtEquRoom.Text = EquRow[Equ.fEquRoom].ToString();
            }

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (txtEquRoom.Text.Trim() == "")
            {
                MessageBox.Show("请输入设备安装的房间名！", "保存错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtEquID.Text.Trim().Length != 12)
            {
                MessageBox.Show("请确保输入的设备编码与设备的实际编码一致！", "保存错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            const string PATTERN = @"[A-Fa-f0-9]+$";
            bool bo = System.Text.RegularExpressions.Regex.IsMatch(txtEquID.Text.Trim(), PATTERN);
            if (!bo)
            {
                MessageBox.Show("请确保输入的设备编码与设备的实际编码一致！", "保存错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Hashtable tHt = new Hashtable();
            tHt.Add(Equ.fEquID, txtEquID.Text.Trim());
            tHt.Add(Equ.fEquRoom, txtEquRoom.Text.Trim());

            if (isNew)
            {
                Equ.getnSingInstance().insertMainRecord(tHt);
            }
            else
            {
                Equ.getnSingInstance().updateByPKey(EquRow[Equ.fID].ToString(), tHt);
            }

            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
