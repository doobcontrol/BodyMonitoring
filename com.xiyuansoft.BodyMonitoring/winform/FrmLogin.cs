using com.xiyuansoft.BodyMonitoring.bormodel;
using com.xiyuansoft.bormodel.commdata;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace com.xiyuansoft.BodyMonitoring.winform
{
    public partial class FrmLogin : Form
    {
        public static DataRow loginedUserRow;

        public FrmLogin()
        {
            InitializeComponent();

            this.Icon = global::com.xiyuansoft.BodyMonitoring.Properties.Resources.defaultWinIcon;
            this.Text = "登陆系统";

            UIHelper.SetDialogForm(this);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ShowInTaskbar = true;
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            UIHelper.loadComboBoxlistFromDatatable(
                cmbUserName,
                User.getnSingInstance().selectAll(),
                User.fUserName
                );

            UIHelper.selectItemofCombByRowID(cmbUserName, User.fID, "admin");
        }

        private void FrmLogin_Shown(object sender, EventArgs e)
        {
            txtLoginPass.Focus();

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                string loginname = (cmbUserName.SelectedValue as DataRow)[User.fLoginName].ToString();
                loginedUserRow = User.getnSingInstance().Login(loginname, txtLoginPass.Text);

                //loginedUserRow = User.getnSingInstance().Login(txtLoginName.Text, txtLoginPass.Text);
                DialogResult = DialogResult.OK;
            }
            catch (ApplicationException Ae)
            {
                MessageBox.Show
                    (Ae.Message, "登陆错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void cmbUserName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbUserName.SelectedValue != null)
            {
                btnOk.Enabled = true;
            }
            else
            {
                btnOk.Enabled = false;
            }
        }
    }
}
