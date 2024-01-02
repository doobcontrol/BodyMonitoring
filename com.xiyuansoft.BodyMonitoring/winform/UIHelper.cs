using com.xiyuansoft.BodyMonitoring.bormodel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace com.xiyuansoft.BodyMonitoring.winform
{
    class UIHelper
    {
        static public Dictionary<string, string> userRecordDic;
        public static void SetDialogForm(Form dForm)
        {
            dForm.FormBorderStyle = FormBorderStyle.FixedDialog;
            dForm.ControlBox = false;
            dForm.ShowInTaskbar = false;
            dForm.StartPosition = FormStartPosition.CenterParent;

        }

        public static void loadComboBoxlistFromDatatable(
            ComboBox tCb,
            DataTable sDt,
            string displayField
            )
        {
            System.Collections.ArrayList forDataList = new System.Collections.ArrayList();
            foreach (DataRow dr in sDt.Rows)
            {
                forDataList.Add(new System.Collections.DictionaryEntry(
                        dr,
                        dr[displayField].ToString()
                    )
                );
            }

            if (forDataList.Count != 0)
            {
                tCb.DataSource = forDataList;
                tCb.DisplayMember = "Value";
                tCb.ValueMember = "Key";

                tCb.SelectedIndex = 0;
            }
            tCb.DropDownStyle = ComboBoxStyle.DropDownList;
            tCb.SelectedIndex = -1;
        }

        /// <summary>
        /// 格式化DataGridView为只读，单选
        /// </summary>
        /// <param name="objDataGridView">目标表格</param>
        static public void formateDatagridviewToReadonlySignleselect(System.Windows.Forms.DataGridView objDataGridView)
        {
            objDataGridView.AllowUserToAddRows = false;
            objDataGridView.AllowUserToDeleteRows = false;
            objDataGridView.AllowUserToResizeColumns = false;
            objDataGridView.AllowUserToResizeRows = false;
            objDataGridView.ReadOnly = true;
            objDataGridView.RowHeadersVisible = false;
            objDataGridView.ColumnHeadersVisible = true;
            objDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        }


        public static void ShowPoliceTree(TreeView classTv)
        {
            ShowPoTree(classTv, false);
        }
        public static void ShowPersonnelTree(TreeView classTv)
        {
            ShowPoTree(classTv, true);
        }
        public static void ShowPoTree(TreeView classTv, bool showStudent)
        {
            TreeNode tNode = new TreeNode("监区列表");
            classTv.Nodes.Add(tNode);

            DataTable SgDt = Area.getnSingInstance().selectAll();
            foreach (DataRow SgDr in SgDt.Rows)
            {
                TreeNode newNode = new TreeNode(SgDr[Area.fAreaName].ToString());
                newNode.Tag = SgDr;

                tNode.Nodes.Add(newNode);

                loadPolice(
                    newNode,
                    showStudent
                    );
            }
        }

        public static void loadPolice(
            TreeNode gradeNode,
            bool showStudent
            )
        {
            string gradeID = (gradeNode.Tag as DataRow)[Area.fID].ToString();

            DataTable ClassDt = Police.getnSingInstance().selectByOneField(Police.fArea, gradeID);

            foreach (DataRow ClassDr in ClassDt.Rows)
            {
                TreeNode newNode = new TreeNode(ClassDr[Police.fPoliceName].ToString());
                newNode.Tag = ClassDr;

                gradeNode.Nodes.Add(newNode);

                if (showStudent)
                {
                    loadPersonnel(
                        newNode
                        );
                }
            }
        }

        public static void loadPersonnel(
            TreeNode ClassNode
            )
        {
            string ClassID = (ClassNode.Tag as DataRow)[Police.fID].ToString();

            DataTable StudentDt = Personnel.getnSingInstance().selectByOneField(Personnel.fPolice, ClassID);

            foreach (DataRow StudentDr in StudentDt.Rows)
            {
                TreeNode newNode = new TreeNode(StudentDr[Personnel.fPersonnelName].ToString());
                newNode.Tag = StudentDr;

                ClassNode.Nodes.Add(newNode);
            }
        }

        // Load a bitmap without locking it.
        public static Bitmap LoadBitmapUnlocked(string file_name)
        {
            using (Bitmap bm = new Bitmap(file_name))
            {
                return new Bitmap(bm);
            }
        }
        public static void selectItemofCombByRowID(ComboBox Cb, string pField, string rowID)
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

        #region 导出为excel


        #endregion
    }
}
