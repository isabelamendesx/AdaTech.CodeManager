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

namespace AdaTech.CodeManager.Model
{
    public partial class TasksByStatistics : BaseForm
    {
        private Team currentTeam;
        private TechLead currentUser = (TechLead)Session.getInstance.GetCurrentUser();

        public TasksByStatistics(Team team, string taskType)
        {
            InitializeComponent();
            currentTeam = team;
            BuildPage(taskType);
        }

        private void BuildPage(string taskType)
        { 

            switch (taskType)
            {
                case "Completed":
                    InitializeCompletedTasks();
                    break;
                case "In Progress":
                    InitializeInProgressTasks();
                    break;
                case "Delayed":
                    InitializeDelayedTasks();
                    break;
                case "Dropped":
                    InitializeDroppedTasks();
                    break;
                case "To Review":
                    InitializeToReviewTasks();
                    break;
                default:
                    break;
            }
        }

        private void InitializeTaskType(string taskTypeName, Color backgroundColor, Func<List<Model.Task>> tasksGetter)
        {
            lbTaskType.Text = taskTypeName;
            lbTaskType.BackColor = backgroundColor;
            CenterLabelInContainer(lbTaskType, guna2GradientPanel1);

            var tasksToShow = tasksGetter.Invoke();

            if (tasksToShow != null)
            {
                foreach (var task in tasksToShow)
                {
                    var pnTask = costumizePnTaskType(backgroundColor);

                    pnTask.Controls.Add(CostumizePnTaskTypeLbName(task.Name));
                    pnTask.Controls.Add(CostumizePnTaskTypeLbProjectName(TeamData.FindProjectByTask(task, currentUser).Name));

                    conteinerTasks.Controls.Add(pnTask);
                }
            }
        }
        private void OnBtnExitClick(object sender, EventArgs e)
        {
            Close();
            new DashboardTL(currentTeam).ShowDialog();
        }


        #region Auxiliar Methods
        private void InitializeCompletedTasks()
        {
            InitializeTaskType("Completed", Color.FromArgb(0, 192, 0), () => currentTeam.GetCompletedTasks());
        }

        private void InitializeDelayedTasks()
        {
            InitializeTaskType("Delayed", Color.Orange, () => currentTeam.GetDelayedTasks());
        }

        private void InitializeDroppedTasks()
        {
            InitializeTaskType("Dropped", Color.Red, () => currentTeam.GetDroppedTasks());
        }

        private void InitializeToReviewTasks()
        {
            InitializeTaskType("To Review", Color.Purple, () => currentTeam.GetToReviewTasks());
        }

        private void InitializeInProgressTasks()
        {
            InitializeTaskType("In Progress", Color.Yellow, () => currentTeam.GetInProgressTasks());
        }
        #endregion


        #region UI Element Builders

        private void CenterLabelInContainer(Label label, Control container)
        {
            label.Anchor = AnchorStyles.None; 
            label.TextAlign = ContentAlignment.MiddleCenter;

            int centerX = (container.Width - label.Width) / 2;
            label.Location = new Point(centerX, label.Location.Y);
        }

        private Guna2GradientPanel costumizePnTaskType(Color color)
        {
            var pnTaskType = new Guna2GradientPanel();
            pnTaskType.BackColor = Color.Transparent;
            pnTaskType.BorderColor = Color.Transparent;
            pnTaskType.BorderRadius = 15;
            pnTaskType.FillColor = color;
            pnTaskType.FillColor2 = color;
            pnTaskType.Size = new Size(341, 36);

            return pnTaskType;
        }

        private Label CostumizePnTaskTypeLbName(string taskName)
        {
            Label lbTaskName = new Label();
            lbTaskName.Text = taskName;
            lbTaskName.Font = new Font("Century Gothic", 10, FontStyle.Bold);
            lbTaskName.Location = new Point(9, 6);
            lbTaskName.BackColor = Color.Transparent;
            lbTaskName.ForeColor = Color.White;
            lbTaskName.AutoSize = true;
            lbTaskName.TextAlign = ContentAlignment.TopCenter;
            return lbTaskName;
        }

        private Label CostumizePnTaskTypeLbProjectName(string projectName)
        {
            Label lbProjectName = new Label();
            lbProjectName.Text = projectName;
            lbProjectName.Font = new Font("Century Gothic", 8, FontStyle.Regular);
            lbProjectName.Location = new Point(218, 6);
            lbProjectName.BackColor = Color.Transparent;
            lbProjectName.ForeColor = Color.White;
            lbProjectName.AutoSize = true;
            lbProjectName.TextAlign = ContentAlignment.TopLeft;
            return lbProjectName;
        }
            #endregion







        

    }
}