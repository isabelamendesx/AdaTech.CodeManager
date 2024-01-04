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
    public partial class RegisterPage : BaseForm
    {
        private static List<Developer> Developers = UserData.GetDevelopers();
        private static List<Developer> selectedDevelopersList = new List<Developer>();
        // private static TechLead currentUser = (TechLead)Session.getInstance.GetCurrentUser();
        private static List<Guna2ComboBox> cbList = new List<Guna2ComboBox>();
        public RegisterPage()
        {
            InitializeComponent();
            InitializeCbMembers();
        }

        protected void InitializeCbMembers()
        {
            CBMEMBER.Font = new Font("Century Gothic", 8, FontStyle.Regular);
            CBMEMBER.DataSource = Developers;
            CBMEMBER.SelectedIndex = -1;
            cbList.Add(CBMEMBER);
        }


        private void CbMembersSelectedIndexChanged(object sender, EventArgs e)
        {
            Guna2ComboBox senderCB = (Guna2ComboBox)sender;

            Developer devToExclude = (Developer)senderCB.SelectedItem;
            Developers.Remove(devToExclude);

            if (Developers.Count >= 1)
            {
                Guna2ComboBox newComboBox = new Guna2ComboBox();

                newComboBox.Location = new Point(senderCB.Left, senderCB.Bottom + 5);
                newComboBox.Font = senderCB.Font;
                newComboBox.Size = senderCB.Size;
                newComboBox.FillColor = senderCB.FillColor;
                newComboBox.BorderRadius = senderCB.BorderRadius;

                newComboBox.DataSource = Developers;

                cbList.Add(newComboBox);
                pnMembers.Controls.Add(newComboBox);
                newComboBox.SelectedIndex = -1;

                newComboBox.SelectedIndexChanged += CbMembersSelectedIndexChanged;
            }
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
            TechLead currentUser = (TechLead)Session.getInstance.GetCurrentUser();
            List<Developer> teamMembers = new List<Developer>();

            foreach (var cb in cbList)
            {
                if (cb.SelectedItem != null)
                {
                    teamMembers.Add((Developer)cb.SelectedItem);
                }
            }

            currentUser.CreateTeam(txtTeamName.Text, teamMembers);
            CostumizeLbResult();
            Thread.Sleep(2000);
            Hide();
            new SelectTeam().ShowDialog();

        }

        private void OnBtnBackClick(object sender, EventArgs e)
        {
            Close();
            new SelectTeam().ShowDialog();
        }
    }
}
