﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MouseTester
{
    static class Program
    {
        public static string version = "1.4.0";

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
