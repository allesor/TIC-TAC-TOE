using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class Player : User
    {
        public Player(string id, string pass) : base(id, pass) { }

        public override void updatePassword(string newPassword)
        {
            this.user_password = newPassword;
        }

        public string Password
        {
            get { return this.user_password; }
        }
    }
}
