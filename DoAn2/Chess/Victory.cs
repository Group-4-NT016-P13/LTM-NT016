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
    public partial class Victory : Form
    {
        public Victory()
        {

            InitializeComponent();

            // Lấy trạng thái game
            string result = Board.Window.GameState.Text;

           

            // Thiết lập form
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = result == "LOSE" ? Color.Green : Color.Red;
            this.Size = new Size(300, 150);

            // Chuyển đổi "WIN" thành "WINNER" và "LOSE" thành "LOSER"
            if (result == "WIN") result = "WINNER";
            else if (result == "LOSE") result = "LOSER";

            // Tạo và thiết lập Label trong code
            Label labelMessage = new Label();
            labelMessage.Text = result;
            labelMessage.ForeColor = Color.White;
            labelMessage.Font = new Font("Arial", 24, FontStyle.Bold);
            labelMessage.TextAlign = ContentAlignment.MiddleCenter;
            labelMessage.Dock = DockStyle.Fill;

            // Thêm Label vào form
            this.Controls.Add(labelMessage);

            // Thiết lập sự kiện Load cho form để tạo nút đóng
            this.Load += Form1_Load;
        }

        private void Form1_Load(object s, EventArgs e)
        {
            // Tạo nút đóng form
            Button closeButton = new Button();
            closeButton.Text = "X";
            closeButton.Font = new Font("Arial", 10, FontStyle.Bold);
            closeButton.Size = new Size(30, 30);
            closeButton.BackColor = Color.Black;
            closeButton.ForeColor = Color.White;
            closeButton.FlatStyle = FlatStyle.Flat;
            closeButton.FlatAppearance.BorderSize = 0;

            // Đặt vị trí nút ở góc phải trên của form
            closeButton.Location = new Point(this.ClientSize.Width - closeButton.Width - 10, 10);
            closeButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            // Đóng form khi bấm nút (đổi tên biến sender trong lambda)
            closeButton.Click += (obj, args) => this.Close();

            // Thêm nút đóng vào form
            this.Controls.Add(closeButton);
            closeButton.BringToFront();
        }
    }
}
