using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lab
{
    public class Person
    {
        public String Name = String.Empty;
        public int Age = 0;

        public Person(String name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
    }
    
    public class Teacher
    {
        public String Name = String.Empty;
        public int Age = 0;

        public Teacher(String name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

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
    }
    
    [TestClass]
    public class Dynamic
    {
        [TestMethod]
        public void DynamicMethod()
        {
            Person person = new Person("Jay", 18);
            Teacher teacher = new Teacher("Adam", 20);
            Assert.AreEqual("Jay", Converter.Execute(person));
            Assert.AreEqual("Adam", Converter.Execute(teacher));
        }
    }
}