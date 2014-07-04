using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace RestfulDemo
{
	[DataContract]
	public class Person
	{
		[DataMember]
		public string Name { get; set; }
		[DataMember]
		public int Age { get; set; }
		[DataMember]
		public DateTime Birthday { get; set; }
	}

	public class HelloWorldService : IService
	{
		public string GetHelloWorld()
		{
			return "Hello World";
		}

		public string SayHelloWorld()
		{
			return "Hello World";
		}

		public Person GetPerson()
		{
			return new Person { Name = "Jay", Age = 18, Birthday = DateTime.Now };
		}
	}
}
