using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Environment.CurrentDirectory + "\\App.config";
            string path2 = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location + "\\App.config");
            Console.WriteLine(path);
            Console.WriteLine(path2);
        }
    }
}
