
using System;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using System.Threading.Tasks;

namespace For_Jenkins
{
    [TestFixture]
    public class For_Jenkins
    {
        [Test]
        public void TestMethod1()
        {
            string Actual = "a";
            string Expected = "a";
            ClassicAssert.AreEqual(Actual, Expected);   
        }
    }
}
