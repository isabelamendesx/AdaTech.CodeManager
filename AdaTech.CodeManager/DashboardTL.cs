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
        private TechLead currentUser = (TechLead)Session.getInstance.GetCurrentUser();
        private Team currentTeam;

        public DashboardTL(Team team)
        {
            InitializeComponent();
            currentTeam = team;
            BuildPage();
        }

        private void BuildPage()
        {
            InitializeStatisticsNumbersLabels();
            InitializeStatisticsLabelsButtonEffect();
            ConfigureFinishedTasksProgressBar();
            ShowUserInfo();
            ShowProjects();
        }

        private void ShowUserInfo()
        {
            pnInfos.Controls.Add(CostumizeLbName());
            pnInfos.Controls.Add(CostumizeLbJobTitle());
        }

        private void OnBtnBackClick(object sender, EventArgs e)
        {
            Close();
            new SelectTeam().ShowDialog();

        }

        #region Statistics Area Methods

        private void UpdateFinishedTasksProgressBar(int totalTasks, int completedTasks)
        {
            if (totalTasks > 0)
            {
                int completionPercentage = (completedTasks * 100) / totalTasks;
                pbFinishedTasks.Value = completionPercentage;
            }
            else
            {
                pbFinishedTasks.Value = 0;
            }
        }

        private void InitializeStatisticsLabelsButtonEffect()
        {
            ConfigureHoverEffectStatisticLabels(lbCompleted);
            ConfigureHoverEffectStatisticLabels(lbDelayed);
            ConfigureHoverEffectStatisticLabels(lbDropped);
            ConfigureHoverEffectStatisticLabels(lbProgress);
            ConfigureHoverEffectStatisticLabels(lbToReview);

            lbCompleted.MouseClick += (sender, e) => OnStatisticLabelsClick();
            lbDelayed.MouseClick += (sender, e) => OnStatisticLabelsClick();
            lbDropped.MouseClick += (sender, e) => OnStatisticLabelsClick();
            lbProgress.MouseClick += (sender, e) => OnStatisticLabelsClick();
            lbToReview.MouseClick += (sender, e) => OnStatisticLabelsClick();

        }

        private void InitializeStatisticsNumbersLabels()
        {
            // ALL TASKS
            CustomizeLbTaskNumber(currentTeam.CountAllTasks(), 536, 409);

            // COMPLETED TASKS
            CustomizeLbTaskNumber(currentTeam.CountCompletedTasks(), 536, 460);

            // IN PROGRESS
            CustomizeLbTaskNumber(currentTeam.CountInProgressTasks(), 536, 511);

            // DELAYED
            CustomizeLbTaskNumber(currentTeam.CountDelayedTasks(), 787, 409);

            // DROPPED
            CustomizeLbTaskNumber(currentTeam.CountDroppedTasks(), 787, 460);

            // TO REVIEW
            CustomizeLbTaskNumber(currentTeam.CountToReviewTasks(), 787, 511);
        }

        private void ConfigureFinishedTasksProgressBar()
        {
            UpdateFinishedTasksProgressBar(currentTeam.CountAllTasks(), currentTeam.CountCompletedTasks());
        }

        private void ConfigureHoverEffectStatisticLabels(Label label)
        {
            label.MouseEnter += OnLbTasksStatisticsEnter;
            label.MouseLeave += OnLbTasksStatisticsEnter;
        }


        private void OnStatisticLabelsClick()
        {
            Close();
        }

        #endregion

        #region Projects Area Methods

        public void ShowProjects()
        {
            int horizontalSpacing = 10;
            int currentX = 0;

            foreach (var project in currentTeam.Projects)
            {
                var pnProject = CustomizePnTeam();
                pnProject.Click += (sender, e) => OnPnProjectClick(project);

                pnProject.Controls.Add(CostumizeLbProjectName(project.Name));
                pnProject.Controls.Add(CostumizeLbDaysLeft(project.GetDaysUntilTargetDate()));
                pnProject.Controls.Add(CostumizeLbCompletedPercent(project.GetConcludedTasksPercent()));
                pnProject.Controls.Add(CostumizeProjectProgressBar((int)project.GetConcludedTasksPercent()));

                pnProject.Location = new Point(currentX, 0);

                currentX += pnProject.Width + horizontalSpacing;

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

        private void OnBtnCreateProjectClick(object sender, EventArgs e)
        {
            Close();
            new ManageProject(currentTeam).ShowDialog();
        }


        private void OnBtnEditProjetClick(object sender, EventArgs e)
        {
            CostumizeEditElements();
        }

        public void OnPnProjectClick(Project project)
        {
            Close();

            if (!btnEditProject.Enabled)
            {
                Close();
                new ManageProject(currentTeam, project);
                return;
            }

            new KanbanBoard(project, currentTeam).ShowDialog();

        }

        #endregion

        #region UI Element Builders

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
            guna2GradientPanel1.Controls.Add(lbTaskNumber);
            return lbTaskNumber;
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

        private Guna2GradientPanel CustomizePnTeam()
        {
            var pnProject = new Guna2GradientPanel();
            pnProject.BackColor = Color.Transparent;
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
            progressBarProject.Size = new Size(169, 10);
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
            lbDaysLeft.BackColor = Color.Transparent;
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
            lbName.BackColor = Color.Transparent;
            lbName.ForeColor = Color.White;
            lbName.AutoSize = false;
            lbName.Width = 534; ;

            lbName.Anchor = AnchorStyles.None;

            int xPosition = (pnInfos.Width - lbName.Width) / 2;

            lbName.Location = new Point(xPosition, 213);

            lbName.TextAlign = ContentAlignment.TopCenter;
            return lbName;
        }

        private Label CostumizeLbJobTitle()
        {
            Label lbJobTitle = new Label();
            lbJobTitle.Text = "Tech Lead";
            lbJobTitle.Font = new Font("Century Gothic", 8, FontStyle.Regular);
            lbJobTitle.BackColor = Color.Transparent;
            lbJobTitle.ForeColor = Color.White;
            lbJobTitle.AutoSize = true;

            lbJobTitle.Anchor = AnchorStyles.None;

            int xPosition = (pnInfos.Width - lbJobTitle.Width) / 2;

            lbJobTitle.Location = new Point(xPosition, 245);

            lbJobTitle.TextAlign = ContentAlignment.TopCenter;
            return lbJobTitle;
        }

        private void CostumizeEditElements()
        {
            lbDashboard.BackColor = Color.Gray;
            lbProjectsTitle.BackColor = Color.Gray;
            lbStatistics.BackColor = Color.Gray;
            lbFinishedTasks.ForeColor = Color.Gray;
            lbAllTasks.ForeColor = Color.Gray;
            lbCompleted.ForeColor = Color.Gray;
            lbProgress.ForeColor = Color.Gray;
            lbDelayed.ForeColor = Color.Gray;
            lbDropped.ForeColor = Color.Gray;
            lbToReview.ForeColor = Color.Gray;

            btnBack.Enabled = false;
            btnCreateProject.Enabled = false;
            btnEditProject.Enabled = false;

            guna2GradientPanel1.FillColor = Color.FromArgb(64, 64, 64);
            guna2GradientPanel1.FillColor2 = Color.FromArgb(64, 64, 64);
            pnInfos.FillColor = Color.Gray;
            pnInfos.FillColor2 = Color.Gray;
            pnMenu.FillColor = Color.Gray;
            pnMenu.FillColor2 = Color.Gray;
            conteinerProjects.FillColor = Color.Gray;
            conteinerProjects.FillColor2 = Color.Gray;

            lbResult.Visible = true;
        }

        private void OnLbTasksStatisticsLeave(object sender, EventArgs e)
        {
            if (sender is Label label)
            {
                label.BackColor = Color.White;
            }
        }

        private void OnLbTasksStatisticsEnter(object sender, EventArgs e)
        {
            if (sender is Label label)
            {
                label.BackColor = Color.Transparent;
            }
        }

        #endregion

    }
}
