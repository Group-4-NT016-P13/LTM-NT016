using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Chess
{
    public partial class Chess : Form
    {
        public Chess() { InitializeComponent(); }
        Board board;
        int whiteWins = 0;
        int blackWins = 0;

        private void Chess_Load(object sender, EventArgs e)
        {
            board = new Board(this);
            Board.CurrentPlayer = ChessColor.NONE;
            TimeButton.MouseDown += click;
            Undo.MouseDown += click;
            Undo.MouseUp += ReleasedButton;
            RestartButton.MouseUp += click;
        }

        public ChessColor previousPlayer = ChessColor.WHITE;

        void click(object sender, EventArgs e)
        {
            if (sender is Button button) // Sử dụng toán tử is để kiểm tra kiểu
            {
                switch (button.Name)
                {
                    case "TimeButton":
                        if (Board.CurrentPlayer == ChessColor.NONE && previousPlayer == ChessColor.NONE)
                        {
                            TimeButton.Enabled = false;
                            return;
                        }
                        TimeButton.Text = TimeButton.Text == "Start" ? "Stop" : "Start";
                        if (Board.CurrentPlayer == ChessColor.NONE) StartTimer();
                        else StopTimer();
                        break;

                    case "RestartButton":
                        ResetGame();
                        break;
                }
            }

            if (sender is PictureBox pictureBox && pictureBox.Name == "Undo")
            {
                Undo.Image = Properties.Resources.undoArrrow;
                ShowPreviousMove();
            }
        }

        void ShowPreviousMove()
        {
            if (Board.previousMoves.Count == 0) return;
            PreviousBoardState move = previousMove; // Sử dụng biến tạm để lưu trạng thái
            int dir = Board.CurrentPlayer == ChessColor.BLACK ? 1 : -1;
            ChessColor previousPlayer = Board.CurrentPlayer == ChessColor.BLACK ? ChessColor.WHITE : ChessColor.BLACK;

            // Kiểm tra tình huống CHECK
            Movement movement = new Movement();
            if (movement.KingAttacked())
            {
                Board.Window.GameState.Text = "CHECK";
                Board.Window.GameState.ForeColor = System.Drawing.Color.Firebrick;
                IncrementCheckWinCount(); // Tăng số đếm khi có CHECK
                CheckMate();
            }
            else
            {
                Board.Window.GameState.Text = "NORMAL";
                Board.Window.GameState.ForeColor = System.Drawing.Color.Lime;
            }
        }


        void ReleasedButton(object sender, MouseEventArgs e)
        {
            Undo.Image = Properties.Resources.undoArrrow;
        }

        PreviousBoardState previousMove
        {
            get { return Board.previousMoves.Last(); }
        }

        PlayerTime Black = new PlayerTime(0, 0);
        PlayerTime White = new PlayerTime(0, 0);
        public Timer timer;

        private void StartTimer()
        {
            Board.CurrentPlayer = previousPlayer;
            void ShowLabel(Label label, ref PlayerTime time)
            {
                time.seconds++;
                if (time.seconds >= 60)
                {
                    time.minutes++;
                    time.seconds = 0; // Đặt lại giây về 0 sau khi vượt quá 60
                }
                label.Text = time.TimeFormat();
            }

            timer = new Timer { Interval = 1000 };
            timer.Tick += (object sender, EventArgs e) => {
                string player = Board.CurrentPlayer.ToString();
                if (player == "BLACK")
                    ShowLabel(BlackTimer, ref Black);
                else
                    ShowLabel(WhiteTimer, ref White);
            };
            timer.Start();
        }

        public void StopTimer()
        {
            timer?.Stop(); // Dùng toán tử null-conditional để kiểm tra timer
            previousPlayer = Board.CurrentPlayer;
            Board.CurrentPlayer = ChessColor.NONE;
            BlackTimer.Text = Black.TimeFormat();
            WhiteTimer.Text = White.TimeFormat();
        }

        struct PlayerTime
        {
            public int seconds;
            public int minutes;

            public PlayerTime(int seconds, int minutes)
            {
                this.seconds = seconds;
                this.minutes = minutes;
            }

            public string TimeFormat()
            {
                string Format(int time)
                {
                    return time.ToString().PadLeft(2, '0'); // Dùng PadLeft để định dạng
                }
                return Format(minutes) + ":" + Format(seconds);
            }
        }

        void ResetGame(bool whiteWinsFlag = false, bool blackWinsFlag = false)
        {
            if (whiteWinsFlag) whiteWins++;
            else if (blackWinsFlag) blackWins++;

            // Đặt lại trò chơi
            while (Board.previousMoves.Count > 0) ShowPreviousMove();

            Board.previousMoves = new List<PreviousBoardState>();
            Black = new PlayerTime(0, 0);
            White = new PlayerTime(0, 0);
            StopTimer();
            TimeButton.Text = "Start";
            Board.CurrentPlayer = ChessColor.NONE;

            // Cập nhật hiển thị số lần thắng
            UpdateWinsDisplay();

            // Đặt lại số đếm CHECK/WIN
            label3.Text = "0"; // Reset về 0 khi bắt đầu lại
        }


        void UpdateWinsDisplay()
        {
            label3.Text = whiteWins.ToString(); // Hiển thị số lần thắng của người chơi trắng
            label6.Text = blackWins.ToString(); // Hiển thị số lần thắng của người chơi đen
        }

        public void CheckMate()
        {
            // Kiểm tra tình huống checkmate
            bool isCheckmate = false; // Đặt biến này theo điều kiện thực tế của bạn
            if (isCheckmate)
            {
                ResetGame(Board.CurrentPlayer == ChessColor.WHITE, Board.CurrentPlayer == ChessColor.BLACK);
                IncrementCheckWinCount();
            }
        }
        private void IncrementCheckWinCount()
        {
            int currentCount = int.Parse(label3.Text);
            label3.Text = (currentCount + 1).ToString();
        }

    }
}
