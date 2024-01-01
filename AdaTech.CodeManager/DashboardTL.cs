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
    public partial class DashboardTL : BaseForm
    {
        private static TechLead currentUser = (TechLead)Session.getInstance.GetCurrentUser();
        private static Team currentTeam;

        public DashboardTL(Team team)
        {
            InitializeComponent();
            currentTeam = team;
            ShowUserInfo();
            ShowProjects();
        }

        private void guna2GradientPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void OnBtnBackClick(object sender, EventArgs e)
        {
            Close();
            new SelectTeam().ShowDialog();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ShowUserInfo()
        {
            pnInfos.Controls.Add(CostumizeLbName());
            pnInfos.Controls.Add(CostumizeLbJobTitle());
        }



        public void ShowProjects()
        {
            foreach (var project in currentTeam.Projects)
            {
                var pnProject = CustomizePnTeam();
                pnProject.Click += (sender, e) => OnPnProjectClick(project);

                pnProject.Controls.Add(CostumizeLbProjectName(project.Name));
                pnProject.Controls.Add(CostumizeLbDaysLeft(project.DaysUntilTargetDate()));
                pnProject.Controls.Add(CostumizeLbCompletedPercent(project.concludedTasksPercent()));
                pnProject.Controls.Add(CostumizeProjectProgressBar((int)project.concludedTasksPercent()));

                conteinerProject.Controls.Add(pnProject);
            }
        }


        public void OnPnProjectClick(Project project)
        {
            Close();
            new KanbanBoard(project);

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


        private void OnBtnCreateProjectClick(object sender, EventArgs e)
        {
            Close();
            new ProjectRegister(currentTeam).ShowDialog();
        }


        private void guna2GradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

    // CSS COSTUMIZATIONS 

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

        private Guna2GradientPanel CustomizePnTeam()
        {
            var pnProject = new Guna2GradientPanel();
            pnProject.BackColor = Color.FromArgb(27, 32, 46);
            pnProject.BorderColor = Color.FromArgb(83, 95, 253);
            pnProject.BorderRadius = 15;
            pnProject.FillColor = Color.FromArgb(83, 95, 253);
            pnProject.FillColor2 = Color.FromArgb(83, 95, 253);
            pnProject.Size = new Size(226, 138);
            pnProject.Margin = new Padding(10);
            pnProject.MouseEnter += OnPnProjectMouseEnter;
            pnProject.MouseLeave += OnPnProjectMouseLeave;

            return pnProject;
        }

        private Label CostumizeLbProjectName(string projectName)
        {
            Label lbProjectName = new Label();
            lbProjectName.Text = projectName;
            lbProjectName.Font = new Font("Century Gothic", 14, FontStyle.Bold);
            lbProjectName.Location = new Point(12, 45);
            lbProjectName.BackColor = Color.FromArgb(251, 152, 51);
            lbProjectName.ForeColor = Color.White;
            lbProjectName.AutoSize = true;
            lbProjectName.TextAlign = ContentAlignment.TopCenter;
            return lbProjectName;
        }

        private Guna2ProgressBar CostumizeProjectProgressBar(int percentageDone)
        {
             Guna2ProgressBar progressBarProject = new Guna2ProgressBar();
            progressBarProject.ProgressColor = Color.White;
            progressBarProject.ProgressColor2 = Color.White;
            progressBarProject.FillColor = Color.FromArgb(64, 64, 64);
            progressBarProject.BackColor = Color.Transparent;
            progressBarProject.BorderRadius = 10;
            progressBarProject.Size = new Size(169,10);
            progressBarProject.Location = new Point(28, 115);
            progressBarProject.Value = percentageDone;

            return progressBarProject;

        }

        private Label CostumizeLbCompletedPercent(double completedTasks)
        {
            Label lbCompletedPercent = new Label();
            lbCompletedPercent.Text = $"{completedTasks:F2}%";
            lbCompletedPercent.Font = new Font("Century Gothic", 8, FontStyle.Regular);
            lbCompletedPercent.Location = new Point(158, 84);
            lbCompletedPercent.BackColor = Color.FromArgb(251, 152, 51);
            lbCompletedPercent.ForeColor = Color.White;
            lbCompletedPercent.AutoSize = true;
            lbCompletedPercent.TextAlign = ContentAlignment.TopLeft;
            return lbCompletedPercent;
        }

        private Label CostumizeLbDaysLeft(int daysLeft)
        {
            Label lbDaysLeft = new Label();
            lbDaysLeft.Text = $"{daysLeft} days";
            lbDaysLeft.Font = new Font("Century Gothic", 8, FontStyle.Regular);
            lbDaysLeft.Location = new Point(14, 20);
            lbDaysLeft.BackColor = Color.FromArgb(251, 152, 51);
            lbDaysLeft.ForeColor = Color.White;
            lbDaysLeft.AutoSize = true;
            lbDaysLeft.TextAlign = ContentAlignment.TopLeft;
            return lbDaysLeft;
        }

        private Label CostumizeLbName()
        {
            Label lbName = new Label();
            lbName.Text = $"{currentUser.Name}";
            lbName.Font = new Font("Century Gothic", 10, FontStyle.Bold);
            lbName.Location = new Point(34, 193);
            lbName.BackColor = Color.FromArgb(16, 20, 28);
            lbName.ForeColor = Color.White;
            lbName.AutoSize = true;
            lbName.TextAlign = ContentAlignment.TopCenter;
            return lbName;
        }

        private Label CostumizeLbJobTitle()
        {
            Label lbJobTitle = new Label();
            lbJobTitle.Text = "Tech Lead";
            lbJobTitle.Font = new Font("Century Gothic", 8, FontStyle.Regular);
            lbJobTitle.Location = new Point(90, 226);
            lbJobTitle.BackColor = Color.FromArgb(16, 20, 28);
            lbJobTitle.ForeColor = Color.White;
            lbJobTitle.AutoSize = true;
            lbJobTitle.TextAlign = ContentAlignment.TopRight;
            return lbJobTitle;
        }

        private void guna2ProgressBar1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click() { }
        private void label4_Click() { }
        private void label3_Click() { }
    }
}
