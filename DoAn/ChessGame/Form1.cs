using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace ChessGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeChessBoard();
        }
        private const int size = 8;
        private Panel[,] panels = new Panel[size, size];
        private void InitializeChessBoard()
        {
            
            tableLayoutPanel1.RowCount = size;
            tableLayoutPanel1.ColumnCount = size;

            // Tạo ô bàn cờ
            for (int i = 0; i < size; i++)
            {   
                for (int j = 0; j < size; j++)
                {
                    
                    Panel panel = new Panel();
                    panel.Dock = DockStyle.Fill;

                    
                    if ((i + j) % 2 == 0)
                        panel.BackColor = Color.FromArgb(255, 235, 205);
                    else
                        panel.BackColor = Color.FromArgb(139, 69, 19);

                    if (i == 1) 
                    {
                       panel.BackgroundImage = Properties.Resources.PawnBlack; // Đảm bảo hình ảnh đã được thêm vào Resources
                    }
                    else if (i == 6) // Quân tốt trắng
                    {
                       panel.BackgroundImage = Properties.Resources.PawnWhite; // Đảm bảo hình ảnh đã được thêm vào Resources
                    }
                    else if (i == 0) // Quân cờ đen
                    {
                        panel.BackgroundImage = GetBlackPieceImage(j);
                    }
                    else if (i == 7) // Quân cờ trắng
                    {
                        panel.BackgroundImage = GetWhitePieceImage(j);
                    }

                    panel.BackgroundImageLayout = ImageLayout.Stretch; // Đặt chế độ hiển thị hình ảnh
                    tableLayoutPanel1.Controls.Add(panel, j, i);
                    panels[i, j] = panel; // Lưu panel vào mảng để sử dụng sau này nếu cần
                    
                }
            }
        }

        private Image GetBlackPieceImage(int column)
        {
            switch (column)
            {
                //case 0: return Properties.Resources.RookBlack;
                //case 1: return Properties.Resources.KnightBlack;
                //case 2: return Properties.Resources.BishopBlack;
                //case 3: return Properties.Resources.QueenBlack;
                //case 4: return Properties.Resources.KingBlack;
                //case 5: return Properties.Resources.BishopBlack;
                //case 6: return Properties.Resources.KnightBlack;
                //case 7: return Properties.Resources.RookBlack;
                default: return null;
            }
        }

        private Image GetWhitePieceImage(int column)
        {
            switch (column)
            {
                //case 0: return Properties.Resources.RookWhite;
                //case 1: return Properties.Resources.KnightWhite;
                //case 2: return Properties.Resources.BishopWhite;
                //case 3: return Properties.Resources.QueenWhite;
                //case 4: return Properties.Resources.KingWhite;
                //case 5: return Properties.Resources.BishopWhite;
                //case 6: return Properties.Resources.KnightWhite;
                //case 7: return Properties.Resources.RookWhite;
                default: return null;
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            // Không cần triển khai gì ở đây
        }
    }
}
