using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AllegroWebAplication.Providers;

namespace AllegroWebAplication.Tests.Providers
{
    [TestClass]
    public class AllegroApiWrapperTest
    {
        AllegroApiService.servicePortClient allegroServiceClient = new AllegroApiService.servicePortClient();

        [TestMethod]
        public void GetLocalVersionKey()
        {
            AllegroApiWrapper allegroApiWrapper = new AllegroApiWrapper(allegroServiceClient);
            long r = allegroApiWrapper.GetLocalVersionKey();
            Assert.AreNotEqual(0, r);
        }

        [TestMethod]
        public void DoLogin()
        {
            AllegroApiWrapper allegroApiWrapper = new AllegroApiWrapper(allegroServiceClient);
            allegroApiWrapper.GetLocalVersionKey();
            string handler = allegroApiWrapper.DoLogin();

            Assert.IsNotNull(handler);
            Assert.AreNotEqual("", handler);
        }

        [TestMethod]
        public void GetMySellItems()
        {
            AllegroApiWrapper allegroApiWrapper = new AllegroApiWrapper(allegroServiceClient);
            allegroApiWrapper.GetLocalVersionKey();
            allegroApiWrapper.DoLogin();
            var r = allegroApiWrapper.GetMySellItems();
            Assert.IsNotNull(r);
        }
    }
}
