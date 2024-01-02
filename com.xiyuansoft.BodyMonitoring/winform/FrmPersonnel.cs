using com.xiyuansoft.BodyMonitoring.bormodel;
using com.xiyuansoft.bormodel.commdata;
using System;
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
    public partial class FrmPersonnel : Form
    {
        public bool canSelect = false;
        public DataRow thePersonnel;

        public FrmPersonnel()
        {
            InitializeComponent();
            this.Icon = global::com.xiyuansoft.BodyMonitoring.Properties.Resources.defaultWinIcon;
            this.Text = "测试对象人员管理";

            UIHelper.SetDialogForm(this);

            treeView1.Dock = DockStyle.Fill;
            dataGridView1.Dock = DockStyle.Fill;
        }

        private void FrmPersonnel_Load(object sender, EventArgs e)
        {
            if (canSelect)
            {
                tsmiSelect.Visible = true;
            }

            //根据登陆人员是否能编辑显示编辑条



            UIHelper.ShowPoliceTree(treeView1);
            treeView1.ExpandAll();
        }

        private void tsbNewPolice_Click(object sender, EventArgs e)
        {
            FrmAreaPliceEdit fape = new FrmAreaPliceEdit();
            fape.isNew = true;
            if (treeView1.SelectedNode.Level == 0)
            {
                fape.isArea= true;
            }
            else if (treeView1.SelectedNode.Level == 1)
            {
                fape.isArea = false;
                fape.theArea = treeView1.SelectedNode.Tag as DataRow;
            }

            if (fape.ShowDialog() == DialogResult.OK)
            {
                if (treeView1.SelectedNode.Level == 0)
                {
                    TreeNode newNode = new TreeNode(fape.theArea[Area.fAreaName].ToString());
                    newNode.Tag = fape.theArea;
                    treeView1.SelectedNode.Nodes.Add(newNode);
                }
                else if (treeView1.SelectedNode.Level == 1)
                {
                    TreeNode newNode = new TreeNode(fape.thePolice[Police.fPoliceName].ToString());
                    newNode.Tag = fape.thePolice;
                    treeView1.SelectedNode.Nodes.Add(newNode);
                }
                if (treeView1.SelectedNode.Nodes.Count > 0)
                {
                    treeView1.SelectedNode.Expand();
                }
            }
        }

        private void tsbEditPolice_Click(object sender, EventArgs e)
        {
            FrmAreaPliceEdit fape = new FrmAreaPliceEdit();
            fape.isNew = false;
            if (treeView1.SelectedNode.Level == 1)
            {
                fape.isArea = true;
                fape.theArea = treeView1.SelectedNode.Tag as DataRow;
            }
            else if (treeView1.SelectedNode.Level == 2)
            {
                fape.isArea = false;
                fape.thePolice = treeView1.SelectedNode.Tag as DataRow;
            }

            if (fape.ShowDialog() == DialogResult.OK)
            {
                if (treeView1.SelectedNode.Level == 1)
                {
                    treeView1.SelectedNode.Tag = fape.theArea;
                    treeView1.SelectedNode.Text = fape.theArea[Area.fAreaName].ToString();
                }
                else if (treeView1.SelectedNode.Level == 2)
                {
                    treeView1.SelectedNode.Tag = fape.thePolice;
                    treeView1.SelectedNode.Text = fape.thePolice[Police.fPoliceName].ToString();
                }
            }
        }

        private void tsbDelPolice_Click(object sender, EventArgs e)
        {
            string delID;
            if (treeView1.SelectedNode.Level == 1)
            {
                delID = (treeView1.SelectedNode.Tag as DataRow)[Area.fID].ToString();
                if (Police.getnSingInstance().selectCountByOneField(Police.fArea, delID) != 0)
                {
                    MessageBox.Show("不能删除有干警数据的监区","删除错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }
                Area.getnSingInstance().deleteByPKey(delID);
                treeView1.Nodes.Remove(treeView1.SelectedNode);
            }
            else if (treeView1.SelectedNode.Level == 2)
            {
                delID = (treeView1.SelectedNode.Tag as DataRow)[Police.fID].ToString();
                if (Personnel.getnSingInstance().selectCountByOneField(Personnel.fPolice, delID) != 0)
                {
                    MessageBox.Show("不能删除有责任对象数据的干警", "删除错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Police.getnSingInstance().deleteByPKey(delID);
                treeView1.Nodes.Remove(treeView1.SelectedNode);
            }
        }

        private void tsbNewPersonnel_Click(object sender, EventArgs e)
        {
            FrmPersonnelEdit fpd = new FrmPersonnelEdit();
            fpd.isNew = true;
            fpd.thePolice = treeView1.SelectedNode.Tag as DataRow;
            fpd.theArea = treeView1.SelectedNode.Parent.Tag as DataRow;
            if (fpd.ShowDialog() == DialogResult.OK)
            {
                showPersonnelList();
            }
        }

        private void tsbEditPersonnel_Click(object sender, EventArgs e)
        {
            FrmPersonnelEdit fpd = new FrmPersonnelEdit();
            fpd.isNew = false;
            fpd.thePolice = treeView1.SelectedNode.Tag as DataRow;
            fpd.theArea = treeView1.SelectedNode.Parent.Tag as DataRow;
            fpd.thePersonnel = dataGridView1.SelectedRows[0].Tag as DataRow;
            if (fpd.ShowDialog() == DialogResult.OK)
            {
                showPersonnelList();
            }
        }

        private void tsbDelPersonnel_Click(object sender, EventArgs e)
        {
            string delID = (dataGridView1.SelectedRows[0].Tag as DataRow)[Personnel.fID].ToString();
            string delName = (dataGridView1.SelectedRows[0].Tag as DataRow)[Personnel.fPersonnelName].ToString();
            if (MonitorRecord.getnSingInstance().selectCountByOneField(MonitorRecord.fPersonnel, delID) != 0)
            {
                if (MessageBox.Show(
                    "删除人员将同时删除该人员相关的全部监测数据，确定删除[" + delName + "]吗？", 
                    "删除确认", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    MonitorRecord.getnSingInstance().deleteByOneField(MonitorRecord.fPersonnel, delID);
                }
                else
                {
                    return;
                }
            }
            //先删除照片
            if (File.Exists((dataGridView1.SelectedRows[0].Tag as DataRow)[Personnel.fPersonnelPhoto].ToString()))
            {
                File.Delete((dataGridView1.SelectedRows[0].Tag as DataRow)[Personnel.fPersonnelPhoto].ToString());
            }
            Personnel.getnSingInstance().deleteByPKey(delID);
            showPersonnelList();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            thePersonnel = dataGridView1.SelectedRows[0].Tag as DataRow;
            DialogResult = DialogResult.OK;
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeView1.SelectedNode == null)
            {
                toolStrip1.Enabled = false;
                toolStrip2.Enabled = false;
                dataGridView1.Rows.Clear();
            }
            else
            {
                if (treeView1.SelectedNode.Level == 0)
                {
                    toolStrip1.Enabled = false;
                    toolStrip2.Enabled = true;

                    tsbNewPolice.Enabled = true;
                    tsbEditPolice.Enabled = false;
                    tsbDelPolice.Enabled = false;

                    dataGridView1.Rows.Clear();
                }
                else if (treeView1.SelectedNode.Level == 1)
                {
                    toolStrip1.Enabled = false;
                    toolStrip2.Enabled = true;

                    tsbNewPolice.Enabled = true;
                    tsbEditPolice.Enabled = true;
                    tsbDelPolice.Enabled = true;

                    dataGridView1.Rows.Clear();
                }
                else if (treeView1.SelectedNode.Level == 2)
                {
                    toolStrip1.Enabled = true;
                    toolStrip2.Enabled = true;

                    tsbNewPolice.Enabled = false;
                    tsbEditPolice.Enabled = true;
                    tsbDelPolice.Enabled = true;


                    tsbEditPersonnel.Enabled = false;
                    tsbDelPersonnel.Enabled = false;
                    //string PoliceID = (treeView1.SelectedNode.Tag as DataRow)[Police.fID].ToString();

                    showPersonnelList();

                }
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                tsbEditPersonnel.Enabled = false;
                tsbDelPersonnel.Enabled = false;
                tsmiSelect.Enabled = false;
            }
            else
            {
                tsbEditPersonnel.Enabled = true;
                tsbDelPersonnel.Enabled = true;
                tsmiSelect.Enabled = true;
            }
        }

        private void showPersonnelList()
        {
            List<string> cdnList = new List<string>() { 
                Personnel.fPolice + "='"+(treeView1.SelectedNode.Tag as DataRow)[Police.fID].ToString()+"'" 
            };
            DataTable PersonnelDt = Personnel.getnSingInstance().fullSelect(cdnList);
            DataGridView objDataGridView = dataGridView1;
            UIHelper.formateDatagridviewToReadonlySignleselect(objDataGridView);
            objDataGridView.Columns.Clear();
            objDataGridView.Rows.Clear();

            Dictionary<string, string> fieldDic = new Dictionary<string, string>();
            fieldDic.Add(Personnel.fPersonnelName, "姓名");
            fieldDic.Add(Personnel.fPersonnelCode, "编码");
            fieldDic.Add(Personnel.fPersonnelSex + CommList.fName, "性别");
            fieldDic.Add(Personnel.fPersonnelBirth, "出生日期");

            addStudClumn(objDataGridView, fieldDic);

            objDataGridView.Tag = PersonnelDt;
            foreach (DataRow PersonnelDr in PersonnelDt.Rows)
            {

                addStudCell(objDataGridView, fieldDic, PersonnelDr);

            }
        }

        static public void addStudClumn(DataGridView objDataGridView, Dictionary<string, string> fieldDic)
        {
            int newColumnIndex;

            foreach (string fCode in fieldDic.Keys)
            {
                newColumnIndex = objDataGridView.Columns.Add(
                fCode,
                fieldDic[fCode]
                );
            }
        }
        static public void addStudCell(
            DataGridView objDataGridView,
            Dictionary<string, string> fieldDic,
            DataRow studentDr)
        {
            int newRowIndex;
            newRowIndex = objDataGridView.Rows.Add();
            foreach (string fCode in fieldDic.Keys)
            {
                objDataGridView.Rows[newRowIndex].Tag = studentDr;  //把本行数据全部保存到行tag中，以便取ID等用途

                objDataGridView.Rows[newRowIndex].Cells[fCode].Value
                    = studentDr[fCode].ToString();
            }
        }
    }
}
