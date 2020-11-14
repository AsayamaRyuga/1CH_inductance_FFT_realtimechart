/*******************
 * ver1:グラフの描画
 * ver2:CSV出力
 * ver3:ゼロ点調整
 * ver4.2:リアルタイムフーリエ処理
***************/

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
using System.Numerics;
using MathNet.Numerics;
using MathNet.Numerics.IntegralTransforms;

namespace Ayas_realTimeChart_ver1
{
    public partial class Form1 : Form
    {
        string message;//センサから送られてくるメッセージ格納用
        static Stopwatch sw = new Stopwatch();
        string timeStamp;
        private double[] originalData = new double[5];// 時間＋センサから送られてくる値
        private double[] ZeroData = new double[5];// センサゼロ値
        private double[] data = new double[5];// 初期値からの差分

        // 計算用
        private int order = 5; //生データの小数を何桁目まで残すか．

        // フーリエ変換用
        int N = 256;//フーリエ変換の要素数 complexDataの要素数も同様に変更すること
        private Complex[] complexData = new Complex[256];
        private double[] complexDataBefore = new double[256];
        int dataPointNum = 0;// データの個数カウント用

        // ログ作成用
        static Logging logging = new Logging();
        private bool flag_log = false;

        // グラフ作成用
        string legend1 = "CH0";
        string legend2 = "complex data";
        int displayTime = 15;// グラフに何秒間分のデータを表示するか(秒)
        private bool flag_zeroset = true;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                serialPort1.Close();
                this.Text = "Ayas RealTimeChart ver.4.2";// UIのタイトル設定
                sw.Stop();
            }
            catch{ }
        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            try
            {
                timeStamp = Convert.ToString(Math.Round((double)sw.ElapsedTicks / Stopwatch.Frequency, 1));
                message = timeStamp + "," + serialPort1.ReadLine();// 時間＋シリアルポートから読み込んだ値
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
                sw.Restart();// stopwatchスタート
                chart1.Series[legend1].Points.Clear();
                chart2.Series[legend2].Points.Clear();
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
                logging.end();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DisplayText(object sender, EventArgs e)
        {
            textBox1.AppendText(message + Environment.NewLine);
            
        }

        private void showChart(object sender, EventArgs e)
        {
            try
            {
                string[] strArrayData = message.Split(',');// カンマで分割

                if (strArrayData.Length == 5)
                {

                    //ゼロ点調整
                    if (checkBox_zeroset.Checked && flag_zeroset == true)
                    {
                        for (int i = 1; i < strArrayData.Length; i++)
                        {
                            ZeroData[i] = Math.Round(Convert.ToDouble(strArrayData[i]), order);
                        }
                        //label_Free.Text = "Zero pos.: " + ZeroData[1] + ", " + ZeroData[2] + ", " + ZeroData[3] + ", " + ZeroData[4];

                        if (ZeroData[4] < 20)// ゼロ点調整を終わらせる条件
                        {
                            flag_zeroset = false;
                        }
                    }

                    for (int i = 1; i < strArrayData.Length; i++)
                    {
                        originalData[i] = Math.Round(Convert.ToDouble(strArrayData[i]), order);// 小数第５位までに四捨五入
                        data[i] = originalData[i] - ZeroData[i];// ゼロ点からの差分をデータとする

                        // 複素数データに変換し、追加
                        //complexData[dataPointNum] = new Complex(originalData[1], 0);
                        complexData[dataPointNum] = new Complex(data[1], 0);
                        complexDataBefore[dataPointNum] = data[1];//for debug
                        label_Free2.Text = Convert.ToString(complexData[dataPointNum]);
                    }

                    // データの個数カウント
                    dataPointNum++;
                    label_Free.Text = "point num:" + dataPointNum;

                    double CH0 = Convert.ToDouble(data[1]);
                    //double y = Convert.ToDouble(strArrayData[1]);// CH0のインダクタンス値(ゼロ点調整前)
                    double time = Convert.ToDouble(strArrayData[0]);// 時間
                    chart1.Series[legend1].Points.AddXY(time, CH0);

                    // グラフの横軸の表示範囲設定
                    chart1.ChartAreas[0].AxisX.Maximum = time;
                    chart1.ChartAreas[0].AxisX.Minimum = time - displayTime;// 何秒前のデータまで表示するか

                    // logの作成
                    if (flag_log)
                    {
                        string logmsg = strArrayData[1] + "," + strArrayData[2] + "," + strArrayData[3] + "," + strArrayData[4];// CSVファイルに書き込み
                        logging.write(logmsg);
                    }
                }

                if (dataPointNum == N)// データ数がNならFFT実行
                {
                    this.Invoke(new EventHandler(FFT));// FFT処理スレッドへ
                    dataPointNum = 0;// データの個数のカウントのリセット
                }

                // グラフの描画設定
                chart1.Series[legend1].IsVisibleInLegend = false;// 凡例表示設定
                chart1.Series[legend1].IsValueShownAsLabel = false;// データラベル表示設定
                chart1.Series[legend1].ChartType = SeriesChartType.Line;// 折れ線グラフを指定
                chart1.Series[legend1].BorderWidth = 2;// 折れ線グラフの幅を指定
                chart1.Series[legend1].Color = Color.FromArgb(243, 152, 0);// RGBでグラフの色を指定
                chart1.ChartAreas[0].AxisY.Maximum = 0.1;// Y軸の最大値指定
                chart1.ChartAreas[0].AxisY.Minimum = -0.05;// Y軸の最小値指定
            }

            catch { }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                serialPort1.Close();
                sw.Stop();
                logging.end();
            }
            catch { }
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

        private void FFT(object sender, EventArgs e)
        {
            Fourier.Forward(complexData, FourierOptions.Default);// FFT実行
            chart2.Series.Clear();
            chart2.ChartAreas.Clear();
            //chart2.Series[legend2].Points.Clear();
            // ChartにChartAreaを追加
            string chart_area2 = "Area2";
            chart2.ChartAreas.Add(new ChartArea(chart_area2));

            chart2.Series.Add(legend2);

            for (int i = 0; i <= N/2; i++)
            {
                chart2.Series[legend2].Points.AddXY(i / 9600, complexData[i].Magnitude);// 複素数の絶対値Magnitudeで表示complexData.Length  / (1 / 9600)
                //chart2.Series[legend2].Points.Add(complexData[i].Magnitude);
                //chart2.Series[legend2].Points.AddXY(i, complexDataBefore[i]);// そのまま生データの表示（確認用）
                //chart2.Series[legend2].Points.AddXY(i, i*i);
                label_Free2.Text = "FFT---" + i;
            }

            // グラフの描画設定
            chart2.Series[legend2].IsVisibleInLegend = false;// 凡例表示設定
            chart2.Series[legend2].IsValueShownAsLabel = false;// データラベル表示設定
            //chart2.Series[legend2].ChartType = SeriesChartType.Column;// 棒グラフを指定
            chart2.Series[legend2].ChartType = SeriesChartType.Line;// 折れ線グラフを指定
            /***var complexData = new Complex[N];
            string[] strArrayData = message.Split(',');// カンマで分割

            // 複素数データに変換し、追加
            complexData[iFourier] = new Complex(Convert.ToDouble(strArrayData[1]), 0);
            iFourier++;

            Fourier.Forward(complexData, FourierOptions.Default);

            //var point = complexData.Take();***/
        }
    }
}
