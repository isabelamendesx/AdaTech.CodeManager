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
        private Team currentTeam;
        private Project projectToEdit;
        private User currentUser = Session.getInstance.GetCurrentUser();

        public ManageProject(Team team, Project? project = null)
        {
            InitializeComponent();
            currentTeam = team;

            if (project != null)
            {
                projectToEdit = project;
                BuildEditPage();
                ShowDialog();
            }

        }

        private void onBtnBackClick(object sender, EventArgs e)
        {
            Close();
            new SelectTeam().ShowDialog();
        }

        private void OnBtnCreateProjectClick(object sender, EventArgs e)
        {
            CreateProjectAndShowResult();
            CloseAndShowDashboard();
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

        private void OnBtnSaveProjectClick(object sender, EventArgs e)
        {
            UpdateProjectInformation();
            SaveTeamsAndShowResult();
            CloseAndShowDashboard();
        }


        #region Project Edit Methods

        private void UpdateProjectInformation()
        {
            projectToEdit.Name = txtProjectName.Text;
            projectToEdit.Description = string.IsNullOrEmpty(txtProjectDescription.Text) ? null : txtProjectDescription.Text;
            projectToEdit.StartDate = dpStart.Value;
            projectToEdit.TargetDate = dpTarget.Value != DateTimePicker.MinimumDateTime ? dpTarget.Value : (DateTime?)null;
        }

        private void SaveTeamsAndShowResult()
        {
            TeamData.SaveTeams();
            lbResult.Visible = true;
        }

        private async void CloseAndShowDashboard()
        {
            await System.Threading.Tasks.Task.Delay(1000);
            Close();
            new DashboardTL(currentTeam).ShowDialog();
        }

        private void BuildEditPage()
        {
            UpdateUIForEditMode();
            PopulateEditPageFields();
        }

        private void UpdateUIForEditMode()
        {
            lbCreateOrEdit.Text = "Edit a";
            lbCreateOrEdit.Location = new Point(182, 39);
            lbProject.Location = new Point(265, 39);

            btnSave.Visible = true;
            btnDeleteProject.Visible = true;
            btnCreate.Visible = false;
        }

        private void PopulateEditPageFields()
        {
            txtProjectName.Text = projectToEdit.Name;
            txtProjectDescription.Text = projectToEdit.Description;

            dpStart.Value = projectToEdit.StartDate;
            dpTarget.Value = projectToEdit.TargetDate ?? DateTimePicker.MinimumDateTime;
        }

        #endregion

        #region Project Create Nethods
        private void CreateProjectAndShowResult()
        {
            string projectName = txtProjectName.Text;
            string? projectDescription = string.IsNullOrEmpty(txtProjectDescription.Text) ? null : txtProjectDescription.Text;
            DateTime startDate = dpStart.Value;
            DateTime? targetDate = dpTarget.Value != DateTimePicker.MinimumDateTime ? dpTarget.Value : (DateTime?)null;

            currentTeam.AddProject(projectName, projectDescription, startDate, targetDate);
            TeamData.SaveTeams();

            ShowProjectCreationResult();
        }

        private void ShowProjectCreationResult()
        {
            lbResult.Text = "Project created!";
            lbResult.Visible = true;
        }

        #endregion


    }
}
