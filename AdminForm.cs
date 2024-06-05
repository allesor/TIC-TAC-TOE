using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
        }

        private void btnCreatePlayer_Click(object sender, EventArgs e)
        {
            string username = txtNewUsername.Text;
            string password = txtNewPassword.Text;

            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                Form1.Players.Add(new Player(username, password));
                MessageBox.Show("Player created successfully.");
                txtNewUsername.Clear();
                txtNewPassword.Clear();
            }
            else
            {
                MessageBox.Show("Username and Password cannot be empty.");
            }
        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            string username = txtResetUsername.Text;
            string newPassword = txtResetPassword.Text;

            var player = Form1.Players.FirstOrDefault(p => p.verifyLogin(username, string.Empty) || p.verifyLogin(username, p.Password));
            if (player != null && !string.IsNullOrEmpty(newPassword))
            {
                player.updatePassword(newPassword);
                MessageBox.Show("Password reset successfully.");
                txtResetUsername.Clear();
                txtResetPassword.Clear();
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.ShowDialog();
            this.Close();
        }
    }
}
