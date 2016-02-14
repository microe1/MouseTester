using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MouseTester
{
    public class Settings
    {
        public bool lines;
        public bool stem;
        public bool transparent;
        public bool fixedsize;

        public bool maximized;

        public int plotindex;

        public int xpos;
        public int ypos;

        public double cpi1 = 400.0;
        public double cpi2 = 400.0;
        public string desc1;
        public string desc2;

        private static bool ToBoolean(string arg, bool defvalue = false)
        {
            int n;
            if (int.TryParse(arg, out n))
                return n != 0;

            bool b;
            if (bool.TryParse(arg, out b))
                return b;

            return defvalue;
        }

        public static Settings Read(IniFile ini)
        {
            Settings result = new Settings();
            result.lines = ToBoolean(ini.Read("Lines", "Config"), false);
            result.stem = ToBoolean(ini.Read("Stem", "Config"), false);
            result.transparent = ToBoolean(ini.Read("Transparent", "Config"), true);
            result.fixedsize = ToBoolean(ini.Read("FixedSize", "Config"), true);

            result.maximized = ToBoolean(ini.Read("Maximized", "Config"), true);

            result.plotindex = -1;
            int.TryParse(ini.Read("Plot", "Config"), out result.plotindex);

            int.TryParse(ini.Read("XPos", "Config"), out result.xpos);
            int.TryParse(ini.Read("YPos", "Config"), out result.ypos);

            bool res1 = double.TryParse(ini.Read("CPI1", "Config"), NumberStyles.Float, CultureInfo.InvariantCulture, out result.cpi1);
            double.TryParse(ini.Read("CPI2", "Config"), NumberStyles.Float, CultureInfo.InvariantCulture, out result.cpi2);

            result.desc1 = ini.Read("Desc1", "Config");
            result.desc2 = ini.Read("Desc2", "Config");

            if (result.desc1 == "")
                result.desc1 = "MouseTester";
            if (result.desc2 == "")
                result.desc2 = "MouseTester";

            return result;
        }

        public void Write(IniFile ini)
        {
            ini.Write("Lines", lines ? "true" : "false", "Config");
            ini.Write("Stem", stem ? "true" : "false", "Config");
            ini.Write("Transparent", transparent ? "true" : "false", "Config");
            ini.Write("FixedSize", fixedsize ? "true" : "false", "Config");

            ini.Write("Maximized", maximized ? "true" : "false", "Config");

            ini.Write("Plot", plotindex.ToString(), "Config");

            ini.Write("XPos", xpos.ToString(), "Config");
            ini.Write("YPos", ypos.ToString(), "Config");

            ini.Write("CPI1", cpi1.ToString(CultureInfo.InvariantCulture), "Config");
            ini.Write("CPI2", cpi2.ToString(CultureInfo.InvariantCulture), "Config");

            ini.Write("Desc1", desc1, "Config");
            ini.Write("Desc2", desc2, "Config");
        }
    }
}
