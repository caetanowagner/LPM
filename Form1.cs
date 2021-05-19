using System;
using System.Timers;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Windows.Forms.DataVisualization.Charting;
using System.Threading;
//using System.Linq;

namespace MicroMeter
{
    public partial class Form1 : Form
    {
        int dataCounter = 0;

        int[] ch1RawCurrent = new int[500000];
        int[] ch2RawCurrent = new int[500000];
        int[] ch3RawCurrent = new int[500000];
        int[] ch1RawVoltage = new int[500000];

        int[] ch1SmothCurrent = new int[500000];
        int[] ch2SmothCurrent = new int[500000];
        int[] ch3SmothCurrent = new int[500000];
        int[] ch1SmothVoltage = new int[500000];

        const string USB_BLINK_LED = "0";
        const string USB_REFRESH_CONN = "1";
        const string USB_GET_STATUS = "2";
        const string USB_START_ACQUISITION = "3";
        const string USB_STOP_ACQUISITION = "4";
        const string USB_ERROR_ACQUISITION = "5";
        const string USB_RESET_FAULTS = "6";
        const string USB_RESET_DEVICE = "7";

        /*	Device to host status	*/
        const int DEVICE_ACQ_STATUS = 0x01;		//	1 = acquisition on, 0 = acquisition off
        const int DEVICE_TIMEOUT = 0x02;		//
        const int DEVICE_ACQ_ERROR = 0x04;		//  1 = acquisition error
        const int DEVICE_ADC_DMA_ERROR = 0x08;		//  1 = ADC DMA error
        const int DEVICE_NMI_Handler = 0x10;
        const int DEVICE_HardFault_Handler = 0x20;
        const int DEVICE_MemManage_Handler = 0x40;
        const int DEVICE_BusFault_Handler = 0x80;
        const int DEVICE_UsageFault_Handler = 0x100;
        const int DEVICE_ERROR_HANDLER = 0x200;
        const int DEVICE_RESERVED2 = 0x400;
        const int DEVICE_RESERVED3 = 0x800;
        const int DEVICE_RESERVED4 = 0x1000;
        const int DEVICE_RESERVED5 = 0x2000;
        const int DEVICE_RESERVED6 = 0x4000;
        const int DEVICE_RESERVED7 = 0x8000;

        DateTime acquisitionStarted;


        int deviceStatus = 0;
        int connCounter = 0;
        int i = 0;
        //bool getStatus = false;
        //bool setTimeout = false;
        //bool setAcquisition = false;

        DataTable RawData = new DataTable("Raw");
        DataTable SmothData = new DataTable("Smoth");

        public Form1()
        {
            InitializeComponent();

            RawData.Columns.Add("X");
            RawData.Columns.Add("Voltage");
            RawData.Columns.Add("I_ch1");
            RawData.Columns.Add("I_ch2");
            RawData.Columns.Add("I_ch3");
            RawData.Columns.Add("Power");

            SmothData.Columns.Add("X");
            SmothData.Columns.Add("Voltage");
            SmothData.Columns.Add("I_ch1");
            SmothData.Columns.Add("I_ch2");
            SmothData.Columns.Add("I_ch3");
            SmothData.Columns.Add("Power");


            //ds.Tables.Add(SmothData);

            //chart1.DataSource = ds.Tables[0];


        }

        private void updateChart()
        {
            this.Invoke((Action)delegate ()
            {
                chart1.Refresh();
            });
            //string message = String.Format("Update chart thread: {0}", threadCounter.ToString());
            //System.Diagnostics.Debug.WriteLine(message);
            //threadCounter++;
            Thread.Sleep(300);
        }
        private void ScanPorts()
        {
            cboxPorts.Items.Clear();
            cboxPorts.Text = "";
            string[] scanPorts = SerialPort.GetPortNames();
            cboxPorts.Items.AddRange(scanPorts);
            if (cboxPorts.Items.Count >= 1)
                cboxPorts.SelectedIndex = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ScanPorts();
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            chart1.Series[2].Points.Clear();
            chart1.Series[3].Points.Clear();

            chart1.Series[0].Color = Color.Blue;
            chart1.Series[1].Color = Color.Green;
            chart1.Series[2].Color = Color.Yellow;
            chart1.Series[3].Color = Color.Red;

            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.ChartAreas[0].AxisX.Maximum = 500000;
            chart1.ChartAreas[0].AxisY.Minimum = 0;
            chart1.ChartAreas[0].AxisY.Maximum = 4200;

            chart1.ChartAreas[0].AxisX.IsMarginVisible = false;
            chart1.Series[0].Points.AddXY(0, ch1RawVoltage[0]);
            chart1.Refresh();
        }

