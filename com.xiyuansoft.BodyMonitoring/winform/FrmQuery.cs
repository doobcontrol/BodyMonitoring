using com.xiyuansoft.BodyMonitoring.bormodel;
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
    public partial class FrmQuery : Form
    {
        public FrmQuery()
        {
            InitializeComponent();
            this.Icon = global::com.xiyuansoft.BodyMonitoring.Properties.Resources.defaultWinIcon;
            this.Text = "测试对象人员管理";

            UIHelper.SetDialogForm(this);
        }

        private void FrmQuery_Load(object sender, EventArgs e)
        {
            treeView1.Dock = DockStyle.Fill;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView2.Dock = DockStyle.Fill;

            UIHelper.ShowPersonnelTree(treeView1);
            treeView1.ExpandAll();

            FrmEquSet.showEqu(dataGridView2);

            DateTime timeStamp = DateTime.Now;

            dtpStartDate.Value = timeStamp;
            dtpEndDate.Value = timeStamp;
            dtpStartTime.Value = timeStamp.AddHours(-1);
            dtpEndTime.Value = timeStamp;

        }

        private void tsmiQuery_Click(object sender, EventArgs e)
        {
            List<string> qCdnList = new List<string>();
            if (tabControl1.SelectedIndex == 0)
            {
                if (treeView1.SelectedNode == null)
                {
                    //message
                    MessageBox.Show("选择要查询的人员");
                    return;
                }
                else if (treeView1.SelectedNode.Level != 3)
                {
                    //message
                    MessageBox.Show("选择要查询的人员");
                    return;
                }
                qCdnList.Add(MonitorRecord.TableCode + "." + MonitorRecord.fPersonnel + "='"+
                    (treeView1.SelectedNode.Tag as DataRow)[Personnel.fID].ToString()
                    +"'" );
            }
            else
            {
                if (dataGridView2.SelectedRows.Count == 0)
                {
                    //message
                    MessageBox.Show("选择要查询的房间");
                    return;
                }
                qCdnList.Add(MonitorRecord.TableCode + "." + MonitorRecord.fEqu + "='" +
                    (dataGridView2.SelectedRows[0].Tag as DataRow)[Equ.fID].ToString()
                    + "'");
            }
            qCdnList.Add(MonitorRecord.TableCode + "." + MonitorRecord.fMonitorTime + ">='" +
                dtpStartDate.Value.ToString("yyyy-MM-dd") + " " + dtpStartTime.Value.ToString("hh:mm:ss")
                + "'");
            qCdnList.Add(MonitorRecord.TableCode + "." + MonitorRecord.fMonitorTime + "<='" +
                dtpEndDate.Value.ToString("yyyy-MM-dd") + " " + dtpEndTime.Value.ToString("hh:mm:ss")
                + "'");
            List<string> indexList = new List<string>() { MonitorRecord.fMonitorTime };

            DataTable qDt = MonitorRecord.getnSingInstance().fullSelect(qCdnList, indexList);
            showDetailList(dataGridView1, qDt);
        }

        private void tsmiExit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        public static void showDetailList(DataGridView dgv, DataTable qDt)
        {
            UIHelper.formateDatagridviewToReadonlySignleselect(dgv);
            dgv.Columns.Clear();
            dgv.Rows.Clear();

            Dictionary<string, string> fieldDic = new Dictionary<string, string>();
            fieldDic.Add(MonitorRecord.fMonitorTime, "时间");
            fieldDic.Add(MonitorRecord.fHeartRate, "心率");
            fieldDic.Add(MonitorRecord.fBreathee, "呼吸");

            addStudClumn(dgv, fieldDic);

            dgv.Tag = qDt;
            foreach (DataRow PersonnelDr in qDt.Rows)
            {

                addStudCell(dgv, fieldDic, PersonnelDr);

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
