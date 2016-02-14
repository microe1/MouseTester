﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.Windows.Forms;

using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.WindowsForms;

namespace MouseTester
{
    public partial class MousePlot : Form
    {
        private Settings settings;
        private GraphComponents BlueComponent, RedComponent, GreenComponent, YellowComponent;
        private MouseLog mlog, mlog2;
        private List<MouseEvent> events = new List<MouseEvent>();
        private int last_start;
        private int last_end;
        double x_min;
        double x_max;
        double y_min;
        double y_max;
        private bool dual = false;

        #region LOADING
        public MousePlot(MouseLog Mlog, MouseLog Mlog2, Settings settings)
        {
            this.settings = settings;

            InitializeComponent();

            this.mlog = Mlog;
            this.mlog2 = Mlog2;
            if (mlog2 != null && mlog2.Events.Count != 0)
                dual = true;

            IndexMouseLogs();

            this.last_start = 0;
            this.last_end = events.Count - 1;
            initialize_plot();

            GraphType[] grapthtypes = 
            {
                new GraphType("xCount vs. Time", "Time (ms)", "xCounts", GraphType.GT.normal, plot_xcounts_vs_time),
                new GraphType("yCount vs. Time", "Time (ms)", "yCounts", GraphType.GT.normal, plot_ycounts_vs_time),
                new GraphType("xyCount vs. Time", "Time (ms)", "Counts", GraphType.GT.dual, plot_xycounts_vs_time),
                new GraphType("Interval vs. Time", "Time (ms)", "Update Time (ms)", GraphType.GT.normal, plot_interval_vs_time),
                new GraphType("Frequency vs. Time", "Time (ms)", "Frequency (Hz)", GraphType.GT.normal, plot_frequency_vs_time),
                new GraphType("xVelocity vs. Time", "Time (ms)", "xVelocity (m/s)", GraphType.GT.normal, plot_xvelocity_vs_time),
                new GraphType("yVelocity vs. Time", "Time (ms)", "yVelocity (m/s)", GraphType.GT.normal, plot_yvelocity_vs_time),
                new GraphType("xyVelocity vs. Time", "Time (ms)", "Velocity (m/s)", GraphType.GT.dual, plot_xyvelocity_vs_time),
                new GraphType("xSum vs. Time", "Time (ms)", "xSum (m/s)", GraphType.GT.normal, plot_xsum_vs_time),
                new GraphType("ySum vs. Time", "Time (ms)", "ySum (m/s)", GraphType.GT.normal, plot_ysum_vs_time),
                new GraphType("xySum vs. Time", "Time (ms)", "Sum (m/s)", GraphType.GT.dual, plot_xysum_vs_time),
                new GraphType("X vs. Y", "xCounts", "yCounts", GraphType.GT.nolines, plot_x_vs_y),
            };

            foreach (GraphType type in grapthtypes)
                comboBoxPlotType.Items.Add(type);

            this.comboBoxPlotType.SelectedIndex = 0;

            this.groupBox4.Enabled = dual;

            this.numericUpDownStart.Minimum = 0;
            this.numericUpDownStart.Maximum = last_end;
            this.numericUpDownStart.Value = last_start;
            this.numericUpDownStart.ValueChanged += new EventHandler(this.numericUpDownStart_ValueChanged);

            this.numericUpDownEnd.Minimum = 0;
            this.numericUpDownEnd.Maximum = last_end;
            this.numericUpDownEnd.Value = last_end;
            this.numericUpDownEnd.ValueChanged += new EventHandler(this.numericUpDownEnd_ValueChanged);

            checkBoxLines.Checked = settings.lines;
            checkBoxBgnd.Checked = settings.transparent;
            checkBoxSize.Checked = settings.fixedsize;
            checkBoxStem.Checked = settings.stem;

            if (settings.maximized)
                this.WindowState = FormWindowState.Maximized;
            else
            {
                Rectangle wa = Screen.PrimaryScreen.WorkingArea;

                if (settings.xpos + Size.Width > wa.Right)
                    settings.xpos = wa.Right - Size.Width;
                if (settings.ypos + Size.Height > wa.Bottom)
                    settings.ypos = wa.Bottom - Size.Height;

                if (settings.xpos < 0)
                    settings.xpos = 0;
                if (settings.ypos < 0)
                    settings.ypos = 0;

                this.Location = new Point(settings.xpos, settings.ypos);
            }

            if (settings.plotindex >= 0 && settings.plotindex < comboBoxPlotType.Items.Count)
                comboBoxPlotType.SelectedIndex = settings.plotindex;

            this.checkBoxLines.CheckedChanged += new EventHandler(this.Refresh_Plot_Helper);
            this.checkBoxStem.CheckedChanged += new EventHandler(this.Refresh_Plot_Helper);
            this.comboBoxPlotType.SelectedIndexChanged += new EventHandler(this.Refresh_Plot_Helper);
            refresh_plot();
        }

