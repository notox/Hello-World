using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Text.RegularExpressions;

namespace RegularExpression
{
	class Program
	{
		static void Main(string[] args)
		{
			string raw = "89496iolafg# CT123456adgag";
			//string pattern = "#\\s*([A-Z]+\\d+)";
			string pattern = "([A-Z]+\\d+)";
			MatchCollection matches = Regex.Matches(raw, pattern);
			foreach (Match match in matches)
			{
				Console.WriteLine(match.Groups[1].Value);
			}
			Console.ReadKey();
		}
	}
}
