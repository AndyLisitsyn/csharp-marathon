using System;

namespace Task02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class Customer
    {
        public static void Register(string email, string password)
        {
            var mailService = new MailService()
            {
                Email = email,
                EmailTitle = "User registration",
                EmailBody = "Body of message..."
            };
            var smsService = new SmsService()
            {
                Number = "111 111 111",
                SmsText = "User successfully registered..."
            };

            try
            {
                if (mailService.ValidEmail())
                {
                    mailService.SendNotification();
                    smsService.SendNotification();
                }
            }
            catch
            {
                throw;
            }
        }
    }

    public abstract class NotificationService
    {
        public abstract void SendNotification();
    }

    public class MailService : NotificationService
    {
        public string Email { get; set; }
        public string EmailTitle { get; set; }
        public string EmailBody { get; set; }

        public bool ValidEmail()
        {
            return Email.Contains("@");
        }

        public override void SendNotification()
        {
            Console.WriteLine("Mail:{0}, Title:{1}, Body:{2}", Email, EmailTitle, EmailBody);
        }
    }

    public class SmsService : NotificationService
    {
        public string Number { get; set; }
        public string SmsText { get; set; }

        public override void SendNotification()
        {
            Console.WriteLine("Number:{0}, Message:{1}", Number, SmsText);
        }
    }
}
