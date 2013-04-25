using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlienLanguageCSharp;

namespace AlienLanguageCSharpUT
{
	[TestClass]
	public class AlienLanguageUT
	{
		[TestMethod]
		public void say_abc()
		{
			AlienLanguage language = new AlienLanguage();
			int actual = language.process("abc");
			Assert.AreEqual(1, actual);
		}
		
		//[TestMethod]
		//public void say_abc_with_brasket()
		//{
		//    AlienLanguage language = new AlienLanguage();
		//    int actual = language.process("(ab)bc");
		//    Assert.AreEqual(2, actual);
		//}
	}
}
