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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (Form1.Admin.verifyLogin(username, password))
            {
                Form1.LoggedInUser = Form1.Admin;
                this.Hide();
                AdminForm adminForm = new AdminForm();
                adminForm.ShowDialog();
                this.Close();
            }
            else
            {
                var player = Form1.Players.FirstOrDefault(p => p.verifyLogin(username, password));
                if (player != null)
                {
                    Form1.LoggedInUser = player;
                    this.Hide();
                    Form1 gameForm = new Form1();
                    gameForm.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Invalid credentials.");
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
