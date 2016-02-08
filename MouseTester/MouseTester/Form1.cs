using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace MouseTester
{
    public partial class Form1 : Form
    {
        private RawMouse mouse = new RawMouse();

        private Settings settings;
        private IniFile configini;

        enum state { idle, measure_wait, measure, collect_wait, collect, log };
        private state test_state = state.idle;

        enum dualstate { disable, wait1, wait2, ready };
        private dualstate dual_state = dualstate.disable;

        private MouseLog mlog1 = new MouseLog(), mlog2 = new MouseLog();
        private MouseLog mlog;

        private TextBox textBoxCPI1, textBoxDesc1;

        private IntPtr last_released_leftclick = IntPtr.Zero;

        public Form1()
        {
            InitializeComponent();
            try 
            {
                Process.GetCurrentProcess().ProcessorAffinity = new IntPtr(2); // Use only the second core 
                Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.RealTime; // Set highest process priority
                Thread.CurrentThread.Priority = ThreadPriority.Highest; // Set highest thread priority
            } 
            catch (Exception ex) 
            {
                Debug.WriteLine(ex.ToString());
            }

            this.tabControl1.TabPages.RemoveAt(1);

            this.mlog = this.mlog1;
            this.textBoxCPI = textBoxCPI1;
            this.textBoxDesc = textBoxDesc1;

            this.mouse.RegisterRawInputMouse(Handle);
            this.mouse.mevent += new RawMouse.MouseEventHandler(this.logMouseEvent);

            this.textBox1.Text = "Enter the correct CPI" +
                                 "\r\n        or\r\n" +
                                 "Press the Measure button" +
                                 "\r\n        or\r\n" +
                                 "Press the Load button";
            this.toolStripStatusLabel1.Text = "";

            configini = new IniFile("config.ini");
            settings = Settings.Read(configini);

            this.mlog1.Cpi = settings.cpi1;
            this.mlog2.Cpi = settings.cpi2;
            this.mlog1.Desc = settings.desc1;
            this.mlog2.Desc = settings.desc2;

            this.textBoxDesc1.Text = this.mlog1.Desc.ToString();
            this.textBoxCPI1.Text = this.mlog1.Cpi.ToString();
            this.textBoxDesc2.Text = this.mlog2.Desc.ToString();
            this.textBoxCPI2.Text = this.mlog2.Cpi.ToString();

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
                if (mevent.buttonflags == 0x0002)
                    last_released_leftclick = mevent.hDevice;
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
                    //this.mlog.Add(mevent);
                    this.toolStripStatusLabel1.Text = "Collecting";
                    this.test_state = state.collect;
                }
            }
            else if (this.test_state == state.collect)
            {
                if (mevent.buttonflags == 0x0002)
                {
                    double ts_min = 0.0;

                    if (mlog1.Events.Count > 0)
                        ts_min = mlog1.Events[0].ts;

                    if (dual_state == dualstate.ready && mlog2.Events.Count > 0 && mlog2.Events[0].ts < ts_min)
                        ts_min = mlog2.Events[0].ts;

                    foreach (MouseEvent e in this.mlog1.Events)
                        e.ts -= ts_min;
                    foreach (MouseEvent e in this.mlog2.Events)
                        e.ts -= ts_min;

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
                else
                {
                    if (dual_state == dualstate.ready)
                    {
                        if (mevent.hDevice == mlog1.hDevice)
                            mlog1.Events.Add(mevent);
                        else if (mevent.hDevice == mlog2.hDevice)
                            mlog2.Events.Add(mevent);
                    }
                    else
                        this.mlog.Add(mevent);
                }
            }
            else if (this.test_state == state.log)
            {
                if (dual_state == dualstate.ready)
                {
                    if (mevent.hDevice == mlog1.hDevice)
                        mlog1.Events.Add(mevent);
                    else if (mevent.hDevice == mlog2.hDevice)
                        mlog2.Events.Add(mevent);
                }
                else
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
                this.mlog1.Clear();
                this.mlog2.Clear();
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
                this.mlog1.Clear();
                this.mlog2.Clear();
                this.mouse.StopWatchReset();
                this.test_state = state.log;
                buttonLog.Text = "Log Stop (F2)";
            }
            else if (this.test_state == state.log)
            {
                double ts_min = 0.0;

                if (mlog1.Events.Count > 0)
                    ts_min = mlog1.Events[0].ts;

                if (dual_state == dualstate.ready && mlog2.Events.Count > 0 && mlog2.Events[0].ts < ts_min)
                    ts_min = mlog2.Events[0].ts;

                foreach (MouseEvent me in this.mlog1.Events)
                    me.ts -= ts_min;
                foreach (MouseEvent me in this.mlog2.Events)
                    me.ts -= ts_min;

                this.textBox1.Text = "Press the plot button to view data\r\n" +
                                     "        or\r\n" +
                                     "Press the save button to save log file\r\n" +
                                     "Events: " + this.mlog.Events.Count.ToString() + "\r\n" +
                                     "Sum X: " + this.mlog.deltaX().ToString() + " counts    " + Math.Abs(this.mlog.deltaX() / this.mlog.Cpi * 2.54).ToString("0.0") + " cm\r\n" +
                                     "Sum Y: " + this.mlog.deltaY().ToString() + " counts    " + Math.Abs(this.mlog.deltaY() / this.mlog.Cpi * 2.54).ToString("0.0") + " cm\r\n" +
                                     "Path: " + this.mlog.path().ToString("0") + " counts    " + (this.mlog.path() / this.mlog.Cpi * 2.54).ToString("0.0") + " cm";
                this.toolStripStatusLabel1.Text = "";
                this.test_state = state.idle;
                buttonLog.Text = "Log Start (F2)";
            }
        }

        private void buttonPlot_Click(object sender, EventArgs e)
        {
            if (this.mlog1.Cpi == 0.0 || this.mlog2.Cpi == 0.0)
            {
                MessageBox.Show("CPI value is invalid, please run Measure");
                return;
            }

            if (this.mlog1.Events.Count > 0 || this.mlog2.Events.Count > 0)
            {
                this.mlog1.Desc = textBoxDesc1.Text;
                this.mlog2.Desc = textBoxDesc2.Text;

                MousePlot mousePlot = new MousePlot(this.mlog1, dual_state == dualstate.ready ? this.mlog2 : null, settings);
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

            if (this.mlog.Cpi == 0.0)
            {
                MessageBox.Show("CPI value is invalid, please run Measure");
                return;
            }

            /*if (this.mlog.Events.Count > 0)
            {
                MousePlot mousePlot = new MousePlot(this.mlog, null);
                mousePlot.Show();
            }*/
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
            this.textBox1.Text = "Press the Collect or Log Start button\r\n";
        }

        private void Numtextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;

            // only allow one decimal point
            //if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            //e.Handled = true;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            settings.cpi1 = mlog1.Cpi;
            settings.cpi2 = mlog2.Cpi;
            settings.desc1 = mlog1.Desc;
            settings.desc2 = mlog2.Desc;

            settings.Write(configini);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F2)
                buttonLog_Click(sender, e);
        }

        private void textBoxCPI1_TextChanged(object sender, EventArgs e)
        {
            this.mlog.Cpi = Convert.ToDouble(textBoxCPI.Text);
        }

        private void textBoxDesc1_TextChanged(object sender, EventArgs e)
        {
            this.mlog.Desc = textBoxDesc.Text;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage1)
            {
                this.mlog = this.mlog1;
                this.textBoxCPI = textBoxCPI1;
                this.textBoxDesc = textBoxDesc1;
            }
            else
            {
                this.mlog = this.mlog2;
                this.textBoxCPI = textBoxCPI2;
                this.textBoxDesc = textBoxDesc2;
            }
        }

        private void buttonEnableDual_MouseClick(object sender, MouseEventArgs e)
        {
            switch (dual_state)
            {
                case dualstate.ready:

                    labelID.Text = "ID: not set";
                    label2.Text = "ID: not set";
                    buttonEnableDual.Text = "Enable dual device";
                    dual_state = dualstate.disable;
                    tabControl1.TabPages.RemoveAt(1);
                    break;

                case dualstate.disable:

                    buttonEnableDual.Text = "Click here with Device 1";
                    dual_state = dualstate.wait1;
                    break;

                case dualstate.wait1:

                    buttonEnableDual.Text = "Click here with Device 2";
                    dual_state = dualstate.wait2;

                    mlog1.hDevice = last_released_leftclick;

                    labelID.Text = "ID: " + mlog1.hDevice.ToString();

                    break;

                case dualstate.wait2:

                    if (last_released_leftclick == mlog1.hDevice)
                        break;

                    mlog2.hDevice = last_released_leftclick;
                    dual_state = dualstate.ready;
                    tabControl1.TabPages.Add(tabPage2);
                    buttonEnableDual.Text = "Disable dual device";
                    label2.Text = "ID: " + mlog2.hDevice.ToString();

                    break;

                default:
                    break;

            }
        }
    }
}