        private void IndexMouseLogs()
        {
            mlog.Events.Sort((x,y) => x.ts.CompareTo(y.ts));

            if (mlog.Events.Count > 0)
                mlog.Events[0].lastts = 0;

            for (int i = 1; i < mlog.Events.Count; ++i)
            {
                mlog.Events[i].hDevice = mlog.hDevice;
                mlog.Events[i].lastts = mlog.Events[i - 1].ts;
            }

            if (!dual)
                foreach (MouseEvent ev in mlog.Events)
                    events.Add(ev);
            else
            {
                mlog2.Events.Sort((x,y) => x.ts.CompareTo(y.ts));

                if (mlog2.Events.Count > 0)
                    mlog2.Events[0].lastts = 0;

                for (int i = 1; i < mlog2.Events.Count; ++i)
                {
                    mlog2.Events[i].hDevice = mlog2.hDevice;
                    mlog2.Events[i].lastts = mlog2.Events[i - 1].ts;
                }

                int i1 = 0, i2 = 0;

                while (i1 < mlog.Events.Count && i2 < mlog2.Events.Count)
                {   // it could have been written in one line, but it would kill readability and i doubt performance advantage
                    MouseEvent min = null;
                    if (i1 == mlog.Events.Count)
                        min = mlog2.Events[i2++];
                    else if (i2 == mlog2.Events.Count)
                        min = mlog2.Events[i1++];
                    else
                        min = mlog.Events[i1].ts < mlog2.Events[i2].ts ? mlog.Events[i1++] : mlog2.Events[i2++];

                    events.Add(min);
                }

                for (; i1 < mlog.Events.Count; ++i1)
                    events.Add(mlog.Events[i1]);

                for (; i2 < mlog2.Events.Count; ++i2)
                    events.Add(mlog2.Events[i2]);
            }
        }

        private void initialize_plot()
        {
            var pm = new PlotModel()
            {
                Title = mlog.Desc + (dual ? " vs. " + mlog2.Desc : ""),
                Subtitle = PlotSubtitle(),
                PlotType = PlotType.Cartesian,
                Background = OxyColors.White
            };
            plot1.Model = pm;
        }
        #endregion

