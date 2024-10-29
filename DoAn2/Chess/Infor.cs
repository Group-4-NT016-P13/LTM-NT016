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
    public partial class Infor : Form
    {
        private string ChangedNickname;
        private string ChangedEmail;
        public Infor()
        {
            InitializeComponent();
        }
        public Infor(string Nickname,string Email)
        {
            Nickname = Nickname_txt.Text;
            Email = Email_txt.Text;
        }

        private void Fix_btn_Click(object sender, EventArgs e)
        {
            Nickname_txt.Text = ChangedNickname;
            Email_lb.Text = ChangedEmail;
            Menu Newmenu = new Menu(ChangedNickname,ChangedEmail);
            Newmenu.Show();
            this.Hide();
        }
    }
}
