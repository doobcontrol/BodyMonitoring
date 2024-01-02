using com.xiyuansoft.BodyMonitoring.bormodel;
using com.xiyuansoft.bormodel;
using com.xiyuansoft.bormodel.commdata;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace com.xiyuansoft.BodyMonitoring.winform
{
    public partial class FrmMainForm : Form
    {
        FormBorderStyle defFBS;
        public FrmMainForm()
        {
            InitializeComponent();

            this.Icon = global::com.xiyuansoft.BodyMonitoring.Properties.Resources.defaultWinIcon;
            this.Text = "封闭式房间单人生命监测系统";// "智能体征监测系统";

            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Padding = new Padding(10);

            myBMThread.myOnlineMessageEventSender += new BMThread.OnlineMessageEventHandler(myOnlineMessageReceiver);
            this.WindowState = FormWindowState.Maximized;

            defFBS = this.FormBorderStyle;
            Player = new SoundPlayer("alerm.wav");

        }

        private void FrmMainForm_Load(object sender, EventArgs e)
        {

            showEqus();
        }

        private void ParsetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmParset().ShowDialog();
        }

        private void EquSetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmEquSet().ShowDialog();
        }

        BMThread myBMThread = new BMThread();
        //BMSimulateThread myBMThread = new BMSimulateThread();
        private void StarttoolStripButton1_Click(object sender, EventArgs e)
        {
            showEqus();
            if (BizPars.getnSingInstance().getPar(SysBizPars.comPort) == "")
            {
                MessageBox.Show("请先设置串口参数");
                return;
            }
            myBMThread.equDic = equDic;
            myBMThread.StartMonitor();

            timer1.Start();
        }

        private void StoptoolStripButton2_Click(object sender, EventArgs e)
        {
            timer1.Stop();

            myBMThread.EndtMonitor();
            myBMThread.equDic = null;
            Player.Stop(); ;
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            myBMThread.myOnlineMessageEventSender -= new BMThread.OnlineMessageEventHandler(myOnlineMessageReceiver);
            myBMThread.EndtMonitor();
            myBMThread.equDic = null;
            this.Close();
        }

        Dictionary<string, Dictionary<string, object>> equDic;
        private void showEqus()
        {
            tableLayoutPanel1.Controls.Clear();

            equDic = new Dictionary<string, Dictionary<string, object>>();

            DataTable eqTb = Equ.getnSingInstance().selectAll();
            SuspendLayout();
            foreach (DataRow dr in eqTb.Rows)
            {
                Dictionary<string, object> newEquDic = showOneEqu(dr);
                equDic.Add(dr[Equ.fEquID].ToString(), newEquDic);
                newEquDic.Add("datarow", dr);
                newEquDic.Add("lastActtime", DateTime.Now);
                newEquDic.Add("work", false);
            }
            ResumeLayout();
        }

        private DateTime getLastActtime(Dictionary<string, object> equDic)
        {
            DateTime retDt;
            lock (equDic["lastActtime"])
            {
                retDt = (DateTime)equDic["lastActtime"];
            }
            return retDt;
        }
        private void setLastActtime(Dictionary<string, object> equDic, DateTime LastActtime)
        {

            lock (equDic["lastActtime"])
            {
                equDic["lastActtime"] = LastActtime;
            }
        }

        private Color backGroundColor = Color.FromArgb(40, 49, 73); //b8e4c9
        private Color breathBeatColor = Color.FromArgb(219, 237, 243);
        private Color panelColor = Color.FromArgb(219, 231, 243);
        private Color chartbackGroundColor = Color.FromArgb(64, 75, 105);
        
        private int equPHeight=0;

        private Dictionary<string, object> showOneEqu(DataRow dr)
        {
            Dictionary<string, object> retDic = new Dictionary<string, object>();

            if (equPHeight == 0)
            {
                equPHeight = tableLayoutPanel1.Height / 2 - 15;
            }

            Panel maxForPanel = new Panel();
            maxForPanel.Dock = DockStyle.Top;
            maxForPanel.Height = equPHeight;
            tableLayoutPanel1.Controls.Add(maxForPanel);

            Panel outPanel = new Panel();
            
            maxForPanel.Controls.Add(outPanel);
            outPanel.Padding = new System.Windows.Forms.Padding(5, 6, 0, 0);
            outPanel.SuspendLayout();
            //outPanel.BorderStyle = BorderStyle.FixedSingle;
            outPanel.Dock = DockStyle.Fill;
            Panel dataPanel = new Panel();
            dataPanel.Padding = new System.Windows.Forms.Padding(5, 6, 0, 0);
            dataPanel.Width = 200;
            dataPanel.BackColor = backGroundColor;
            Panel ChartPanel = new Panel();
            outPanel.Controls.Add(ChartPanel);
            outPanel.Controls.Add(dataPanel);
            dataPanel.Dock = DockStyle.Left;
            ChartPanel.Dock = DockStyle.Fill;
            outPanel.ResumeLayout();

            ToolStrip mTs = new ToolStrip();
            mTs.BackColor = panelColor;
            dataPanel.Controls.Add(mTs);

            ToolStripButton tsbMaxMe = new ToolStripButton();
            tsbMaxMe.ToolTipText = "全屏显示";
            tsbMaxMe.Image = global::com.xiyuansoft.BodyMonitoring.Properties.Resources.image_zoom_in;
            tsbMaxMe.Click += new System.EventHandler(this.BtnMaxMe_Click);
            tsbMaxMe.Tag = outPanel;
            mTs.Items.Add(tsbMaxMe);

            ToolStripButton tsbPersonnel = new ToolStripButton();
            tsbPersonnel.ToolTipText = "选择监测对象";
            tsbPersonnel.Image = global::com.xiyuansoft.BodyMonitoring.Properties.Resources.meeting_observer;
            tsbPersonnel.Click += new System.EventHandler(this.BtnPersonnel_Click);
           // tsbPersonnel.Tag = outPanel;
            mTs.Items.Add(tsbPersonnel);
            
            int stX = 12;
            int stY = 10;

            PictureBox alertPhoto = new PictureBox();
            stY += 30;
            alertPhoto.Size = new System.Drawing.Size(30, 30);
            alertPhoto.Location = new Point(stX, stY);
            alertPhoto.SizeMode = PictureBoxSizeMode.Zoom;
            alertPhoto.Visible = false;
            alertPhoto.Image = global::com.xiyuansoft.BodyMonitoring.Properties.Resources.alert;

            Label lblMode = new Label();
            lblMode.ForeColor = Color.Red; ;
            lblMode.AutoSize = true;
            lblMode.Location = new Point(stX + 40, stY + 5);
            lblMode.Text = "情绪波动中";
            lblMode.Visible = false;

            CheckBox chkWork = new CheckBox();
            chkWork.Location = new Point(stX + 120, stY);
            chkWork.ForeColor = breathBeatColor;
            chkWork.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            chkWork.Text = "监测";
            chkWork.Tag = retDic;
            //mTs.Items.Add(chkWork);

            Label lblEquID = new Label();
            lblEquID.ForeColor = breathBeatColor;
            stY += 40;
            lblEquID.AutoSize = true;
            lblEquID.Location = new Point(stX, stY);

            Label lblEquRoom = new Label();
            lblEquRoom.ForeColor = breathBeatColor;
            stY += 30;
            lblEquRoom.AutoSize = true;
            lblEquRoom.Location = new Point(stX, stY);

            Label lblPersonnel = new Label();
            lblPersonnel.ForeColor = breathBeatColor;
            stY += 30;
            lblPersonnel.AutoSize = true;
            lblPersonnel.Location = new Point(stX, stY);

            Label lblPersonnelArea = new Label();
            lblPersonnelArea.ForeColor = breathBeatColor;
            stY += 30;
            lblPersonnelArea.AutoSize = true;
            lblPersonnelArea.Location = new Point(stX, stY);

            Label lblHeartRate = new Label();
            lblHeartRate.AutoSize = true;
            lblHeartRate.ForeColor = breathBeatColor;
            lblHeartRate.Font = new System.Drawing.Font(
                "黑体",//"Courier New",
                20,
                System.Drawing.FontStyle.Bold
                );
            stY += 30;
            lblHeartRate.Location = new Point(stX, stY);
            Label lblBreathe = new Label();
            lblBreathe.ForeColor = breathBeatColor;
            lblBreathe.AutoSize = true;
            lblBreathe.Font = new System.Drawing.Font(
                "黑体",//"Courier New",
                20, 
                System.Drawing.FontStyle.Bold
                );
            stY += 30;
            lblBreathe.Location = new Point(stX, stY);

            GroupBox gbPersonnel = new GroupBox();
            gbPersonnel.ForeColor = breathBeatColor;
            stY += 40;
            gbPersonnel.Size=new Size(200,400);
            gbPersonnel.Text = "人员信息：未设置";
            gbPersonnel.Location = new Point(0, stY);
            gbPersonnel.Visible = false;
            dataPanel.Controls.Add(gbPersonnel);

            int pX = 12;
            int pY = 15;

            PictureBox pbPersonnelPhoto = new PictureBox();
            pbPersonnelPhoto.Size = new System.Drawing.Size(160, 200);
            pbPersonnelPhoto.Location = new Point(pX, pY);
            pbPersonnelPhoto.SizeMode = PictureBoxSizeMode.Zoom;
            pbPersonnelPhoto.Image = global::com.xiyuansoft.BodyMonitoring.Properties.Resources.defaultphoto;
            gbPersonnel.Controls.Add(pbPersonnelPhoto);

            Label lblPersonnelCode = new Label();
            lblPersonnelCode.ForeColor = breathBeatColor;
            pY += 210;
            lblPersonnelCode.AutoSize = true;
            lblPersonnelCode.Text = "编码：";
            lblPersonnelCode.Location = new Point(pX, pY);
            gbPersonnel.Controls.Add(lblPersonnelCode);

            Label lblPersonnelSex = new Label();
            lblPersonnelSex.ForeColor = breathBeatColor;
            pY += 30;
            lblPersonnelSex.AutoSize = true;
            lblPersonnelSex.Text = "性别：";
            lblPersonnelSex.Location = new Point(pX, pY);
            gbPersonnel.Controls.Add(lblPersonnelSex);

            Label lblPersonnelBirth = new Label();
            lblPersonnelBirth.ForeColor = breathBeatColor;
            pY += 30;
            lblPersonnelBirth.AutoSize = true;
            lblPersonnelBirth.Text = "出生日期：";
            lblPersonnelBirth.Location = new Point(pX, pY);
            gbPersonnel.Controls.Add(lblPersonnelBirth);

            Label lblArea = new Label();
            lblArea.ForeColor = breathBeatColor;
            pY += 30;
            lblArea.AutoSize = true;
            lblArea.Text = "所属监区：";
            lblArea.Location = new Point(pX, pY);
            gbPersonnel.Controls.Add(lblArea);

            Label lblPolice = new Label();
            lblPolice.ForeColor = breathBeatColor;
            pY += 30;
            lblPolice.AutoSize = true;
            lblPolice.Text = "责任干警：";
            lblPolice.Location = new Point(pX, pY);
            gbPersonnel.Controls.Add(lblPolice);



            dataPanel.Controls.Add(alertPhoto);
            dataPanel.Controls.Add(lblMode);
            dataPanel.Controls.Add(chkWork);
            dataPanel.Controls.Add(lblEquID);
            dataPanel.Controls.Add(lblEquRoom);
            dataPanel.Controls.Add(lblPersonnel);
            dataPanel.Controls.Add(lblPersonnelArea);
            dataPanel.Controls.Add(lblHeartRate);
            dataPanel.Controls.Add(lblBreathe);

            Chart chart = new Chart();
            chart.Dock = DockStyle.Fill;
            chart.BackColor = backGroundColor;
            ChartPanel.Controls.Add(chart);

            DateTime minValue;
            DateTime maxValue;
            Series HeartRateSeries;
            Series BreatheSeries;

            ChartArea chartArea = new ChartArea();
            chartArea.AxisX.LabelStyle.Format = "hh:mm:ss";
            chartArea.Name = "ChartArea1";
            chartArea.BackColor = chartbackGroundColor;
            chartArea.AxisX.MajorGrid.LineColor = Color.White;
            chartArea.AxisY.MajorGrid.LineColor = Color.White;
            chartArea.AxisX.LabelStyle.ForeColor = Color.White;
            chartArea.AxisY.LabelStyle.ForeColor = Color.White;
            chart.ChartAreas.Add(chartArea);

            // Predefine the viewing area of the chart
            minValue = DateTime.Now;
            maxValue = minValue.AddSeconds(120);

            chart.ChartAreas[0].AxisX.Minimum = minValue.ToOADate();
            chart.ChartAreas[0].AxisX.Maximum = maxValue.ToOADate();

            // Reset number of series in the chart.
            chart.Series.Clear();

            // create a line chart series
            HeartRateSeries = new Series("心率");
            HeartRateSeries.ChartType = SeriesChartType.Line;
            HeartRateSeries.BorderWidth = 2;
            HeartRateSeries.Color = Color.LightGreen;
            HeartRateSeries.XValueType = ChartValueType.DateTime;
            HeartRateSeries.Name = "HeartRateSeries";
            chart.Series.Add(HeartRateSeries);

            BreatheSeries = new Series("呼吸");
            BreatheSeries.ChartType = SeriesChartType.Line;
            BreatheSeries.BorderWidth = 2;
            BreatheSeries.Color = Color.LightBlue;
            BreatheSeries.XValueType = ChartValueType.DateTime;
            BreatheSeries.Name = "BreatheSeries";
            chart.Series.Add(BreatheSeries);    


            lblEquID.Text = "设备：" + dr[Equ.fEquID].ToString();
            lblEquRoom.Text = "房间：" + dr[Equ.fEquRoom].ToString();
            lblPersonnel.Text = "人员：未设置";
            lblPersonnelArea.Text = "监区：未设置";
            lblHeartRate.Text = "心率：";
            lblBreathe.Text = "呼吸：";

            retDic.Add("outPanel", outPanel);

            retDic.Add("alertPhoto", alertPhoto);
            retDic.Add("lblMode", lblMode);
            retDic.Add("lblEquID", lblEquID);
            retDic.Add("lblEquRoom", lblEquRoom);
            retDic.Add("lblPersonnel", lblPersonnel);
            retDic.Add("lblPersonnelArea", lblPersonnelArea);
            retDic.Add("lblHeartRate", lblHeartRate);
            retDic.Add("lblBreathe", lblBreathe);
            retDic.Add("chart", chart);

            retDic.Add("gbPersonnel", gbPersonnel);
            retDic.Add("lblPersonnelCode", lblPersonnelCode);
            retDic.Add("lblPersonnelSex", lblPersonnelSex);
            retDic.Add("lblPersonnelBirth", lblPersonnelBirth);
            retDic.Add("lblArea", lblArea);
            retDic.Add("lblPolice", lblPolice);
            retDic.Add("pbPersonnelPhoto", pbPersonnelPhoto);

            mTs.Tag = retDic;

            return retDic;
        }
        FormWindowState orgFWS;
        private void BtnMaxMe_Click(object sender, EventArgs e)
        {
            Dictionary<string, object> equDic = (sender as ToolStripButton).Owner.Tag as Dictionary<string, object>;
            GroupBox gbPersonnel = equDic["gbPersonnel"] as GroupBox;
            if ((((sender as ToolStripButton).Tag) as Panel).Parent == this)
            {
                (((sender as ToolStripButton).Tag) as Panel).Parent = (((sender as ToolStripButton).Tag) as Panel).Tag as Panel;
                (sender as ToolStripButton).ToolTipText = "全屏显示";
                (sender as ToolStripButton).Image = global::com.xiyuansoft.BodyMonitoring.Properties.Resources.image_zoom_in;
                menuStrip1.Show();
                toolStrip1.Show();
                tableLayoutPanel1.Show();
                statusStrip1.Show();

                gbPersonnel.Hide();

                //没有标题
                this.FormBorderStyle = defFBS;
                this.WindowState = orgFWS;
            }
            else
            {
                (((sender as ToolStripButton).Tag) as Panel).Tag = (((sender as ToolStripButton).Tag) as Panel).Parent;
                this.Controls.Add(((sender as ToolStripButton).Tag) as Panel);
                tableLayoutPanel1.Hide();
                menuStrip1.Hide();
                toolStrip1.Hide();
                statusStrip1.Hide();
                (((sender as ToolStripButton).Tag) as Panel).BringToFront();
                (sender as ToolStripButton).ToolTipText = "恢复";
                (sender as ToolStripButton).Image = global::com.xiyuansoft.BodyMonitoring.Properties.Resources.image_zoom_out;

                gbPersonnel.Show();

                //没有标题
                orgFWS = this.WindowState;
                this.WindowState = FormWindowState.Maximized;
                this.FormBorderStyle = FormBorderStyle.None;
            }
        }

        private void BtnPersonnel_Click(object sender, EventArgs e)
        {
            FrmPersonnel fp =  new FrmPersonnel();
            fp.canSelect = true;
            if (fp.ShowDialog() == DialogResult.OK)
            {
                DataRow selectedPsersonnelDr = fp.thePersonnel;

                Dictionary<string, object> equDic = (sender as ToolStripButton).Owner.Tag as Dictionary<string, object>;
                if (equDic.ContainsKey("PersonnelRow"))
                {
                    equDic["PersonnelRow"] = selectedPsersonnelDr;
                }
                else
                {
                    equDic.Add("PersonnelRow", selectedPsersonnelDr);
                }

                (equDic["gbPersonnel"] as GroupBox).Text
                    = "人员信息";
                (equDic["lblPersonnel"] as Label).Text
                    = "人员：" + selectedPsersonnelDr[Personnel.fPersonnelName].ToString();
                (equDic["lblPersonnelArea"] as Label).Text
                    = "监区：" + selectedPsersonnelDr[Personnel.fAreaName].ToString();
                (equDic["lblPersonnelCode"] as Label).Text
                    = "编码：" + selectedPsersonnelDr[Personnel.fPersonnelCode].ToString();
                (equDic["lblPersonnelSex"] as Label).Text
                    = "性别：" + selectedPsersonnelDr[Personnel.fPersonnelSex + CommList.fName].ToString();
                (equDic["lblPersonnelBirth"] as Label).Text
                    = "出生日期：" + selectedPsersonnelDr[Personnel.fPersonnelBirth].ToString();
                (equDic["lblArea"] as Label).Text
                    = "所属监区：" + selectedPsersonnelDr[Personnel.fAreaName].ToString();
                (equDic["lblPolice"] as Label).Text
                    = "责任干警：" + selectedPsersonnelDr[Personnel.fPoliceName].ToString();

                if (
                    selectedPsersonnelDr[Personnel.fPersonnelPhoto].ToString().Trim() != ""
                    && File.Exists(selectedPsersonnelDr[Personnel.fPersonnelPhoto].ToString().Trim()))
                {
                    (equDic["pbPersonnelPhoto"] as PictureBox).Image =
                        UIHelper.LoadBitmapUnlocked(selectedPsersonnelDr[Personnel.fPersonnelPhoto].ToString().Trim());
                }
                else
                {
                    (equDic["pbPersonnelPhoto"] as PictureBox).Image = global::com.xiyuansoft.BodyMonitoring.Properties.Resources.defaultphoto;
                }

            }
        }



        private void myOnlineMessageReceiver(string msg, Dictionary<string, int> bmDataDic, string equid)
        {
            //实例化代理
            OnlineMessageHandler handler = new OnlineMessageHandler(myOnlineMessageHandler);
            //调用Invoke
            //this.Invoke(handler, new object[] { e });
            this.BeginInvoke(handler, new object[] { msg, bmDataDic, equid });
        }
        /*定义一代理
         * 说明:其实例作为Invoke参数,以实现后台线程调用主线的函数
         * MessageEventArgs传递显示的信息.
         * */
        public delegate void OnlineMessageHandler(string msg, Dictionary<string, int> bmDataDic, string equid);
        public void myOnlineMessageHandler(string msg, Dictionary<string, int> bmDataDic, string equid)
        {
            if (bmDataDic != null)
            {
                if (
                    bmDataDic["HeartRate"] > int.Parse(BizPars.getnSingInstance().getPar(SysBizPars.ModeHartrate))
                    && bmDataDic["Breathe"] > int.Parse(BizPars.getnSingInstance().getPar(SysBizPars.ModeBreath))
                    )
                {
                    (equDic[equid]["lblMode"] as Label).Show();
                }
                else
                {
                    (equDic[equid]["lblMode"] as Label).Hide();
                }

                if (
                    bmDataDic["HeartRate"] > int.Parse(BizPars.getnSingInstance().getPar(SysBizPars.HeartRateMax))
                    || bmDataDic["HeartRate"] < int.Parse(BizPars.getnSingInstance().getPar(SysBizPars.HeartRateMin))
                    || bmDataDic["Breathe"] > int.Parse(BizPars.getnSingInstance().getPar(SysBizPars.BreatheMax))
                    || bmDataDic["Breathe"] < int.Parse(BizPars.getnSingInstance().getPar(SysBizPars.BreatheMin))
                    )
                {
                    //alert(bmDataDic, equid);
                    (equDic[equid]["alertPhoto"] as PictureBox).Show();
                    Player.Play();
                }
                else
                {
                    (equDic[equid]["alertPhoto"] as PictureBox).Hide();
                    Player.Stop(); ;
                }

                (equDic[equid]["lblHeartRate"] as Label).Text = "心率：" + bmDataDic["HeartRate"];
                (equDic[equid]["lblBreathe"] as Label).Text = "呼吸：" + bmDataDic["Breathe"];

                SaveData(bmDataDic, equid);

                AddData(bmDataDic, equid);

                setLastActtime(equDic[equid], DateTime.Now);
            }
            else
            {
                if(equid != null){
                    if (msg.StartsWith("\r\n读串口错："))
                    {
                        (equDic[equid]["lblHeartRate"] as Label).Text = "心率：设备无响应";
                        (equDic[equid]["lblBreathe"] as Label).Text = "呼吸：设备无响应";
                    }
                }
                else
                {
                    toolStripStatusLabel1.Text = msg;
                }
            }
        }

        public void AddData(Dictionary<string, int> bmDataDic, string equid)
        {


            DateTime timeStamp = DateTime.Now;

            Chart chart = equDic[equid]["chart"] as Chart;
            Series HeartRateSeries = chart.Series["HeartRateSeries"];
            Series BreatheSeries = chart.Series["BreatheSeries"];

            AddNewPoint(timeStamp, bmDataDic["HeartRate"], chart, HeartRateSeries);
            //HeartRateSeries.Legend = "心率：" + bmDataDic["HeartRate"];

            AddNewPoint(timeStamp, bmDataDic["Breathe"], chart, BreatheSeries);
            //BreatheSeries.Legend = "呼吸：" + bmDataDic["Breathe"];

            chart.Invalidate();
        }

        /// The AddNewPoint function is called for each series in the chart when
        /// new points need to be added.  The new point will be placed at specified
        /// X axis (Date/Time) position with a Y value in a range +/- 1 from the previous
        /// data point's Y value, and not smaller than zero.
        public void AddNewPoint(
            DateTime timeStamp,
            int value,
            Chart chart,
            System.Windows.Forms.DataVisualization.Charting.Series ptSeries
            )
        {

            // Add new data point to its series.
            ptSeries.Points.AddXY(timeStamp.ToOADate(), value);

            // remove all points from the source series older than 1.5 minutes.
            double removeBefore = timeStamp.AddSeconds((double)(90) * (-1)).ToOADate();
            //remove oldest values to maintain a constant number of data points
            while (ptSeries.Points[0].XValue < removeBefore)
            {
                ptSeries.Points.RemoveAt(0);
            }

            chart.ChartAreas[0].AxisX.Minimum = ptSeries.Points[0].XValue;
            chart.ChartAreas[0].AxisX.Maximum = DateTime.FromOADate(ptSeries.Points[0].XValue).AddMinutes(2).ToOADate();

            //chart1.Invalidate();
        }

        private void PersonnelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmPersonnel().ShowDialog();
        }


        public void SaveData(Dictionary<string, int> bmDataDic, string equid)
        {
            if (!equDic[equid].ContainsKey("PersonnelRow"))
            {
                return;  //未设置人员
            }
            DataRow PersonnelRow = equDic[equid]["PersonnelRow"] as DataRow;
            DataRow EquRow = equDic[equid]["datarow"] as DataRow;

            DateTime timeStamp = DateTime.Now;

            Hashtable tHt = new Hashtable();
            tHt.Add(MonitorRecord.fPersonnel, PersonnelRow[Personnel.fID].ToString());
            tHt.Add(MonitorRecord.fEqu, EquRow[Equ.fID].ToString());
            tHt.Add(MonitorRecord.fMonitorTime, timeStamp.ToString("yyyy-MM-dd hh-mm-ss"));
            tHt.Add(MonitorRecord.fHeartRate, bmDataDic["HeartRate"].ToString());
            tHt.Add(MonitorRecord.fBreathee, bmDataDic["Breathe"].ToString());
            MonitorRecord.getnSingInstance().insertMainRecord(tHt);
        }

        private void monitorDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmQuery().ShowDialog();
        }

        // The player making the current sound.
        private SoundPlayer Player = null;
        private void alert(Dictionary<string, int> bmDataDic, string equid){


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (Dictionary<string, object> eq in equDic.Values)
            {
                if (
                    !(bool)eq["work"] ||
                    getLastActtime(eq).AddSeconds(5) < DateTime.Now)
                {
                    resetEquShowHandler handler = new resetEquShowHandler(resetEquShow);
                    this.BeginInvoke(handler, new object[] { eq });
                }
            }
        }
        public delegate void resetEquShowHandler(Dictionary<string, object> eq);
        public void resetEquShow(Dictionary<string, object> eq)
        {
            (eq["lblHeartRate"] as Label).Text = "心率：---";
            (eq["lblBreathe"] as Label).Text = "呼吸：---";

            Chart chart = eq["chart"] as Chart;

            Series HeartRateSeries = chart.Series["HeartRateSeries"];
            Series BreatheSeries = chart.Series["BreatheSeries"];
            HeartRateSeries.Points.Clear();
            BreatheSeries.Points.Clear();
            (eq["alertPhoto"] as PictureBox).Hide();
            Player.Stop(); ;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Dictionary<string, object> equDic = (sender as CheckBox).Tag as Dictionary<string, object>;
            equDic["work"] = (sender as CheckBox).Checked;
        }
    }
}
