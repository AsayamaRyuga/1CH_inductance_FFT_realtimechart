/*******************
 * ver1:グラフの描画
 * ver2:CSV出力
 * ver3:ゼロ点調整
 * ver4:
 *******************/

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
        string message;//センサから送られてくるメッセージ格納用
        static Stopwatch sw = new Stopwatch();
        string timeStamp;
        private double[] originalData = new double[5];// 時間＋センサから送られてくる値
        private double[] ZeroData = new double[5];// センサゼロ値
        private double[] data = new double[5];// 初期値からの差分

        // 計算用
        private int order = 5; //生データの小数を何桁目まで残すか．

        private double x_raw = 0;//右側と左側のインダクタンス値の合計値の差(増幅前)
        private double y_raw = 0;//上側と下側のインダクタンス値の合計値の差（増幅前）
        private double z_raw = 0;//４つのインダクタンス値の合計値（増幅前）
        private int amp = 100000; //int計算するためのコイルインダクタンス値の増幅率 initファイルで更新

        private int x = 0; //右側と左側のインダクタンス値の合計値の差
        private int y = 0; //上側と下側のインダクタンス値の合計値の差
        private int z = 0; //４つのインダクタンス値の合計値
        private int z_old = 0;//直前のdの保存用

        private int x_reso = 256;//xの解像度
        private int y_reso = 256;//yの解像度
        private int z_reso = 256;//zの解像度
        private int x_origin = 128;//解像度範囲中のxのゼロ点
        private int y_origin = 128;//解像度範囲中のyのゼロ点
        private int z_origin = 0;//解像度範囲中のzのゼロ点
        private double x_max = 120;//増幅後のxの最大値（ゼロ点からの差分）
        private double y_max = 60;//増幅後のyの最大値（ゼロ点からの差分）
        private double z_max = 60;//増幅後のzの最大値（ゼロ点からの差分）

        // ログ作成用
        static Logging logging = new Logging();
        private bool flag_log = false;

        // グラフ作成用
        string legend1 = "CH0";
        int displayTime = 10;// グラフに何秒間分のデータを表示するか(秒)
        private bool flag_zeroset = true;

        //自動ゼロ点調整用
        private int reset_diff = 2; //initファイルで更新
        private int reset_count = 50; //initファイルで更新
        private int resetcounter = 0; //initファイルで更新

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                serialPort1.Close();
                this.Text = "Ayas RealTimeChart ver.3";// UIのタイトル設定
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
                        label_Free.Text = "Zero pos.: " + ZeroData[1] + ", " + ZeroData[2] + ", " + ZeroData[3] + ", " + ZeroData[4];

                        if (ZeroData[4] < 20)// ゼロ点調整を終わらせる条件
                        {
                            flag_zeroset = false;
                        }
                    }

                    for (int i = 1; i < strArrayData.Length; i++)
                    {
                        originalData[i] = Math.Round(Convert.ToDouble(strArrayData[i]), order);// 小数第５位までに四捨五入
                        data[i] = originalData[i] - ZeroData[i];// ゼロ点からの差分をデータとする
                    }
                    

                    z_old = z;//自動ゼロ点更新用

                    //４次元データを三次元データに変換
                    x_raw = data[3] + data[4] - data[1] - data[2];
                    y_raw = data[1] + data[4] - data[2] - data[3];
                    z_raw = data[1] + data[2] + data[3] + data[4];// 押下度合いの計算

                    x = (int)(x_raw * amp);
                    y = (int)(y_raw * amp);
                    z = (int)(z_raw * amp);// 押下度合いの計算

                    //解像度設定に合わせる
                    x = (int)(Convert.ToDouble(x_reso - 1 - x_origin) * x / (x_max * amp));
                    y = (int)(Convert.ToDouble(y_reso - 1 - y_origin) * y / (y_max * amp));
                    z = (int)(Convert.ToDouble(z_reso - 1 - z_origin) * z / (z_max * amp));

                    //overflow check
                    if (x < 0 - x_origin) x = 0 - x_origin;
                    if (x > x_reso - 1) x = x_reso - 1;
                    if (y < 0 - y_origin) y = 0 - y_origin;
                    if (y > y_reso - 1) y = y_reso - 1;
                    if (z < 0 - z_origin) z = 0 - z_origin;
                    if (z > z_reso - 1) z = z_reso - 1;

                    /***
                    //自動ゼロ点更新
                    if (checkBox_zeroset.Checked)
                    {
                        if (Math.Abs(z_old - z) < reset_diff)// 前回差分が規定値未満の状況が…
                        {
                            resetcounter++;
                        }
                        else
                        {
                            resetcounter = 0;
                        }

                        if (resetcounter > reset_count)// 規定ステップ連続すればゼロ点調整のフラグをオンにする
                        {
                            flag_zeroset = true;
                            resetcounter = 0;
                        }
                    }***/

                    double CH0 = Convert.ToDouble(data[1]);
                    //double y = Convert.ToDouble(strArrayData[1]);// CH0のインダクタンス値
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
    }
}
