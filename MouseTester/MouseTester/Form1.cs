using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

using OxyPlot;

namespace MouseTester
{
    using OxyPlot.Series;

    public partial class Form1 : Form
    {
        private RawMouse mouse = new RawMouse();
        private MouseLog mlog = new MouseLog();
        enum state { idle, measure_wait, measure, collect_wait, collect, log };
        private state test_state = state.idle;

        public Form1()
        {
            InitializeComponent();
            try {
                Process.GetCurrentProcess().ProcessorAffinity = new IntPtr(2); // Use only the second core 
                Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.RealTime; // Set highest process priority
                Thread.CurrentThread.Priority = ThreadPriority.Highest; // Set highest thread priority
            } catch (Exception ex) {
                Debug.WriteLine(ex.ToString());
            }

            this.mouse.RegisterRawInputMouse(Handle);
            this.mouse.mevent += new RawMouse.MouseEventHandler(this.logMouseEvent);
            this.textBoxDesc.Text = this.mlog.Desc.ToString();
            this.textBoxCPI.Text = this.mlog.Cpi.ToString();
            this.textBox1.Text = "Enter the correct CPI" +
                                 "\r\n        or\r\n" +
                                 "Press the Measure button" +
                                 "\r\n        or\r\n" +
                                 "Press the Load button";
            this.toolStripStatusLabel1.Text = "";
        }

        protected override void WndProc(ref Message m)
        {
            this.mouse.ProcessRawInput(m);
            base.WndProc(ref m);
        }

        public void logMouseEvent(object RawMouse, MouseEvent mevent)
        {
            //Debug.WriteLine(mevent.ts + ", " + mevent.lastx + ", " + mevent.lasty + ", " + mevent.buttons);
            if (this.test_state == state.idle)
            {

            }
            else if (this.test_state == state.measure_wait)
            {
                if (mevent.buttonflags == 0x0001)
                {
                    this.mlog.Add(mevent);
                    this.toolStripStatusLabel1.Text = "Measuring";
                    this.test_state = state.measure;
                }
            }
            else if (this.test_state == state.measure)
            {
                this.mlog.Add(mevent);
                if (mevent.buttonflags == 0x0002)
                {
                    double x = 0.0;
                    double y = 0.0;
                    double ts_min = this.mlog.Events[0].ts;
                    foreach (MouseEvent e in this.mlog.Events)
                    {
                        e.ts -= ts_min;
                        x += (double)e.lastx;
                        y += (double)e.lasty;
                    }
                    this.mlog.Cpi = Math.Round(Math.Sqrt((x * x) + (y * y)) / (10 / 2.54));
                    this.textBoxCPI.Text = this.mlog.Cpi.ToString();
                    this.textBox1.Text = "Press the Collect or Log Start button\r\n";
                    this.toolStripStatusLabel1.Text = "";
                    this.test_state = state.idle;
                }
            }
            else if (this.test_state == state.collect_wait)
            {
                if (mevent.buttonflags == 0x0001)
                {
                    this.mlog.Add(mevent);
                    this.toolStripStatusLabel1.Text = "Collecting";
                    this.test_state = state.collect;
                }
            }
            else if (this.test_state == state.collect)
            {
                this.mlog.Add(mevent);
                if (mevent.buttonflags == 0x0002)
                {
                    double ts_min = this.mlog.Events[0].ts;
                    foreach (MouseEvent e in this.mlog.Events)
                    {
                        e.ts -= ts_min;
                    }
                    this.textBox1.Text = "Press the plot button to view data\r\n" +
                                         "        or\r\n" +
                                         "Press the save button to save log file\r\n" +
                                         "Events: " + this.mlog.Events.Count.ToString() + "\r\n" +
                                         "Sum X: " + this.mlog.deltaX().ToString() + " counts    " + Math.Abs(this.mlog.deltaX() / this.mlog.Cpi * 2.54).ToString("0.0") + " cm\r\n" +
                                         "Sum Y: " + this.mlog.deltaY().ToString() + " counts    " + Math.Abs(this.mlog.deltaY() / this.mlog.Cpi * 2.54).ToString("0.0") + " cm\r\n" +
                                         "Path: " + this.mlog.path().ToString("0") + " counts    " + (this.mlog.path() / this.mlog.Cpi * 2.54).ToString("0.0") + " cm";
                    this.toolStripStatusLabel1.Text = "";
                    this.test_state = state.idle;
                }
            }
            else if (this.test_state == state.log)
            {
                this.mlog.Add(mevent);
            }
        }

