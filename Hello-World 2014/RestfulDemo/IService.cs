using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace RestfulDemo
{
	[ServiceContract]
	public interface IService
	{
		[OperationContract]
		[WebGet(UriTemplate="HelloWorld", ResponseFormat = WebMessageFormat.Json)]
		string GetHelloWorld();

		[OperationContract]
		[WebGet(UriTemplate = "Persons", ResponseFormat = WebMessageFormat.Json)]
		Person GetPerson();

		[OperationContract(Name="SayHelloWorld")]
		string SayHelloWorld();
	}
}
