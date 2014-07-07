using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lab
{
    public class MyType
    {
        
    }

    public class OtherType
    {
        
    }

    public class SecondType
    {
        private readonly MyType _value = null;

        public static implicit operator MyType(SecondType t)
        {
            return t._value;
        }
    }

    [TestClass]
    public class UserDefinedConversionOperator
    {
        [TestMethod]
        public void Execute()
        {
            var secondType = GetObject();
            var myType = secondType as MyType;
            Assert.IsNull(myType);

            //var myNewType = new MyType();
            //var otherType = myNewType as OtherType;
        }

        public object GetObject()
        {
            return new SecondType();
        }
    }
}
