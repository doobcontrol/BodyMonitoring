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
    public partial class FrmAreaPliceEdit : Form
    {
        public bool isNew = true;
        public bool isArea = true;

        public DataRow theArea;
        public DataRow thePolice;

        public FrmAreaPliceEdit()
        {
            InitializeComponent();
            this.Icon = global::com.xiyuansoft.BodyMonitoring.Properties.Resources.defaultWinIcon;

            UIHelper.SetDialogForm(this);
        }

        private void FrmAreaPliceEdit_Load(object sender, EventArgs e)
        {
            if (isArea)
            {
                this.Text = "监区编辑";
                label1.Text = "监区名称：";
                if (!isNew)
                {
                    txtOjbName.Text = theArea[Area.fAreaName].ToString();
                }
            }
            else
            {
                this.Text = "干警编辑";
                label1.Text = "干警姓名：";
                if (!isNew)
                {
                    txtOjbName.Text = thePolice[Police.fPoliceName].ToString();
                }
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (txtOjbName.Text.Trim() == "")
            {
                return;
            }

            Hashtable tHt = new Hashtable();
            string newID;
            if (isArea)
            {
                tHt.Add(Area.fAreaName, txtOjbName.Text);
                if (isNew)
                {
                    newID = Area.getnSingInstance().insertMainRecord(tHt);
                    theArea = Area.getnSingInstance().fullSelectByID(newID).Rows[0];
                }
                else
                {
                    newID = theArea[Area.fID].ToString();
                    Area.getnSingInstance().updateByPKey(newID, tHt);
                    theArea = Area.getnSingInstance().fullSelectByID(newID).Rows[0];
                }
            }
            else
            {
                tHt.Add(Police.fPoliceName, txtOjbName.Text);
                if (isNew)
                {
                    tHt.Add(Police.fArea, theArea[Area.fID].ToString());
                    newID = Police.getnSingInstance().insertMainRecord(tHt);
                    thePolice = Police.getnSingInstance().fullSelectByID(newID).Rows[0];
                }
                else
                {
                    newID = thePolice[Police.fID].ToString();
                    Police.getnSingInstance().updateByPKey(newID, tHt);
                    thePolice = Police.getnSingInstance().fullSelectByID(newID).Rows[0];
                }
            }
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
