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
        string element;//センサから送られてくるメッセージ格納用
        static Stopwatch sw = new Stopwatch();
        string timeStamp;
        private double[] originalData = new double[5];// 時間＋センサから送られてくる値
        private double[] ZeroData = new double[5];// センサゼロ値
        private double[] data = new double[5];// 初期値からの差分

        // ログ作成用
        static Logging logging = new Logging();
        private bool flag_log = false;

        // グラフ作成用
        string legend1 = "CH0";
        int displayTime = 10;// グラフに何秒間分のデータを表示するか(秒)

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                serialPort1.Close();
                this.Text = "Ayas RealTimeChart ver.2";
                sw.Stop();
            }
            catch
            {

            }
        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            try
            {
                timeStamp = Convert.ToString(Math.Round((double)sw.ElapsedTicks / Stopwatch.Frequency, 1));
                element = timeStamp + "," + serialPort1.ReadLine();// 時間＋シリアルポートから読み込んだ値
                this.Invoke(new EventHandler(DisplayText));
                this.Invoke(new EventHandler(showChart));
            }
            catch { }                                
        }

        private void button_Connect_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.Open();
                textBox1.ResetText();
                sw.Restart();//stopwatchスタート
                chart1.Series[legend1].Points.Clear();
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
                sw.Stop();
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

            if (element.Length >= 5)
            {
                string[] strArrayData = element.Split(',');// カンマで分割
                double y = Convert.ToDouble(strArrayData[1]);// CH0のインダクタンス値
                double x = Convert.ToDouble(strArrayData[0]);// 時間
                chart1.Series[legend1].Points.AddXY(x, y);
                
                // グラフの横軸の表示範囲設定
                chart1.ChartAreas[0].AxisX.Maximum = x ;
                chart1.ChartAreas[0].AxisX.Minimum = x - displayTime;// 何秒前のデータまで表示するか

                // logの作成
                if (flag_log)
                {
                    string logmsg = strArrayData[1] + "," + strArrayData[2] + "," + strArrayData[3] + "," + strArrayData[4];// CSVファイルに書き込み
                    logging.write(logmsg);
                }
            }
            
            // グラフの描画設定
            chart1.Series[legend1].IsVisibleInLegend = false;// 凡例表示設定
            chart1.Series[legend1].IsValueShownAsLabel = false;// データラベル表示設定
            chart1.Series[legend1].ChartType = SeriesChartType.Line;// 折れ線グラフを指定
            chart1.Series[legend1].BorderWidth = 2;// 折れ線グラフの幅を指定
            chart1.Series[legend1].Color = Color.FromArgb(243, 152, 0);// RGBでグラフの色を指定
            chart1.ChartAreas[0].AxisY.Maximum = 8.24;
            chart1.ChartAreas[0].AxisY.Minimum = 8.12;
        }



        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            serialPort1.Close();
            sw.Stop();
        }

        private void button_logon_Click(object sender, EventArgs e)
        {
            flag_log = true;
            groupBox_log.Text = "Data Log (on)";
        }

        private void button_logoff_Click(object sender, EventArgs e)
        {
            flag_log = false;
            groupBox_log.Text = "Data Log (off)";
            logging.end();
        }
    }
}
