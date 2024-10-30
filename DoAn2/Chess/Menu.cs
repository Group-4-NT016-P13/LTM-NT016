using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    public partial class Menu : Form
    {
        private string User_Username;
        private string User_Nickname;
        private string User_Email;
        public Menu()
        {
            InitializeComponent();
        }
        public Menu(string Username,string Nickname, string Email)
        {
            User_Username = Username;
            User_Nickname = Nickname;
            User_Email = Email;
            InitializeComponent();
            ToolTip toolTip = new ToolTip();
            string toolTipText = $"Tên người dùng: {Nickname}\nEmail: {Email}";
            toolTip.SetToolTip(UserInfo, toolTipText);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void UserInfo_Click(object sender, EventArgs e)
        {
            Infor log = new Infor(User_Username,User_Nickname,User_Email);
            log.ShowDialog();
            this.Hide();
        }
    }
}
