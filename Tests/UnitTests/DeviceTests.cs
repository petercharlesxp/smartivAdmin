using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using smartivAdmin.Data;
using smartivAdmin.Reop;

namespace Tests.UnitTests
{
    [TestClass]
    public class DeviceTests
    {
        [TestMethod]
        public void GetAllDevices()
        {
            var deviceRepo = new DeviceRepo();

            var devices = deviceRepo.GetAllDevices();

            Assert.AreEqual(20, devices.Count);
        }
    }
}
