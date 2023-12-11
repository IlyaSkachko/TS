using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11_12.Logger
{
    public class Logger
    {
        public Logger() { }

        public static void WriteLog(string message)
        {
            using (var sw = new System.IO.StreamWriter("D:/UNIVER/Course3/ТПО/Lab11_12/Lab11_12/Files/log.txt", true))
            {
                sw.WriteLine($"{DateTime.Now} [INFO] {message}");
            }
        }
    }
}