        private void BtnScanPorts_Click(object sender, EventArgs e)
        {
            ScanPorts();
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int dataLen = serialPort1.BytesToRead;
            byte[] dataReceived = new byte[dataLen];
            int nbrDataRead = serialPort1.Read(dataReceived, 0, dataLen);

            //bool _timStatus = false;

            if (nbrDataRead > 0)
            {
                int _val = (Int32)BitConverter.ToInt16(dataReceived, 0);

                if ((nbrDataRead <= 2) && (_val == DEVICE_ACQ_STATUS) && (deviceStatus == 0))
                {
                    deviceStatus = _val;
                    UpdateDevStatus();

                    this.Invoke((Action)delegate ()
                    {
                        timChartUpdate.Start();
                    });

                    //timChartUpdate.Start();
                }
                else if ((nbrDataRead > 50))// && (deviceStatus == DEVICE_ACQ_STATUS))
                {
                    deviceStatus = 1;
                    int _nbrDataRead = nbrDataRead / 8;
                    ++connCounter;
                    //System.Diagnostics.Debug.WriteLine(connCounter.ToString());

                    this.Invoke((Action)delegate ()
                    {
                        chart1.Series.SuspendUpdates(); //before adding my points, then calling

                        timConnRefresh.Start();

                        for (i = 0; i < (dataLen / 8); i++)
                        {
                            if (dataCounter >= 500000 - 1)
                            {

                                chart1.Refresh();
                                deviceStatus &= ~DEVICE_ACQ_STATUS;
                                serialPort1.WriteLine(USB_STOP_ACQUISITION);
                                chart1.Series.ResumeUpdates(); //followed by 
                                chart1.Series.Invalidate();



                                dataCounter = 0;
                                //chart1.Series[0].Points.Clear();
                                //chart1.Series[1].Points.Clear();
                                //chart1.Series[2].Points.Clear();
                                //chart1.Series[3].Points.Clear();
                            }

                            ch1RawVoltage[dataCounter] = (Int32)BitConverter.ToInt16(dataReceived, (i * 8));
                            ch1RawCurrent[dataCounter] = (Int32)BitConverter.ToInt16(dataReceived, (i * 8) + 2);
                            ch2RawCurrent[dataCounter] = (Int32)BitConverter.ToInt16(dataReceived, (i * 8) + 4);
                            ch3RawCurrent[dataCounter] = (Int32)BitConverter.ToInt16(dataReceived, (i * 8) + 6);

                            //chart1.Series.SuspendUpdates(); //before adding my points, then calling
                            //chart1.Series.ResumeUpdates(); //followed by 
                            //chart1.Series.Invalidate();

                            chart1.Series[0].Points.AddXY(dataCounter, ch1RawVoltage[dataCounter]);
                            chart1.Series[1].Points.AddXY(dataCounter, ch1RawCurrent[dataCounter]);
                            chart1.Series[2].Points.AddXY(dataCounter, ch2RawCurrent[dataCounter]);
                            chart1.Series[3].Points.AddXY(dataCounter, ch3RawCurrent[dataCounter]);

                            dataCounter++;
                        }

                        //https://social.msdn.microsoft.com/Forums/vstudio/en-US/09135316-3867-405b-aae8-b1e2907281b9/poor-realtime-performance-of-the-mschart-control?forum=MSWinWebChart
                        //https://docs.microsoft.com/pt-br/archive/blogs/alexgor/microsoft-chart-control-how-to-improve-chart-performance
                        //https://www.codeproject.com/Articles/17564/Simple-Performance-Chart
                        //http://www.genlogic.com/free_community_edition.html
                        //chart1.Refresh();

                    });

                }
                else if (nbrDataRead <= 2)
                {
                    deviceStatus = _val;
                    UpdateDevStatus();
                }
            }
        }

