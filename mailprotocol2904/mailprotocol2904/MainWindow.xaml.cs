using System;
using System.Windows;
using MailKit.Net.Smtp; 
using MimeKit; 

namespace mailprotocol2904
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string email = EmailTextBox.Text;
            string password = PasswordTextBox.Text;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both email and password.");
                return;
            }

            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("Sender", email));
                message.To.Add(new MailboxAddress("Recipient", "recipient@example.com"));
                message.Subject = "Test Email";

                var body = new TextPart("plain")
                {
                    Text = "This is a test email sent from WPF using MailKit."
                };

                message.Body = body;

                
                using (var client = new MailKit.Net.Smtp.SmtpClient())  
                {
                    client.Connect("smtp.example.com", 587, false);
                    client.Authenticate(email, password);
                    client.Send(message);
                    client.Disconnect(true);
                }

                MessageBox.Show("Email sent successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }
}
