﻿using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace XexToolGUI
{
    internal static class Program
    {
        public static info Info { get; set; }
        public static IDCScript IDCScript { get; set; }
        public static TitleUpdate TitleUpdate { get; set; }
        public static Dump Dump { get; set; }
        public static xml xml { get; set; }
        public static About About { get; set; }
        public static xexgui xexgui { get; set; }
        public static HelpReverse HelpReverse { get; set; }
        public static Process process { get; set; }
        public static void CurrentProcess(string Args)
        {
            process.StartInfo.FileName = "xextool.exe";
            process.StartInfo.Arguments = Args;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process.Start();
            process.BeginOutputReadLine();
            process.Close();

        }

        private static void ProcessOutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(xexgui = new xexgui());
        }
    }
}
