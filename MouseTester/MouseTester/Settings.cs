using System;
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

        public static bool operator==(Settings s1, Settings s2)
        {
            return
                s1.lines == s2.lines &&
                s1.stem == s2.stem &&
                s1.transparent == s2.transparent &&
                s1.fixedsize == s2.fixedsize &&
                s1.maximized == s2.maximized &&
                s1.plotindex == s2.plotindex;
        }

        public static bool operator!=(Settings s1, Settings s2)
        {
            return !(s1 == s2);
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
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
        }
    }
}
