using com.xiyuansoft.BodyMonitoring.bormodel;
using com.xiyuansoft.bormodel.commdata;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace com.xiyuansoft.BodyMonitoring.winform
{
    public partial class FrmPersonnelEdit : Form
    {
        public bool isNew = true;

        public DataRow theArea;
        public DataRow thePolice;
        public DataRow thePersonnel;

        public FrmPersonnelEdit()
        {
            InitializeComponent();
            this.Icon = global::com.xiyuansoft.BodyMonitoring.Properties.Resources.defaultWinIcon;

            this.Text = "被监测对象人员编辑";

            UIHelper.SetDialogForm(this);
        }

        private void FrmPersonnelEdit_Load(object sender, EventArgs e)
        {
            DateTime nowDate = DateTime.Now;
            dtpPersonnelBirth.Value = nowDate;

            DataTable sexTb = CommList.getnSingInstance().selectChildByParent(CommListType.ID_SEX);
            showDtToComb(cmbPersonnelSex, sexTb, CommList.fName);

            lblArea.Text = "所属监区：" + theArea[Area.fAreaName].ToString();
            lblPolice.Text = "责任干警：" + thePolice[Police.fPoliceName].ToString();
            if (!isNew)
            {
                txtPersonnelName.Text = thePersonnel[Personnel.fPersonnelName].ToString();
                txtPersonnelCode.Text = thePersonnel[Personnel.fPersonnelCode].ToString();
                selectItemofCombByRowID(cmbPersonnelSex, CommList.fID, thePersonnel[Personnel.fPersonnelSex].ToString());
                dtpPersonnelBirth.Value = DateTime.Parse(thePersonnel[Personnel.fPersonnelBirth].ToString());

                if (thePersonnel[Personnel.fPersonnelPhoto].ToString() != ""
                    && File.Exists(thePersonnel[Personnel.fPersonnelPhoto].ToString())
                    )
                {
                    pictureBox1.Image = UIHelper.LoadBitmapUnlocked(thePersonnel[Personnel.fPersonnelPhoto].ToString());
                    pictureBox1.Tag = thePersonnel[Personnel.fPersonnelPhoto].ToString();
                }
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if(
                txtPersonnelName.Text.Trim()=="" 
                || txtPersonnelCode.Text.Trim()==""
                || cmbPersonnelSex.SelectedItem==null
                )
            {
                MessageBox.Show("信息不完整","保存错误",MessageBoxButtons.OK,MessageBoxIcon.Error);

                return;
            }

            Hashtable tHt = new Hashtable();
            if (isNew)
            {
                string tDir = "photo";
                if (pictureBox1.Tag != null)
                {
                    string oDir = pictureBox1.Tag as string;
                    if (!Directory.Exists(tDir))
                    {
                        Directory.CreateDirectory(tDir);
                    }
                    tDir = tDir + "\\" + System.Guid.NewGuid().ToString("N");
                    File.Copy(oDir, tDir);
                    tHt.Add(Personnel.fPersonnelPhoto, tDir);
                }
                tHt.Add(Personnel.fArea, theArea[Area.fID].ToString());
                tHt.Add(Personnel.fAreaName, theArea[Area.fAreaName].ToString());
                tHt.Add(Personnel.fPolice, thePolice[Police.fID].ToString());
                tHt.Add(Personnel.fPoliceName, thePolice[Police.fPoliceName].ToString());
                tHt.Add(Personnel.fPersonnelName, txtPersonnelName.Text.Trim());
                tHt.Add(Personnel.fPersonnelCode, txtPersonnelCode.Text.Trim());
                tHt.Add(Personnel.fPersonnelSex, (cmbPersonnelSex.SelectedValue as DataRow)[CommList.fID].ToString());
                tHt.Add(Personnel.fPersonnelBirth, dtpPersonnelBirth.Value.ToString("yyyy-MM-dd"));


                Personnel.getnSingInstance().insertMainRecord(tHt);

            }
            else
            {
                string tDir = "photo";
                
                if (pictureBox1.Tag != null)
                {
                    string oDir = pictureBox1.Tag as string;

                    if (thePersonnel[Personnel.fPersonnelPhoto].ToString() == "")
                    {
                        if (!Directory.Exists(tDir))
                        {
                            Directory.CreateDirectory(tDir);
                        }
                        tDir = tDir + "\\" + System.Guid.NewGuid().ToString("N");
                        tHt.Add(Personnel.fPersonnelPhoto, tDir);
                    }
                    else
                    {
                        tDir = thePersonnel[Personnel.fPersonnelPhoto].ToString();
                    }

                    if (oDir != tDir)
                    {
                        File.Copy(oDir, tDir, true);
                    }
                }

                tHt.Add(Personnel.fPersonnelName, txtPersonnelName.Text.Trim());
                tHt.Add(Personnel.fPersonnelCode, txtPersonnelCode.Text.Trim());
                tHt.Add(Personnel.fPersonnelSex, (cmbPersonnelSex.SelectedValue as DataRow)[CommList.fID].ToString());
                tHt.Add(Personnel.fPersonnelBirth, dtpPersonnelBirth.Value.ToString("yyyy-MM-dd"));

                Personnel.getnSingInstance().updateByPKey(thePersonnel[Personnel.fID].ToString(), tHt);
            }

            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnSelectPhoto_Click(object sender, EventArgs e)
        {
            string defaultDir = System.IO.Directory.GetCurrentDirectory() + "\\";
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter =  
                "All Image Files|*.bmp;*.ico;*.gif;*.jpeg;*.jpg;*.png;*.tif;*.tiff|"
                + "Windows Bitmap(*.bmp)|*.bmp|"
                + "Windows Icon(*.ico)|*.ico|"
                + "Graphics Interchange Format (*.gif)|(*.gif)|"
                + "JPEG File Interchange Format (*.jpg)|*.jpg;*.jpeg|"
                + "Portable Network Graphics (*.png)|*.png|"
                + "Tag Image File Format (*.tif)|*.tif;*.tiff";
            ofd.DefaultExt = "JPEG File Interchange Format (*.jpg)|*.jpg;*.jpeg|";
            //ofd.InitialDirectory = defaultDir;
            ofd.ValidateNames = true;
            ofd.CheckPathExists = true;
            ofd.CheckFileExists = true;

            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                pictureBox1.Image = UIHelper.LoadBitmapUnlocked(ofd.FileName);
                pictureBox1.Tag = ofd.FileName;
            }
        }


        private void showDtToComb(ComboBox Cb, DataTable ShowDt, string DisplayField)
        {
            System.Collections.ArrayList forDataList = new System.Collections.ArrayList();
            foreach (DataRow ShowDr in ShowDt.Rows)
            {
                forDataList.Add(new System.Collections.DictionaryEntry(
                    ShowDr,
                    ShowDr[DisplayField].ToString())
                    );
            }

            Cb.DataSource = forDataList;
            Cb.DisplayMember = "Value";
            Cb.ValueMember = "Key";

            Cb.SelectedIndex = 0;
        }
        private void selectItemofCombByRowID(ComboBox Cb, string pField, string rowID)
        {
            foreach (DictionaryEntry de in Cb.Items)
            {
                if ((de.Key as DataRow)[pField].ToString() == rowID)
                {
                    Cb.SelectedItem = de;
                    break;
                }
            }
        }

    }
}
