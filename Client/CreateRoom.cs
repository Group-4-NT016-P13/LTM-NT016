using System;
using System.Net.Sockets;
using System.Windows.Forms;

namespace Client
{
    public partial class CreateRoom : Form
    {
        private int click = 0; 
        public CreateRoom()
        {
            InitializeComponent();
            RoomId(); 
        }

 
        private void RoomId(int length = 6)
        {
            Random random = new Random();
            string roomId = "";

            for (int i = 0; i < length; i++)
            {
                roomId += random.Next(0, 10).ToString(); 
            }

            textBox1.Text = roomId;  
            textBox1.Enabled = false; 
        }

   
        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    
        private void W_Click(object sender, EventArgs e)
        {
            if (click == 0) 
            {
                click++;
                MessageBox.Show("YOU ARE WHITE");
                W.Enabled = false;
                label3.Text = click + "/2"; 
            }
        }

        
        private void B_Click(object sender, EventArgs e)
        {
            if (click == 1) 
            {
                click++;
                MessageBox.Show("YOU ARE BLACK");
                B.Enabled = false; 
                label3.Text = click + "/2"; 
            }
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            if (click != 2) 
            {
                MessageBox.Show("NOT READY");
                return;
            }

            ChessWindow newGame = new ChessWindow(); 
            newGame.Show();
            this.Hide(); 
        }
    }
}
