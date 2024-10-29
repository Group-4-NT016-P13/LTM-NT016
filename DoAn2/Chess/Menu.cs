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
        private string UserNickname;
        private string UserEmail;
        public Menu()
        {
            InitializeComponent();
        }
        public Menu(string Nickname, string Email)
        {
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
            Infor log = new Infor(UserNickname,UserEmail);
            log.Show();
            this.Hide();
        }
    }
}
