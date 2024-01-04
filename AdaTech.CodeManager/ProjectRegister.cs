using AdaTech.CodeManager.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdaTech.CodeManager
{
    public partial class ProjectRegister : BaseForm
    {
        private static TechLead currentUser = (TechLead)Session.getInstance.GetCurrentUser();
        private static Team currentTeam;
        public ProjectRegister(Team team)
        {
            InitializeComponent();
            currentTeam = team;
        }

        private void OnBtnCreateClick(object sender, EventArgs e)
        {
            string projectName = txtProjectName.Text;
            string projectDescripton = txtProjectDescription.Text;
            DateTime startDate = dpStart.Value;
            DateTime targetDate = dpTarget.Value;

            currentTeam.AddProject(projectName, projectDescripton, startDate, targetDate);

            Close();
            new DashboardTL(currentTeam).ShowDialog();
        }

        private void onBtnBackClick(object sender, EventArgs e)
        {
            Close();
            new SelectTeam().ShowDialog();
        }
    }
}
