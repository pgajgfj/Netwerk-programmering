using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

class TicTacToeServer
{
    private static TcpListener listener;
    private static TcpClient client1;
    private static TcpClient client2;
    private static NetworkStream stream1;
    private static NetworkStream stream2;

    static void Main()
    {
        listener = new TcpListener(IPAddress.Any, 12345);
        listener.Start();
        Console.WriteLine("Сервер запущений, чекаємо на підключення...");

        client1 = listener.AcceptTcpClient();
        stream1 = client1.GetStream();
        Console.WriteLine("Клієнт 1 підключений.");

        client2 = listener.AcceptTcpClient();
        stream2 = client2.GetStream();
        Console.WriteLine("Клієнт 2 підключений.");

        Thread gameThread = new Thread(PlayGame);
        gameThread.Start();
    }

    private static void PlayGame()
    {
        string board = "         ";
        string turn = "X";
        while (true)
        {
            board = "         ";  
            SendMessage(stream1, "Нова гра почалась! Ваш хід. Грайте X: " + board);
            SendMessage(stream2, "Нова гра почалась! Очікуйте хід X: " + board);

            while (true)
            {
                int move1 = GetMove(stream1);
                board = MakeMove(board, move1, "X");
                if (CheckWin(board))
                {
                    SendMessage(stream1, "Виграв X! Гра завершена.");
                    SendMessage(stream2, "Виграв X! Гра завершена.");
                    break;
                }

                SendMessage(stream1, "Очікуйте хід O: " + board);
                SendMessage(stream2, "Ваш хід. Грайте O: " + board);

                int move2 = GetMove(stream2);
                board = MakeMove(board, move2, "O");
                if (CheckWin(board))
                {
                    SendMessage(stream1, "Виграв O! Гра завершена.");
                    SendMessage(stream2, "Виграв O! Гра завершена.");
                    break;
                }
            }
        }
    }

    private static void SendMessage(NetworkStream stream, string message)
    {
        byte[] buffer = Encoding.UTF8.GetBytes(message);
        stream.Write(buffer, 0, buffer.Length);
    }

    private static int GetMove(NetworkStream stream)
    {
        byte[] buffer = new byte[256];
        int bytesRead = stream.Read(buffer, 0, buffer.Length);
        string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
        return int.Parse(message);
    }

    private static string MakeMove(string board, int position, string player)
    {
        char[] boardArray = board.ToCharArray();
        boardArray[position] = player[0];
        return new string(boardArray);
    }

    private static bool CheckWin(string board)
    {
        string[] winningCombinations = {
            "012", "345", "678",
            "036", "147", "258",
            "048", "246"
        };

        foreach (var combination in winningCombinations)
        {
            char a = board[combination[0] - '0'];
            char b = board[combination[1] - '0'];
            char c = board[combination[2] - '0'];
            if (a == b && b == c && a != ' ')
            {
                return true;
            }
        }
        return false;
    }
}
