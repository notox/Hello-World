using System;

namespace Boxing
{
    class Program
    {
        static void Main(string[] args)
        {
            Int32 v = 5;
            Object o = v;
            v = 123;

            // Version 1
            Console.WriteLine(v + ", " + (Int32) o);
            
            // Version 2
            Console.WriteLine(v + ", " + o);

            // Version 3
            Console.WriteLine(v.ToString() + ", " + o);
        }
    }
}
