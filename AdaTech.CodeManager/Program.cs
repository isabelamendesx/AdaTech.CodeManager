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
            /*
            TechLead techLead = new TechLead("techlead", "techlead", "Isabela Mendes");
            Developer developer = new Developer("dev1", "dev1", "Matheus Vidal",Level.Mid, MainSkill.BackEnd);;
            Developer developer2 = new Developer("dev2", "dev2", "Ivy Rigon",Level.Junior, MainSkill.UI_UX);
            Developer developer3 = new Developer("dev3", "dev3", "Luís Eduardo",Level.Senior, MainSkill.FrontEnd);


            UserData.AddUser(developer);
            UserData.AddUser(developer2);
            UserData.AddUser(developer3);
            UserData.AddUser(techLead);
            */

         
            


            ApplicationConfiguration.Initialize();
            Application.Run(new LoginPage());
        }
    }
}