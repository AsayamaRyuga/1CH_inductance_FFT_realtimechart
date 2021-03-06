﻿namespace Ayas_realTimeChart_ver1
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
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
            this.checkBox_zeroset = new System.Windows.Forms.CheckBox();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label_Free2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.groupBox_log.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(254, 9);
            this.chart1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "CH0";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(410, 329);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // button_Connect
            // 
            this.button_Connect.Location = new System.Drawing.Point(35, 9);
            this.button_Connect.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.button_Connect.Name = "button_Connect";
            this.button_Connect.Size = new System.Drawing.Size(77, 25);
            this.button_Connect.TabIndex = 1;
            this.button_Connect.Text = "Connect";
            this.button_Connect.UseVisualStyleBackColor = true;
            this.button_Connect.Click += new System.EventHandler(this.button_Connect_Click);
            // 
            // button_Disconnect
            // 
            this.button_Disconnect.Location = new System.Drawing.Point(115, 9);
            this.button_Disconnect.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.button_Disconnect.Name = "button_Disconnect";
            this.button_Disconnect.Size = new System.Drawing.Size(77, 25);
            this.button_Disconnect.TabIndex = 2;
            this.button_Disconnect.Text = "Disconnect";
            this.button_Disconnect.UseVisualStyleBackColor = true;
            this.button_Disconnect.Click += new System.EventHandler(this.button_Disconnect_Click);
            // 
            // label_Free
            // 
            this.label_Free.AutoSize = true;
            this.label_Free.Location = new System.Drawing.Point(251, 341);
            this.label_Free.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_Free.Name = "label_Free";
            this.label_Free.Size = new System.Drawing.Size(56, 12);
            this.label_Free.TabIndex = 3;
            this.label_Free.Text = "Free label";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(3, 99);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(250, 253);
            this.textBox1.TabIndex = 4;
            // 
            // serialPort1
            // 
            this.serialPort1.PortName = "COM5";
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // button_logon
            // 
            this.button_logon.Location = new System.Drawing.Point(16, 16);
            this.button_logon.Margin = new System.Windows.Forms.Padding(2);
            this.button_logon.Name = "button_logon";
            this.button_logon.Size = new System.Drawing.Size(41, 25);
            this.button_logon.TabIndex = 5;
            this.button_logon.Text = "on";
            this.button_logon.UseVisualStyleBackColor = true;
            this.button_logon.Click += new System.EventHandler(this.button_logon_Click);
            // 
            // button_logoff
            // 
            this.button_logoff.Location = new System.Drawing.Point(60, 16);
            this.button_logoff.Margin = new System.Windows.Forms.Padding(2);
            this.button_logoff.Name = "button_logoff";
            this.button_logoff.Size = new System.Drawing.Size(41, 25);
            this.button_logoff.TabIndex = 6;
            this.button_logoff.Text = "off";
            this.button_logoff.UseVisualStyleBackColor = true;
            this.button_logoff.Click += new System.EventHandler(this.button_logoff_Click);
            // 
            // groupBox_log
            // 
            this.groupBox_log.Controls.Add(this.button_logoff);
            this.groupBox_log.Controls.Add(this.button_logon);
            this.groupBox_log.Location = new System.Drawing.Point(25, 47);
            this.groupBox_log.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox_log.Name = "groupBox_log";
            this.groupBox_log.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox_log.Size = new System.Drawing.Size(113, 47);
            this.groupBox_log.TabIndex = 7;
            this.groupBox_log.TabStop = false;
            this.groupBox_log.Text = "Data Log (off)";
            // 
            // checkBox_zeroset
            // 
            this.checkBox_zeroset.AutoSize = true;
            this.checkBox_zeroset.Checked = true;
            this.checkBox_zeroset.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_zeroset.Location = new System.Drawing.Point(158, 63);
            this.checkBox_zeroset.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox_zeroset.Name = "checkBox_zeroset";
            this.checkBox_zeroset.Size = new System.Drawing.Size(64, 16);
            this.checkBox_zeroset.TabIndex = 8;
            this.checkBox_zeroset.Text = "ZeroSet";
            this.checkBox_zeroset.UseVisualStyleBackColor = true;
            // 
            // chart2
            // 
            chartArea2.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart2.Legends.Add(legend2);
            this.chart2.Location = new System.Drawing.Point(254, 368);
            this.chart2.Name = "chart2";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "complex data";
            this.chart2.Series.Add(series2);
            this.chart2.Size = new System.Drawing.Size(410, 264);
            this.chart2.TabIndex = 9;
            this.chart2.Text = "chart2";
            // 
            // label_Free2
            // 
            this.label_Free2.AutoSize = true;
            this.label_Free2.Location = new System.Drawing.Point(392, 342);
            this.label_Free2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_Free2.Name = "label_Free2";
            this.label_Free2.Size = new System.Drawing.Size(35, 12);
            this.label_Free2.TabIndex = 10;
            this.label_Free2.Text = "label2";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 638);
            this.Controls.Add(this.label_Free2);
            this.Controls.Add(this.chart2);
            this.Controls.Add(this.checkBox_zeroset);
            this.Controls.Add(this.groupBox_log);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label_Free);
            this.Controls.Add(this.button_Disconnect);
            this.Controls.Add(this.button_Connect);
            this.Controls.Add(this.chart1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.groupBox_log.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
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
        private System.Windows.Forms.CheckBox checkBox_zeroset;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.Label label_Free2;
    }
}