        private void buttonMeasure_Click(object sender, EventArgs e)
        {
            if (this.test_state == state.idle) {
                this.textBox1.Text = "1. Press and hold the left mouse button\r\n" +
                                     "2. Move the mouse 10 cm in a straight line\r\n" +
                                     "3. Release the left mouse button\r\n";
                this.toolStripStatusLabel1.Text = "Press the left mouse button";
                this.mlog.Clear();
                this.mouse.StopWatchReset();
                this.test_state = state.measure_wait;
            }
        }
        
        private void buttonCollect_Click(object sender, EventArgs e)
        {
            if (this.test_state == state.idle)
            {
                this.textBox1.Text = "1. Press and hold the left mouse button\r\n" +
                                     "2. Move the mouse\r\n" +
                                     "3. Release the left mouse button\r\n";
                this.toolStripStatusLabel1.Text = "Press the left mouse button";
                this.mlog.Clear();
                this.mouse.StopWatchReset();
                this.test_state = state.collect_wait;
            }
        }

        private void buttonLog_Click(object sender, EventArgs e)
        {
            if (this.test_state == state.idle)
            {
                this.textBox1.Text = "1. Press the Log Stop button\r\n";
                this.toolStripStatusLabel1.Text = "Logging...";
                this.mlog.Clear();
                this.mouse.StopWatchReset();
                this.test_state = state.log;
                buttonLog.Text = "Log Stop";
            }
            else if (this.test_state == state.log)
            {
                double ts_min = this.mlog.Events[1].ts;
                foreach (MouseEvent me in this.mlog.Events)
                {
                    me.ts -= ts_min;
                }
                this.textBox1.Text = "Press the plot button to view data\r\n" +
                                     "        or\r\n" +
                                     "Press the save button to save log file\r\n" +
                                     "Events: " + this.mlog.Events.Count.ToString() + "\r\n" +
                                     "Sum X: " + this.mlog.deltaX().ToString() + " counts    " + Math.Abs(this.mlog.deltaX() / this.mlog.Cpi * 2.54).ToString("0.0") + " cm\r\n" +
                                     "Sum Y: " + this.mlog.deltaY().ToString() + " counts    " + Math.Abs(this.mlog.deltaY() / this.mlog.Cpi * 2.54).ToString("0.0") + " cm\r\n" +
                                     "Path: " + this.mlog.path().ToString("0") + " counts    " + (this.mlog.path() / this.mlog.Cpi * 2.54).ToString("0.0") + " cm";
                this.toolStripStatusLabel1.Text = "";
                this.test_state = state.idle;
                buttonLog.Text = "Log Start";
            }
        }

        private void buttonPlot_Click(object sender, EventArgs e)
        {
            if (this.mlog.Events.Count > 0)
            {
                this.mlog.Desc = textBoxDesc.Text;
                MousePlot mousePlot = new MousePlot(this.mlog);
                mousePlot.Show();
            }
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "CSV Files (*.csv)|*.csv|All Files(*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.Multiselect = false;
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.mlog.Load(openFileDialog1.FileName);
            }
            this.textBox1.Text = "Events: " + this.mlog.Events.Count.ToString() + "\r\n" +
                                 "Sum X: " + this.mlog.deltaX().ToString() + " counts    " + Math.Abs(this.mlog.deltaX() / this.mlog.Cpi * 2.54).ToString("0.0") + " cm\r\n" +
                                 "Sum Y: " + this.mlog.deltaY().ToString() + " counts    " + Math.Abs(this.mlog.deltaY() / this.mlog.Cpi * 2.54).ToString("0.0") + " cm\r\n" +
                                 "Path: " + this.mlog.path().ToString("0") + " counts    " + (this.mlog.path() / this.mlog.Cpi * 2.54).ToString("0.0") + " cm";
            this.textBoxDesc.Text = this.mlog.Desc.ToString();
            this.textBoxCPI.Text = this.mlog.Cpi.ToString();
            if (this.mlog.Events.Count > 0)
            {
                MousePlot mousePlot = new MousePlot(this.mlog);
                mousePlot.Show();
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "CSV Files (*.csv)|*.csv|All Files(*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.mlog.Desc = textBoxDesc.Text;
                this.mlog.Save(saveFileDialog1.FileName);
            }
        }

        private void textBoxCPI_Validated(object sender, EventArgs e)
        {
            try
            {
                this.mlog.Cpi = double.Parse(this.textBoxCPI.Text);
            }
            catch //(Exception ex)
            {
                MessageBox.Show("Invalid CPI, resetting to previous value");
                this.textBoxCPI.Text = this.mlog.Cpi.ToString();
            }
            this.textBox1.Text = "Press the Collect or Log Start button\r\n";
        }
    }
}
