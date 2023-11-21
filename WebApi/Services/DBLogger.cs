using System;

namespace WebApi.Services
{
    public class DBlogger : ILoggerService
    {
        public void Write(string message)
        {
            Console.WriteLine("[DBLogger -]" + message);
        }
    }
}