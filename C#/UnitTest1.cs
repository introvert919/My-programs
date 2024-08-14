using System;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using System.Net.Http;
using System.Threading.Tasks;

namespace Тест_Nunit_для_Jenkins
{

    [TestFixture]

   
      


public class UnitTest1
{

    static HttpClient httpClient = new HttpClient();

    [OneTimeSetUp]
    public async Task Main()
    {
        
       
    }

    [OneTimeTearDown]

    public void Close_url()
    {
       httpClient.Dispose();
    }

    [Test]

        public async Task TestMethod1()
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "https://www.google.com");
            HttpResponseMessage response = await httpClient.SendAsync(request);

            string Actual = response.StatusCode.ToString();
            string Expected = "OK";

            ClassicAssert.AreEqual(Expected, Actual);
        }
        }
}


