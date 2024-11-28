using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chess
{
    public partial class MatchGame : Form
    {
        private TCPClient client;
        private bool isFindingMatch = false;
       // private bool WaitingPlayer = false;

        public MatchGame(TCPClient client)
        {
            InitializeComponent();
            this.client = client;
            Username_txt.Text = client.Username;
            Email_txt.Text = client.Email;
            Rating_txt.Text = client.Rating.ToString();
        }
        private static string GenerateRandomString(int length)
        {
            const string chars = "0123456789";
            Random random = new Random();

            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        private async void btn_find_Click(object sender, EventArgs e)
        {
            if (isFindingMatch)
            {
                MessageBox.Show("Đang tìm trận. Vui lòng chờ...");
                return;
            }

            isFindingMatch = true;
            lblStatus.Text = "Đang tìm trận...";

            // Gửi yêu cầu tìm trận
            await FindMatchAsync();
        }

        private async Task FindMatchAsync()
        {
            try
            {
                // Gửi yêu cầu tìm trận tới server
                string response = await client.FindMatchAsync();

                // Kiểm tra phản hồi từ server
                if (response.StartsWith("WAITING"))
                {
                    lblStatus.Text = "Chờ đợi người chơi khác...";
                    await ListenForMatchAsync(); // Lắng nghe thông báo tìm thấy trận
                }
                else if (response.StartsWith("MATCH_FOUND"))
                {
                    OpenChessBoard(response); // Mở bàn cờ nếu tìm thấy trận
                }
                else
                {
                    lblStatus.Text = "Lỗi: " + response;
                    isFindingMatch = false;
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Lỗi: " + ex.Message;
                isFindingMatch = false;
            }
        }

        private async Task ListenForMatchAsync()
        {
            while (true)
            {
                // Đọc phản hồi từ server về việc tìm trận
                string response = await client.WaitForMatchAsync();

                if (response.StartsWith("MATCH_FOUND") || response.StartsWith("START"))
                {
                    OpenChessBoard(response); // Mở bàn cờ khi trận đấu được tìm thấy
                    break;
                }
                else
                {
                    lblStatus.Text = response;
                    await Task.Delay(1000); // Đợi một chút rồi kiểm tra lại
                }
            }
        }

        private void OpenChessBoard(string matchResponse)
        {
            if (string.IsNullOrEmpty(matchResponse))
            {
                MessageBox.Show("Lỗi: Phản hồi trận đấu không hợp lệ.");
                return;
            }

            string[] parts = matchResponse.Split(' ');

            if (parts.Length < 2)
            {
                MessageBox.Show("Lỗi: Định dạng phản hồi trận đấu không hợp lệ.");
                return;
            }

            string playerColor = parts[1]; // "WHITE" hoặc "BLACK"
            MessageBox.Show($"Trận đấu đã tìm thấy! Bạn đang chơi với màu: {playerColor}");

            // Mở bàn cờ không chặn giao diện
            ChessBoardForm chessBoard = new ChessBoardForm(client, playerColor);
            this.Hide();
            chessBoard.Show();
            chessBoard.FormClosed += (s, e) => this.Show();
        }

        private void MatchGame_Load(object sender, EventArgs e)
        {
            // Thêm logic nếu cần khi form tải
        }
        private void label1_Click(object sender, EventArgs e)
        {
            // Thêm logic nếu cần khi nhấp vào label
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            this.Hide();
            form1.Show();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Champion champ = new Champion(client);
            champ.Show();
        }

        private void FindRoom_btn_Click(object sender, EventArgs e)
        {
            Find_btn.Visible = !Find_btn.Visible;
            FindRoom_btn.Visible = !FindRoom_btn.Visible;
            CreateRoom_btn.Visible = !CreateRoom_btn.Visible;
            AIPlay_btn.Visible = !AIPlay_btn.Visible;
            lblStatus.Visible = !lblStatus.Visible;

            RoomID_txt.Visible = !RoomID_txt.Visible;
            RoomID_txt.ReadOnly = false;
            Notification_txt.Visible = !Notification_txt.Visible;
            FindRoom2_btn.Visible = !FindRoom2_btn.Visible;



        }

        private async void CreateRoom_btn_Click(object sender, EventArgs e)
        {
            Find_btn.Visible = !Find_btn.Visible;
            FindRoom_btn.Visible = !FindRoom_btn.Visible;
            CreateRoom_btn.Visible = !CreateRoom_btn.Visible;
            AIPlay_btn.Visible = !AIPlay_btn.Visible;
            lblStatus.Visible = !lblStatus.Visible;

            RoomID_txt.Visible = !RoomID_txt.Visible;
            Notification_txt.Visible = !Notification_txt.Visible;

            RoomID_txt.Text = GenerateRandomString(5);
            string roomId = RoomID_txt.Text.Trim();
            string request = $"CREATEROOM {roomId}";
            try
            {
                string response = await client.SendRequestAsync(request);
                string[] parts = response.Split(' ');
                if (response.StartsWith("SUCCESS"))
                {
                    client.RoomID = parts[2];
                    Notification_txt.Text = response;
                    await ListenForMatchAsync(); // Lắng nghe thông báo tìm thấy người chơi
                }
                else if (response.StartsWith("ERROR"))
                {
                    Notification_txt.Text = "Phòng đã tồn tại";
                }
                else
                {
                    Notification_txt.Text = $"Lỗi: {response}";
                }
            }
            catch (Exception ex)
            {
                Notification_txt.Text = $"Lỗi: {ex.Message}";
            }
        }

        private async void FindRoom2_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(RoomID_txt.Text))
            {
                Notification_txt.Text = "Vui lòng nhập mã phòng.";
                return;
            }

            string roomId = RoomID_txt.Text.Trim();
            string request = $"FINDROOM {roomId}";

            try
            {
                string response = await client.SendRequestAsync(request);
                string[] parts = response.Split(' ');
                if (response.StartsWith("SUCCESS"))
                {
                    client.RoomID = parts[2];
                    Notification_txt.Text = "Phòng đã tìm thấy! Đang kết nối...";
                    OpenChessBoard(response);
                }
                else if (response.StartsWith("ERROR"))
                {
                    Notification_txt.Text = "Phòng không tồn tại. Vui lòng kiểm tra lại.";
                }
                else
                {
                    Notification_txt.Text = $"Lỗi: {response}";
                }
            }
            catch (Exception ex)
            {
                Notification_txt.Text = $"Lỗi: {ex.Message}";
            }
        }
    }
}