        private void BtnConnect_Click(object sender, EventArgs e)
        {

            if (cboxPorts.SelectedItem != null)
            {
                connCounter = 1;
                //connCounterHist = 0;

                try
                {
                    serialPort1.PortName = cboxPorts.SelectedItem.ToString();
                    serialPort1.Open();
                    sqConnection.BackColor = Color.Green;
                    timGetStatus.Start();
                    //System.Diagnostics.Debug.WriteLine("Comport connected");

                }
                catch (Exception)
                {
                    string message = string.Format("Could not connect to {0} serial port.", cboxPorts.SelectedItem.ToString());
                    MessageBox.Show(message, "Serial Connection", MessageBoxButtons.OK);
                    //throw;
                }
            }
            else
                MessageBox.Show("Select com port before connecting.", "Serial Connection", MessageBoxButtons.OK);
        }

        private void BtnDisconnect_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                if ((deviceStatus & DEVICE_ACQ_STATUS) == DEVICE_ACQ_STATUS)
                {
                    serialPort1.WriteLine(USB_STOP_ACQUISITION);
                    deviceStatus = 0;
                }

                UpdateDevStatus();
                serialPort1.Close();
                sqConnection.BackColor = Color.LightGray;
            }
        }

        private void BtnStartAcq_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen && (deviceStatus == 0))
            {
                acquisitionStarted = DateTime.Now;

                clearChartSeries();
                serialPort1.WriteLine(USB_START_ACQUISITION);
                timConnRefresh.Start();
            }

        }

        private void BtnStopAcq_Click(object sender, EventArgs e)
        {
            TimeSpan _loop = DateTime.Now - acquisitionStarted;
            string _timespan = _loop.ToString();
            _timespan = _timespan.Substring(3, 9);
            lblTime.Text = _timespan;
            timChartUpdate.Interval = 200;

            this.Invoke((Action)delegate ()
            {
                timChartUpdate.Stop();

            });

            if (serialPort1.IsOpen)
            {
                serialPort1.WriteLine(USB_STOP_ACQUISITION);
                timConnRefresh.Stop();

                if (dataCounter > 1)
                {
                    chart1.ChartAreas[0].AxisX.Minimum = 0;
                    chart1.ChartAreas[0].AxisX.Maximum = dataCounter;
                    chart1.Refresh();
                }
                if (!timGetStatus.Enabled) timGetStatus.Start();
            }
            dataCounter = 0;
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            dataCounter = 0;
            if (serialPort1.IsOpen)
            {
                serialPort1.WriteLine(USB_RESET_FAULTS);
                timGetStatus.Start();
            }
        }

        private void timGetStatus_Tick(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                timGetStatus.Stop();


                serialPort1.WriteLine(USB_GET_STATUS);
            }
        }

        private void timConnRefresh_Tick(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                if ((deviceStatus == DEVICE_ACQ_STATUS) && (connCounter < 1))
                {
                    try
                    {
                        serialPort1.WriteLine(USB_GET_STATUS);
                        timGetStatus.Start();
                    }
                    catch (TimeoutException ex)
                    {
                        string message = string.Format("Tim_connRefresh deviceStatus = 0");
                        Console.WriteLine(ex);
                    }

                }
                else if ((deviceStatus == DEVICE_ACQ_STATUS) && (connCounter >= 1))
                {
                    try
                    {
                        serialPort1.WriteLine(USB_REFRESH_CONN);
                        //string message = string.Format("Acquisition counter: {0}", connCounter.ToString());
                        //System.Diagnostics.Debug.WriteLine(message);
                        connCounter = 1;
                    }
                    catch (Exception)
                    {
                        System.Diagnostics.Debug.WriteLine("usb write timeout");
                    }

                }
                else
                {
                    //serialPort1.WriteLine(USB_ERROR_ACQUISITION);
                    //System.Diagnostics.Debug.WriteLine("Timer error");
                    timConnRefresh.Stop();
                    //timGetStatus.Start();
                }
            }
        }

        private void UpdateDevStatus()
        {
            if ((deviceStatus & DEVICE_ACQ_STATUS) == DEVICE_ACQ_STATUS)
                sqAcquisition.BackColor = Color.Green;
            else
                sqAcquisition.BackColor = Color.LightGray;

            if ((deviceStatus & DEVICE_TIMEOUT) == DEVICE_TIMEOUT)
                sqTimeout.BackColor = Color.Green;
            else
                sqTimeout.BackColor = Color.LightGray;

            if ((deviceStatus & DEVICE_ACQ_ERROR) == DEVICE_ACQ_ERROR)
                sqAcquisitionError.BackColor = Color.Green;
            else
                sqAcquisitionError.BackColor = Color.LightGray;

            if ((deviceStatus & DEVICE_ADC_DMA_ERROR) == DEVICE_ADC_DMA_ERROR)
                sqDMAError.BackColor = Color.Green;
            else
                sqDMAError.BackColor = Color.LightGray;

            if (deviceStatus >= 0x10)
                sqHWError.BackColor = Color.Green;
            else
                sqHWError.BackColor = Color.LightGray;
        }

        private void timChartUpdate_Tick(object sender, EventArgs e)
        {


            TimeSpan _loop = DateTime.Now - acquisitionStarted;
            string _timespan = _loop.ToString();
            _timespan = _timespan.Substring(3, 9);
            lblTime.Text = _timespan;

            if (dataCounter > 250000)
                timChartUpdate.Interval = 1000;
            else if (dataCounter > 200000)
                timChartUpdate.Interval = 800;
            else if (dataCounter > 150000)
                timChartUpdate.Interval = 600;
            else if (dataCounter > 100000)
                timChartUpdate.Interval = 400;
            else if (dataCounter > 50000)
                timChartUpdate.Interval = 200;
            else
                timChartUpdate.Interval = 100;

            if (dataCounter >=50000)
                chart1.ChartAreas[0].AxisX.Minimum = dataCounter-50000;

            chart1.ChartAreas[0].AxisX.Maximum = dataCounter;
            chart1.Refresh();
        }

        private void clearChartSeries()
        {
            if (chart1.Series.Count > 0)
            {
                //Remove all series
                while (chart1.Series.Count > 0)
                {
                    chart1.Series.RemoveAt(0);
                }

                //Add series
                chart1.Series.Add("Voltage");
                chart1.Series.Add("I_Ch1");
                chart1.Series.Add("I_Ch2");
                chart1.Series.Add("I_Ch3");

                //Series color
                chart1.Series[0].Color = Color.Blue;
                chart1.Series[1].Color = Color.Green;
                chart1.Series[2].Color = Color.Yellow;
                chart1.Series[3].Color = Color.Red;

                //Series axis values
                chart1.ChartAreas[0].AxisX.Minimum = 0;
                chart1.ChartAreas[0].AxisX.Maximum = 500000;
                chart1.ChartAreas[0].AxisY.Minimum = 0;
                chart1.ChartAreas[0].AxisY.Maximum = 4200;

                //Series type
                for (int i = 0; i < chart1.Series.Count; i++)
                {
                    chart1.Series[i].ChartType = SeriesChartType.FastLine;
                }

                chart1.ChartAreas[0].AxisX.IsMarginVisible = false;
                //chart1.Series[0].Points.AddXY(0, ch1RawVoltage[0]);
                chart1.Refresh();
            }
        }




        //private void AddScaleBreaks()
        //{

        //    // Enable scale breaks.  

        //    chart1.Series[0].Points.AddXY(1, 1);
        //    chart1.Series[0].Points.AddXY(10, 10);

        //    chart1.ChartAreas[0].AxisY.ScaleBreakStyle.Enabled = true;
        //    //chart1.ChartAreas[1].AxisY.ScaleBreakStyle.Enabled = true;
        //    //chart1.ChartAreas[2].AxisY.ScaleBreakStyle.Enabled = true;
        //    //chart1.ChartAreas[3].AxisY.ScaleBreakStyle.Enabled = true;
        //    //chart1.ChartAreas[4].AxisY.ScaleBreakStyle.Enabled = true;

        //    //chart1.ChartAreas["Series1"].AxisY.ScaleBreakStyle.Enabled = true;
        //    //chart1.ChartAreas["I_ch1"].AxisY.ScaleBreakStyle.Enabled = true;
        //    //chart1.ChartAreas["I_ch2"].AxisY.ScaleBreakStyle.Enabled = true;
        //    //chart1.ChartAreas["I_ch2"].AxisY.ScaleBreakStyle.Enabled = true;
        //    //chart1.ChartAreas["Power"].AxisY.ScaleBreakStyle.Enabled = true;

        //    //// Show scale break if more than 25% of the chart is empty space.  
        //    chart1.ChartAreas[0].AxisY.ScaleBreakStyle.CollapsibleSpaceThreshold = 25;
        //    //chart1.ChartAreas["I_ch1"].AxisY.ScaleBreakStyle.CollapsibleSpaceThreshold = 25;
        //    //chart1.ChartAreas["I_ch2"].AxisY.ScaleBreakStyle.CollapsibleSpaceThreshold = 25;
        //    //chart1.ChartAreas["I_ch3"].AxisY.ScaleBreakStyle.CollapsibleSpaceThreshold = 25;
        //    //chart1.ChartAreas["Power"].AxisY.ScaleBreakStyle.CollapsibleSpaceThreshold = 25;

        //    //// Set the line width of the scale break.  
        //    chart1.ChartAreas[0].AxisY.ScaleBreakStyle.LineWidth = 2;
        //    //chart1.ChartAreas["I_ch1"].AxisY.ScaleBreakStyle.LineWidth = 2;
        //    //chart1.ChartAreas["I_ch2"].AxisY.ScaleBreakStyle.LineWidth = 2;
        //    //chart1.ChartAreas["I_ch3"].AxisY.ScaleBreakStyle.LineWidth = 2;
        //    //chart1.ChartAreas["Power"].AxisY.ScaleBreakStyle.LineWidth = 2;

        //    //// Set the color of the scale break.  
        //    chart1.ChartAreas[0].AxisY.ScaleBreakStyle.LineColor = Color.Red;
        //    //chart1.ChartAreas["I_ch1"].AxisY.ScaleBreakStyle.LineColor = Color.Red;
        //    //chart1.ChartAreas["I_ch2"].AxisY.ScaleBreakStyle.LineColor = Color.Red;
        //    //chart1.ChartAreas["I_ch3"].AxisY.ScaleBreakStyle.LineColor = Color.Red;
        //    //chart1.ChartAreas["Power"].AxisY.ScaleBreakStyle.LineColor = Color.Red;

        //    //// If all data points are significantly far from zero, the chart will calculate the scale minimum value.  
        //    chart1.ChartAreas[0].AxisY.ScaleBreakStyle.StartFromZero = StartFromZero.Auto;
        //    //chart1.ChartAreas["I_ch1"].AxisY.ScaleBreakStyle.StartFromZero = StartFromZero.Auto;
        //    //chart1.ChartAreas["I_ch2"].AxisY.ScaleBreakStyle.StartFromZero = StartFromZero.Auto;
        //    //chart1.ChartAreas["I_ch3"].AxisY.ScaleBreakStyle.StartFromZero = StartFromZero.Auto;
        //    //chart1.ChartAreas["Power"].AxisY.ScaleBreakStyle.StartFromZero = StartFromZero.Auto;

        //    //// Set the spacing gap between the lines of the scale break (as a percentage of the Y-axis).  
        //    chart1.ChartAreas[0].AxisY.ScaleBreakStyle.Spacing = 2;
        //    //chart1.ChartAreas["I_ch1"].AxisY.ScaleBreakStyle.Spacing = 2;
        //    //chart1.ChartAreas["I_ch2"].AxisY.ScaleBreakStyle.Spacing = 2;
        //    //chart1.ChartAreas["I_ch3"].AxisY.ScaleBreakStyle.Spacing = 2;
        //    //chart1.ChartAreas["Power"].AxisY.ScaleBreakStyle.Spacing = 2;
        //}

        //private void BtnScaleBreak_Click(object sender, EventArgs e)
        //{
        //    CreateLine();
        //    //AddScaleBreaks();
        //}


    }
}


