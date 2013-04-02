using System;
using System.Text;
using System.IO;

namespace DirectoryExists
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exsits = Directory.Exists(string.Empty);

            Console.WriteLine(exsits ? "Exsits" : "Not Exsits");
            Console.ReadKey();
        }
    }
}
