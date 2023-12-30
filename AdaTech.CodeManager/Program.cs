using AdaTech.CodeManager.Model;

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
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            //Developer developer = new Developer("developer", "developer", "Developer", Level.JR_DEVELOPER);
            //TechLead techLead = new TechLead("techlead", "techlead", "TechLead");

            //UserData.AddUser(developer);
            //UserData.AddUser(techLead);



            ApplicationConfiguration.Initialize();
            Application.Run(new LoginPage());
        }
    }
}