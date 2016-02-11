namespace MouseTester
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
        private string axisX, axisY;

        public string AxisX
        { get { return axisX; } }
        public string AxisY
        { get { return axisY; } }

        private GT _DualGraph;
        public GT DualGraph
        {
            get
            {
                return _DualGraph;
            }
        }

        public GraphType(string Name, string axisX, string axisY, GT DualGraph, GraphFunction PlotFunc)
        {
            this.Name = Name;
            this.axisX = axisX;
            this.axisY = axisY;
            this._DualGraph = DualGraph;
            this.PlotFunc = PlotFunc;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
