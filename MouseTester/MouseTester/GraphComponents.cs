using OxyPlot;
using OxyPlot.Series;

namespace MouseTester
{
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
}
