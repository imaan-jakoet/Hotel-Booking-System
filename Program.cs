using PhumlaKamnandi.PresentationLayer.Forms;
using System;
using System.Windows.Forms;

namespace PhumlaKamnandi
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Set the data directory for the database
            string dataDirectory = Application.StartupPath;
            AppDomain.CurrentDomain.SetData("DataDirectory", dataDirectory);

            // Start with login form
            Application.Run(new LoginForm());
        }
    }
}