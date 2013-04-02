using System;
using System.IO;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
			byte[] all = File.ReadAllBytes("d:/standalone/flow.lut");
			Console.WriteLine(all.Length);


        }
    }
}
