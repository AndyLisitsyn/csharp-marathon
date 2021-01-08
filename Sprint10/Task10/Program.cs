using System;

namespace Task10
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    using System.IO;

public interface ILogger
    {
        void LogMessage(string msg);
    }

    public class DbLogger : ILogger
    {
        public void LogMessage(string mMessage)
        {
            //Code to write message in database.  
        }
    }

    public class FileLogger : ILogger
    {
        public void LogMessage(string mStackTrace)
        {
            //code to log stack trace into a file.  
        }
    }

    public class ExceptionLogger
    {
        ILogger _logger;

        public ExceptionLogger(ILogger logger)
        {
            _logger = logger;
        }

        public void LogException(Exception mException)
        {
            _logger.LogMessage(GetUserReadableMessage(mException));
        }

        private string GetUserReadableMessage(Exception ex)
        {
            string strMessage = string.Empty;
            //code to convert Exception's stack trace and message to user   
            // readable format.  
            return strMessage;
        }
    }

    public class DataExporter
    {
        public void ExportDataFromFile()
        {
            try
            {
                //code to export data from files to database.  
            }
            catch (IOException ex)
            {
                new ExceptionLogger(new DbLogger()).LogException(ex);
            }
            catch (Exception ex)
            {
                new ExceptionLogger(new FileLogger()).LogException(ex);
            }
        }
    }
}
