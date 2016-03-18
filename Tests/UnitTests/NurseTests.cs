using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using smartivAdmin.Data;
using smartivAdmin.Reop;

namespace Tests.UnitTests
{
    [TestClass]
    public class NurseTests
    {
        [TestMethod]
        public void GetAvailableNurses()
        {
            var context = new SmartivContext();

            var nurseRepo = new NurseRepo(context);

            var nurses = nurseRepo.GetAvaiableNurses();

            Assert.AreEqual(4, nurses.Count);
        }  
    }
}