        #region REFRESH
        private void refresh_plot()
        {
            PlotModel pm = plot1.Model;
            pm.Series.Clear();
            pm.Axes.Clear();

            ResetPlotComponents();

            if (checkBoxLines.Checked)
            {
                BlueComponent.lines.Smooth = false;
                RedComponent.lines.Smooth = false;

                if (dual)
                {
                    GreenComponent.lines.Smooth = false;
                    YellowComponent.lines.Smooth = false;
                }
            }

            GraphType type = comboBoxPlotType.SelectedItem as GraphType;
            if (type == null)
            {
                MessageBox.Show("Something bad happened! SelectedItem is null...");
                return;
            }
            else
            {
                reset_minmax();

                type.PlotFunc(mlog, 0.0, BlueComponent, RedComponent);
                if (type.DualGraph == GraphType.GT.nolines)
                    BlueComponent.Add(pm, checkBoxLines.Checked);
                else
                {
                    BlueComponent.Add(pm, checkBoxLines.Checked, checkBoxStem.Checked);
                    if (type.DualGraph == GraphType.GT.dual)
                        RedComponent.Add(pm, checkBoxLines.Checked, checkBoxStem.Checked);
                }

                if (dual)
                {
                    type.PlotFunc(mlog2, -(double)numericUpDownDelay.Value, GreenComponent, YellowComponent);
                    if (type.DualGraph == GraphType.GT.nolines)
                        GreenComponent.Add(pm, checkBoxLines.Checked);
                    else
                    {
                        GreenComponent.Add(pm, checkBoxLines.Checked, checkBoxStem.Checked);
                        if (type.DualGraph == GraphType.GT.dual)
                            YellowComponent.Add(pm, checkBoxLines.Checked, checkBoxStem.Checked);
                    }
                }

            }

            var linearAxis1 = new LinearAxis();
            linearAxis1.AbsoluteMinimum = x_min - (x_max - x_min) / 20.0;
            linearAxis1.AbsoluteMaximum = x_max + (x_max - x_min) / 20.0;
            linearAxis1.MajorGridlineColor = OxyColor.FromArgb(40, 0, 0, 139);
            linearAxis1.MajorGridlineStyle = LineStyle.Solid;
            linearAxis1.MinorGridlineColor = OxyColor.FromArgb(20, 0, 0, 139);
            linearAxis1.MinorGridlineStyle = LineStyle.Solid;
            linearAxis1.Position = AxisPosition.Bottom;
            linearAxis1.Title = type.AxisX;
            pm.Axes.Add(linearAxis1);

            var linearAxis2 = new LinearAxis();
            linearAxis2.AbsoluteMinimum = y_min - (y_max - y_min) / 20.0;
            linearAxis2.AbsoluteMaximum = y_max + (y_max - y_min) / 20.0;
            linearAxis2.MajorGridlineColor = OxyColor.FromArgb(40, 0, 0, 139);
            linearAxis2.MajorGridlineStyle = LineStyle.Solid;
            linearAxis2.MinorGridlineColor = OxyColor.FromArgb(20, 0, 0, 139);
            linearAxis2.MinorGridlineStyle = LineStyle.Solid;
            linearAxis2.Title = type.AxisY;
            pm.Axes.Add(linearAxis2);

            plot1.RefreshPlot(true);
        }

        private void ResetPlotComponents()
        {
            BlueComponent = new GraphComponents(OxyColors.Blue);
            RedComponent = new GraphComponents(OxyColors.Red);
            if (dual)
            {
                GreenComponent = new GraphComponents(OxyColors.Green);
                YellowComponent = new GraphComponents(OxyColors.Orange);
            }
        }

        private void reset_minmax()
        {
            x_min = double.MaxValue;
            x_max = double.MinValue;
            y_min = double.MaxValue;
            y_max = double.MinValue;
        }
        private void update_minmax(double x, double y)
        {
            if (x < x_min)
                x_min = x;
            if (x > x_max)
                x_max = x;

            if (y < y_min)
                y_min = y;
            if (y > y_max)
                y_max = y;
        }

        private string PlotSubtitle()
        {
            return mlog.Cpi.ToString() + " cpi" + (dual ? " vs. " + mlog2.Cpi.ToString() + " cpi" + " & " + numericUpDownDelay.Value.ToString("+#.#;-#.#;0", CultureInfo.InvariantCulture) + " ms delay" : "");
        }

        private void Refresh_Plot_Helper(object sender, EventArgs e)
        {
            refresh_plot();
        }
        #endregion

