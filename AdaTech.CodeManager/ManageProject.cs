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
    public partial class ManageProject : BaseForm
    {
        private static Team currentTeam;
        private static Project projectToEdit;
        private User currentUser = Session.getInstance.GetCurrentUser();

        public ManageProject(Team team, Project? project = null)
        {
            InitializeComponent();
            currentTeam = team;

            if (project != null)
            {
                projectToEdit = project;
                InitializeEditPage();
                ShowDialog();
            }

        }

        private void onBtnBackClick(object sender, EventArgs e)
        {
            Close();
            new SelectTeam().ShowDialog();
        }

        private async void OnBtnDeleteProjectClick(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete this project?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                TeamData.RemoveProject(projectToEdit);
                lbResult.BackColor = Color.Red;
                lbResult.Text = "project deleted!";
                lbResult.Visible = true;

                await System.Threading.Tasks.Task.Delay(1000);
                Close();
                new DashboardTL(currentTeam).ShowDialog();
                return;
            }
        }

        #region Project Edit Methods
        private async void OnBtnSaveClick(object sender, EventArgs e)
        {
            projectToEdit.Name = txtProjectName.Text;
            projectToEdit.Description = string.IsNullOrEmpty(txtProjectDescription.Text) ? null : txtProjectDescription.Text;
            projectToEdit.StartDate = dpStart.Value;
            projectToEdit.TargetDate = dpTarget.Value != DateTimePicker.MinimumDateTime ? dpTarget.Value : (DateTime?)null;

            TeamData.SaveTeams();
            lbResult.Visible = true;

            await System.Threading.Tasks.Task.Delay(1000);

            Close();
            new DashboardTL(currentTeam).ShowDialog();
        }

        private void InitializeEditPage()
        {
            lbCreateOrEdit.Text = "Edit a";
            lbCreateOrEdit.Location = new Point(182, 39);
            lbProject.Location = new Point(265, 39);

            btnSave.Visible = true;
            btnDeleteProject.Visible = true;
            btnCreate.Visible = false;

            if(currentUser is Developer)
            {
                btnDeleteProject.Enabled = false;
            }

            txtProjectName.Text = projectToEdit.Name;
            txtProjectDescription.Text = projectToEdit.Description;

            dpStart.Enabled = false;
            dpTarget.Value = (DateTime)projectToEdit.TargetDate;
        }
        #endregion

        #region Project Create Nethods
        private async void OnBtnCreateClick(object sender, EventArgs e)
        {
            string projectName = txtProjectName.Text;
            string? projectDescripton = string.IsNullOrEmpty(txtProjectDescription.Text) ? null : txtProjectDescription.Text;
            DateTime startDate = dpStart.Value;
            DateTime? targetDate = dpTarget.Value != DateTimePicker.MinimumDateTime ? dpTarget.Value : (DateTime?)null;

            currentTeam.AddProject(projectName, projectDescripton, startDate, targetDate);
            TeamData.SaveTeams();

            lbResult.Text = "project created!";
            lbResult.Visible = true;

            await System.Threading.Tasks.Task.Delay(1000);
            Close();
            new DashboardTL(currentTeam).ShowDialog();
        }
        #endregion


    }
}
