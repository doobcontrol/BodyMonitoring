using com.xiyuansoft.BodyMonitoring.bormodel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace com.xiyuansoft.BodyMonitoring.winform
{
    public partial class FrmEditPassword : Form
    {
        public FrmEditPassword()
        {
            InitializeComponent();

            this.statusStrip1.SizingGrip = false;
            toolStripStatusLabel1.Text = "";

            this.Text = "修改当前登陆用户的密码";

            UIHelper.SetDialogForm(this);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (UIHelper.userRecordDic[User.fLoginPass].ToString() != txtOldPassword.Text)
                {
                    MessageBox.Show
                        ("旧密码不正确", "保存错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (txtNewPassword1.Text != txtNewPassword2.Text)
                {
                    MessageBox.Show
                        ("新密码输入不一至", "保存错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                disableUI("正在保存……");
                User.getnSingInstance().EditPassword(
                    UIHelper.userRecordDic[User.fID].ToString(),
                    txtNewPassword1.Text);
                UIHelper.userRecordDic[User.fLoginPass] = txtNewPassword1.Text;
                disableUI("保存成功");
                DialogResult = DialogResult.OK;
            }
            catch (ApplicationException Ae)
            {
                MessageBox.Show
                    (Ae.Message, "保存错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void disableUI(string info)
        {
            pnlWork.Enabled = false;
            toolStripStatusLabel1.Text = info;
        }
        private void enabledUI(string info)
        {
            pnlWork.Enabled = true;
            toolStripStatusLabel1.Text = info;
        }
    }
}
