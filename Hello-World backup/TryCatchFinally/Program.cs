using System;
using System.Collections.Generic;
using System.Text;

namespace TryCatchFinally
{
	class Program
	{
		static void Test()
		{
			try
			{
				Console.WriteLine("I am try.");
				return;
			}
			catch (System.Exception ex)
			{
				Console.WriteLine("I am catch.");
			}
			finally
			{
				Console.WriteLine("I am finally.");
			}
		}
		
		static void Main(string[] args)
		{
			Test();
			Console.ReadKey();
		}
	}
}
