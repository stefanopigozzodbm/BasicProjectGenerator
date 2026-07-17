using Basic_Project_Generator.Interfaces;
using Basic_Project_Generator.UserInterfaces;
using Siemens.Collaboration.Net;
using System;
using System.Windows.Forms;

namespace Basic_Project_Generator
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                // Resolve Openness DLL via NuGet-Package OpennessResolver
                Api.Global.Openness().Initialize();

                Application.Run(new BasicProjectGenerator());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}{Environment.NewLine}{Environment.NewLine}Details:{Environment.NewLine}{ex}", "Basic Project Generator", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
