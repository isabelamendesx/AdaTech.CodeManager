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
        private List<Developer> availableTeamMembers = UserData.GetDevelopers();
        private TechLead currentUser = (TechLead)Session.getInstance.GetCurrentUser();
        private List<Guna2ComboBox> cbList = new List<Guna2ComboBox>();
        private Team teamToEdit;

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

            if (IsDuplicateSelection(senderCB))
            {
                ShowDuplicateSelectionWarning(senderCB);
                return;
            }

            AddNewComboBox(senderCB);
        }

        private void OnBtnBackClick(object sender, EventArgs e)
        {
            Close();
            new SelectTeam().ShowDialog();
        }

        private async void OnBtnCreateTeamClick(object sender, EventArgs e)
        {
            try
            {
                List<Guid> teamMembersID = GetSelectedTeamMembers();

                TeamData.AddTeam(new Team(txtTeamName.Text, teamMembersID, currentUser.UserID));

                ShowResultAndClose("Team created!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating team: {ex.Message}");
            }
        }

        private void OnBtnSaveTeamClick(object sender, EventArgs e)
        {
            UpdateTeamInformation();
            SaveTeamData();
            ShowResultAndClose();
        }

        private async void OnBtnDeleteTeamClick(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete this team?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                TeamData.RemoveTeam(teamToEdit);
                lbResult.BackColor = Color.Red;
                lbResult.Text = "team deleted!";
                lbResult.Visible = true;

                await System.Threading.Tasks.Task.Delay(1000);
                Close();
                new SelectTeam().ShowDialog();
                return;
            }

        }

        #region Create Team Auxiliar Methods

        private void InitializeCreatePage()
        {
            btnDeleteTeam.Visible = false;
            cbList.Clear();
            InitializeCreateTeamMembersComboBoxes();
        }

        private void InitializeCreateTeamMembersComboBoxes()
        {
            ConfigureComboBox(CBMEMBER, availableTeamMembers);
            cbList.Add(CBMEMBER);
        }

        private void ConfigureComboBox(Guna2ComboBox comboBox, IEnumerable<Developer> dataSource)
        {
            comboBox.Font = new Font("Century Gothic", 8, FontStyle.Regular);
            comboBox.DataSource = dataSource;
            comboBox.SelectedIndex = -1;
        }

        private List<Guid> GetSelectedTeamMembers()
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

            return teamMembersID;
        }

        private async void ShowResultAndClose(string message)
        {
            lbResult.Text = message;
            lbResult.Visible = true;

            await System.Threading.Tasks.Task.Delay(1000);

            Close();
            new SelectTeam().ShowDialog();
        }

        #endregion 


        #region Edit Team Auxiliar Methods

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

                ConfigureComboBoxEvents(newComboBox);
                AddComboBoxToContainer(newComboBox);
                cbList.Add(newComboBox);
            }
        }

        private void ConfigureComboBoxEvents(Guna2ComboBox comboBox)
        {
            comboBox.SelectedIndexChanged += CbMembersSelectedIndexChanged;
        }

        private void AddComboBoxToContainer(Guna2ComboBox comboBox)
        {
            conteinerMembers.Controls.Add(comboBox);
        }

        private void UpdateTeamInformation()
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
        }

        private void SaveTeamData()
        {
            TeamData.SaveTeams();
        }

        private async void ShowResultAndClose()
        {
            lbResult.Visible = true;
            await System.Threading.Tasks.Task.Delay(1000);
            Close();
            new SelectTeam().ShowDialog();
        }

        #endregion


        #region Combo Boxes Select Index Changed Auxiliar Methods

        private bool IsDuplicateSelection(Guna2ComboBox senderCB)
        {
            return cbList.Count > 1 && cbList.Any(cb => cb.SelectedItem == senderCB.SelectedItem && cb != senderCB);
        }

        private void ShowDuplicateSelectionWarning(Guna2ComboBox senderCB)
        {
            MessageBox.Show("You already selected this member", "Duplicate Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            senderCB.SelectedIndex = -1;
        }

        private void AddNewComboBox(Guna2ComboBox originalComboBox)
        {
            Guna2ComboBox newComboBox = CreateNewComboBox(originalComboBox);
            cbList.Add(newComboBox);
            conteinerMembers.Controls.Add(newComboBox);
            newComboBox.SelectedIndex = -1;
            newComboBox.SelectedIndexChanged += CbMembersSelectedIndexChanged;
        }

        private Guna2ComboBox CreateNewComboBox(Guna2ComboBox originalComboBox)
        {
            Guna2ComboBox newComboBox = new Guna2ComboBox();
            CopyComboBoxProperties(originalComboBox, newComboBox);
            newComboBox.DataSource = new List<Developer>(availableTeamMembers);
            return newComboBox;
        }

        private void CopyComboBoxProperties(Guna2ComboBox sourceComboBox, Guna2ComboBox destinationComboBox)
        {
            destinationComboBox.Font = sourceComboBox.Font;
            destinationComboBox.Size = sourceComboBox.Size;
            destinationComboBox.FillColor = sourceComboBox.FillColor;
            destinationComboBox.BorderRadius = sourceComboBox.BorderRadius;
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
            btnSave.Visible = true;
            btnDeleteTeam.Visible = true;
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