        #region UI CALLBACKS
        private void numericUpDownStart_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDownStart.Value >= numericUpDownEnd.Value)
                numericUpDownStart.Value = last_start;
            else
            {
                last_start = (int)numericUpDownStart.Value;
                refresh_plot();
            }
        }
        private void numericUpDownEnd_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDownEnd.Value <= numericUpDownStart.Value)
                numericUpDownEnd.Value = last_end;
            else
            {
                last_end = (int)numericUpDownEnd.Value;
                refresh_plot();
            }
        }
        private void numericUpDownDelay_ValueChanged(object sender, EventArgs e)
        {
            plot1.Model.Subtitle = PlotSubtitle();
            refresh_plot();
        }

        private void MousePlot_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
                settings.maximized = false;
            else if (this.WindowState == FormWindowState.Maximized)
                settings.maximized = true;
        }

        private void MousePlot_FormClosing(object sender, FormClosingEventArgs e)
        {
            settings.lines = checkBoxLines.Checked;
            settings.transparent = checkBoxBgnd.Checked;
            settings.fixedsize = checkBoxSize.Checked;
            settings.stem = checkBoxStem.Checked;

            settings.plotindex = comboBoxPlotType.SelectedIndex;

            settings.xpos = Location.X;
            settings.ypos = Location.Y;
        }

        private void buttonSavePNG_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "PNG Files (*.png)|*.png";
            saveFileDialog1.FilterIndex = 1;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                int width = checkBoxSize.Checked ? 800 : (int)this.plot1.Model.Width;
                int height = checkBoxSize.Checked ? 600 : (int)this.plot1.Model.Height;
                Brush backgnd = checkBoxBgnd.Checked ? null : new SolidBrush(Color.White);

                MousePlot.Export(this.plot1.Model, saveFileDialog1.FileName, width, height, backgnd);
            }
        }
        #endregion

        #region PLOT FUNCTIONS
        private void plot_xcounts_vs_time(MouseLog mlog, double delay, GraphComponents main_comp, GraphComponents sec_comp)
        {
            for (int i = last_start; i <= last_end; i++)
            {
                if (events[i].hDevice != mlog.hDevice)
                    continue;

                double x = events[i].ts + delay;
                double y = events[i].lastx;
                update_minmax(x, y);
                main_comp.Add(x, y);
            }
        }
        private void plot_ycounts_vs_time(MouseLog mlog, double delay, GraphComponents main_comp, GraphComponents sec_comp)
        {
            for (int i = last_start; i <= last_end; i++)
            {
                if (events[i].hDevice != mlog.hDevice)
                    continue;

                double x = events[i].ts + delay;
                double y = events[i].lasty;
                update_minmax(x, y);
                main_comp.Add(x, y);
            }
        }
        private void plot_xycounts_vs_time(MouseLog mlog, double delay, GraphComponents main_comp, GraphComponents sec_comp)
        {
            for (int i = last_start; i <= last_end; i++)
            {
                if (events[i].hDevice != mlog.hDevice)
                    continue;

                double x = events[i].ts + delay;
                double y = events[i].lastx;
                update_minmax(x, y);
                main_comp.Add(x, y);
            }

            for (int i = last_start; i <= last_end; i++)
            {
                if (events[i].hDevice != mlog.hDevice)
                    continue;

                double x = events[i].ts + delay;
                double y = events[i].lasty;
                update_minmax(x, y);
                sec_comp.Add(x, y);
            }
        }
        private void plot_interval_vs_time(MouseLog mlog, double delay, GraphComponents main_comp, GraphComponents sec_comp)
        {
            for (int i = last_start; i <= last_end; i++)
            {
                if (events[i].hDevice != mlog.hDevice)
                    continue;

                double x = events[i].ts;
                double y;
                if (i == 0)
                    y = 0.0;
                else
                    y = events[i].ts - events[i].lastts;

                update_minmax(x, y);
                main_comp.Add(x, y);
            }
        }
        private void plot_frequency_vs_time(MouseLog mlog, double delay, GraphComponents main_comp, GraphComponents sec_comp)
        {
            for (int i = last_start; i <= last_end; i++)
            {
                if (events[i].hDevice != mlog.hDevice)
                    continue;

                double x = events[i].ts;
                double y;
                if (i == 0)
                    y = 0.0;
                else
                    y = 1000.0 / (events[i].ts - events[i].lastts);

                update_minmax(x, y);
                main_comp.Add(x, y);
            }
        }
        private void plot_xvelocity_vs_time(MouseLog mlog, double delay, GraphComponents main_comp, GraphComponents sec_comp)
        {
            if (mlog.Cpi > 0)
            {
                for (int i = last_start; i <= last_end; i++)
                {
                    if (events[i].hDevice != mlog.hDevice)
                        continue;

                    double x = events[i].ts + delay;
                    double y;
                    if (i == 0)
                        y = 0.0;
                    else
                        y = (events[i].lastx) / (events[i].ts - events[i].lastts) / mlog.Cpi * 25.4;

                    update_minmax(x, y);
                    main_comp.Add(x, y);
                }
            }
            else
                MessageBox.Show("CPI value is invalid, please run Measure");
        }
        private void plot_yvelocity_vs_time(MouseLog mlog, double delay, GraphComponents main_comp, GraphComponents sec_comp)
        {
            if (mlog.Cpi > 0)
            {
                for (int i = last_start; i <= last_end; i++)
                {
                    if (events[i].hDevice != mlog.hDevice)
                        continue;

                    double x = events[i].ts + delay;
                    double y;
                    if (i == 0)
                        y = 0.0;
                    else
                        y = (events[i].lasty) / (events[i].ts - events[i].lastts) / mlog.Cpi * 25.4;

                    update_minmax(x, y);
                    main_comp.Add(x, y);
                }
            }
            else
                MessageBox.Show("CPI value is invalid, please run Measure");
        }
        private void plot_xyvelocity_vs_time(MouseLog mlog, double delay, GraphComponents main_comp, GraphComponents sec_comp)
        {
            if (mlog.Cpi > 0)
            {
                for (int i = last_start; i <= last_end; i++)
                {
                    if (events[i].hDevice != mlog.hDevice)
                        continue;

                    double x = events[i].ts + delay;
                    double y;
                    if (i == 0)
                        y = 0.0;
                    else
                        y = (events[i].lastx) / (events[i].ts - events[i].lastts) / mlog.Cpi * 25.4;

                    update_minmax(x, y);
                    main_comp.Add(x, y);
                }

                for (int i = last_start; i <= last_end; i++)
                {
                    if (events[i].hDevice != mlog.hDevice)
                        continue;

                    double x = events[i].ts + delay;
                    double y;
                    if (i == 0)
                        y = 0.0;
                    else
                        y = (events[i].lasty) / (events[i].ts - events[i].lastts) / mlog.Cpi * 25.4;

                    update_minmax(x, y);
                    sec_comp.Add(x, y);
                }
            }
            else
                MessageBox.Show("CPI value is invalid, please run Measure");
        }
        private void plot_xsum_vs_time(MouseLog mlog, double delay, GraphComponents main_comp, GraphComponents sec_comp)
        {
            double y = 0;

            for (int i = last_start; i <= last_end; i++)
            {
                if (events[i].hDevice != mlog.hDevice)
                    continue;

                double x = events[i].ts + delay;
                y += events[i].lastx;
                update_minmax(x, y);
                main_comp.Add(x, y);
            }
        }
        private void plot_ysum_vs_time(MouseLog mlog, double delay, GraphComponents main_comp, GraphComponents sec_comp)
        {
            double y = 0;

            for (int i = last_start; i <= last_end; i++)
            {
                if (events[i].hDevice != mlog.hDevice)
                    continue;

                double x = events[i].ts + delay;
                y += events[i].lasty;
                update_minmax(x, y);
                main_comp.Add(x, y);
            }
        }
        private void plot_xysum_vs_time(MouseLog mlog, double delay, GraphComponents main_comp, GraphComponents sec_comp)
        {
            double y = 0;

            for (int i = last_start; i <= last_end; i++)
            {
                if (events[i].hDevice != mlog.hDevice)
                    continue;

                double x = events[i].ts + delay;
                y += events[i].lastx;
                update_minmax(x, y);
                main_comp.Add(x, y);
            }

            y = 0;

            for (int i = last_start; i <= last_end; i++)
            {
                if (events[i].hDevice != mlog.hDevice)
                    continue;

                double x = events[i].ts + delay;
                y += events[i].lasty;
                update_minmax(x, y);
                sec_comp.Add(x, y);
            }
        }
        private void plot_x_vs_y(MouseLog mlog, double delay, GraphComponents main_comp, GraphComponents sec_comp)
        {
            double x = 0.0;
            double y = 0.0;
            for (int i = last_start; i <= last_end; i++)
            {
                if (events[i].hDevice != mlog.hDevice)
                    continue;

                x += events[i].lastx;
                y += events[i].lasty;
                update_minmax(x, x);
                update_minmax(y, y);
                main_comp.Add(x, y, false);
            }
        }
        #endregion

        public static void Export(PlotModel model, string fileName, int width, int height, Brush background = null)
        {
            using (var bm = new Bitmap(width, height))
            {
                using (Graphics g = Graphics.FromImage(bm))
                {
                    if (background != null)
                        g.FillRectangle(background, 0, 0, width, height);

                    var rc = new GraphicsRenderContext { RendersToScreen = false };
                    rc.SetGraphicsTarget(g);
                    model.Update();
                    model.Render(rc, width, height);
                    bm.Save(fileName, ImageFormat.Png);
                }
            }
        }


    }
}
