using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherParser
{
    internal class MessagesViewer
    {
        public static void WriteLine(string message)
        {
            Console.WriteLine(message);
        }

        public static void Write(string message)
        {
            Console.Write(message);
        }

        public static void Write(string format, object? arg0, object? arg1)
        {
            Console.Write(format, arg0, arg1);
        }
    }
}
