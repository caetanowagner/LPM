
namespace MicroMeter
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea8 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend8 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series36 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series37 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series38 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series39 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series40 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.BtnScanPorts = new System.Windows.Forms.Button();
            this.cboxPorts = new System.Windows.Forms.ComboBox();
            this.BtnConnect = new System.Windows.Forms.Button();
            this.BtnDisconnect = new System.Windows.Forms.Button();
            this.BtnStartAcq = new System.Windows.Forms.Button();
            this.BtnStopAcq = new System.Windows.Forms.Button();
            this.LblVolts = new System.Windows.Forms.Label();
            this.LblAmp = new System.Windows.Forms.Label();
            this.LblPower = new System.Windows.Forms.Label();
            this.LblVoltsUnit = new System.Windows.Forms.Label();
            this.LblAmpUnit = new System.Windows.Forms.Label();
            this.LblPowerUnit = new System.Windows.Forms.Label();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.ds = new System.Data.DataSet();
            this.BtnReset = new System.Windows.Forms.Button();
            this.sqConnection = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.sqAcquisition = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.sqDMAError = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.sqAcquisitionError = new System.Windows.Forms.Button();
            this.sqHWError = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.timGetStatus = new System.Windows.Forms.Timer(this.components);
            this.timConnRefresh = new System.Windows.Forms.Timer(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.sqTimeout = new System.Windows.Forms.Button();
            this.lblTime = new System.Windows.Forms.Label();
            this.timChartUpdate = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ds)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnScanPorts
            // 
            this.BtnScanPorts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnScanPorts.Location = new System.Drawing.Point(112, 674);
            this.BtnScanPorts.Name = "BtnScanPorts";
            this.BtnScanPorts.Size = new System.Drawing.Size(100, 23);
            this.BtnScanPorts.TabIndex = 1;
            this.BtnScanPorts.Text = "Scan Ports";
            this.BtnScanPorts.UseVisualStyleBackColor = true;
            this.BtnScanPorts.Click += new System.EventHandler(this.BtnScanPorts_Click);
            // 
            // cboxPorts
            // 
            this.cboxPorts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cboxPorts.FormattingEnabled = true;
            this.cboxPorts.Location = new System.Drawing.Point(6, 676);
            this.cboxPorts.Name = "cboxPorts";
            this.cboxPorts.Size = new System.Drawing.Size(100, 21);
            this.cboxPorts.TabIndex = 0;
            // 
            // BtnConnect
            // 
            this.BtnConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnConnect.Location = new System.Drawing.Point(218, 674);
            this.BtnConnect.Name = "BtnConnect";
            this.BtnConnect.Size = new System.Drawing.Size(100, 23);
            this.BtnConnect.TabIndex = 2;
            this.BtnConnect.Text = "Connect";
            this.BtnConnect.UseVisualStyleBackColor = true;
            this.BtnConnect.Click += new System.EventHandler(this.BtnConnect_Click);
            // 
            // BtnDisconnect
            // 
            this.BtnDisconnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnDisconnect.Location = new System.Drawing.Point(323, 674);
            this.BtnDisconnect.Name = "BtnDisconnect";
            this.BtnDisconnect.Size = new System.Drawing.Size(100, 23);
            this.BtnDisconnect.TabIndex = 3;
            this.BtnDisconnect.Text = "Disconnect";
            this.BtnDisconnect.UseVisualStyleBackColor = true;
            this.BtnDisconnect.Click += new System.EventHandler(this.BtnDisconnect_Click);
            // 
            // BtnStartAcq
            // 
            this.BtnStartAcq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnStartAcq.Location = new System.Drawing.Point(429, 674);
            this.BtnStartAcq.Name = "BtnStartAcq";
            this.BtnStartAcq.Size = new System.Drawing.Size(100, 23);
            this.BtnStartAcq.TabIndex = 4;
            this.BtnStartAcq.Text = "Start Acquisition";
            this.BtnStartAcq.UseVisualStyleBackColor = true;
            this.BtnStartAcq.Click += new System.EventHandler(this.BtnStartAcq_Click);
            // 
            // BtnStopAcq
            // 
            this.BtnStopAcq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnStopAcq.Location = new System.Drawing.Point(535, 674);
            this.BtnStopAcq.Name = "BtnStopAcq";
            this.BtnStopAcq.Size = new System.Drawing.Size(100, 23);
            this.BtnStopAcq.TabIndex = 5;
            this.BtnStopAcq.Text = "Stop Acquisition";
            this.BtnStopAcq.UseVisualStyleBackColor = true;
            this.BtnStopAcq.Click += new System.EventHandler(this.BtnStopAcq_Click);
            // 
            // LblVolts
            // 
            this.LblVolts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblVolts.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LblVolts.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.LblVolts.Location = new System.Drawing.Point(1289, 134);
            this.LblVolts.Name = "LblVolts";
            this.LblVolts.Size = new System.Drawing.Size(69, 22);
            this.LblVolts.TabIndex = 7;
            this.LblVolts.Text = "3,3 ";
            this.LblVolts.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // LblAmp
            // 
            this.LblAmp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblAmp.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LblAmp.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.LblAmp.Location = new System.Drawing.Point(1289, 156);
            this.LblAmp.Name = "LblAmp";
            this.LblAmp.Size = new System.Drawing.Size(69, 22);
            this.LblAmp.TabIndex = 8;
            this.LblAmp.Text = "300,23 ";
            this.LblAmp.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // LblPower
            // 
            this.LblPower.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblPower.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LblPower.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.LblPower.Location = new System.Drawing.Point(1289, 178);
            this.LblPower.Name = "LblPower";
            this.LblPower.Size = new System.Drawing.Size(69, 22);
            this.LblPower.TabIndex = 9;
            this.LblPower.Text = "0,990 ";
            this.LblPower.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // LblVoltsUnit
            // 
            this.LblVoltsUnit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblVoltsUnit.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LblVoltsUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.LblVoltsUnit.Location = new System.Drawing.Point(1359, 134);
            this.LblVoltsUnit.Name = "LblVoltsUnit";
            this.LblVoltsUnit.Size = new System.Drawing.Size(36, 22);
            this.LblVoltsUnit.TabIndex = 10;
            this.LblVoltsUnit.Text = "V";
            // 
            // LblAmpUnit
            // 
            this.LblAmpUnit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblAmpUnit.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LblAmpUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.LblAmpUnit.Location = new System.Drawing.Point(1359, 156);
            this.LblAmpUnit.Name = "LblAmpUnit";
            this.LblAmpUnit.Size = new System.Drawing.Size(36, 22);
            this.LblAmpUnit.TabIndex = 11;
            this.LblAmpUnit.Text = "mA";
            // 
            // LblPowerUnit
            // 
            this.LblPowerUnit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblPowerUnit.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LblPowerUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.LblPowerUnit.Location = new System.Drawing.Point(1359, 178);
            this.LblPowerUnit.Name = "LblPowerUnit";
            this.LblPowerUnit.Size = new System.Drawing.Size(36, 22);
            this.LblPowerUnit.TabIndex = 12;
            this.LblPowerUnit.Text = "W";
            // 
            // serialPort1
            // 
            this.serialPort1.BaudRate = 230400;
            this.serialPort1.ReadBufferSize = 200000;
            this.serialPort1.ReadTimeout = 500;
            this.serialPort1.ReceivedBytesThreshold = 2;
            this.serialPort1.WriteTimeout = 1000;
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // chart1
            // 
            this.chart1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chart1.AntiAliasing = System.Windows.Forms.DataVisualization.Charting.AntiAliasingStyles.None;
            this.chart1.BackColor = System.Drawing.Color.DarkGray;
            this.chart1.BorderlineColor = System.Drawing.Color.Black;
            this.chart1.BorderlineWidth = 3;
            chartArea8.Area3DStyle.LightStyle = System.Windows.Forms.DataVisualization.Charting.LightStyle.Realistic;
            chartArea8.BackColor = System.Drawing.Color.DarkGray;
            chartArea8.BackSecondaryColor = System.Drawing.Color.DarkGray;
            chartArea8.BorderWidth = 2;
            chartArea8.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea8);
            this.chart1.DataSource = this.ds;
            legend8.Name = "Legend1";
            this.chart1.Legends.Add(legend8);
            this.chart1.Location = new System.Drawing.Point(6, 0);
            this.chart1.Name = "chart1";
            series36.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            series36.ChartArea = "ChartArea1";
            series36.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series36.Color = System.Drawing.Color.Blue;
            series36.Legend = "Legend1";
            series36.MarkerSize = 1;
            series36.Name = "Voltage";
            series37.ChartArea = "ChartArea1";
            series37.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series37.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            series37.Legend = "Legend1";
            series37.MarkerSize = 1;
            series37.Name = "I_ch1";
            series38.ChartArea = "ChartArea1";
            series38.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series38.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            series38.Legend = "Legend1";
            series38.MarkerSize = 1;
            series38.Name = "I_ch2";
            series39.ChartArea = "ChartArea1";
            series39.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series39.Color = System.Drawing.Color.Aqua;
            series39.Legend = "Legend1";
            series39.MarkerSize = 1;
            series39.Name = "I_ch3";
            series40.ChartArea = "ChartArea1";
            series40.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series40.Color = System.Drawing.Color.Red;
            series40.Legend = "Legend1";
            series40.MarkerSize = 1;
            series40.Name = "Power";
            this.chart1.Series.Add(series36);
            this.chart1.Series.Add(series37);
            this.chart1.Series.Add(series38);
            this.chart1.Series.Add(series39);
            this.chart1.Series.Add(series40);
            this.chart1.Size = new System.Drawing.Size(1414, 656);
            this.chart1.TabIndex = 13;
            this.chart1.Text = "chart1";
            // 
            // ds
            // 
            this.ds.DataSetName = "dsVoltage";
            // 
            // BtnReset
            // 
            this.BtnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnReset.Location = new System.Drawing.Point(641, 674);
            this.BtnReset.Name = "BtnReset";
            this.BtnReset.Size = new System.Drawing.Size(100, 23);
            this.BtnReset.TabIndex = 6;
            this.BtnReset.Text = "Reset";
            this.BtnReset.UseVisualStyleBackColor = true;
            this.BtnReset.Click += new System.EventHandler(this.BtnReset_Click);
            // 
            // sqConnection
            // 
            this.sqConnection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sqConnection.BackColor = System.Drawing.Color.LightGray;
            this.sqConnection.Enabled = false;
            this.sqConnection.Location = new System.Drawing.Point(1289, 219);
            this.sqConnection.Name = "sqConnection";
            this.sqConnection.Size = new System.Drawing.Size(18, 18);
            this.sqConnection.TabIndex = 21;
            this.sqConnection.TabStop = false;
            this.sqConnection.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1313, 222);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Connection";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1313, 270);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 28;
            this.label3.Text = "Acquisition";
            // 
            // sqAcquisition
            // 
            this.sqAcquisition.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sqAcquisition.BackColor = System.Drawing.Color.LightGray;
            this.sqAcquisition.Enabled = false;
            this.sqAcquisition.Location = new System.Drawing.Point(1289, 267);
            this.sqAcquisition.Name = "sqAcquisition";
            this.sqAcquisition.Size = new System.Drawing.Size(18, 18);
            this.sqAcquisition.TabIndex = 27;
            this.sqAcquisition.TabStop = false;
            this.sqAcquisition.UseVisualStyleBackColor = false;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1313, 320);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 32;
            this.label5.Text = "DMA Error";
            // 
            // sqDMAError
            // 
            this.sqDMAError.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sqDMAError.BackColor = System.Drawing.Color.LightGray;
            this.sqDMAError.Enabled = false;
            this.sqDMAError.Location = new System.Drawing.Point(1289, 317);
            this.sqDMAError.Name = "sqDMAError";
            this.sqDMAError.Size = new System.Drawing.Size(18, 18);
            this.sqDMAError.TabIndex = 31;
            this.sqDMAError.TabStop = false;
            this.sqDMAError.UseVisualStyleBackColor = false;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1313, 294);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 13);
            this.label6.TabIndex = 30;
            this.label6.Text = "Acquisition Error";
            // 
            // sqAcquisitionError
            // 
            this.sqAcquisitionError.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sqAcquisitionError.BackColor = System.Drawing.Color.LightGray;
            this.sqAcquisitionError.Enabled = false;
            this.sqAcquisitionError.Location = new System.Drawing.Point(1289, 293);
            this.sqAcquisitionError.Name = "sqAcquisitionError";
            this.sqAcquisitionError.Size = new System.Drawing.Size(18, 18);
            this.sqAcquisitionError.TabIndex = 29;
            this.sqAcquisitionError.TabStop = false;
            this.sqAcquisitionError.UseVisualStyleBackColor = false;
            // 
            // sqHWError
            // 
            this.sqHWError.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sqHWError.BackColor = System.Drawing.Color.LightGray;
            this.sqHWError.Enabled = false;
            this.sqHWError.Location = new System.Drawing.Point(1289, 341);
            this.sqHWError.Name = "sqHWError";
            this.sqHWError.Size = new System.Drawing.Size(18, 18);
            this.sqHWError.TabIndex = 33;
            this.sqHWError.TabStop = false;
            this.sqHWError.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1313, 344);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 34;
            this.label2.Text = "Hardware Fault";
            // 
            // timGetStatus
            // 
            this.timGetStatus.Interval = 50;
            this.timGetStatus.Tick += new System.EventHandler(this.timGetStatus_Tick);
            // 
            // timConnRefresh
            // 
            this.timConnRefresh.Interval = 500;
            this.timConnRefresh.Tick += new System.EventHandler(this.timConnRefresh_Tick);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1313, 246);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 39;
            this.label4.Text = "Timeout";
            // 
            // sqTimeout
            // 
            this.sqTimeout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sqTimeout.BackColor = System.Drawing.Color.LightGray;
            this.sqTimeout.Enabled = false;
            this.sqTimeout.Location = new System.Drawing.Point(1289, 243);
            this.sqTimeout.Name = "sqTimeout";
            this.sqTimeout.Size = new System.Drawing.Size(18, 18);
            this.sqTimeout.TabIndex = 38;
            this.sqTimeout.TabStop = false;
            this.sqTimeout.UseVisualStyleBackColor = false;
            // 
            // lblTime
            // 
            this.lblTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTime.AutoSize = true;
            this.lblTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.Location = new System.Drawing.Point(747, 674);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(104, 22);
            this.lblTime.TabIndex = 40;
            this.lblTime.Text = "00:00:00.000";
            // 
            // timChartUpdate
            // 
            this.timChartUpdate.Interval = 200;
            this.timChartUpdate.Tick += new System.EventHandler(this.timChartUpdate_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(1411, 700);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.sqTimeout);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.sqHWError);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.sqDMAError);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.sqAcquisitionError);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.sqAcquisition);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sqConnection);
            this.Controls.Add(this.BtnReset);
            this.Controls.Add(this.LblPowerUnit);
            this.Controls.Add(this.LblAmpUnit);
            this.Controls.Add(this.LblPower);
            this.Controls.Add(this.LblAmp);
            this.Controls.Add(this.LblVolts);
            this.Controls.Add(this.BtnStopAcq);
            this.Controls.Add(this.BtnStartAcq);
            this.Controls.Add(this.BtnDisconnect);
            this.Controls.Add(this.BtnConnect);
            this.Controls.Add(this.cboxPorts);
            this.Controls.Add(this.BtnScanPorts);
            this.Controls.Add(this.LblVoltsUnit);
            this.Controls.Add(this.chart1);
            this.Name = "Form1";
            this.Text = "Micrometer Low Power Analyzer";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ds)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnScanPorts;
        private System.Windows.Forms.ComboBox cboxPorts;
        private System.Windows.Forms.Button BtnConnect;
        private System.Windows.Forms.Button BtnDisconnect;
        private System.Windows.Forms.Button BtnStartAcq;
        private System.Windows.Forms.Button BtnStopAcq;
        private System.Windows.Forms.Label LblVolts;
        private System.Windows.Forms.Label LblAmp;
        private System.Windows.Forms.Label LblPower;
        private System.Windows.Forms.Label LblVoltsUnit;
        private System.Windows.Forms.Label LblAmpUnit;
        private System.Windows.Forms.Label LblPowerUnit;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Data.DataSet ds;
        private System.Windows.Forms.Button BtnReset;
        private System.Windows.Forms.Button sqConnection;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button sqAcquisition;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button sqDMAError;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button sqAcquisitionError;
        private System.Windows.Forms.Button sqHWError;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timGetStatus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button sqTimeout;
        public System.Windows.Forms.Timer timConnRefresh;
        private System.Windows.Forms.Label lblTime;
        public System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Timer timChartUpdate;
    }
}

