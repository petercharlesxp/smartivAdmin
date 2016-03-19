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

        [TestMethod]
        public void Create_saves_a_patient_context()
        {
            var context = new SmartivContext();
            var patientRepo = new PatientRepo(context);
            var patients = patientRepo.GetAllPatients();
            int count0 = patients.Count;

            var patient = patientRepo.AddPatient("Katy2", "Helly2", "T2", "Female", "00:80:E1:B4:7B:96");
            patients = patientRepo.GetAllPatients();
            int count1 = patients.Count;

            //Assert.AreEqual(1, count1 - count0);
            Assert.AreEqual(251, patient.patientID);
        }

        [TestMethod] 
        public void GetAllPatientadminssioninfos()
        {
            var context = new SmartivContext();
            var patientadmissioninfoRepo = new PatientadmissioninfoRepo(context);
            var patientadmissionfnfoes = patientadmissioninfoRepo.GetAllPatientadmissioninfos();
            Assert.AreEqual(3, patientadmissionfnfoes.Count);
        }

        [TestMethod]
        public void Assign_Patient_Admission()
        {
            var context = new SmartivContext();
            var patientadmissioninfoRepo = new PatientadmissioninfoRepo(context);
            var patientadmissioninfos = patientadmissioninfoRepo.GetAllPatientadmissioninfos();
            int count0 = patientadmissioninfos.Count;

            var patientadmissioninfo = patientadmissioninfoRepo.AddPatientadmissioninfo(231, 31, 4);
            patientadmissioninfos = patientadmissioninfoRepo.GetAllPatientadmissioninfos();
            int count1 = patientadmissioninfos.Count;
            Assert.AreEqual(1, count1 - count0);
        }
    }
}
