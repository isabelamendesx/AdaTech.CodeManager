using AdaTech.CodeManager.Model;
using Guna.UI2.WinForms;
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
    public partial class DashboardDEV : Form
    {
        private static Developer currentUser = (Developer)Session.getInstance.GetCurrentUser();
        private static Team currentTeam = UserData.GetTeam(currentUser);

        public DashboardDEV()
        {
            InitializeComponent();
            ShowUserInfo();
            ShowProjects();
        }

        public void ShowProjects()
        {

            foreach (var project in currentTeam.Projects)
            {
                var pnProject = CustomizePnProject();
                pnProject.Click += (sender, e) => OnPnProjectClick(project);

                pnProject.Controls.Add(CostumizeLbProjectName(project.Name));
                pnProject.Controls.Add(CostumizeLbDaysLeft(project.DaysUntilTargetDate()));
                pnProject.Controls.Add(CostumizeLbCompletedPercent(project.concludedTasksPercent()));
                pnProject.Controls.Add(CostumizeProjectProgressBar((int)project.concludedTasksPercent()));

                conteinerProjects.Controls.Add(pnProject);
            }
        }

        public void OnPnProjectClick(Project project)
        {
            Close();
            new KanbanBoard(project, currentTeam).ShowDialog();

        }

        private void OnPnProjectMouseEnter(object sender, EventArgs e)
        {
            if (sender is Guna2GradientPanel pnProject)
            {
                CustomizePanelOnMouseEnter(pnProject);
            }
        }


        private void OnPnProjectMouseLeave(object sender, EventArgs e)
        {
            if (sender is Guna2GradientPanel pnProject)
            {
                CustomizePanelOnMouseLeave(pnProject);
            }
        }


        private void btnBack_Click(object sender, EventArgs e)
        {
            Close();
            Session.getInstance.EndSession();
            new LoginPage().ShowDialog();
        }

        private void ShowUserInfo()
        {
            pnInfos.Controls.Add(CostumizeLbName());
            pnInfos.Controls.Add(CostumizeLbJobTitle());
        }


        // CUSTOMIZE METHODS

        // CONTEINER PROJECTS

        private Label CostumizeLbDaysLeft(int daysLeft)
        {
            Label lbDaysLeft = new Label();
            lbDaysLeft.Text = $"{daysLeft} days";
            lbDaysLeft.Font = new Font("Century Gothic", 10, FontStyle.Regular);
            lbDaysLeft.Location = new Point(18,31);
            lbDaysLeft.BackColor = Color.FromArgb(251, 152, 51);
            lbDaysLeft.ForeColor = Color.White;
            lbDaysLeft.AutoSize = true;
            lbDaysLeft.TextAlign = ContentAlignment.TopLeft;
            return lbDaysLeft;
        }

        private Label CostumizeLbCompletedPercent(double completedTasks)
        {
            Label lbCompletedPercent = new Label();
            lbCompletedPercent.Text = $"{completedTasks:F2}%";
            lbCompletedPercent.Font = new Font("Century Gothic", 10, FontStyle.Regular);
            lbCompletedPercent.Location = new Point(224, 111);
            lbCompletedPercent.BackColor = Color.FromArgb(251, 152, 51);
            lbCompletedPercent.ForeColor = Color.White;
            lbCompletedPercent.AutoSize = true;
            lbCompletedPercent.TextAlign = ContentAlignment.TopLeft;
            return lbCompletedPercent;
        }

        private Guna2ProgressBar CostumizeProjectProgressBar(int percentageDone)
        {
            Guna2ProgressBar progressBarProject = new Guna2ProgressBar();
            progressBarProject.ProgressColor = Color.White;
            progressBarProject.ProgressColor2 = Color.White;
            progressBarProject.FillColor = Color.FromArgb(64, 64, 64);
            progressBarProject.BackColor = Color.Transparent;
            progressBarProject.BorderRadius = 10;
            progressBarProject.Size = new Size(169, 10);
            progressBarProject.Location = new Point(18, 148);
            progressBarProject.Value = percentageDone;

            return progressBarProject;

        }

        private Label CostumizeLbProjectName(string projectName)
        {
            Label lbProjectName = new Label();
            lbProjectName.Text = projectName;
            lbProjectName.Font = new Font("Century Gothic", 14, FontStyle.Bold);
            lbProjectName.Location = new Point(16, 62);
            lbProjectName.BackColor = Color.FromArgb(251, 152, 51);
            lbProjectName.ForeColor = Color.White;
            lbProjectName.AutoSize = true;
            lbProjectName.TextAlign = ContentAlignment.TopCenter;
            return lbProjectName;
        }


        private void CustomizePanelOnMouseEnter(Guna2GradientPanel pnProject)
        {
            pnProject.FillColor = Color.FromArgb(252, 239, 239);
            pnProject.FillColor2 = Color.FromArgb(252, 239, 239);
        }

        private void CustomizePanelOnMouseLeave(Guna2GradientPanel pnProject)
        {
            pnProject.FillColor = Color.FromArgb(83, 95, 253);
            pnProject.FillColor2 = Color.FromArgb(83, 95, 253);
        }
        private Guna2GradientPanel CustomizePnProject()
        {
            var pnProject = new Guna2GradientPanel();
            pnProject.BackColor = Color.FromArgb(27, 32, 46);
            pnProject.BorderColor = Color.FromArgb(83, 95, 253);
            pnProject.BorderRadius = 15;
            pnProject.FillColor = Color.FromArgb(83, 95, 253);
            pnProject.FillColor2 = Color.FromArgb(83, 95, 253);
            pnProject.Size = new Size(283, 182);
            pnProject.Margin = new Padding(10);
            pnProject.MouseEnter += OnPnProjectMouseEnter;
            pnProject.MouseLeave += OnPnProjectMouseLeave;

            return pnProject;
        }

        private Label CostumizeLbName()
        {
            Label lbName = new Label();
            lbName.Text = $"{currentUser.Name}";
            lbName.Font = new Font("Century Gothic", 10, FontStyle.Bold);
            lbName.BackColor = Color.FromArgb(16, 20, 28);
            lbName.ForeColor = Color.White;
            lbName.AutoSize = false;
            lbName.Width = 238;

            // Centraliza o Label dentro do controle pai
            lbName.Anchor = AnchorStyles.None;

            // Calcula a posição X para centralizar
            int xPosition = (pnInfos.Width - lbName.Width) / 2;

            // Define a localização ajustada
            lbName.Location = new Point(xPosition, 182);

            lbName.TextAlign = ContentAlignment.TopCenter;
            return lbName;
        }

        private Label CostumizeLbJobTitle()
        {
            Label lbJobTitle = new Label();
            lbJobTitle.Text = currentUser.MainSkill.ToString() + " Developer";
            lbJobTitle.Font = new Font("Century Gothic", 8, FontStyle.Regular);
            lbJobTitle.BackColor = Color.FromArgb(16, 20, 28);
            lbJobTitle.ForeColor = Color.White;
            lbJobTitle.AutoSize = false;
            lbJobTitle.Width = 238;

            // Centraliza o Label dentro do controle pai
            lbJobTitle.Anchor = AnchorStyles.None;

            // Calcula a posição X para centralizar
            int xPosition = (pnInfos.Width - lbJobTitle.Width) / 2;

            // Define a localização ajustada
            lbJobTitle.Location = new Point(xPosition, 208);

            lbJobTitle.TextAlign = ContentAlignment.TopCenter;
            return lbJobTitle;
        }

        private void pnInfos_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
