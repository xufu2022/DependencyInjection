using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutofacSamples
{
   public interface ILog: IDisposable
    {
        void Write(string message);
    }
   public interface IConsole
   {

   }
    public class ConsoleLog : ILog, IConsole
    {
        public void Write(string message)
        {
            Console.WriteLine(message);
        }

        public void Dispose()
        {
            Console.WriteLine("console logger no longer required");
        }
    }

    public class SMSLog : ILog
    {
        private string phoneNumber;

        public SMSLog(string phoneNumber)
        {
            this.phoneNumber = phoneNumber;
        }

        public void Write(string message)
        {
            Console.WriteLine($"SMS to {phoneNumber} : {message}");
        }

        public void Dispose()
        {
        }
    }
}
