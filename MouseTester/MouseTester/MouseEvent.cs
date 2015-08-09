using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MouseTester
{
    public class MouseEvent
    {
        public ushort buttonflags;
        public int lastx;
        public int lasty;
        public double ts;

        public IntPtr hDevice;

        public uint index; //used for graphing, creating a virtual "common index" for each event: if they were in same log and ordered by ts

        public MouseEvent(IntPtr hDevice, ushort buttonflags, int lastx, int lasty, double ts)
        {
            this.hDevice = hDevice;
            this.buttonflags = buttonflags;
            this.lastx = lastx;
            this.lasty = lasty;
            this.ts = ts;
        }
    }
}
