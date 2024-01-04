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

            InitializeTasks(Status.BackLog, conteinerBackLog);
            InitializeTasks(Status.ToDo, conteinerToDo);
            InitializeTasks(Status.Doing, conteinerDoing);
            InitializeTasks(Status.Done, conteinerDone);
            InitializeTasks(Status.Review, conteinerReview);
            InitializeTasks(Status.Cancelled, conteinerCancelled);

        }

        private void InitializeTasks(Status desiredStatus, FlowLayoutPanel conteiner)
        {
            var tasks = currentProject.GetTasksByStatus(desiredStatus);

            if (tasks != null)
            {
                foreach (var task in tasks)
                {
                    var pnTask = costumizepnTask();

                    pnTask.Click += (sender, e) => OnPnTaskClick(task);

                    pnTask.Controls.Add(CostumizeLbTaskName(task.Name));
                    pnTask.Controls.Add(CostumizeTaskPicBox());

                    if (task.Priority == Priority.High)
                    {
                        pnTask.Controls.Add(CostumizeLbPriority(Color.Red, "HIGH"));
                    }
                    else if (task.Priority == Priority.Low)
                    {
                        pnTask.Controls.Add(CostumizeLbPriority(Color.Green, "LOW"));
                    }
                    else if (task.Priority == Priority.Medium)
                    {
                        pnTask.Controls.Add(CostumizeLbPriority(Color.Yellow, "MEDIUM"));
                    }

                    conteiner.Controls.Add(pnTask);
                }
            }
        }

        public void OnPnTaskClick(Model.Task task)
        {
            Close();
            new RegisterTask(currentProject,currentTeam, currentUser, task);
        }

        private Label CostumizeLbTaskName(string taskName)
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

        private Label CostumizeLbPriority(Color color, string priority)
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

        private Guna2CirclePictureBox CostumizeTaskPicBox()
        {
            Guna2CirclePictureBox taskAvatar = new Guna2CirclePictureBox();
            taskAvatar.Size = new Size(25, 25);
            taskAvatar.Location = new Point(104, 9);
            return taskAvatar;
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
            pnTask.MouseEnter += OnPnTaskMouseEnter;
            pnTask.MouseLeave += OnPnTaskMouseLeave;

            return pnTask;

        }

        private void OnPnTaskMouseEnter(object sender, EventArgs e)
        {
            if (sender is Guna2GradientPanel pnTask)
            {
                CustomizePanelOnMouseEnter(pnTask);
            }
        }


        private void OnPnTaskMouseLeave(object sender, EventArgs e)
        {
            if (sender is Guna2GradientPanel pnTask)
            {
                CustomizePanelOnMouseLeave(pnTask);
            }
        }

        private void CustomizePanelOnMouseEnter(Guna2GradientPanel pnTask)
        {
            pnTask.FillColor = Color.FromArgb(252, 239, 239);
            pnTask.FillColor2 = Color.FromArgb(252, 239, 239);
        }

        private void CustomizePanelOnMouseLeave(Guna2GradientPanel pnTask)
        {
            pnTask.FillColor = Color.FromArgb(16, 20, 28);
            pnTask.FillColor2 = Color.FromArgb(16, 20, 28);
        }

        private void OnBtnCreateTaskClick(object sender, EventArgs e)
        {
            Close();
            new RegisterTask(currentProject, currentTeam, currentUser).ShowDialog();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void OnBtnBackClick(object sender, EventArgs e)
        {
            Close();
            if(currentUser is TechLead)
            {
                new DashboardTL(currentTeam).ShowDialog();
            }
            else {
                new DashboardDEV().ShowDialog();            
            }
        }
    }
}
