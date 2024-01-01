using AdaTech.CodeManager.Model;
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
        public KanbanBoard(Project project, Team team)
        {
            InitializeComponent();
            InitializeBackLog();
            currentProject = project;
            currentTeam = team;
        }

        private void InitializeBackLog()
        {
            if (currentProject.getBackLogTasks() != null)
            {
                foreach (var task in currentProject.getBackLogTasks())
                {
                    var label = new Label();
                    label.Text = task.Name;
                    label.ForeColor = Color.White;

                    conteinerBackLog.Controls.Add(label);
                }
            }
        }

        private void KanbanBoard_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void OnBtnCreateTaskClick(object sender, EventArgs e)
        {
            Close();
            new RegisterTask(currentProject, currentTeam).ShowDialog();
        }
    }
}
