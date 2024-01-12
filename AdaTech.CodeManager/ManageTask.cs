using AdaTech.CodeManager.Model;
using Guna.UI2.WinForms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace AdaTech.CodeManager
{
    public partial class ManageTask : BaseForm
    {
        private Project currentProject;
        private Team currentTeam;
        private  List<Developer> avaiableAssigneeCandidates = new List<Developer>();
        private  List<Guna2ComboBox> cbList = new List<Guna2ComboBox>();
        private  User currentUser = Session.getInstance.GetCurrentUser();
        private static Model.Task taskToEdit;
        public ManageTask(Project project, Team team, User currentUser, Model.Task? task = null)
        {

            InitializeComponent();
            currentTeam = team;
            currentProject = project;
            avaiableAssigneeCandidates = currentTeam.GetTeamMembers();

            if(task == null)
            {
                BuildCreateTaskPage();
                ShowDialog();
                return;
            }

            taskToEdit = task;
            BuildEditTaskPage();
            ShowDialog();

        }

        private void BuildEditTaskPage()
        {
            InitializeCbTaskStatus();
            InitializeCbTaskPriority();
            CostumizeEditElements();
            InitializeEditAssigneesMembersComboBoxes();
        }

        private void BuildCreateTaskPage()
        {
            InitializeCbTaskStatus();
            InitializeCbTaskPriority();
            InitializeCbAssignees();
        }

        private void OnBtnBackClick(object sender, EventArgs e)
        {
            Close();
            new KanbanBoard(currentProject, currentTeam);
        }

        private void CbAssigneesSelectedIndexChanged(object sender, EventArgs e)
        {
            Guna2ComboBox senderCB = (Guna2ComboBox)sender;

            if (senderCB.SelectedItem == "")
            {
                return;
            }

            if (cbList.Count > 1 && cbList.Any(cb => cb.SelectedItem == senderCB.SelectedItem && cb != senderCB))
            {
                MessageBox.Show("You already selected this member", "Duplicate Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                senderCB.SelectedIndex = -1;
                return;
            }

            Guna2ComboBox newComboBox = new Guna2ComboBox();
            newComboBox.Font = senderCB.Font;
            newComboBox.Size = senderCB.Size;
            newComboBox.FillColor = senderCB.FillColor;
            newComboBox.BorderRadius = senderCB.BorderRadius;

            newComboBox.Items.Add("");
            newComboBox.Items.AddRange(avaiableAssigneeCandidates.ToArray());

            cbList.Add(newComboBox);
            conteinerMembers.Controls.Add(newComboBox);
            newComboBox.SelectedIndex = -1;

            newComboBox.SelectedIndexChanged += CbAssigneesSelectedIndexChanged;
        }

        #region Edit Task Methods

        private void InitializeEditAssigneesMembersComboBoxes()
        {


            int index = 0;
            foreach (var assignee in taskToEdit.Owners)
            {
                Guna2ComboBox newComboBox = CreateNewComboBox(assignee);
                int selectedIndex = avaiableAssigneeCandidates.IndexOf(assignee) + 1;
                newComboBox.SelectedIndex = selectedIndex;

                newComboBox.DataSource = taskToEdit.Owners;

                cbList.Add(newComboBox);
                conteinerMembers.Controls.Add(newComboBox);
                newComboBox.SelectedIndexChanged += CbAssigneesSelectedIndexChanged;
                newComboBox.SelectedIndex = index++;
            }
        }

        private async void onBtnEditClick(object sender, EventArgs e)
        {

            if (currentUser is Developer)
            {
                lbWaiting.Visible = true;
                currentProject.AddTaskToApprove(taskToEdit);
                currentProject.Tasks.Remove(taskToEdit);
                await System.Threading.Tasks.Task.Delay(1000);
                Close();
                new KanbanBoard(currentProject, currentTeam);
                return;
            }

                taskToEdit.Name = txtTaskName.Text;
                taskToEdit.Description = txtTaskDescription.Text;
                taskToEdit.EndDate = dpStart.Value.Date;
                taskToEdit.Status = (Model.Status)cbTaskStatus.SelectedItem;
                taskToEdit.Priority = (Priority)cbTaskPriority.SelectedItem;
                taskToEdit.IsTechLeadAssignee = cbSelfAssign.Checked;

                var newOwners = new List<Developer>();

                foreach (var cb in cbList)
                {
                    if (cb.SelectedItem != null)
                    {
                        newOwners.Add(cb.SelectedItem as Developer);
                    }
                }
                
                taskToEdit.Owners.Clear();
                taskToEdit.Owners = newOwners;
           
            lbResult.Text = "task edited!";
            lbResult.Visible = true;
            await System.Threading.Tasks.Task.Delay(1000);
            Close();
            new KanbanBoard(currentProject, currentTeam).ShowDialog();
        }


        #endregion



















        #region Create Task Methods

        private void InitializeCbTaskStatus()
        {
            cbTaskStatus.DataSource = Enum.GetValues(typeof(Model.Status));
        }
        private void InitializeCbTaskPriority()
        {
            cbTaskPriority.DataSource = Enum.GetValues(typeof(Priority));
        }

        private void InitializeCbAssignees()
        {
            cbAssignees.Items.Add("");
            cbAssignees.Items.AddRange(avaiableAssigneeCandidates.ToArray());
            cbAssignees.SelectedIndex = -1;
            cbList.Add(cbAssignees);
        }

        private async void OnBtnCreateTaskClick(object sender, EventArgs e)
        {
            string taskName = txtTaskName.Text;
            string? taskDescription = txtTaskDescription.Text;
            DateTime startDate = dpStart.Value.Date;
            DateTime targetDate = dpStart.Value.Date;
            Model.Status? taskStatus = (Model.Status)cbTaskStatus.SelectedItem;
            Priority taskPriority = (Priority)cbTaskPriority.SelectedItem;
            List<Developer?> owners = new List<Developer?>();

            foreach (var cb in cbList)
            {
                if (cb.SelectedItem != null)
                {
                    owners.Add(cb.SelectedItem as Developer);
                }
            }

            bool selfAssign = cbSelfAssign.Checked;
            Model.Task task = new Model.Task(taskName, startDate, targetDate, taskDescription, owners, taskStatus, taskPriority, selfAssign);

            if (currentUser is Developer)
            {
                lbWaiting.Visible = true;
                currentProject.AddTaskToApprove(task);
                await System.Threading.Tasks.Task.Delay(1000);
                Close();
                new KanbanBoard(currentProject, currentTeam);
                return;
            }

            lbResult.Visible = true;
            currentProject.AddTask(task);
            await System.Threading.Tasks.Task.Delay(1000);
            Close();
            new KanbanBoard(currentProject, currentTeam).ShowDialog();
        }


        #endregion

        #region UI Element Builders

        private Guna2ComboBox CreateNewComboBox(Developer assignee)
        {
            Guna2ComboBox newComboBox = new Guna2ComboBox
            {
                Font = new Font("Century Gothic", 8, FontStyle.Bold),
                Size = new Size(381, 36),
                FillColor = Color.FromArgb(252, 239, 239),
                BorderRadius = 20
            };

            newComboBox.Items.Add("");
            newComboBox.Items.AddRange(avaiableAssigneeCandidates.ToArray());

            return newComboBox;
        }
        private void CostumizeEditElements()
        {
            lbCreateorEdit.Text = "Edit a";
            lbCreateorEdit.Location = new Point(196, 44);
            lbEdit.Location = new Point(279, 44);
            txtTaskName.Text = taskToEdit.Name;
            txtTaskDescription.Text = taskToEdit.Description;
            dpStart.Value = taskToEdit.StartDate;
            dpStart.Enabled = false;
            dpTarget.Value = taskToEdit.EndDate;
            cbTaskStatus.SelectedIndex = (int)taskToEdit.Status;
            cbTaskPriority.SelectedIndex = (int)taskToEdit.Priority;
            btnEdit.Visible = true;
            btnCreateTask.Visible = false;
        }

        #endregion
    }
}
