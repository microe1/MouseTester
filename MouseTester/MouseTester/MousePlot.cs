using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using OxyPlot;

namespace MouseTester
{
    using System.Drawing;
    using System.Drawing.Imaging;
    using OxyPlot.WindowsForms;
    using OxyPlot.Axes;
    using OxyPlot.Series;

    public partial class MousePlot : Form
    {
        delegate void GraphFunction(MouseLog mlog, double delay, GraphComponents main_comp, GraphComponents sec_comp);

        class GraphType
        {
            public enum GT : byte
            {
                normal,
                dual,
                nolines
            }

            public GraphFunction PlotFunc;
            private string Name;
            private GT _DualGraph;
            public GT DualGraph 
            {
                get
                {
                    return _DualGraph;
                }
            }

            public GraphType(string Name, GT DualGraph, GraphFunction PlotFunc)
            {
                this.Name = Name;
                this._DualGraph = DualGraph;
                this.PlotFunc = PlotFunc;
            }

            public override string ToString()
            {
                return Name;
            }
        }

        class GraphComponents
        {
            public ScatterSeries scatters;
            public LineSeries lines;
            public StemSeries stems;

            public GraphComponents(OxyColor color)
            {
                scatters = new ScatterSeries
                {
                    BinSize = 8,
                    MarkerFill = color,
                    MarkerSize = 2.0,
                    MarkerStroke = color,
                    MarkerStrokeThickness = 1.0,
                    MarkerType = MarkerType.Circle
                };

                lines = new LineSeries
                {
                    Color = color,
                    LineStyle = LineStyle.Solid,
                    StrokeThickness = 1.0,
                    Smooth = true
                };

                stems = new StemSeries
                {
                    Color = color,
                    StrokeThickness = 1.0,
                };
            }

            public void Add(double x, double y, bool stem = true)
            {
                scatters.Points.Add(new ScatterPoint(x, y));
                lines.Points.Add(new DataPoint(x, y));
                if (stem)
                    stems.Points.Add(new DataPoint(x, y));
            }

            public void Add(PlotModel pm, bool line)
            {
                pm.Series.Add(scatters);
                if (line)
                    pm.Series.Add(lines);
            }

            public void Add(PlotModel pm, bool line, bool stem)
            {
                pm.Series.Add(scatters);
                if (!line)
                    plot_fit();

                pm.Series.Add(lines);
                if (stem)
                    pm.Series.Add(stems);
            }

#if true
            // Window based smoothing
            private void plot_fit()
            {
                double sum = 0.0;

                lines.Points.Clear();

                for (int i = 0; ((i < 8) && (i < scatters.Points.Count)); i++)
                {
                    sum = sum + scatters.Points[i].Y;
                }

                for (int i = 3; i < scatters.Points.Count - 5; i++)
                {
                    double x = (scatters.Points[i].X + scatters.Points[i + 1].X) / 2.0;
                    double y = sum;
                    lines.Points.Add(new DataPoint(x, y / 8.0));
                    sum = sum - scatters.Points[i - 3].Y;
                    sum = sum + scatters.Points[i + 5].Y;
                }
            }
#else
// Time based smoothing
        private void plot_fit()
        {
            double hz = 125;
            double ms = 1000.0 / hz;
            lines.Points.Clear();

            int ind = 0;
            for (double x = scatters.Points[0].X; x <= scatters.Points[scatters.Points.Count - 1].X; x += ms)
            {
                double sum = 0.0;
                while (scatters.Points[ind].X <= x)
                {
                    sum += scatters.Points[ind++].Y;
                }
                lines.Points.Add(new DataPoint(x - (ms / 2.0), sum / ms));
            }
        }
#endif
        }

        private GraphComponents BlueComponent, RedComponent, GreenComponent, YellowComponent;

        private MouseLog mlog, mlog2;
        private List<MouseEvent> events = new List<MouseEvent>();
        private int last_start;
        private int last_end;
        double x_min;
        double x_max;
        double y_min;
        double y_max;
        private string xlabel = "";
        private string ylabel = "";

