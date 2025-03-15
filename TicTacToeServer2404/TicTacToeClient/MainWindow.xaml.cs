using System;
using System.Net.Sockets;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace TicTacToeClient
{
    public partial class MainWindow : Window
    {
        private TcpClient _client;
        private NetworkStream _stream;
        private string _player = "X";
        private string _board = "         ";

        public MainWindow()
        {
            InitializeComponent();
            _client = new TcpClient("127.0.0.1", 12345);
            _stream = _client.GetStream();
            ReceiveGameUpdates();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            int index = int.Parse(button.Name.Substring(6));
            if (_board[index] == ' ')
            {
                _board = _board.Substring(0, index) + _player + _board.Substring(index + 1);
                UpdateButtons();
                SendMove(index);
                CheckGameStatus();
                TogglePlayer();
            }
        }

        private void SendMove(int index)
        {
            byte[] message = Encoding.UTF8.GetBytes(index.ToString());
            _stream.Write(message, 0, message.Length);
        }

        private void UpdateButtons()
        {
            button0.Content = _board[0].ToString();
            button1.Content = _board[1].ToString();
            button2.Content = _board[2].ToString();
            button3.Content = _board[3].ToString();
            button4.Content = _board[4].ToString();
            button5.Content = _board[5].ToString();
            button6.Content = _board[6].ToString();
            button7.Content = _board[7].ToString();
            button8.Content = _board[8].ToString();
        }

        private void TogglePlayer()
        {
            _player = _player == "X" ? "O" : "X";
        }

        private void ReceiveGameUpdates()
        {
            byte[] buffer = new byte[256];
            _stream.BeginRead(buffer, 0, buffer.Length, new AsyncCallback(ReceiveCallback), buffer);
        }

        private void ReceiveCallback(IAsyncResult ar)
        {
            byte[] buffer = (byte[])ar.AsyncState;
            int bytesRead = _stream.EndRead(ar);
            string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
            Dispatcher.Invoke(() => gameStatus.Text = message);
            ReceiveGameUpdates();
        }

        private void CheckGameStatus()
        {
            string[] winningCombinations = {
                "012", "345", "678",
                "036", "147", "258",
                "048", "246"
            };

            foreach (var combination in winningCombinations)
            {
                char a = _board[combination[0] - '0'];
                char b = _board[combination[1] - '0'];
                char c = _board[combination[2] - '0'];
                if (a == b && b == c && a != ' ')
                {
                    gameStatus.Text = _player == "X" ? "Виграв X!" : "Виграв O!";
                    MessageBox.Show($"{_player} виграв! Гра почнеться знову.");
                    ResetGame();
                    return;
                }
            }

            if (_board.IndexOf(' ') == -1)
            {
                gameStatus.Text = "Нічия!";
                MessageBox.Show("Нічия! Гра почнеться знову.");
                ResetGame();
            }
        }

        private void ResetGame()
        {
            _board = "         ";
            UpdateButtons();
            gameStatus.Text = "Нова гра почалась!";
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
