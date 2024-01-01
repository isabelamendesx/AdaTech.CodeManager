using AdaTech.CodeManager.Model;
using Guna.UI2.WinForms;
using System;
using System.Collections;
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
    public partial class RegisterTask : BaseForm
    {
        private static Project currentProject;
        private static Team currentTeam;
        private static List<Employee> assigneesOptions;
        private static List<Guna2ComboBox> cbList = new List<Guna2ComboBox>();
        public RegisterTask(Project project, Team team)
        {
            currentProject = project;
            currentTeam = team;
            InitializeComponent();
            InitializaCbAssignees();
            InitializeCbTaskStatus();
            InitializeCbTaskPriority();
        }

        private void RegisterTask_Load(object sender, EventArgs e)
        {

        }

        private void InitializaCbAssignees()
        {
            assigneesOptions = currentTeam.TeamMembers.Cast<Employee>().ToList();
            assigneesOptions.Add((Employee)Session.getInstance.GetCurrentUser());

            cbAssignees.DataSource = assigneesOptions;
            cbAssignees.SelectedIndex = -1;
            cbList.Add(cbAssignees);
        }

        private void InitializeCbTaskStatus()
        {
            cbTaskStatus.DataSource = Enum.GetValues(typeof(Status));
        }

        private void InitializeCbTaskPriority()
        {
            cbTaskPriority.DataSource = Enum.GetValues(typeof(Priority));
        }

        private void CbAssigneesSelectedIndexChanged(object sender, EventArgs e)
        {
            Guna2ComboBox senderCB = (Guna2ComboBox)sender;

            // Obter o desenvolvedor selecionado
            Employee empToExclude = (Employee)senderCB.SelectedItem;
            assigneesOptions.Remove(empToExclude);

            // Criar um novo ComboBox antes de remover o desenvolvedor da lista
            if (assigneesOptions.Count >= 1)
            {
                // Criar um novo ComboBox antes de remover o desenvolvedor da lista
                Guna2ComboBox newComboBox = new Guna2ComboBox();

                newComboBox.Location = new Point(senderCB.Left, senderCB.Bottom + 5);
                newComboBox.Font = senderCB.Font;
                newComboBox.Size = senderCB.Size;
                newComboBox.FillColor = senderCB.FillColor;
                newComboBox.BorderRadius = senderCB.BorderRadius;

                // Definir a fonte de dados com a lista atualizada
                newComboBox.DataSource = assigneesOptions;

                cbList.Add(newComboBox);
                pnAssignees.Controls.Add(newComboBox);
                newComboBox.SelectedIndex = -1;

                newComboBox.SelectedIndexChanged += CbAssigneesSelectedIndexChanged;
            }
        } 

        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void OnBtnCreateTaskClick(object sender, EventArgs e)
        {
            string taskName = txtTaskName.Text;
            string taskDescription = txtTaskDescription.Text;
            DateTime startDate  = dpStart.Value.Date;
            DateTime targetDate  = dpStart.Value.Date;
            Status taskStatus = (Status)cbTaskStatus.SelectedItem;
            Priority taskPriority = (Priority)cbTaskPriority.SelectedItem;

            List<Employee?> employees = cbList
                .Where(cb => cb.SelectedItem is Employee)
                .Select(cb => cb.SelectedItem as Employee)
                .ToList();

            Model.Task task = new Model.Task(taskName, taskDescription, employees, taskStatus, startDate, targetDate, taskPriority);

            currentProject.AddTask(task);

        }
    }
}
