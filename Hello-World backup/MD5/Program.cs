using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace MD5
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Please input a string:");
			string input = Console.ReadLine();
			HashAlgorithm hash = HashAlgorithm.Create("MD5");
			byte[] data = hash.ComputeHash(Encoding.Default.GetBytes(input));

			StringBuilder builder = new StringBuilder();
			for (int i = 0; i < data.Length; i++)
			{
				builder.Append(data[i].ToString());
			}
			string output = builder.ToString();
			Console.WriteLine("The output is: ");
			Console.WriteLine(output);

			Console.ReadKey();
		}
	}

}
