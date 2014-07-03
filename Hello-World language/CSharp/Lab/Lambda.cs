using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lab
{
	[TestClass]
	public class Lambda
	{
		[TestMethod]
		public void Closure()
		{
			int max = 0;
			Func<string, bool> predicate = 
				item =>
				{
					max++;
					return item.Length < max;
				};
			var list = new List<string>
			{
				"111",
				"222",
				"333",
				"444",
				"555",
				"666"
			};
			var newList = list.Where(predicate);
			Assert.AreEqual(3, newList.Count());
			Assert.IsTrue(newList.Contains("444"));
			Assert.IsTrue(newList.Contains("555"));
			Assert.IsTrue(newList.Contains("666"));
		}
	}
}
