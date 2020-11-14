//test git

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;
using System.Diagnostics;

namespace Ayas_realTimeChart_ver1
{
    public partial class Form1 : Form
    {
        string element;
        static Stopwatch sw = new Stopwatch();
        string timeStamp;

        public Form1()
        {
            InitializeComponent();
        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            timeStamp = Convert.ToString(Math.Round((double)sw.ElapsedTicks / Stopwatch.Frequency , 1));
            element = timeStamp + "," + serialPort1.ReadLine();
            this.Invoke(new EventHandler(DisplayText));
            this.Invoke(new EventHandler(showChart));
        }

        private void button_Connect_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.Open();
                sw.Restart();//stopwatchスタート
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button_Disconnect_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DisplayText(object sender, EventArgs e)
        {
            textBox1.AppendText(element + Environment.NewLine);
        }

        private void showChart(object sender, EventArgs e)
        {
            string legend1 = "Series1";
            if (element.Length >= 5)
            {
                string[] strArrayData = element.Split(',');
                double y = Convert.ToDouble(strArrayData[1]);
                double x = Convert.ToDouble(strArrayData[0]);
                //double y = double.Parse(strArrayData[1]);
                //double x = double.Parse(strArrayData[0]);
                chart1.Series[legend1].Points.AddXY(x, y);
                chart1.ChartAreas[0].AxisX.Maximum = x ;
                chart1.ChartAreas[0].AxisX.Minimum = x - 10;
            }
            
            chart1.Series[legend1].IsVisibleInLegend = false;// 凡例表示設定
            chart1.Series[legend1].IsValueShownAsLabel = false;// データラベル表示設定
            chart1.Series[legend1].ChartType = SeriesChartType.Line;// 折れ線グラフを指定
            chart1.Series[legend1].BorderWidth = 2;// 折れ線グラフの幅を指定
            chart1.Series[legend1].Color = Color.FromArgb(243, 152, 0);// RGBでグラフの色を指定
            chart1.ChartAreas[0].AxisY.Maximum = 8.3;
            chart1.ChartAreas[0].AxisY.Minimum = 8;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                serialPort1.Close();
                sw.Stop();
            }
            catch { }
        }
    }
}
