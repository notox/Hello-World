using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lab
{
    public class Customer
    {
        public string Name { get; set; }
    }

    [TestClass]
    public class ImplicitPropertySyntax
    {
        [TestMethod]
        public void TestImplicitProperty()
        {
            var c = new Customer { Name = "Jay" };
            Assert.AreEqual("Jay", c.Name);
        }
    }
}
