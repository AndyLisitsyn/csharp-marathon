using System;

namespace Task07
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class Invoice
    {
        IFileLogger fileLogger;
        public long Amount { get; set; }
        public DateTime InvoiceDate { get; set; }
        public void FileLogger()
        {
            fileLogger = new FileLogger();
        }
        public void Add()
        {
            Console.WriteLine("Adding amount...");
            // Code for adding invoice
            // Once Invoice has been added , send mail 
            string mailMessage = "Your invoice is ready.";
            var mailSender = new MailSender();
            mailSender.SendEmail(mailMessage);
        }
        public void Delete()
        {
            Console.WriteLine("Deleting amount...");
            // Code for Delete invoice
        }
    }

    interface IFileLogger
    {
        void Check();
        void Debug();
        void Info();
    }

    public class FileLogger : IFileLogger
    {
        public void Check()
        {
            /// log check result to file
        }
        public void Debug()
        {
            /// log debug result to file
        }
        public void Info()
        {
            /// log info result to file
        }
    }

    public class MailSender
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }

        public void SendEmail(string mailMessage)
        {
            Console.WriteLine("Sending Email: {0}", mailMessage);
            // Code for getting Email setting and send invoice mail
        }
    }
}
