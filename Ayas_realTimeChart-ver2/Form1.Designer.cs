namespace Ayas_realTimeChart_ver1
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.button_Connect = new System.Windows.Forms.Button();
            this.button_Disconnect = new System.Windows.Forms.Button();
            this.label_Free = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.button_logon = new System.Windows.Forms.Button();
            this.button_logoff = new System.Windows.Forms.Button();
            this.groupBox_log = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.groupBox_log.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(423, 14);
            this.chart1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "CH0";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(683, 493);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // button_Connect
            // 
            this.button_Connect.Location = new System.Drawing.Point(58, 14);
            this.button_Connect.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_Connect.Name = "button_Connect";
            this.button_Connect.Size = new System.Drawing.Size(128, 38);
            this.button_Connect.TabIndex = 1;
            this.button_Connect.Text = "Connect";
            this.button_Connect.UseVisualStyleBackColor = true;
            this.button_Connect.Click += new System.EventHandler(this.button_Connect_Click);
            // 
            // button_Disconnect
            // 
            this.button_Disconnect.Location = new System.Drawing.Point(192, 14);
            this.button_Disconnect.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_Disconnect.Name = "button_Disconnect";
            this.button_Disconnect.Size = new System.Drawing.Size(128, 38);
            this.button_Disconnect.TabIndex = 2;
            this.button_Disconnect.Text = "Disconnect";
            this.button_Disconnect.UseVisualStyleBackColor = true;
            this.button_Disconnect.Click += new System.EventHandler(this.button_Disconnect_Click);
            // 
            // label_Free
            // 
            this.label_Free.AutoSize = true;
            this.label_Free.Location = new System.Drawing.Point(419, 512);
            this.label_Free.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Free.Name = "label_Free";
            this.label_Free.Size = new System.Drawing.Size(88, 19);
            this.label_Free.TabIndex = 3;
            this.label_Free.Text = "Free label";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(5, 148);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(414, 378);
            this.textBox1.TabIndex = 4;
            // 
            // serialPort1
            // 
            this.serialPort1.PortName = "COM5";
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // button_logon
            // 
            this.button_logon.Location = new System.Drawing.Point(26, 24);
            this.button_logon.Name = "button_logon";
            this.button_logon.Size = new System.Drawing.Size(68, 38);
            this.button_logon.TabIndex = 5;
            this.button_logon.Text = "on";
            this.button_logon.UseVisualStyleBackColor = true;
            this.button_logon.Click += new System.EventHandler(this.button_logon_Click);
            // 
            // button_logoff
            // 
            this.button_logoff.Location = new System.Drawing.Point(100, 24);
            this.button_logoff.Name = "button_logoff";
            this.button_logoff.Size = new System.Drawing.Size(68, 38);
            this.button_logoff.TabIndex = 6;
            this.button_logoff.Text = "off";
            this.button_logoff.UseVisualStyleBackColor = true;
            this.button_logoff.Click += new System.EventHandler(this.button_logoff_Click);
            // 
            // groupBox_log
            // 
            this.groupBox_log.Controls.Add(this.button_logoff);
            this.groupBox_log.Controls.Add(this.button_logon);
            this.groupBox_log.Location = new System.Drawing.Point(42, 70);
            this.groupBox_log.Name = "groupBox_log";
            this.groupBox_log.Size = new System.Drawing.Size(188, 71);
            this.groupBox_log.TabIndex = 7;
            this.groupBox_log.TabStop = false;
            this.groupBox_log.Text = "Data Log (off)";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1119, 540);
            this.Controls.Add(this.groupBox_log);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label_Free);
            this.Controls.Add(this.button_Disconnect);
            this.Controls.Add(this.button_Connect);
            this.Controls.Add(this.chart1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.groupBox_log.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button button_Connect;
        private System.Windows.Forms.Button button_Disconnect;
        private System.Windows.Forms.Label label_Free;
        private System.Windows.Forms.TextBox textBox1;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button button_logon;
        private System.Windows.Forms.Button button_logoff;
        private System.Windows.Forms.GroupBox groupBox_log;
    }
}

