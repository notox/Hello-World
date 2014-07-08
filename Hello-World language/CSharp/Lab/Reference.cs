using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lab
{
	[TestClass]
	public class Reference
	{
		public void ModifyReference(Customer customer)
		{
			customer = new Customer{ Name = "张三" };
		}

		public void ModifyContent(Customer customer)
		{
			customer.Name = "张三";
		}


		[TestMethod]
		public void Execute()
		{
			var customer = new Customer{ Name = "李四" };
			ModifyReference(customer);
			Assert.AreEqual("李四", customer.Name);
			ModifyContent(customer);
			Assert.AreEqual("张三", customer.Name);
		}
	}
}
