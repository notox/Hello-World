using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Lambda
{
	class Program
	{
		static void Main(string[] args)
		{
			ForEach();
			Predicate();
		}

		public static void ForEach()
		{
			var nums = new List<int> { 1, 2, 3, 4, 5, 6 };
			Parallel.ForEach(nums, (value) =>
			{
				Console.WriteLine(value);
			});
			Console.ReadKey();
		}

		public static void Predicate()
		{
			var nums = new List<int> { 1, 2, 3, 4, 5, 6 };
			
			int total = SumAll(nums, n => true);
			Console.WriteLine(total);
			total = SumAll(nums, n => n % 2 == 0);
			Console.WriteLine(total);
			total = SumAll(nums, n => n > 3);
			Console.WriteLine(total);
			Console.ReadKey();
		}

		public static int SumAll(IEnumerable<int> nums, Predicate<int> predicate)
		{
			return nums.Where(i => predicate(i)).Sum();
		}
	}
}
