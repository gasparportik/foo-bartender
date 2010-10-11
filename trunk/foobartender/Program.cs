using System;
using System.Windows.Forms;
using DataAccessLayer;
using foobartender.forms;
using Util;

namespace foobartender
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Logger.Instance.Log("Application started.");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            DAL.SetDatabase(Properties.Settings.Default.DatabaseHost, Properties.Settings.Default.DatabaseName);
            
            MainForm.Instance.WindowState = (FormWindowState)Properties.Settings.Default["WindowState"];
            Application.Run(MainForm.Instance);
            Properties.Settings.Default["WindowState"] = MainForm.Instance.WindowState;

            Properties.Settings.Default.Save();
            Logger.Instance.Log("Application terminated gracefully.");
        }
    }
}
