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

        private void guna2HtmlLabel5_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel3_Click(object sender, EventArgs e)
        {

        }

        private void txtTeamName_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel4_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {

        }

        private void OnBtnCreateClick(object sender, EventArgs e)
        {
            string projectName = txtProjectName.Text;
            string projectDescripton = txtProjectDescription.Text;
            DateTime startDate = dpStart.Value;
            DateTime targetDate = dpTarget.Value;

            currentTeam.AddProject(projectName, projectDescripton, startDate, targetDate);

            Close();
            new Dashboard().ShowDialog();
        }
    }
}
