using System;
using System.Windows.Forms;
using static excercise_2.login;

namespace excercise_2
{
    public partial class infor : Form
    {
        public infor(string username, string email)
        {
            InitializeComponent();
            textBox1.Text = username;
            textBox4.Text = email;
 
        }
        private void infor_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
