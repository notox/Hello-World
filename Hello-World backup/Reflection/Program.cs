using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Reflection
{
    class Program
    {
        static void Main(string[] args)
        {
            // Using GetType to obtain type information:
            int i = 42;
            System.Type type = i.GetType();
            System.Console.WriteLine(type);

            // Using Reflection to get information from an Assembly:
            System.Reflection.Assembly o = System.Reflection.Assembly.Load("mscorlib.dll");
            System.Console.WriteLine(o.GetName());
        }
    }
}
