using AdaTech.CodeManager.Model;

namespace AdaTech.CodeManager
{
    public partial class LoginPage : Form
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void onBtnLoginClick(object sender, EventArgs e)
        {
            string enteredUsername = txtUsername.Text;
            string enteredPassword = txtPassword.Text;

            User? selectedUser = UserData.SelectUser(enteredUsername);

            if (selectedUser != null && selectedUser.CheckPassword(enteredPassword))
            {
                Session.getInstance.SetCurrentUser(selectedUser);

                if(selectedUser is TechLead)
                {
                    new SelectTeam().ShowDialog();
                }
                else if(selectedUser is Developer){
                    new DashboardDEV().ShowDialog();
                }

                
            }

            txtUsername.Clear();
            txtPassword.Clear();
            lbResult2.Text = selectedUser != null ? "User not found or incorrect password" : string.Empty;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void LoginPage_Load(object sender, EventArgs e)
        {

        }

        private void OnBtnExitClick(object sender, EventArgs e)
        {
            Close();
        }
    }
}