        private bool dual = false;
        private bool init = true;

        public MousePlot(MouseLog Mlog, MouseLog Mlog2)
        {
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
                new GraphType("xCount vs. Time", GraphType.GT.normal, plot_xcounts_vs_time),
                new GraphType("yCount vs. Time", GraphType.GT.normal, plot_ycounts_vs_time),
                new GraphType("xyCount vs. Time", GraphType.GT.dual, plot_xycounts_vs_time),
                new GraphType("Interval vs. Time", GraphType.GT.normal, plot_interval_vs_time),
                new GraphType("Frequency vs. Time", GraphType.GT.normal, plot_frequency_vs_time),
                new GraphType("xVelocity vs. Time", GraphType.GT.normal, plot_xvelocity_vs_time),
                new GraphType("yVelocity vs. Time", GraphType.GT.normal, plot_yvelocity_vs_time),
                new GraphType("xyVelocity vs. Time", GraphType.GT.dual, plot_xyvelocity_vs_time),
                new GraphType("X vs. Y", GraphType.GT.nolines, plot_x_vs_y),
            };

            foreach (GraphType type in grapthtypes)
                comboBoxPlotType.Items.Add(type);

            this.comboBoxPlotType.SelectedIndex = 0;

            this.groupBox4.Enabled = dual;

            this.numericUpDownStart.Minimum = 0;
            this.numericUpDownStart.Maximum = last_end;
            this.numericUpDownStart.Value = last_start;
            this.numericUpDownStart.ValueChanged += new System.EventHandler(this.numericUpDownStart_ValueChanged);

            this.numericUpDownEnd.Minimum = 0;
            this.numericUpDownEnd.Maximum = last_end;
            this.numericUpDownEnd.Value = last_end;
            this.numericUpDownEnd.ValueChanged += new System.EventHandler(this.numericUpDownEnd_ValueChanged);

