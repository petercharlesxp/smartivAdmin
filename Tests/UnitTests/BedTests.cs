using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using smartivAdmin.Data;
using smartivAdmin.Reop;

namespace Tests.UnitTests
{
    [TestClass]
    public class BedTests
    {
        [TestMethod]
        public void GetAllBeds()
        {
            var context = new SmartivContext();

            var bedRepo = new BedRepo(context);

            var beds = bedRepo.GetAllBeds();

            Assert.AreEqual(5, beds.Count);
        }
    }
}
