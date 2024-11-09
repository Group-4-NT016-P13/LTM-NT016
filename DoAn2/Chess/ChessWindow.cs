using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Chess
{
    public partial class Chess : Form
    {
        private Socket ClientSocket;
        private string Nickname;
        public Chess()
        {
            InitializeComponent();

        }
        public Chess(Socket clientSocket,string nickname)
        {
            ClientSocket = clientSocket;
            Nickname = nickname;
        }

        Board board;
        private int blackScore = 0;
        private int whiteScore = 0;
        string RoomId = GenerateRandomString(5);

        private static string GenerateRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random random = new Random();

            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        

        private void Chess_Load(object sender, EventArgs e)
        {
            refresh.Enabled = false;
            board = new Board(this);
            Board.CurrentPlayer = ChessColor.NONE;
            TimeButton.MouseDown += click;
            Undo.MouseDown += click;
            Undo.MouseUp += ReleasedButton;
            RestartButton.MouseUp += click;
            refresh.MouseUp += click;
            RoomID_txt.Text = RoomId;
        }
        public ChessColor previousPlayer = ChessColor.WHITE;
       async void click(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(Button))
                switch (((Button)sender).Name)
                {
                    case "TimeButton":

                        if (Board.CurrentPlayer == ChessColor.NONE && previousPlayer == ChessColor.NONE) { TimeButton.Enabled = false; return; }
                        TimeButton.Text = TimeButton.Text == "Start" ? "Stop" : "Start";
                        if (Board.CurrentPlayer == ChessColor.NONE)
                        {
                            StartTimer();
                            /*Roompacket = new Packet("RoomRequest", "", RoomID_txt.Text, Nickname);
                            string Packetstring = Roompacket.ToPacketRoomString();
                            byte[] messageBytes = Encoding.UTF8.GetBytes(Packetstring);
                            await Task.Run(() => ClientSocket.Send(messageBytes));*/
                        }
                        else
                        {
                            StopTimer();
                        }
                        break;
                    case "RestartButton":
                        int moves = Board.previousMoves.Count;
                        for (int i = 0; i < moves; i++)
                            ShowPreviousMove();
                        Board.previousMoves = new List<PreviousBoardState>();
                        Black = new PlayerTime(0, 0);
                        White = new PlayerTime(0, 0);
                        if (timer != null) StopTimer();
                        TimeButton.Text = "Start";
                        Board.CurrentPlayer = ChessColor.NONE;
                        break;
                    case "refresh":
                        Victory victoryform = new Victory();
                        victoryform.ShowDialog();

                        moves = Board.previousMoves.Count;
                        for (int i = 0; i < moves; i++)
                            ShowPreviousMove();

                        //dat lai trang thai ban co
                        Board.previousMoves = new List<PreviousBoardState>();
                        Black = new PlayerTime(0, 0);
                        White = new PlayerTime(0, 0);

                        if (timer != null) StopTimer();
                        TimeButton.Text = "Start";
                        Board.CurrentPlayer = ChessColor.NONE;
                        if (GameState.Text != "CHECK" || GameState.Text != "PLAYING" || GameState.Text != "NORMAL")
                        {
                            if (previousPlayer == ChessColor.WHITE)
                            {
                                blackScore++;
                            }
                            else if (previousPlayer == ChessColor.BLACK)
                            {
                                whiteScore++;
                            }
                            else if (previousPlayer == ChessColor.WHITE && GameState.Text == "LOSE")
                            {

                                blackScore++;
                            }
                            else if (previousPlayer == ChessColor.BLACK && GameState.Text == "LOSE")
                            {
                                whiteScore++;
                            }
                            else if (previousPlayer == ChessColor.WHITE && GameState.Text == "WIN")
                            {
                                whiteScore++;
                            }
                            else if (previousPlayer == ChessColor.BLACK && GameState.Text == "WIN")
                            {
                                blackScore++;
                            }
                        }

                        BlackScoreLabel.Text = blackScore.ToString();
                        WhiteScoreLabel.Text = whiteScore.ToString();
                        refresh.Enabled = false;
                        break;

                }
            if (sender.GetType() == typeof(PictureBox))
                switch (((PictureBox)sender).Name)
                {
                    case "Undo":
                        Undo.Image = Properties.Resources.undoArrrow;
                        ShowPreviousMove();
                        break;
                }
        }

        void ShowPreviousMove()
        {
            if (Board.previousMoves.Count == 0) return;

            int dir = Board.CurrentPlayer == ChessColor.BLACK ? 1 : -1;
            ChessColor previousPlayer = Board.CurrentPlayer == ChessColor.BLACK ? ChessColor.WHITE : ChessColor.BLACK;

            // Xử lý các nước đi đặc biệt cho vua và tốt
            if (previousMove.piece.piecekind == PieceKind.King)
            {
                int ydir = previousPlayer == ChessColor.WHITE ? 7 : 0;
                if (previousMove.moveIndex == 8) // Castling right
                {
                    Board.tiles[ydir, 5].PieceAssign(new ChessPiece(PieceKind.EMPTY));
                    Board.tiles[ydir, 7].PieceAssign(new ChessPiece(PieceKind.Rook, previousPlayer));
                }
                if (previousMove.moveIndex == 9) // Castling left
                {
                    Board.tiles[ydir, 3].PieceAssign(new ChessPiece(PieceKind.EMPTY));
                    Board.tiles[ydir, 0].PieceAssign(new ChessPiece(PieceKind.Rook, previousPlayer));
                }
            }
            else if (previousMove.piece.piecekind == PieceKind.Pawn)
            {
                if (previousMove.moveIndex == 4 || previousMove.moveIndex == 5)
                    Board.tiles[previousMove.move.y + dir, previousMove.move.x].PieceAssign(new ChessPiece(PieceKind.Pawn, Board.CurrentPlayer, true));
            }

            // Khôi phục nước đi trước
            Board.tiles[previousMove.move.y, previousMove.move.x].PieceAssign(previousMove.removedPiece);
            Board.tiles[previousMove.previousLocation.y, previousMove.previousLocation.x].PieceAssign(previousMove.piece);
            Board.previousMoves.RemoveAt(Board.previousMoves.Count - 1);
            Board.CurrentPlayer = previousPlayer;

            // Cập nhật trạng thái quân cờ
            ChessPiece.UpdateAllAttacks();
            Movement movement = new Movement();

            // Kiểm tra xem có ai bị chiếu không
            if (movement.KingAttacked())
            {
                // Nếu chỉ bị chiếu
                Board.Window.GameState.Text = "CHECK";
                Board.Window.GameState.ForeColor = System.Drawing.Color.Firebrick;

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
        PreviousBoardState previousMove { get { return Board.previousMoves.Last(); } }
        PlayerTime Black = new PlayerTime(0, 0);
        PlayerTime White = new PlayerTime(0, 0);
        public Timer timer;
        private void StartTimer()
        {
            Board.CurrentPlayer = previousPlayer;
            void ShowLabel(Label label, ref PlayerTime time)
            {
                time.seconds += 1;
                label.Text = time.TimeFormat();
                if (time.seconds >= 59) { time.minutes += 1; }
            }
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += (object sender, EventArgs e) => {
                string player = Board.CurrentPlayer.ToString();
                if (player == "BLACK")
                    ShowLabel(BlackTimer, ref Black);
                else ShowLabel(WhiteTimer, ref White);
            };
            timer.Start();
            refresh.Enabled = false;
        }
        public void StopTimer()
        {
            timer.Stop();
            previousPlayer = Board.CurrentPlayer;
            Board.CurrentPlayer = ChessColor.NONE;
            BlackTimer.Text = Black.TimeFormat();
            WhiteTimer.Text = White.TimeFormat();
            TimeButton.Text = TimeButton.Text == "Start" ? "Stop" : "Start";
            refresh.Enabled = true;
        }
        struct PlayerTime
        {
            public int seconds;
            public int minutes;
            public PlayerTime(int seconds, int minutes) { this.seconds = seconds; this.minutes = minutes; }
            public string TimeFormat()
            {
                string Format(string time)
                {
                    if (time.Length == 1) time = "0" + time;
                    return time;
                }
                if (seconds >= 60) seconds = 0;
                return Format(minutes.ToString()) + ":" + Format(seconds.ToString());
            }
        }



        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
