using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace MouseTester
{
    public class MouseLog
    {
        private string desc = "MouseTester";
        private double cpi = 400.0;
        private List<MouseEvent> events = new List<MouseEvent>(1000000);
        
        public double Cpi 
        { 
            get 
            { 
                return this.cpi; 
            } 
            set
            { 
                cpi = value; 
            }
        }

        public string Desc
        {
            get
            {
                return this.desc;
            }
            set
            {
                this.desc = value;
            }
        }

        public List<MouseEvent> Events
        {
            get
            {
                return this.events;
            }
        }

        public void Add(MouseEvent e)
        {
            this.events.Add(e);
        }

        public void Clear()
        {
            this.events.Clear();
        }

        public void Load(string fname)
        {
            this.Clear();

            try
            {
                using (StreamReader sr = File.OpenText(fname))
                {
                    this.desc = sr.ReadLine();
                    this.cpi = double.Parse(sr.ReadLine());
                    string headerline = sr.ReadLine();
                    while (sr.Peek() > -1)
                    {
                        string line = sr.ReadLine();
                        string[] values = line.Split(',');
                        this.Add(new MouseEvent(0, int.Parse(values[0]), int.Parse(values[1]), double.Parse(values[2])));
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        public void Save(string fname)
        {
            try
            {
                using (StreamWriter sw = File.CreateText(fname))
                {
                    sw.WriteLine(this.desc);
                    sw.WriteLine(this.cpi.ToString());
                    sw.WriteLine("xCount,yCount,Time (ms)");
                    foreach (MouseEvent e in this.events)
                    {
                        sw.WriteLine(e.lastx.ToString() + "," + e.lasty.ToString() + "," + e.ts.ToString(CultureInfo.InvariantCulture));
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }
        
        public int deltaX()
        {
            return this.events.Sum(e => e.lastx);
        }

        public int deltaY()
        {
            return this.events.Sum(e => e.lasty);
        }

        public double path()
        {
            return this.events.Sum(e => Math.Sqrt((e.lastx * e.lastx) + (e.lasty * e.lasty)));
        }
    }
}
