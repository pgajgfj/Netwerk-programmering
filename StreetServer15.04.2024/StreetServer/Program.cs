using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.IO;

class Server
{
    static Dictionary<string, List<string>> streets = new();

    static void Main()
    {
        LoadStreetData(); // Завантажуємо список вулиць

        IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, 12345);
        Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        serverSocket.Bind(endPoint);
        serverSocket.Listen(10);
        Console.WriteLine("🚀 Сервер запущено. Очікування підключень...");

        while (true)
        {
            Socket clientSocket = serverSocket.Accept();
            Console.WriteLine("✅ Клієнт підключився!");

            byte[] buffer = new byte[1024];
            int received = clientSocket.Receive(buffer);
            string zipCode = Encoding.UTF8.GetString(buffer, 0, received);
            Console.WriteLine($"📩 Отримано поштовий індекс: {zipCode}");

            string response = GetStreetsByZip(zipCode);
            byte[] data = Encoding.UTF8.GetBytes(response);
            clientSocket.Send(data);

            clientSocket.Close();
        }
    }

    static void LoadStreetData()
    {
        // Фіксовані дані (можна замінити на читання з файлу або БД)
        streets["10001"] = new List<string> { "Main St", "Broadway", "1st Ave" };
        streets["10002"] = new List<string> { "Park Ave", "Lexington Ave", "2nd St" };
        streets["10003"] = new List<string> { "Wall St", "5th Ave", "Madison Ave" };
    }

    static string GetStreetsByZip(string zipCode)
    {
        return streets.ContainsKey(zipCode)
            ? string.Join(", ", streets[zipCode])
            : "❌ Немає даних для цього індексу!";
    }
}
