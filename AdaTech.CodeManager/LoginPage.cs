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
                    Hide();
                    new SelectTeam().ShowDialog();
                    return;
                }
                else if(selectedUser is Developer){
                    Hide();
                    new DashboardDEV().ShowDialog();
                    return;
                }    
            }

            HandleAuthenticationError();

        }
        private void OnBtnExitClick(object sender, EventArgs e)
        {
            Close();
        }

        private void HandleAuthenticationError()
        {
            MessageBox.Show("User not found or incorrect password", "Authentication Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtUsername.Clear();
            txtPassword.Clear();
        }

 
    }
}
