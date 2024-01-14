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
        private List<Developer> avaiableAssigneeCandidates = new List<Developer>();
        private List<Guna2ComboBox> cbList = new List<Guna2ComboBox>();
        private User currentUser = Session.getInstance.GetCurrentUser();
        private Model.Task taskToEdit;

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

        private void CbAssigneesSelectedIndexChanged(object sender, EventArgs e)
        {
            Guna2ComboBox senderComboBox = (Guna2ComboBox)sender;

            if (IsSelectionEmpty(senderComboBox))
            {
                return;
            }

            if (IsDuplicateSelection(senderComboBox))
            {
                MessageBox.Show("You already selected this member", "Duplicate Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                senderComboBox.SelectedIndex = -1;
                return;
            }

            Guna2ComboBox newComboBox = CreateNewComboBoxFrom(senderComboBox);

            AddComboBoxToListAndContainerEdit(newComboBox);
        }
        private void OnBtnBackClick(object sender, EventArgs e)
        {
            Close();
            new KanbanBoard(currentProject, currentTeam).ShowDialog();
        }

        private void OnBtnCreateTaskClick(object sender, EventArgs e)
        {
            try
            {
                Model.Task task = CreateTask();

                if (currentUser is Developer)
                {
                    ApproveTask(task);
                }
                else
                {
                    AddTaskToProject(task);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void OnBtnEditTaskClick(object sender, EventArgs e)
        {
            if (currentUser is Developer)
            {
                ApproveTaskForDeveloper();
            }
            else
            {
                EditTask();
            }
        }

        #region Edit Task Auxiliar Methods

        private void InitializeEditAssigneesMembersComboBoxes()
        {
            foreach (var assignee in taskToEdit.Owners)
            {
                Guna2ComboBox newComboBox = CreateNewComboBox(assignee);
                int selectedIndex = avaiableAssigneeCandidates.IndexOf(assignee) + 1;
                newComboBox.SelectedIndex = selectedIndex;

                AddComboBoxToListAndContainerEdit(newComboBox);
            }
        }

        private void AddComboBoxToListAndContainerEdit(Guna2ComboBox comboBox)
        {
            cbList.Add(comboBox);
            conteinerMembers.Controls.Add(comboBox);
            comboBox.SelectedIndexChanged += CbAssigneesSelectedIndexChanged;
        }


        private async void ApproveTaskForDeveloper()
        {
            lbWaiting.Visible = true;
            currentProject.AddTaskToApprove(taskToEdit);
            currentProject.Tasks.Remove(taskToEdit);
            await System.Threading.Tasks.Task.Delay(1000);
            Close();
            new KanbanBoard(currentProject, currentTeam);
        }

        private async void EditTask()
        {
            UpdateTaskProperties();

            var newOwners = cbList
                .Select(cb => cb.SelectedItem as Developer)
                .Where(owner => owner != null)
                .ToList();

            taskToEdit.Owners.Clear();
            taskToEdit.Owners.AddRange(newOwners);
            TeamData.SaveTeams();

            DisplayResultMessage("Task edited!");
            await System.Threading.Tasks.Task.Delay(1000);
            Close();
            new KanbanBoard(currentProject, currentTeam).ShowDialog();
        }

        private void UpdateTaskProperties()
        {
            taskToEdit.Name = txtTaskName.Text;
            taskToEdit.Description = txtTaskDescription.Text;
            taskToEdit.EndDate = dpStart.Value.Date;
            taskToEdit.Status = (Model.Status)cbTaskStatus.SelectedItem;
            taskToEdit.Priority = (Priority)cbTaskPriority.SelectedItem;
            taskToEdit.IsTechLeadAssignee = cbSelfAssign.Checked;
        }

        private void DisplayResultMessage(string message)
        {
            lbResult.Text = message;
            lbResult.Visible = true;
        }

        #endregion

        #region Create Task Auxiliar Methods

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

        private List<Developer?> GetSelectedOwners()
        {
            List<Developer?> owners = new List<Developer?>();

            foreach (var cb in cbList)
            {
                if (cb.SelectedItem != null && cb.SelectedItem.ToString() != "")
                {
                    owners.Add(cb.SelectedItem as Developer);
                }
            }

            return owners;
        }

        private Model.Task CreateTask()
        {
            string taskName = txtTaskName.Text;
            string? taskDescription = txtTaskDescription.Text;
            DateTime startDate = dpStart.Value.Date;
            DateTime targetDate = dpStart.Value.Date;
            Model.Status? taskStatus = (Model.Status)cbTaskStatus.SelectedItem;
            Priority taskPriority = (Priority)cbTaskPriority.SelectedItem;
            List<Developer?> owners = GetSelectedOwners();
            bool selfAssign = cbSelfAssign.Checked;

            return new Model.Task(taskName, startDate, targetDate, taskDescription, owners, taskStatus, taskPriority, selfAssign);
        }

        private async void ApproveTask(Model.Task task)
        {
            if (currentUser is Developer)
            {
                lbWaiting.Visible = true;
                currentProject.AddTaskToApprove(task);
                await System.Threading.Tasks.Task.Delay(1000);
                Close();
                new KanbanBoard(currentProject, currentTeam);
            }
        }

        private async void AddTaskToProject(Model.Task task)
        {
            lbResult.Visible = true;
            currentProject.AddTask(task);
            await System.Threading.Tasks.Task.Delay(1000);
            Close();
            new KanbanBoard(currentProject, currentTeam).ShowDialog();
        }

        #endregion

        #region Combo Boxes Select Index Changed Auxiliar Methods

        private bool IsSelectionEmpty(Guna2ComboBox comboBox)
        {
            return comboBox.SelectedItem == "";
        }

        private bool IsDuplicateSelection(Guna2ComboBox senderComboBox)
        {
            return cbList.Count > 1 && cbList.Any(cb => cb.SelectedItem == senderComboBox.SelectedItem && cb != senderComboBox);
        }

        private Guna2ComboBox CreateNewComboBoxFrom(Guna2ComboBox sourceComboBox)
        {
            Guna2ComboBox newComboBox = CreateNewComboBox();
            CopyComboBoxProperties(sourceComboBox, newComboBox);
            return newComboBox;
        }

        private Guna2ComboBox CreateNewComboBox()
        {
            Guna2ComboBox newComboBox = new Guna2ComboBox();
            newComboBox.Items.Add("");
            newComboBox.Items.AddRange(avaiableAssigneeCandidates.ToArray());
            newComboBox.SelectedIndex = -1;
            newComboBox.SelectedIndexChanged += CbAssigneesSelectedIndexChanged;
            return newComboBox;
        }

        private void CopyComboBoxProperties(Guna2ComboBox source, Guna2ComboBox destination)
        {
            destination.Font = source.Font;
            destination.Size = source.Size;
            destination.FillColor = source.FillColor;
            destination.BorderRadius = source.BorderRadius;
        }

        private void AddComboBoxToListAndContainer(Guna2ComboBox comboBox)
        {
            cbList.Add(comboBox);
            conteinerMembers.Controls.Add(comboBox);
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
            cbAssignees.Visible = false;
            cbTaskStatus.SelectedIndex = (int)taskToEdit.Status;
            cbTaskPriority.SelectedIndex = (int)taskToEdit.Priority;
            btnEdit.Visible = true;
            btnCreateTask.Visible = false;
        }

        #endregion
    }
}
