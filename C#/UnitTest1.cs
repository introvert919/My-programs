using System;
using NUnit.Framework;
using NUnit.Framework.Legacy;



namespace Тест_Nunit_для_Jenkins
{

    [TestFixture]

        public class UnitTest1
        {

        [Test]
        public void TestMethod1()
        {
            string a = "a";
            string b = "a";

            ClassicAssert.AreEqual(a, b);
        }
        }
}


