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
            InitializeTaskNumbersLabels();
            InitializeButtonLabels();
            ConfigurarProgressBar();
            ShowUserInfo();
            ShowProjects();

        }


        private void InitializeButtonLabels()
        {
            ConfigurarEfeitoHoverLabel(lbCompleted);
            ConfigurarEfeitoHoverLabel(lbDelayed);
            ConfigurarEfeitoHoverLabel(lbDropped);
            ConfigurarEfeitoHoverLabel(lbProgress);
            ConfigurarEfeitoHoverLabel(lbToReview);

            lbCompleted.MouseClick += (sender, e) => OnLabelButtonClick();
            lbDelayed.MouseClick += (sender, e) => OnLabelButtonClick();
            lbDropped.MouseClick += (sender, e) => OnLabelButtonClick();
            lbProgress.MouseClick += (sender, e) => OnLabelButtonClick();
            lbToReview.MouseClick += (sender, e) => OnLabelButtonClick();

        }

        private void OnLabelButtonClick()
        {
            Close();

        }

        private void InitializeTaskNumbersLabels()
        {
            // ALL TASKS
            CustomizeLbTaskNumber(CountAllTasks(), 536, 409);

            // COMPLETED TASKS
            CustomizeLbTaskNumber(CountCompletedTasks(), 536, 460);

            // IN PROGRESS
            CustomizeLbTaskNumber(CountProgressTasks(), 536, 511);

            // DELAYED
            CustomizeLbTaskNumber(CountDelayedTasks(), 787, 409);

            // DROPPED
            CustomizeLbTaskNumber(CountDroppedTasks(), 787, 460);

            // TO REVIEW
            CustomizeLbTaskNumber(CountToReviewTasks(), 787, 511);
        }

        private int CountProgressTasks()
        {
            return currentTeam.Projects
                .SelectMany(project => project.Tasks)
                .Count(task => task.Status == Status.Doing || task.Status == Status.Testing);
        }

        private int CountDelayedTasks()
        {
            DateTime today = DateTime.Now;
            return currentTeam.Projects
                .SelectMany(project => project.Tasks)
                 .Where(task => task.Status != Status.Done)
                .Count(task => task.EndDate != null && task.EndDate < today);
        }

        private int CountDroppedTasks()
        {
            DateTime today = DateTime.Now;
            return currentTeam.Projects
                    .SelectMany(project => project.Tasks)
                    .Count(task => task.EndDate != null && (today - task.EndDate).TotalDays > 10);
        }

        private int CountToReviewTasks()
        {
            return currentTeam.Projects
                .SelectMany(project => project.Tasks)
                .Count(task => task.Status == Status.Review);
        }

        private int CountAllTasks()
        {
            return currentTeam.Projects
                .SelectMany(project => project.Tasks)
                .Count();
        }

        private void AtualizarBarraDeProgresso(int totalTarefas, int tarefasCompletas)
        {
            if (totalTarefas > 0)
            {
                int percentualCompleto = (tarefasCompletas * 100) / totalTarefas;
                progressBTeam.Value = percentualCompleto;
            }
            else
            {
                progressBTeam.Value = 0;
            }
        }

        private void ConfigurarProgressBar()
        {
            int totalTarefas = CountAllTasks();
            int tarefasCompletas = CountCompletedTasks();

            AtualizarBarraDeProgresso(totalTarefas, tarefasCompletas);
        }

        private void ConfigurarEfeitoHoverLabel(Label label)
        {
            label.MouseEnter += Label_MouseEnter;
            label.MouseLeave += Label_MouseLeave;
        }

        private void Label_MouseEnter(object sender, EventArgs e)
        {
            if (sender is Label label)
            {
                label.BackColor = Color.White; 
            }
        }

        private void Label_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Label label)
            {
                label.BackColor = Color.Transparent; 
            }
        }

        private int CountCompletedTasks()
        {
            return currentTeam.Projects
                .SelectMany(project => project.Tasks)
                .Count(task => task.Status == Status.Done);
        }


        private void OnBtnBackClick(object sender, EventArgs e)
        {
            Close();
            new SelectTeam().ShowDialog();

        }

        private void ShowUserInfo()
        {
            pnInfos.Controls.Add(CostumizeLbName());
            pnInfos.Controls.Add(CostumizeLbJobTitle());
        }



        public void ShowProjects()
        {
            int horizontalSpacing = 10; // Espaçamento horizontal entre os projetos
            int currentX = 0; // Posição inicial em X

            foreach (var project in currentTeam.Projects)
            {
                var pnProject = CustomizePnTeam();
                pnProject.Click += (sender, e) => OnPnProjectClick(project);

                pnProject.Controls.Add(CostumizeLbProjectName(project.Name));
                pnProject.Controls.Add(CostumizeLbDaysLeft(project.DaysUntilTargetDate()));
                pnProject.Controls.Add(CostumizeLbCompletedPercent(project.concludedTasksPercent()));
                pnProject.Controls.Add(CostumizeProjectProgressBar((int)project.concludedTasksPercent()));

                // Defina a posição horizontal do pnProject
                pnProject.Location = new Point(currentX, 0);

                // Atualize a posição para o próximo controle
                currentX += pnProject.Width + horizontalSpacing;

                conteinerTest.Controls.Add(pnProject);
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


        private void OnBtnCreateProjectClick(object sender, EventArgs e)
        {
            Close();
            new ProjectRegister(currentTeam).ShowDialog();
        }


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
            lbName.BackColor = Color.FromArgb(16, 20, 28);
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
            lbJobTitle.BackColor = Color.FromArgb(16, 20, 28);
            lbJobTitle.ForeColor = Color.White;
            lbJobTitle.AutoSize = true;

            lbJobTitle.Anchor = AnchorStyles.None;

            int xPosition = (pnInfos.Width - lbJobTitle.Width) / 2;

            lbJobTitle.Location = new Point(xPosition, 245);

            lbJobTitle.TextAlign = ContentAlignment.TopCenter;
            return lbJobTitle;
        }

        #endregion

    }
}