            init = false;
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
                Subtitle = mlog.Cpi.ToString() + " cpi" + (dual ? " vs. " + mlog2.Cpi.ToString() + " cpi" + " & " + numericUpDownDelay.Value.ToString("+#.#;-#.#;0", CultureInfo.InvariantCulture) + " ms delay" : ""),
                PlotType = PlotType.Cartesian,
                Background = OxyColors.White
            };
            plot1.Model = pm;
        }
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
            linearAxis1.Title = xlabel;
            pm.Axes.Add(linearAxis1);

            var linearAxis2 = new LinearAxis();
            linearAxis2.AbsoluteMinimum = y_min - (y_max - y_min) / 20.0;
            linearAxis2.AbsoluteMaximum = y_max + (y_max - y_min) / 20.0;
            linearAxis2.MajorGridlineColor = OxyColor.FromArgb(40, 0, 0, 139);
            linearAxis2.MajorGridlineStyle = LineStyle.Solid;
            linearAxis2.MinorGridlineColor = OxyColor.FromArgb(20, 0, 0, 139);
            linearAxis2.MinorGridlineStyle = LineStyle.Solid;
            linearAxis2.Title = ylabel;
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
            {
                x_min = x;
            }
            if (x > x_max)
            {
                x_max = x;
            }
            if (y < y_min)
            {
                y_min = y;
            }
            if (y > y_max)
            {
                y_max = y;
            }
        }

        private void plot_xcounts_vs_time(MouseLog mlog, double delay, GraphComponents main_comp, GraphComponents sec_comp)
        {
            xlabel = "Time (ms)";
            ylabel = "xCounts";
            
            for (int i = last_start; i <= last_end; i++)
            {
                if (events[i].hDevice != mlog.hDevice)
                    continue;

                double x =events[i].ts + delay;
                double y =events[i].lastx;
                update_minmax(x, y);
                main_comp.Add(x, y);
            }
        }
        private void plot_ycounts_vs_time(MouseLog mlog, double delay, GraphComponents main_comp, GraphComponents sec_comp)
        {
            xlabel = "Time (ms)";
            ylabel = "yCounts";

            for (int i = last_start; i <= last_end; i++)
            {
                if (events[i].hDevice != mlog.hDevice)
                    continue;

                double x =events[i].ts + delay;
                double y =events[i].lasty;
                update_minmax(x, y);
                main_comp.Add(x, y);
            }
        }
        private void plot_xycounts_vs_time(MouseLog mlog, double delay, GraphComponents main_comp, GraphComponents sec_comp)
        {
            xlabel = "Time (ms)";
            ylabel = "Counts [x = Blue, y = Red]";

            for (int i = last_start; i <= last_end; i++)
            {
                if (events[i].hDevice != mlog.hDevice)
                    continue;

                double x =events[i].ts + delay;
                double y =events[i].lastx;
                update_minmax(x, y);
                main_comp.Add(x, y);
            }

            for (int i = last_start; i <= last_end; i++)
            {
                if (events[i].hDevice != mlog.hDevice)
                    continue;

                double x =events[i].ts + delay;
                double y =events[i].lasty;
                update_minmax(x, y);
                sec_comp.Add(x, y);
            }
        }
        private void plot_interval_vs_time(MouseLog mlog, double delay, GraphComponents main_comp, GraphComponents sec_comp)
        {
            xlabel = "Time (ms)";
            ylabel = "Update Time (ms)";

            for (int i = last_start; i <= last_end; i++)
            {
                if (events[i].hDevice != mlog.hDevice)
                    continue;

                double x =events[i].ts;
                double y;
                if (i == 0)
                {
                    y = 0.0;
                }
                else
                {
                    y =events[i].ts - events[i].lastts;
                }
                update_minmax(x, y);
                main_comp.Add(x, y);
            }
        }
        private void plot_frequency_vs_time(MouseLog mlog, double delay, GraphComponents main_comp, GraphComponents sec_comp)
        {
            xlabel = "Time (ms)";
            ylabel = "Frequency (Hz)";

            for (int i = last_start; i <= last_end; i++)
            {
                if (events[i].hDevice != mlog.hDevice)
                    continue;

                double x = events[i].ts;
                double y;
                if (i == 0)
                {
                    y = 0.0;
                }
                else
                {
                    y = 1000.0 / (events[i].ts - events[i].lastts);
                }
                update_minmax(x, y);
                main_comp.Add(x, y);
            }
        }
        private void plot_xvelocity_vs_time(MouseLog mlog, double delay, GraphComponents main_comp, GraphComponents sec_comp)
        {
            xlabel = "Time (ms)";
            ylabel = "xVelocity (m/s)";

            if (mlog.Cpi > 0)
            {
                for (int i = last_start; i <= last_end; i++)
                {
                    if (events[i].hDevice != mlog.hDevice)
                        continue;

                    double x = events[i].ts + delay;
                    double y;
                    if (i == 0)
                    {
                        y = 0.0;
                    }
                    else
                    {
                        y = (events[i].lastx) / (events[i].ts - events[i].lastts) / mlog.Cpi * 25.4;
                    }
                    update_minmax(x, y);
                    main_comp.Add(x, y);
                }
            }
            else
            {
                MessageBox.Show("CPI value is invalid, please run Measure");
            }
        }
        private void plot_yvelocity_vs_time(MouseLog mlog, double delay, GraphComponents main_comp, GraphComponents sec_comp)
        {
            xlabel = "Time (ms)";
            ylabel = "yVelocity (m/s)";

            if (mlog.Cpi > 0)
            {
                for (int i = last_start; i <= last_end; i++)
                {
                    if (events[i].hDevice != mlog.hDevice)
                        continue;

                    double x =events[i].ts + delay;
                    double y;
                    if (i == 0)
                    {
                        y = 0.0;
                    }
                    else
                    {
                        y = (events[i].lasty) / (events[i].ts - events[i].lastts) / mlog.Cpi * 25.4;
                    }
                    update_minmax(x, y);
                    main_comp.Add(x, y);
                }
            }
            else
            {
                MessageBox.Show("CPI value is invalid, please run Measure");
            }
        }
        private void plot_xyvelocity_vs_time(MouseLog mlog, double delay, GraphComponents main_comp, GraphComponents sec_comp)
        {
            xlabel = "Time (ms)";
            ylabel = "Velocity (m/s) [x = Blue, y = Red]";

            if (mlog.Cpi > 0)
            {
                for (int i = last_start; i <= last_end; i++)
                {
                    if (events[i].hDevice != mlog.hDevice)
                        continue;

                    double x =events[i].ts + delay;
                    double y;
                    if (i == 0)
                    {
                        y = 0.0;
                    }
                    else
                    {
                        y = (events[i].lastx) / (events[i].ts - events[i].lastts) / mlog.Cpi * 25.4;
                    }
                    update_minmax(x, y);
                    main_comp.Add(x, y);
                }

                for (int i = last_start; i <= last_end; i++)
                {
                    if (events[i].hDevice != mlog.hDevice)
                        continue;

                    double x =events[i].ts + delay;
                    double y;
                    if (i == 0)
                    {
                        y = 0.0;
                    }
                    else
                    {
                        y = (events[i].lasty) / (events[i].ts - events[i].lastts) / mlog.Cpi * 25.4;
                    }
                    update_minmax(x, y);
                    sec_comp.Add(x, y);
                }
            }
            else
            {
                MessageBox.Show("CPI value is invalid, please run Measure");
            }
        }
        private void plot_x_vs_y(MouseLog mlog, double delay, GraphComponents main_comp, GraphComponents sec_comp)
        {
            xlabel = "xCounts";
            ylabel = "yCounts";

            double x = 0.0;
            double y = 0.0;
            for (int i = last_start; i <= last_end; i++)
            {
                if (events[i].hDevice != mlog.hDevice)
                    continue;

                x +=events[i].lastx;
                y +=events[i].lasty;
                update_minmax(x, x);
                update_minmax(y, y);
                main_comp.Add(x, y, false);
            }
        }

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

        private void Refresh_Plot_Helper(object sender, EventArgs e)
        {
            if (init)
                return;

            refresh_plot();
        }

        private void buttonSavePNG_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "PNG Files (*.png)|*.png";
            saveFileDialog1.FilterIndex = 1;
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                int width = checkBoxSize.Checked ? 800 : (int)this.plot1.Model.Width;
                int height = checkBoxSize.Checked ? 600 : (int)this.plot1.Model.Height;
                Brush backgnd = checkBoxBgnd.Checked ? null : new SolidBrush(Color.White);

                MousePlot.Export(this.plot1.Model, saveFileDialog1.FileName, width, height, backgnd);
            }         
        }

        public static void Export(PlotModel model, string fileName, int width, int height, Brush background = null)
        {
            using (var bm = new Bitmap(width, height))
            {
                using (Graphics g = Graphics.FromImage(bm))
                {
                    if (background != null)
                    {
                        g.FillRectangle(background, 0, 0, width, height);
                    }

                    var rc = new GraphicsRenderContext { RendersToScreen = false };
                    rc.SetGraphicsTarget(g);
                    model.Update();
                    model.Render(rc, width, height);
                    bm.Save(fileName, ImageFormat.Png);
                }
            }
        }

        private void numericUpDownDelay_ValueChanged(object sender, EventArgs e)
        {
            if (init)
                return;

            plot1.Model.Subtitle = mlog.Cpi.ToString() + " cpi" + (dual ? " vs. " + mlog2.Cpi.ToString() + " cpi" + " & " + numericUpDownDelay.Value.ToString("+#.#;-#.#;0", CultureInfo.InvariantCulture) + " ms delay" : "");

            refresh_plot();
        }
    }
}
