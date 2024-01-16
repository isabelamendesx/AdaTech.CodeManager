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
        private static Team userTeam;

        public DashboardDEV()
        {
            InitializeComponent();
            userTeam = TeamData.FindTeamByDeveloper(currentUser);
            BuildPage();
        }

        private void BuildPage()
        {
            ShowUserInfo();
            ShowProjects();
            ShowTasks();
            ConfigureAllTasksProgressBar();
            InitializeTaskNumbersLabels();
            InitializeStatisticsLabelsButtonEffect();
        }

        private void ShowUserInfo()
        {
            pnInfos.Controls.Add(CostumizeLbName());
            pnInfos.Controls.Add(CostumizeLbJobTitle());
        }

        public void OnPnTaskClick(Model.Task task)
        {
            new ManageTask(userTeam.FindProjectByTask(task), TeamData.FindTeamByDeveloper(currentUser), currentUser, task).ShowDialog();
            Close();
        }

        public void OnPnProjectClick(Project project)
        {
            Close();
            new KanbanBoard(project, userTeam).ShowDialog();

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Close();
            Session.getInstance.EndSession();
            new LoginPage().ShowDialog();
        }

        private void OnStatisticLabelsClick(object sender)
        {
            if (sender is Label clickedLabel)
            {
                string labelText = clickedLabel.Text;
                Close();
                new TasksByStatistics(userTeam, labelText).ShowDialog();
            }

        }

        #region Tasks Area Methods

        public void ShowTasks()
        {

            foreach (var task in userTeam.GetAllTasksByDeveloper(currentUser))
            {
                var pnTask = CustomizePnTask();
                pnTask.Click += (sender, e) => OnPnTaskClick(task);

                pnTask.Controls.Add(CostumizeLbTaskName(task.Name));
                pnTask.Controls.Add(CostumizeLbProjectName2(userTeam.FindProjectByTask(task).Name));
                pnTask.Controls.Add(CostumizeLbTaskCompletedPercent(task.GetCompletionPercentage()));
                pnTask.Controls.Add(CostumizeTaskProgressBar(task.GetCompletionPercentage()));

                conteinerTasks.Controls.Add(pnTask);
            }
        }

        #endregion

        #region Statistics Area Methods

        private void InitializeTaskNumbersLabels()
        {
            CustomizeLbTaskNumber(userTeam.Projects.Count(), 185, 426);
            CustomizeLbTaskNumber(userTeam.CountCompletedTasksByDeveloper(currentUser), 185, 473);
            CustomizeLbTaskNumber(userTeam.CountDelayedTasksByDeveloper(currentUser), 185, 523);
        }

        private void UpdateAllTasksProgressBar(int allTasksNumber, int completedTasksNumber)
        {
            if (allTasksNumber > 0)
            {
                int percentualCompleto = (completedTasksNumber * 100) / allTasksNumber;
                progressAllTasks.Value = percentualCompleto;
            }
            else
            {
                progressAllTasks.Value = 0;
            }
        }

        private void ConfigureAllTasksProgressBar()
        {
            int allTasksNumber = userTeam.CountAllTasksByDeveloper(currentUser);
            int completedTasksNumber = userTeam.CountCompletedTasksByDeveloper(currentUser);

            UpdateAllTasksProgressBar(allTasksNumber, completedTasksNumber);
        }

        private void InitializeStatisticsLabelsButtonEffect()
        {
            ConfigureHoverEffectStatisticLabels(lbCompleted);
            ConfigureHoverEffectStatisticLabels(lbDelayed);

            lbCompleted.MouseClick += (sender, e) => OnStatisticLabelsClick(sender);
            lbDelayed.MouseClick += (sender, e) => OnStatisticLabelsClick(sender);

        }
        private void ConfigureHoverEffectStatisticLabels(Label label)
        {
            label.MouseEnter += OnLbTasksStatisticsEnter;
            label.MouseLeave += OnLbTasksStatisticsLeave;
        }


        #endregion

        #region Projects Area Methods
        public void ShowProjects()
        {

            foreach (var project in userTeam.Projects)
            {
                var pnProject = CustomizePnProject();
                pnProject.Click += (sender, e) => OnPnProjectClick(project);

                pnProject.Controls.Add(CostumizeLbProjectName(project.Name));
                pnProject.Controls.Add(CostumizeLbDaysLeft(project.GetDaysUntilTargetDate()));
                pnProject.Controls.Add(CostumizeLbCompletedPercent(project.GetConcludedTasksPercent()));
                pnProject.Controls.Add(CostumizeProjectProgressBar((int)project.GetConcludedTasksPercent()));

                conteinerProjects.Controls.Add(pnProject);
            }
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

        #endregion

        #region UI Element Builders

        private void OnLbTasksStatisticsLeave(object sender, EventArgs e)
        {
            if (sender is Label label)
            {
                label.BackColor = Color.Transparent;
            }
        }

        private void OnLbTasksStatisticsEnter(object sender, EventArgs e)
        {
            if (sender is Label label)
            {
                label.BackColor = Color.White;
            }
        }

        private Guna2ProgressBar CostumizeTaskProgressBar(int percentageDone)
        {
            Guna2ProgressBar progressBarProject = new Guna2ProgressBar();
            progressBarProject.ProgressColor = Color.White;
            progressBarProject.ProgressColor2 = Color.White;
            progressBarProject.FillColor = Color.FromArgb(64, 64, 64);
            progressBarProject.BackColor = Color.Transparent;
            progressBarProject.BorderRadius = 10;
            progressBarProject.Size = new Size(169, 10);
            progressBarProject.Location = new Point(28, 115);
            progressBarProject.Value = percentageDone;

            return progressBarProject;

        }

        private Label CostumizeLbTaskCompletedPercent(double completedTasks)
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

        private Label CostumizeLbProjectName2(string projectName)
        {
            Label lbProjectName = new Label();
            lbProjectName.Text = projectName;
            lbProjectName.Font = new Font("Century Gothic", 8, FontStyle.Regular);
            lbProjectName.Location = new Point(14, 20);
            lbProjectName.BackColor = Color.FromArgb(251, 152, 51);
            lbProjectName.ForeColor = Color.White;
            lbProjectName.AutoSize = true;
            lbProjectName.TextAlign = ContentAlignment.TopLeft;
            return lbProjectName;
        }

        private Label CostumizeLbTaskName(string taskName)
        {
            Label lbTaskName = new Label();
            lbTaskName.Text = taskName;
            lbTaskName.Font = new Font("Century Gothic", 14, FontStyle.Bold);
            lbTaskName.Location = new Point(12, 45);
            lbTaskName.BackColor = Color.FromArgb(251, 152, 51);
            lbTaskName.ForeColor = Color.White;
            lbTaskName.AutoSize = true;
            lbTaskName.TextAlign = ContentAlignment.TopCenter;
            return lbTaskName;
        }

        private Guna2GradientPanel CustomizePnTask()
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

        private Label CostumizeLbDaysLeft(int daysLeft)
        {
            Label lbDaysLeft = new Label();
            lbDaysLeft.Text = $"{daysLeft} days";
            lbDaysLeft.Font = new Font("Century Gothic", 10, FontStyle.Regular);
            lbDaysLeft.Location = new Point(18, 31);
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
            lbCompletedPercent.Location = new Point(204, 117);
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
            progressBarProject.Size = new Size(254, 10);
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

            lbName.Anchor = AnchorStyles.None;

            int xPosition = (pnInfos.Width - lbName.Width) / 2;

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

            lbJobTitle.Anchor = AnchorStyles.None;

            int xPosition = (pnInfos.Width - lbJobTitle.Width) / 2;

            lbJobTitle.Location = new Point(xPosition, 208);

            lbJobTitle.TextAlign = ContentAlignment.TopCenter;
            return lbJobTitle;
        }
        private Label CustomizeLbTaskNumber(int numberTasks, int x, int y)
        {
            Label lbTaskNumber = new Label();
            lbTaskNumber.Text = numberTasks.ToString();
            lbTaskNumber.Font = new Font("Century Gothic", 10, FontStyle.Regular);
            lbTaskNumber.Location = new Point(x, y);
            lbTaskNumber.BackColor = Color.Transparent;
            lbTaskNumber.ForeColor = Color.White;
            lbTaskNumber.AutoSize = true;
            lbTaskNumber.TextAlign = ContentAlignment.TopCenter;
            pnInfos.Controls.Add(lbTaskNumber);
            return lbTaskNumber;
        }

        #endregion
    }
}
