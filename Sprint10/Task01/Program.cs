using System;

namespace Task01
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
        public void Register(string email, string password)
        {
            var mailService = new MailService();

            try
            {
                if (mailService.ValidEmail(email))
                {
                    mailService.SendEmail(email, "Email title", "Email body");
                }
            }
            catch
            {
                throw;
            }
        }
    }

    public class MailService
    {
        public bool ValidEmail(string email)
        {
            return email.Contains("@");
        }

        public void SendEmail(string mail, string emailTitle, string emailBody)
        {
            Console.WriteLine(string.Format("Mail:{0}, Title:{1}, Body:{2}", mail, emailTitle, emailBody));
        }
    }
}
