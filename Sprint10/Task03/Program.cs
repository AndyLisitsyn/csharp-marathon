using System;

namespace Task03
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public interface INotification
    {
        void SendNotification();
    }

    public interface INotificationToDB
    {
        void AddNotificationToDB();
    }

    public class MailService : INotification, INotificationToDB
    {
        public string Email { get; set; }
        public string EmailTitle { get; set; }
        public string EmailBody { get; set; }

        public bool ValidEmail()
        {
            return Email.Contains("@");
        }

        public void SendNotification()
        {
            Console.WriteLine("Mail:{0}, Title:{1}, Body:{2}", Email, EmailTitle, EmailBody);
        }

        public void AddNotificationToDB()
        {

        }
    }

    public class SmsService : INotification
    {
        public string Number { get; set; }
        public string SmsText { get; set; }

        public void SendNotification()
        {
            Console.WriteLine("Number:{0}, Message:{1}", Number, SmsText);
        }
    }

    public class Customer
    {
        public static void Register(string email, string password)
        {
            try
            {
                var mailService = new MailService()
                {
                    Email = email,
                    EmailTitle = "User registration",
                    EmailBody = "Body of message..."
                };

                if (mailService.ValidEmail())
                {
                    mailService.SendNotification();
                    mailService.AddNotificationToDB();
                }

                var smsService = new SmsService()
                {
                    Number = "111 111 111",
                    SmsText = "User successfully registered..."
                };

                smsService.SendNotification();
                //smsService.AddNotificationToDB();
            }
            catch
            {
                throw;
            }
        }
    }
}
