using System;
using System.Configuration;
using System.IO;
using System.Text;

namespace RabbitMQ.Practice.Core.Services
{
    public class LocalLog : ILog
    {
        private static string _dirPath;

        static LocalLog()
        {
            _dirPath = ConfigurationManager.AppSettings["LogBasePath"];

            if (string.IsNullOrEmpty(_dirPath))
            {
                _dirPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");
            }

            if (!Directory.Exists(_dirPath))
            {
                Directory.CreateDirectory(_dirPath);
            }
        }

        public void Info(string message)
        {
            WriteMessageToFile(LogType.Info, message);
        }

        public void Debug(string message)
        {
            WriteMessageToFile(LogType.Debug, message);
        }

        public void Warn(string message)
        {
            WriteMessageToFile(LogType.Warn, message);
        }

        public void Error(string message)
        {
            WriteMessageToFile(LogType.Error, message);
        }

        public void Fatial(string message)
        {
            WriteMessageToFile(LogType.Fatial, message);
        }
        
        private void WriteMessageToFile(LogType type, string message)
        {
            var now = DateTime.Now;

            string path = Path.Combine(_dirPath, $"{DateTime.Now.Year}_{DateTime.Now.Month}_{DateTime.Now.Day}.log");
            using (var fileStream = new FileStream(path, FileMode.Append, FileAccess.Write))
            using (var streamWriter = new StreamWriter(fileStream))
            {
                streamWriter.WriteLine();
                streamWriter.WriteLine($"{now:yyyy/MM/dd(hh:mm:ss fff)}\t[{type}]");
                streamWriter.Write(message);
                streamWriter.WriteLine();
            }
        }
    }
}