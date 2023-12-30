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

            User selectedUser = UserData.SelectUser(enteredUsername);

            if (selectedUser != null && selectedUser.CheckPassword(enteredPassword))
            {
                Session.getInstance.SetCurrentUser(selectedUser);

                new Dashboard().Show();
                //this.Close();
            }

            txtUsername.Clear();
            txtPassword.Clear();
            lbResult.Text = selectedUser != null ? "User not found or incorrect password" : string.Empty;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
