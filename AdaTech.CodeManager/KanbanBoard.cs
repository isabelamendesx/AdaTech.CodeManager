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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AdaTech.CodeManager
{
    public partial class KanbanBoard : BaseForm
    {
        private static Project currentProject;
        private static Team currentTeam;
        private static User currentUser = Session.getInstance.GetCurrentUser();

        public KanbanBoard(Project project, Team team)
        {

            InitializeComponent();
            currentProject = project;
            currentTeam = team;

            InitializeTasks(Model.Status.BackLog, conteinerBackLog);
            InitializeTasks(Model.Status.ToDo, conteinerToDo);
            InitializeTasks(Model.Status.Doing, conteinerDoing);
            InitializeTasks(Model.Status.Done, conteinerDone);
            InitializeTasks(Model.Status.Review, conteinerReview);
            InitializeTasks(Model.Status.Cancelled, conteinerCancelled);

        }

        private void InitializeTasks(Model.Status desiredStatus, FlowLayoutPanel conteiner)
        {
            var tasks = currentProject.GetTasksByStatus(desiredStatus);

            if (tasks != null)
            {
                foreach (var task in tasks)
                {
                    var pnTask = costumizepnTask();

                    pnTask.Click += (sender, e) => OnPnTaskClick(task);

                    pnTask.Controls.Add(CostumizePnTaskLbTaskName(task.Name));
                    pnTask.Controls.Add(CostumizePnTaskPicBox());

                    if (task.Priority == Priority.High)
                    {
                        pnTask.Controls.Add(CostumizePnTaskLbPriority(Color.Red, "HIGH"));
                    }
                    else if (task.Priority == Priority.Low)
                    {
                        pnTask.Controls.Add(CostumizePnTaskLbPriority(Color.Green, "LOW"));
                    }
                    else if (task.Priority == Priority.Medium)
                    {
                        pnTask.Controls.Add(CostumizePnTaskLbPriority(Color.Yellow, "MEDIUM"));
                    }

                    conteiner.Controls.Add(pnTask);
                }
            }
        }

        private void OnPnTaskMouseEnter(object sender, EventArgs e)
        {
            if (sender is Guna2GradientPanel pnTask)
            {
                CustomizeTaskPanelOnMouseEnter(pnTask);
            }
        }

        private void OnPnTaskMouseLeave(object sender, EventArgs e)
        {
            if (sender is Guna2GradientPanel pnTask)
            {
                CustomizeTaskPanelOnMouseLeave(pnTask);
            }
        }


        private void OnBtnCreateTaskClick(object sender, EventArgs e)
        {
            Close();
            new ManageTask(currentProject, currentTeam, currentUser).ShowDialog();
        }


        private void OnBtnBackClick(object sender, EventArgs e)
        {
            Close();
            if (currentUser is TechLead)
            {
                new DashboardTL(currentTeam).ShowDialog();
            }
            else
            {
                new DashboardDEV().ShowDialog();
            }
        }
        public void OnPnTaskClick(Model.Task task)
        {
            Close();
            new ManageTask(currentProject, currentTeam, currentUser, task);
        }

        private void OnBtnEditClick(object sender, EventArgs e)
        {
            CostumizeEditClickElements();
        }

        #region UI Element Builders
        private void CustomizeTaskPanelOnMouseEnter(Guna2GradientPanel pnTask)
        {
            pnTask.FillColor = Color.FromArgb(252, 239, 239);
            pnTask.FillColor2 = Color.FromArgb(252, 239, 239);
        }

        private void CustomizeTaskPanelOnMouseLeave(Guna2GradientPanel pnTask)
        {
            pnTask.FillColor = Color.FromArgb(16, 20, 28);
            pnTask.FillColor2 = Color.FromArgb(16, 20, 28);
        }
        private Guna2GradientPanel costumizepnTask()
        {
            var pnTask = new Guna2GradientPanel();
            pnTask.BackColor = Color.FromArgb(27, 32, 46);
            pnTask.BorderColor = Color.FromArgb(27, 32, 46);
            pnTask.BorderRadius = 15;
            pnTask.FillColor = Color.FromArgb(16, 20, 28);
            pnTask.FillColor2 = Color.FromArgb(16, 20, 28);
            pnTask.Size = new Size(144, 62);
            pnTask.BackColor = Color.Transparent;
            pnTask.MouseEnter += OnPnTaskMouseEnter;
            pnTask.MouseLeave += OnPnTaskMouseLeave;

            return pnTask;
        }

        private Label CostumizePnTaskLbTaskName(string taskName)
        {
            Label lbTaskName = new Label();
            lbTaskName.Text = taskName;
            lbTaskName.Font = new Font("Century Gothic", 8, FontStyle.Bold);
            lbTaskName.Location = new Point(3, 31);
            lbTaskName.BackColor = Color.FromArgb(16, 20, 28);
            lbTaskName.ForeColor = Color.White;
            lbTaskName.AutoSize = true;
            lbTaskName.TextAlign = ContentAlignment.TopCenter;
            return lbTaskName;
        }

        private Label CostumizePnTaskLbPriority(Color color, string priority)
        {
            Label lbPriority = new Label();
            lbPriority.Text = priority;
            lbPriority.Font = new Font("Century Gothic", 6, FontStyle.Regular);
            lbPriority.Location = new Point(6, 9);
            lbPriority.BackColor = color;
            lbPriority.ForeColor = Color.White;
            lbPriority.AutoSize = true;
            lbPriority.TextAlign = ContentAlignment.TopCenter;
            return lbPriority;
        }

        private Guna2CirclePictureBox CostumizePnTaskPicBox()
        {
            Guna2CirclePictureBox taskAvatar = new Guna2CirclePictureBox();
            taskAvatar.Size = new Size(25, 25);
            taskAvatar.Location = new Point(104, 9);
            return taskAvatar;
        }

        private void CostumizeEditClickElements()
        {
            guna2GradientPanel1.FillColor = Color.FromArgb(64, 64, 64);
            guna2GradientPanel1.FillColor2 = Color.FromArgb(64, 64, 64);
            pnMenu.FillColor = Color.Gray;
            pnMenu.FillColor2 = Color.Gray;

            btnBack.Enabled = false;
            btnCreateTask.Enabled = false;
            btnEdit.Enabled = false;

            lbResult.Visible = true;
            lbBacklog.BackColor = Color.Gray;
            lbToDo.BackColor = Color.Gray;
            lbDoing.BackColor = Color.Gray;
            lbDone.BackColor = Color.Gray;
            lbReview.BackColor = Color.Gray;
            lbCancelled.BackColor = Color.Gray;
        }


        #endregion


    }
}
