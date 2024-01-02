using com.xiyuansoft.BodyMonitoring.bormodel;
using com.xiyuansoft.bormodel.metadata;
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
    public partial class FrmEquSet : Form
    {
        public FrmEquSet()
        {
            InitializeComponent();

            this.Icon = global::com.xiyuansoft.BodyMonitoring.Properties.Resources.defaultWinIcon;
            this.Text = "设备及房间管理";

            UIHelper.SetDialogForm(this);
            dataGridView1.Dock = DockStyle.Fill;
        }

        private void FrmEquSet_Load(object sender, EventArgs e)
        {
            showEqu(dataGridView1);
        }

        public static void showEqu(DataGridView objDataGridView)
        {
            DataTable EquDt = Equ.getnSingInstance().selectAll();

            UIHelper.formateDatagridviewToReadonlySignleselect(objDataGridView);
            objDataGridView.Columns.Clear();
            objDataGridView.Rows.Clear();

            int newColumnIndex;
            int newRowIndex;

            newColumnIndex = objDataGridView.Columns.Add(
            Equ.getnSingInstance().getFieldsHt()[Equ.fEquID][Field.fFieldCode].ToString(),
            Equ.getnSingInstance().getFieldsHt()[Equ.fEquID][Field.fFieldName].ToString()
            );
            objDataGridView.Columns[newColumnIndex].Tag
                = Equ.getnSingInstance().getFieldsHt()[Equ.fEquID];

            newColumnIndex = objDataGridView.Columns.Add(
            Equ.getnSingInstance().getFieldsHt()[Equ.fEquRoom][Field.fFieldCode].ToString(),
            Equ.getnSingInstance().getFieldsHt()[Equ.fEquRoom][Field.fFieldName].ToString()
            );
            objDataGridView.Columns[newColumnIndex].Tag
                = Equ.getnSingInstance().getFieldsHt()[Equ.fEquRoom];

            foreach (DataRow ClassDr in EquDt.Rows)
            {
                newRowIndex = objDataGridView.Rows.Add();
                objDataGridView.Rows[newRowIndex].Tag = ClassDr;  //把本行数据全部保存到行tag中，以便取ID等用途
                objDataGridView.Rows[newRowIndex].Cells[Equ.fEquID].Value
                    = ClassDr[Equ.fEquID].ToString();
                objDataGridView.Rows[newRowIndex].Cells[Equ.fEquRoom].Value
                    = ClassDr[Equ.fEquRoom].ToString();
            }
        }

        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmEquEdit fnc = new FrmEquEdit();
            fnc.isNew = true;
            if (fnc.ShowDialog() == DialogResult.OK)
            {
                showEqu(dataGridView1);
            }
        }

        private void EditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                return;
            }
            FrmEquEdit fnc = new FrmEquEdit();
            fnc.isNew = false;
            fnc.EquRow = dataGridView1.SelectedRows[0].Tag as DataRow;
            if (fnc.ShowDialog() == DialogResult.OK)
            {
                showEqu(dataGridView1);
            }
        }

        private void DelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                return;
            }

            Equ.getnSingInstance().deleteByPKey((dataGridView1.SelectedRows[0].Tag as DataRow)[Equ.fID].ToString());
            showEqu(dataGridView1);
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                DelToolStripMenuItem.Enabled = false;
                EditToolStripMenuItem.Enabled = false;
            }
            else
            {
                DelToolStripMenuItem.Enabled = true;
                EditToolStripMenuItem.Enabled = true;
            }
        }
    }
}
