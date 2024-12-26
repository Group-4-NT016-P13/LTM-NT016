using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace chess
{
    public partial class MatchGame : Form
    {
        private TCPClient client;
        private bool isFindingMatch = false;
        private string timeInText;
        private string Time;

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

        private async Task ListenForMatch()
        {
            while (true)
            {
                // Đọc phản hồi từ server về việc tìm trận
                string response = await client.ReceiveResponse();
                string[] parts = response.Split(' ');
                if (response.StartsWith("MATCH_FOUND"))
                {
                    OpenChessBoard(response, true); 
                    break;
                }
                else if(response.StartsWith("START"))
                {
                    Opponentname_txt.Text = parts[2];
                    OpponentRating_txt.Text = parts[3];
                    await Task.Delay(10000);
                    OpenChessBoard(response,false); 
                    break;
                }    
                else
                { 
                    await Task.Delay(1000); 
                }
            }
        }

        private void OpenChessBoard(string matchResponse,bool IsRandom,string time = null)
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

            string playerColor = parts[1];// "WHITE" hoặc "BLACK"
            string opponentname = parts[2];
            if(parts.Length ==1)
            {
                opponentname = "Đối Thủ";
            }    
            MessageBox.Show($"Trận đấu đã tìm thấy! Bạn đang chơi với màu: {playerColor}");
            if(IsRandom)
            {
                Time = "300";
            }    
            
            ChessBoardForm chessBoard = new ChessBoardForm(client, playerColor,opponentname,Time);
            this.Hide();
            chessBoard.Show();
            chessBoard.FormClosed += (s, e) => this.Show();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            AIPlay form1 = new AIPlay();
            this.Hide();
            form1.Show();
           
        }

        private void CreateRandom_btn_Click(object sender, EventArgs e)
        {
            CreateRandom_btn.Visible = !CreateRandom_btn.Visible;
            FindRoom_btn.Visible = !FindRoom_btn.Visible;
            CreateRoom_btn.Visible = !CreateRoom_btn.Visible;
            AIPlay_btn.Visible = !AIPlay_btn.Visible;

            RoomID_txt.Visible = !RoomID_txt.Visible;
            Notification_txt.Visible = !Notification_txt.Visible;

            OpponentRating_txt.Visible = !OpponentRating_txt.Visible;
            OpponenRating_lb.Visible = !OpponenRating_lb.Visible;
            OpponentName_lb.Visible = !OpponentName_lb.Visible;
            Opponentname_txt.Visible = !Opponentname_txt.Visible;
            RoomID_txt.Text = GenerateRandomString(5);
            CreateRandom2_btn.Visible = !CreateRandom2_btn.Visible;
            TimeSelect_lb.Visible = !TimeSelect_lb.Visible;
            TimeList_cb.Visible = !TimeList_cb.Visible;
            PieceColorSelect_lb.Visible = !PieceColorSelect_lb.Visible;
            ColorList_cb.Visible = !ColorList_cb.Visible;
            Return_btn.Visible = !Return_btn.Visible;
        }
        private void FindRoom_btn_Click(object sender, EventArgs e)
        {
            CreateRandom_btn.Visible = !CreateRandom_btn.Visible;
            FindRoom_btn.Visible = !FindRoom_btn.Visible;
            CreateRoom_btn.Visible = !CreateRoom_btn.Visible;
            AIPlay_btn.Visible = !AIPlay_btn.Visible;
            FindRandom_btn.Visible = !FindRandom_btn.Visible;
           
            OpponentRating_txt.Visible = !OpponentRating_txt.Visible;
            OpponenRating_lb.Visible = !OpponenRating_lb.Visible;
            OpponentName_lb.Visible = !OpponentName_lb.Visible;
            Opponentname_txt.Visible = !Opponentname_txt.Visible;
            RoomID_txt.Text = string.Empty;
            RoomID_txt.Visible = !RoomID_txt.Visible;
            RoomID_txt.ReadOnly = false;
            Notification_txt.Visible = !Notification_txt.Visible;
            FindRoom2_btn.Visible = !FindRoom2_btn.Visible;
            Return_btn.Visible = !Return_btn.Visible;


        }

        private  void CreateRoom_btn_Click(object sender, EventArgs e)
        {
            CreateRandom_btn.Visible = !CreateRandom_btn.Visible;
            FindRoom_btn.Visible = !FindRoom_btn.Visible;
            CreateRoom_btn.Visible = !CreateRoom_btn.Visible;
            AIPlay_btn.Visible = !AIPlay_btn.Visible;
            
            RoomID_txt.Visible = !RoomID_txt.Visible;
            Notification_txt.Visible = !Notification_txt.Visible;

            OpponentRating_txt.Visible = !OpponentRating_txt.Visible;
            OpponenRating_lb.Visible = !OpponenRating_lb.Visible;
            OpponentName_lb.Visible = !OpponentName_lb.Visible;
            Opponentname_txt.Visible = !Opponentname_txt.Visible;
            RoomID_txt.Text = GenerateRandomString(5);
            CreateRoom2_btn.Visible = ! CreateRoom2_btn.Visible;
            TimeSelect_lb.Visible = !TimeSelect_lb.Visible;
            TimeList_cb.Visible = !TimeList_cb.Visible;
            PieceColorSelect_lb.Visible = !PieceColorSelect_lb.Visible;
            ColorList_cb.Visible= !ColorList_cb.Visible;
            Return_btn.Visible = !Return_btn.Visible;
        }

        private async void FindRoom2_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(RoomID_txt.Text))
            {
                Notification_txt.Text = "Vui lòng nhập mã phòng.";
                return;
            }
            string roomId = RoomID_txt.Text.Trim();
            try
            {
                string response = await client.FindRoom(roomId,client.Username);
                string[] parts = response.Split(' ');
                if (response.StartsWith("SUCCESS"))
                {
                    Opponentname_txt.Text= parts[2];
                    OpponentRating_txt.Text = parts[3];
                    client.RoomID = parts[4];
                    Time = parts[5]; 
                    Notification_txt.Text = "Phòng đã tìm thấy! Đang kết nối...";
                    await Task.Delay(10000);
                    OpenChessBoard(response,false,Time);
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

        private async void CreateRoom2_btn_Click(object sender, EventArgs e)
        {
            string response = string.Empty;
            bool isTimeChecked = TimeList_cb.CheckedItems.Count> 0;
            bool isColorChecked = ColorList_cb.CheckedItems.Count> 0;
            if(!isTimeChecked || !isColorChecked)
            {
                Notification_txt.Text = "Có cài đặt chưa được chọn, vui lòng chọn đủ các cài đặt";
                return;
            }
            string roomId = RoomID_txt.Text.Trim();
            if(client.PieceColor == "Trắng")
            {
                 response = await client.CreateRoom(roomId, "WHITE", Time,client.Username);
            }    
            else if (client.PieceColor == "Đen")
            {
                 response = await client.CreateRoom(roomId, "BLACK", Time,client.Username);
            }    
            try
            {
                string[] parts = response.Split(' ');
                if (response.StartsWith("SUCCESS"))
                {
                    client.RoomID = parts[2];
                    Notification_txt.Text = parts[0];
                    await ListenForMatch(); // Lắng nghe thông báo tìm thấy người chơi
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
        private async void CreateRandom2_btn_Click(object sender, EventArgs e)
        {
            string response = string.Empty;
            bool isTimeChecked = TimeList_cb.CheckedItems.Count > 0;
            bool isColorChecked = ColorList_cb.CheckedItems.Count > 0;
            if (!isTimeChecked || !isColorChecked)
            {
                Notification_txt.Text = "Có cài đặt chưa được chọn, vui lòng chọn đủ các cài đặt";
                return;
            }
            string roomId = RoomID_txt.Text.Trim();
            if (client.PieceColor == "Trắng")
            {
                response = await client.CreateRandomRoom(roomId, "WHITE", Time, client.Username);
            }
            else if (client.PieceColor == "Đen")
            {
                response = await client.CreateRandomRoom(roomId, "BLACK", Time, client.Username);
            }
            try
            {
                string[] parts = response.Split(' ');
                if (response.StartsWith("SUCCESS"))
                {
                    client.RoomID = parts[2];
                    Notification_txt.Text = parts[0];
                    await ListenForMatch(); // Lắng nghe thông báo tìm thấy người chơi
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
        private async void FindRandom_btn_Click(object sender, EventArgs e)
        {
            try
            {
                string response = await client.FindRandomRoom(client.Username);
                string[] parts = response.Split(' ');
                if (response.StartsWith("SUCCESS"))
                {
                    Opponentname_txt.Text = parts[2];
                    OpponentRating_txt.Text = parts[3];
                    client.RoomID = parts[4];
                    Time = parts[5];
                    Notification_txt.Text = "Phòng đã tìm thấy! Đang kết nối...";
                    await Task.Delay(10000);
                    OpenChessBoard(response, false, Time);
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

        private void TimeList_cb_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            for (int i = 0; i < TimeList_cb.Items.Count; i++)
            {
                if (i != e.Index)
                {
                    TimeList_cb.SetItemChecked(i, false);
                }
            }

            // Lấy mục được chọn
            if (e.NewValue == CheckState.Checked)
            {
                timeInText = TimeList_cb.Items[e.Index].ToString();
                switch(timeInText)
                {
                    case "10 Phút":
                        Time = "600";
                        break;
                    case "6 Phút":
                        Time = "360";
                        break;
                    case "3 Phút":
                        Time = "180";
                        break;
                    case "1 Phút":
                        Time = "60";
                        break;
                }    
                MessageBox.Show($"Bạn đã chọn: {timeInText}");
            }
        }

        private void ColorList_cb_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            for (int i = 0; i < ColorList_cb.Items.Count; i++)
            {
                if (i != e.Index)
                {
                    ColorList_cb.SetItemChecked(i, false);
                }
            }

            // Lấy mục được chọn
            if (e.NewValue == CheckState.Checked)
            {
                client.PieceColor = ColorList_cb.Items[e.Index].ToString();
                MessageBox.Show($"Bạn đã chọn: {client.PieceColor}");
            }
        }

        private async void LogOut_btn_Click(object sender, EventArgs e)
        {
            await Task.Run(async () =>
            {
                string response = await client.Logout(client.Username);
                string[] responseParts = response.Split(' ');
                this.Invoke(new Action(() =>
                {
                    if (response.StartsWith("SUCCESS"))
                    {
                        MessageBox.Show("Đăng Xuất Thành Công");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(response);
                    }
                }));
            });

        }

        private void Return_btn_Click(object sender, EventArgs e)
        {
            Return_btn.Visible = !Return_btn.Visible;
            CreateRandom_btn.Visible = !CreateRandom_btn.Visible;
            FindRoom_btn.Visible = !FindRoom_btn.Visible;
            CreateRoom_btn.Visible = !CreateRoom_btn.Visible;
            AIPlay_btn.Visible = !AIPlay_btn.Visible;
           
            RoomID_txt.Visible = !RoomID_txt.Visible;
            Notification_txt.Visible = !Notification_txt.Visible;

            if(CreateRandom2_btn.Visible)
            {
                CreateRandom2_btn.Visible = !CreateRandom2_btn.Visible;
            }
            if (FindRoom2_btn.Visible)
            {
                FindRoom2_btn.Visible = !FindRoom2_btn.Visible;
            }
            if(FindRandom_btn.Visible)
            {
                FindRandom_btn.Visible = ! FindRandom_btn.Visible;
            }    
            if (CreateRoom2_btn.Visible)
            {
                CreateRoom2_btn.Visible = !CreateRoom2_btn.Visible;
            }
            if(TimeList_cb.Visible)
            {
                TimeList_cb.Visible = !TimeList_cb.Visible;
            }
            if(TimeSelect_lb.Visible)
            {
                TimeSelect_lb.Visible = !TimeSelect_lb.Visible;
            }   
            if(PieceColorSelect_lb.Visible)
            {
                PieceColorSelect_lb.Visible = !PieceColorSelect_lb.Visible;
            }
            if (ColorList_cb.Visible)
            {
                ColorList_cb.Visible = !ColorList_cb.Visible;
            }
            if(Opponentname_txt.Visible)
            {
                Opponentname_txt.Visible = !Opponentname_txt.Visible;
            }    
            if(OpponentName_lb.Visible)
            {
                OpponentName_lb.Visible = !OpponentName_lb.Visible;
            }
            if (OpponentRating_txt.Visible)
            {
                OpponentRating_txt.Visible = !OpponentRating_txt.Visible;
            }
            if (OpponenRating_lb.Visible)
            {
                OpponenRating_lb.Visible = !OpponenRating_lb.Visible;
            }
        }

        private async void  Reload_btn_Click(object sender, EventArgs e)
        {
            try
            {
                string response = await client.UpdateRating(client.Username);
                string[] parts = response.Split(' ');
                if (response.StartsWith("COMPLETE"))
                {
                    Rating_txt.Text = parts[1];
                  
                }
            }
            catch (Exception ex)
            {
                Notification_txt.Text = $"Lỗi: {ex.Message}";
            }
        }

      
    }
}