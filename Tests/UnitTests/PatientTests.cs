using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using smartivAdmin.Data;
using smartivAdmin.Reop;

namespace Tests.UnitTests
{
    [TestClass]
    public class PatientTests
    {
        [TestMethod]
        public void GetAllPatients()
        {
            var context = new SmartivContext();
            var patientRepo = new PatientRepo(context);
            var patients = patientRepo.GetAllPatients();
            Assert.AreEqual(3, patients.Count);
        }

        //[TestMethod]
        //public void CreateDevice_saves_a_patient_context()
        //{
        //    var context = new SmartivContext();
        //    var patientRepo = new PatientRepo(context);
        //    var patients = patientRepo.GetAllPatients();
        //    int count0 = patients.Count;

        //    var patient = patientRepo.AddPatient("Katy", "Helly", "T", "Femaile", "00:80:E1:B4:7B:AC");
        //    patients = patientRepo.GetAllPatients();
        //    int count1 = patients.Count;

        //    Assert.AreEqual(1, count1 - count0);
        //}
    }
}
