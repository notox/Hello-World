using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lab
{
    public class Person
    {
        private String name = String.Empty;
        private int age = 0;
    
        public String Name { get; set; }
        public int Age { get; set; }
    }
    
    public class Teacher
    {
        private String name = String.Empty;
        private int age = 0;

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
            Person person = new Person{Name = "Jay", Age = 18};
            Teacher teacher = new Teacher{Name = "Adam", Age = 20};
            Assert.AreEqual("Jay", Converter.Execute(person));
            Assert.AreEqual("Adam", Converter.Execute(teacher));
        }
    }
}