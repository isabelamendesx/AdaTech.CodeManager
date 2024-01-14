using AdaTech.CodeManager.Model;
using Microsoft.VisualBasic.ApplicationServices;

namespace AdaTech.CodeManager
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new LoginPage());
        }
    }
}