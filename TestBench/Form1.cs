using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace TestBench
{
    public partial class Form1 : Form
    {
        BMThread myBMThread = new BMThread();
        public Form1()
        {
            InitializeComponent();

            myBMThread.myOnlineMessageEventSender += new BMThread.OnlineMessageEventHandler(myOnlineMessageReceiver);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            myBMThread.StartMonitor();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            myBMThread.EndtMonitor();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void myOnlineMessageReceiver(string msg, Dictionary<string, int> bmDataDic)
        {
            //实例化代理
            OnlineMessageHandler handler = new OnlineMessageHandler(myOnlineMessageHandler);
            //调用Invoke
            //this.Invoke(handler, new object[] { e });
            this.BeginInvoke(handler, new object[] { msg, bmDataDic });
        }
        /*定义一代理
         * 说明:其实例作为Invoke参数,以实现后台线程调用主线的函数
         * MessageEventArgs传递显示的信息.
         * */
        public delegate void OnlineMessageHandler(string msg, Dictionary<string, int> bmDataDic);
        public void myOnlineMessageHandler(string msg, Dictionary<string, int> bmDataDic)
        {
            showMessage(msg);
            if (bmDataDic != null)
            {
                AddData(bmDataDic);
            }
        }
        public void showMessage(string msg)
        {
            textBox1.AppendText(msg);
        }

        DateTime minValue;
        DateTime maxValue;
        Series HeartRateSeries;
        Series BreatheSeries;

        private void Form1_Load(object sender, EventArgs e)
        {

            // Predefine the viewing area of the chart
            minValue = DateTime.Now;
            maxValue = minValue.AddSeconds(120);

            chart1.ChartAreas[0].AxisX.Minimum = minValue.ToOADate();
            chart1.ChartAreas[0].AxisX.Maximum = maxValue.ToOADate();

            // Reset number of series in the chart.
            chart1.Series.Clear();

            // create a line chart series
            HeartRateSeries = new Series("心率");
            HeartRateSeries.ChartType = SeriesChartType.Line;
            HeartRateSeries.BorderWidth = 2;
            HeartRateSeries.Color = Color.Green;
            HeartRateSeries.XValueType = ChartValueType.DateTime;
            chart1.Series.Add(HeartRateSeries);

            BreatheSeries = new Series("呼吸");
            BreatheSeries.ChartType = SeriesChartType.Line;
            BreatheSeries.BorderWidth = 2;
            BreatheSeries.Color = Color.Blue;
            BreatheSeries.XValueType = ChartValueType.DateTime;
            chart1.Series.Add(BreatheSeries);    

        }


        public void AddData(Dictionary<string, int> bmDataDic)
        {
            DateTime timeStamp = DateTime.Now;
            
            AddNewPoint(timeStamp, bmDataDic["HeartRate"], HeartRateSeries);
            //HeartRateSeries.Legend = "心率：" + bmDataDic["HeartRate"];

            AddNewPoint(timeStamp, bmDataDic["Breathe"], BreatheSeries);
            //BreatheSeries.Legend = "呼吸：" + bmDataDic["Breathe"];

            chart1.Invalidate();
        }

        /// The AddNewPoint function is called for each series in the chart when
        /// new points need to be added.  The new point will be placed at specified
        /// X axis (Date/Time) position with a Y value in a range +/- 1 from the previous
        /// data point's Y value, and not smaller than zero.
        public void AddNewPoint(
            DateTime timeStamp, 
            int value,
            System.Windows.Forms.DataVisualization.Charting.Series ptSeries
            )
        {
            //double newVal = 0;

            //if (ptSeries.Points.Count > 0)
            //{
            //    newVal = ptSeries.Points[ptSeries.Points.Count - 1].YValues[0] + ((rand.NextDouble() * 2) - 1);
            //}

            //if (newVal < 0)
            //    newVal = 0;

            // Add new data point to its series.
            ptSeries.Points.AddXY(timeStamp.ToOADate(), value);

            // remove all points from the source series older than 1.5 minutes.
            double removeBefore = timeStamp.AddSeconds((double)(90) * (-1)).ToOADate();
            //remove oldest values to maintain a constant number of data points
            while (ptSeries.Points[0].XValue < removeBefore)
            {
                ptSeries.Points.RemoveAt(0);
            }

            chart1.ChartAreas[0].AxisX.Minimum = ptSeries.Points[0].XValue;
            chart1.ChartAreas[0].AxisX.Maximum = DateTime.FromOADate(ptSeries.Points[0].XValue).AddMinutes(2).ToOADate();

            //chart1.Invalidate();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pictureBox1.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            pictureBox1.Hide();
        }

    }
}
