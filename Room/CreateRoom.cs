using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Room
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

            // Tạo ID với số ngẫu nhiên có độ dài nhất định
            for (int i = 0; i < length; i++)
            {
                roomId += random.Next(0, 10).ToString(); // Sinh ra số ngẫu nhiên từ 0 đến 9
            }

            textBox1.Text = roomId;
            textBox1.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
                click++;
                MessageBox.Show("YOU ARE WHITE");
                button3.Enabled = false;  // Vô hiệu hóa button trắng sau khi chọn
                label3.Text = click + "/2";
        }

        private void button4_Click(object sender, EventArgs e)
        {
                click++;
                MessageBox.Show("YOU ARE BLACK");
                button4.Enabled = false;  // Vô hiệu hóa button đen sau khi chọn
                label3.Text = click + "/2";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (click != 2)
            {
                MessageBox.Show("NOT READY");
            }
            else
            {
                MessageBox.Show("Sucessful");
            }
        }
    }
}
