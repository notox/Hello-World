using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lab
{
    public class Person
    {
        public String Name { get; set; }
        public int Age { get; set; }
    }
    
    public class Teacher
    {
        public String Name { get; set; }
        public int Age { get; set; }

        public String Teach()
        {
            return "I am a teacher";
        }
    }

    public class Converter
    {
        public static String Execute(dynamic person)
        {
            return person.Name; 
        }

		//public static String Execute<P>(P p)
		//{
		//    // 个人理解泛型应该可以捉到相应的事情，可能哪里做错了。
		//    return String.Empty;
		//}

        public static IList<String> EmptyList()
        {
            var emptyList = new List<String>();
            return emptyList;
        }
    }

    [TestClass]
    public class Dynamic
    {
        [TestMethod]
        public void DynamicMethod()
        {
            var person = new Person{Name = "Jay", Age = 18};
            var teacher = new Teacher{Name = "Adam", Age = 20};
            Assert.AreEqual("Jay", Converter.Execute(person));
            Assert.AreEqual("Adam", Converter.Execute(teacher));

			//Assert.AreEqual("Jay", Converter.Execute<Person>(person));
			//Assert.AreEqual("Adam", Converter.Execute<Teacher>(teacher));
        }
    }
}