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

namespace AdaTech.CodeManager
{
    public partial class RegisterTask : BaseForm
    {
        private static Project currentProject;
        private static Team currentTeam;
        private static List<Developer> assigneeCandidates;
        private static List<Guna2ComboBox> cbList = new List<Guna2ComboBox>();
        private static User currentUser = Session.getInstance.GetCurrentUser();
        private static Model.Task taskToEdit;
        public RegisterTask(Project project, Team team, User currentUser, Model.Task? task = null)
        {

            InitializeComponent();
            InitializeCbTaskStatus();
            InitializeCbTaskPriority();

            taskToEdit = task;

            if (taskToEdit != null)
            {

                InitializeTaskEdit(taskToEdit);
                ShowDialog();
            }
            else
            {
                if (currentUser is Developer)
                {
                    InitializeRegisterDev();
                }

                else if (currentUser is TechLead)
                {
                    InitializeRegisterTechLead();
                }
                currentProject = project;
                currentTeam = team;
                //assigneeCandidates = currentTeam.TeamMembers;
            }
        }

        private void InitializeTaskEdit(Model.Task task)
        {
            lbCreateorEdit.Text = "Edit a";
            lbCreateorEdit.Location = new Point(268, 44);
            lbEdit.Location = new Point();
            txtTaskName.Text = task.Name;
            txtTaskDescription.Text = task.Description;
            dpStart.Value = task.StartDate;
            dpStart.Enabled = false;
            dpTarget.Value = task.EndDate;
            cbTaskStatus.SelectedIndex = (int)task.Status;
            cbTaskPriority.SelectedIndex = (int)task.Priority;
            btnEdit.Visible = true;
            btnCreateTask.Visible = false;
            pnAssignees.Hide();

            int index = 0;
            foreach (var assignees in task.Owners)
            {
                Guna2ComboBox newComboBox = new Guna2ComboBox();

                newComboBox.Font = new Font("Century Gothic", 8, FontStyle.Bold);
                newComboBox.Size = new Size(381, 36);
                newComboBox.FillColor = Color.FromArgb(252, 239, 239);
                newComboBox.BorderRadius = 20;

                newComboBox.DataSource = task.Owners;

                cbList.Add(newComboBox);
                conteinerEdit.Controls.Add(newComboBox);
                newComboBox.SelectedIndex = index++;
            }



        }

        private void InitializeRegisterTechLead()
        {
            InitializeCbAssignees();
        }

        private void InitializeRegisterDev()
        {
            if (currentUser is Developer)
            {
                pnAssignees.Hide();
            }
        }

        private void InitializeCbAssignees()
        {
            cbAssignees.DataSource = currentTeam.TeamMembersID;
            cbAssignees.SelectedIndex = -1;
            cbList.Add(cbAssignees);
        }

        private void CbAssigneesSelectedIndexChanged(object sender, EventArgs e)
        {
            Guna2ComboBox senderCB = (Guna2ComboBox)sender;

            Developer devToExclude = (Developer)senderCB.SelectedItem;
            assigneeCandidates.Remove(devToExclude);

            if (assigneeCandidates.Count >= 1)
            {
                Guna2ComboBox newComboBox = new Guna2ComboBox();

                newComboBox.Location = new Point(senderCB.Left, senderCB.Bottom + 5);
                newComboBox.Font = senderCB.Font;
                newComboBox.Size = senderCB.Size;
                newComboBox.FillColor = senderCB.FillColor;
                newComboBox.BorderRadius = senderCB.BorderRadius;

                newComboBox.DataSource = assigneeCandidates;

                cbList.Add(newComboBox);
                pnAssignees.Controls.Add(newComboBox);
                newComboBox.SelectedIndex = -1;

                newComboBox.SelectedIndexChanged += CbAssigneesSelectedIndexChanged;
            }
        }



        private void InitializeCbTaskStatus()
        {
            cbTaskStatus.DataSource = Enum.GetValues(typeof(Status));
        }

        private void InitializeCbTaskPriority()
        {
            cbTaskPriority.DataSource = Enum.GetValues(typeof(Priority));
        }


        private void OnBtnCreateTaskClick(object sender, EventArgs e)
        {
            if (currentUser is Developer)
            {
                lbWaiting.Enabled = true;
            }
            else
            {
                string taskName = txtTaskName.Text;
                string taskDescription = txtTaskDescription.Text;
                DateTime startDate = dpStart.Value.Date;
                DateTime targetDate = dpStart.Value.Date;
                Status taskStatus = (Status)cbTaskStatus.SelectedItem;
                Priority taskPriority = (Priority)cbTaskPriority.SelectedItem;

                List<Developer> selectedDevelopers = cbList
                .Select(cb => cb.SelectedItem as Developer)
                .Where(dev => dev != null)
                .ToList();


                Model.Task task;

                if (cbSelfAssign.Checked)
                {
                    task = new Model.Task(taskName, startDate, targetDate, taskDescription, selectedDevelopers, taskStatus, taskPriority, true);
                }
                else
                {
                    task = new Model.Task(taskName, startDate, targetDate, taskDescription, selectedDevelopers, taskStatus, taskPriority, false);
                }


                currentProject.AddTask(task);
            }

        }

        private void onBtnEditClick(object sender, EventArgs e)
        {
            if (currentUser is Developer)
            {
                lbWaiting.Enabled = true;
            }
            else
            {
                        List<Developer?> selectedDevelopers = cbList
                .Select(cb => cb.SelectedItem as Developer)
                .Where(dev => dev != null)
                .ToList();


                taskToEdit.Name = txtTaskName.Text;
                taskToEdit.Description = txtTaskDescription.Text;
                taskToEdit.EndDate = dpStart.Value.Date;
                taskToEdit.Status = (Status)cbTaskStatus.SelectedItem;
                taskToEdit.Priority = (Priority)cbTaskPriority.SelectedItem;
                taskToEdit.Owners = selectedDevelopers;
            }
        }

        private void OnBtnBackClick(object sender, EventArgs e)
        {
            Close();
            new KanbanBoard(currentProject, currentTeam);
        }
    }
}
