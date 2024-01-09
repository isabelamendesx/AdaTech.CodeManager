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
            
            //// TECHLEADS
            //TechLead techLead = new TechLead("isabelam", "isabelam", "Isabela Mendes");
            //TechLead techLead2 = new TechLead("ricardob", "ricardob", "Ricardo Barbosa");
            //TechLead techLead3 = new TechLead("andreav", "andreav", "Andrea Vasconcelos");
            //TechLead techLead4 = new TechLead("claudiac", "claudiac", "Cláudia Costa");
            //TechLead techLead5 = new TechLead("marcelob", "marcelob", "Marcelo Barros");

            //// DEVS
            //Developer developer = new Developer("matheusv", "matheusv", "Matheus Vidal",Level.Mid, MainSkill.BackEnd);;
            //Developer developer2 = new Developer("ivyr", "ivyr", "Ivy Rigon",Level.Junior, MainSkill.UI_UX);
            //Developer developer3 = new Developer("eduardop", "eduardop", "Luís Eduardo",Level.Senior, MainSkill.FrontEnd);
            //Developer developer4 = new Developer("lucasf", "lucasf", "Lucas Fernandes", Level.Senior, MainSkill.QA);
            //Developer developer5 = new Developer("julias", "julias", "Júlia Santos", Level.Junior, MainSkill.BackEnd);
            //Developer developer6 = new Developer("carlosm", "carlosm", "Carlos Martins", Level.Mid, MainSkill.UI_UX);
            //Developer developer7 = new Developer("patriciap", "patriciap", "Patrícia Pereira", Level.Senior, MainSkill.UI_UX);
            //Developer developer8 = new Developer("gustavoa", "gustavoa", "Gustavo Alves", Level.Junior, MainSkill.FrontEnd);
            //Developer developer9 = new Developer("vanessas", "vanessas", "Vanessa Silva", Level.Mid, MainSkill.BackEnd);
            //Developer developer10 = new Developer("renator", "renator", "Renato Rocha", Level.Senior, MainSkill.FrontEnd);



            //UserData.AddUser(developer);
            //UserData.AddUser(developer2);
            //UserData.AddUser(developer3);   
            //UserData.AddUser(developer4);
            //UserData.AddUser(developer5);
            //UserData.AddUser(developer6);  
            //UserData.AddUser(developer7);
            //UserData.AddUser(developer8);
            //UserData.AddUser(developer9);
            //UserData.AddUser(techLead);
            //UserData.AddUser(techLead2);
            //UserData.AddUser(techLead3);
            //UserData.AddUser(techLead4);
            //UserData.AddUser(techLead5);
            
            
         
            


            ApplicationConfiguration.Initialize();
            Application.Run(new LoginPage());
        }
    }
}