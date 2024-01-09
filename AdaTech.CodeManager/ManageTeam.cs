using AdaTech.CodeManager.Model;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdaTech.CodeManager
{
    public partial class ManageTeam : BaseForm
    {
        private static List<Developer> avaiableTeamMembers = UserData.GetDevelopers();
        private static TechLead currentUser = (TechLead)Session.getInstance.GetCurrentUser();
        private static List<Guna2ComboBox> cbList = new List<Guna2ComboBox>();
        private static Team teamToEdit;

        public ManageTeam(Team? team = null)
        {

            InitializeComponent();

            if (team == null)
            {
                InitializeCreatePage();
                return;
            }

            teamToEdit = team;
            InitializeEditPage();

        }

        private void InitializeCreatePage()
        {
            btnSave.Visible = false;
            cbList.Clear();
            InitializeCbMembers();
        }

        private void InitializeEditPage()
        {
            cbList.Clear();
            lbPageType.Text = "Edit a";
            lbPageType.Location = new Point(187, 62);
            lbTeamMembers.Text = "Edit Members";
            CBMEMBER.Visible = false;
            txtTeamName.Text = teamToEdit.Name;
            btnCreate.Visible = false;
            lbTeam.Location = new Point(270, 62);

            int index = 0;
            foreach (var member in teamToEdit.GetTeamMembersName())
            {
                Guna2ComboBox newComboBox = new Guna2ComboBox();

                newComboBox.Font = new Font("Century Gothic", 8, FontStyle.Bold);
                newComboBox.Size = new Size(381, 36);
                newComboBox.FillColor = Color.FromArgb(252, 239, 239);
                newComboBox.BorderRadius = 20;

                newComboBox.DataSource = teamToEdit.GetTeamMembersName();

                cbList.Add(newComboBox);

                conteinerMembers.Controls.Add(newComboBox);
                newComboBox.SelectedIndex = index++;
            }
        }

        protected void InitializeCbMembers()
        {
            CBMEMBER.Font = new Font("Century Gothic", 8, FontStyle.Regular);
            CBMEMBER.DataSource = avaiableTeamMembers;
            CBMEMBER.SelectedIndex = -1;
            cbList.Add(CBMEMBER);
        }

        private void CbMembersSelectedIndexChanged(object sender, EventArgs e)
        {
            Guna2ComboBox senderCB = (Guna2ComboBox)sender;

            if (avaiableTeamMembers.Count < 1)
                return;

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

            newComboBox.DataSource = new List<Developer>(avaiableTeamMembers);

            cbList.Add(newComboBox);
            conteinerMembers.Controls.Add(newComboBox);
            newComboBox.SelectedIndex = -1;

            newComboBox.SelectedIndexChanged += CbMembersSelectedIndexChanged;
        }

        private Label CostumizeLbResult()
        {
            Label lbResult = new Label();
            lbResult.Text = "Team created!";
            lbResult.Font = new Font("Century Gothic", 10, FontStyle.Bold);
            lbResult.Location = new Point(230, 104);
            lbResult.BackColor = Color.FromArgb(252, 239, 239);
            lbResult.AutoSize = true;
            lbResult.ForeColor = Color.White;

            return lbResult;
        }
        private void OnBtnCreateClick(object sender, EventArgs e)
        {

            List<Guid> teamMembersID = new List<Guid>();

            foreach (var cb in cbList)
            {
                if (cb.SelectedItem != null)
                {
                    User user = UserData.SelectUser((User)cb.SelectedItem);
                    teamMembersID.Add(user.UserID);
                }
            }

            TeamData.AddTeam(new Team(txtTeamName.Text, teamMembersID, currentUser.UserID));
            CostumizeLbResult();
            Thread.Sleep(2000);
            Close();
            new SelectTeam().ShowDialog();

        }

        private void OnBtnBackClick(object sender, EventArgs e)
        {
            Close();
            new SelectTeam().ShowDialog();
        }

        private void OnBtnSaveClick(object sender, EventArgs e)
        {
            teamToEdit.Name = txtTeamName.Text;


            List<Guid> teamMembersID = new List<Guid>();

            foreach (var cb in cbList)
            {
                if (cb.SelectedItem != null)
                {
                    User user = UserData.SelectUser((User)cb.SelectedItem);
                    teamMembersID.Add(user.UserID);
                }
            }

            teamToEdit.TeamMembersID = teamMembersID;

            TeamData.SaveTeams();
            lbResult.Visible = true;

            Thread.Sleep(1000);
            Close();
            new SelectTeam().ShowDialog();
        }

    }
}
