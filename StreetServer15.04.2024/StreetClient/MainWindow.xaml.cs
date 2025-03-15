using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StreetClient
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string zipCode = txtZipCode.Text.Trim();
            if (string.IsNullOrEmpty(zipCode))
            {
                MessageBox.Show("❌ Введіть поштовий індекс!", "Помилка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            lstStreets.Items.Clear();
            string response = await Task.Run(() => GetStreets(zipCode));         
            foreach (var street in response.Split(','))
            {
                lstStreets.Items.Add(street.Trim());
            }


        }

        private string GetStreets(string zipCode)
        {
            try
            {
                IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Loopback, 12345);
                Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                clientSocket.Connect(serverEndPoint);
                byte[] data = Encoding.UTF8.GetBytes(zipCode);
                clientSocket.Send(data);

                byte[] buffer = new byte[1024];
                int received = clientSocket.Receive(buffer);
                string response = Encoding.UTF8.GetString(buffer, 0, received);

                clientSocket.Close();
                return response;
            }
            catch (Exception ex)
            {
                return $"❌ Помилка підключення: {ex.Message}";
            }
        }
    }
}
