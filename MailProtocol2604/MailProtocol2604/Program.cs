using System;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Авторизація...");

        Console.Write("Введіть ваш логін (email): ");
        string username = Console.ReadLine();

        if (!IsValidEmail(username))
        {
            Console.WriteLine("Некоректна адреса електронної пошти.");
            return;
        }

        Console.Write("Введіть ваш пароль: ");
        string password = Console.ReadLine();

        if (string.IsNullOrEmpty(password))
        {
            Console.WriteLine("Пароль не може бути порожнім.");
            return;
        }

        Console.WriteLine("\nВведіть дані для відправки листа:");
        Console.Write("Введіть адресу одержувача: ");
        string recipient = Console.ReadLine();

        if (!IsValidEmail(recipient))
        {
            Console.WriteLine("Некоректна адреса електронної пошти одержувача.");
            return;
        }

        Console.Write("Введіть тему листа: ");
        string subject = Console.ReadLine();

        Console.Write("Введіть текст повідомлення: ");
        string body = Console.ReadLine();

        Console.Write("Позначити повідомлення як важливе? (y/n): ");
        bool isImportant = Console.ReadLine().ToLower() == "y";

        string attachmentPath = null;
        Console.Write("Бажаєте прикріпити файл? (y/n): ");
        if (Console.ReadLine().ToLower() == "y")
        {
            Console.Write("Введіть шлях до файлу для прикріплення: ");
            attachmentPath = Console.ReadLine();

            if (!File.Exists(attachmentPath))
            {
                Console.WriteLine("Файл не знайдений. Спробуйте ще раз.");
                return;
            }
        }

        try
        {
            MailMessage mail = new MailMessage(username, recipient, subject, body);

            if (isImportant)
            {
                mail.Priority = MailPriority.High;
            }

            if (!string.IsNullOrEmpty(attachmentPath))
            {
                Attachment attachment = new Attachment(attachmentPath);
                mail.Attachments.Add(attachment);
            }

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(username, password),
                EnableSsl = true
            };

            smtpClient.Send(mail);
            Console.WriteLine("\nПовідомлення успішно надіслано!");

        }
        catch (Exception ex)
        {
            Console.WriteLine("\nПомилка: " + ex.Message);
        }
    }

    public static bool IsValidEmail(string email)
    {
        string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
        Regex regex = new Regex(emailPattern);
        return regex.IsMatch(email);
    }
}
