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
        private static List<Developer> availableTeamMembers = UserData.GetDevelopers();
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

        private void CbMembersSelectedIndexChanged(object sender, EventArgs e)
        {
            Guna2ComboBox senderCB = (Guna2ComboBox)sender;

            if (availableTeamMembers.Count < 1)
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

            newComboBox.DataSource = new List<Developer>(availableTeamMembers);

            cbList.Add(newComboBox);
            conteinerMembers.Controls.Add(newComboBox);
            newComboBox.SelectedIndex = -1;

            newComboBox.SelectedIndexChanged += CbMembersSelectedIndexChanged;
        }

        private void OnBtnBackClick(object sender, EventArgs e)
        {
            Close();
            new SelectTeam().ShowDialog();
        }

        #region Create Team Methods

        private void InitializeCreatePage()
        {
            btnSave.Visible = false;
            cbList.Clear();
            InitializeCreateTeamMembersComboBoxes();
        }

        protected void InitializeCreateTeamMembersComboBoxes()
        {
            CBMEMBER.Font = new Font("Century Gothic", 8, FontStyle.Regular);
            CBMEMBER.DataSource = availableTeamMembers;
            CBMEMBER.SelectedIndex = -1;
            cbList.Add(CBMEMBER);
        }

        private async void OnBtnCreateClick(object sender, EventArgs e)
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

            lbResult.Text = "team created!";
            lbResult.Visible = true;
            
            await System.Threading.Tasks.Task.Delay(1000);

            Close();
            new SelectTeam().ShowDialog();

        }

        #endregion 


        #region Edit Team Methods

        private void InitializeEditPage()
        {
            cbList.Clear();
            CostumizeEditElements();
            InitializeEditTeamMembersComboBoxes();
        }

        private void InitializeEditTeamMembersComboBoxes()
        {
            List<Developer> teamMembers = teamToEdit.GetTeamMembers();

            foreach (var member in teamMembers)
            {
                Guna2ComboBox newComboBox = CreateNewComboBox(member);
                int selectedIndex = availableTeamMembers.IndexOf(member) + 1;
                newComboBox.SelectedIndex = selectedIndex;

                cbList.Add(newComboBox);
                conteinerMembers.Controls.Add(newComboBox);
                newComboBox.SelectedIndexChanged += CbMembersSelectedIndexChanged;
            }
        }

        private async void OnBtnSaveClick(object sender, EventArgs e)
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

            await System.Threading.Tasks.Task.Delay(1000);

            Close();
            new SelectTeam().ShowDialog();
        }


        #endregion 


        #region UI Element Builders

        private void CostumizeEditElements()
        {
            lbPageType.Text = "Edit a";
            lbPageType.Location = new Point(187, 62);
            lbTeamMembers.Text = "Edit Members";
            CBMEMBER.Visible = false;
            txtTeamName.Text = teamToEdit.Name;
            btnCreate.Visible = false;
            lbTeam.Location = new Point(270, 62);
        }

        private Guna2ComboBox CreateNewComboBox(Developer member)
        {
            Guna2ComboBox newComboBox = new Guna2ComboBox
            {
                Font = new Font("Century Gothic", 8, FontStyle.Bold),
                Size = new Size(381, 36),
                FillColor = Color.FromArgb(252, 239, 239),
                BorderRadius = 20
            };

            newComboBox.Items.Add("");
            newComboBox.Items.AddRange(availableTeamMembers.ToArray());

            return newComboBox;
        }


        #endregion



    }
}
