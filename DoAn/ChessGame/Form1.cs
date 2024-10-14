using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ChessGame
{
    public partial class Form1 : Form
    {
        //private Panel selectedPanel = null;
        //private Image selectedPiece = null;
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
                    Panel panel = new Panel
                    {
                        Dock = DockStyle.Fill,
                        BackColor = (i + j) % 2 == 0 ? Color.FromArgb(255, 235, 205) : Color.FromArgb(139, 69, 19),
                        BackgroundImageLayout = ImageLayout.Stretch
                    };
                   // panel.Click += Panel_Click;
                    if (i == 1)
                    {
                        panel.BackgroundImage = LoadImage("PawnBlack.png");
                    }
                    else if (i == 6) // Quân tốt trắng
                    {
                        panel.BackgroundImage = LoadImage("PawnWhite.png");
                    }
                    else if (i == 0)
                    {
                        panel.BackgroundImage = GetBlackPieceImage(j);
                    }
                    else if (i == 7)
                    {
                        panel.BackgroundImage = GetWhitePieceImage(j);
                    }

                    tableLayoutPanel1.Controls.Add(panel, j, i);
                    panels[i, j] = panel;
                }
            }
        }

        private Image GetBlackPieceImage(int column)
        {
            switch (column)
            {
                case 0: return LoadImage("RookBlack.png");
                case 1: return LoadImage("KnightBlack.png");
                case 2: return LoadImage("BishopBlack.png");
                case 3: return LoadImage("QueenBlack.png");
                case 4: return LoadImage("KingBlack.png");
                case 5: return LoadImage("BishopBlack.png");
                case 6: return LoadImage("KnightBlack.png");
                case 7: return LoadImage("RookBlack.png");
                default: return null;
            }
        }

        private Image GetWhitePieceImage(int column)
        {
            switch (column)
            {
                case 0: return LoadImage("RookWhite.png");
                case 1: return LoadImage("KnightWhite.png");
                case 2: return LoadImage("BishopWhite.png");
                case 3: return LoadImage("QueenWhite.png");
                case 4: return LoadImage("KingWhite.png");
                case 5: return LoadImage("BishopWhite.png");
                case 6: return LoadImage("KnightWhite.png");
                case 7: return LoadImage("RookWhite.png");
                default: return null;
            }
        }


        private Image LoadImage(string filename)
        {
            // Đường dẫn cố định đến thư mục hình ảnh
            string imagePath = Path.Combine(@"D:\Dai Hoc\DoAn\image", filename);

            if (File.Exists(imagePath))
            {
                return Image.FromFile(imagePath);
            }
            else
            {
                throw new FileNotFoundException("Hình ảnh không tìm thấy: " + imagePath);
            }
        }
        //private void Panel_Click(object sender, EventArgs e)
        //{
        //    Panel clickedPanel = sender as Panel;

        //    if (selectedPanel == null && clickedPanel.BackgroundImage != null)
        //    {
        //        // Chọn quân cờ
        //        selectedPanel = clickedPanel;
        //        selectedPiece = clickedPanel.BackgroundImage;
        //        clickedPanel.BackgroundImage = null;  // Xóa hình từ ô cũ khi chọn
        //    }
        //    else if (selectedPanel != null)
        //    {
        //        // Di chuyển quân cờ đến ô mới
        //        clickedPanel.BackgroundImage = selectedPiece;

        //        // Xóa trạng thái đã chọn
        //        selectedPanel = null;
        //        selectedPiece = null;
        //    }
        //}

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
