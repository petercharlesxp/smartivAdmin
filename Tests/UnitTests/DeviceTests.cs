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
            var context = new SmartivContext();

            var deviceRepo = new DeviceRepo(context);

            var devices = deviceRepo.GetAllDevices();

            Assert.AreEqual(21, devices.Count);
        }

        [TestMethod]
        public void CreateDevice_saves_a_device_context()
        {
            var context = new SmartivContext();

            var deviceRepo = new DeviceRepo(context);
            var devices = deviceRepo.GetAllDevices();
            int count0 = devices.Count;

            var device = deviceRepo.AddDevice("00:80:E1:B4:7B:9A", "ONLINE", "", "");
            devices = deviceRepo.GetAllDevices();
            int count1 = devices.Count;

            Assert.AreEqual(1, count1 - count0);
        }

    }
}
