using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using smartivAdmin.Data;
using Prism.Commands;
using smartivAdmin.Reop;

namespace smartivAdmin.ViewModels
{
    public class HomeViewModel: BindableBase
    {
        private SmartivContext context;
        private DeviceRepo deviceRepo;
        private NurseRepo nurseRepo;
        private BedRepo bedRepo;
        private PatientRepo patientRepo;
        private PatientadmissioninfoRepo patientadmissioninfoRepo;

        /// <summary>
        /// Assign Patient
        /// </summary>

        private List<device> availableDevices;

        public List<device> AvailableDevices
        {
            get { return availableDevices; }
            set { SetProperty(ref availableDevices, value); }
        }
        

        private device selectedDevice;

        public device SelectedDevice
        {
            get { return selectedDevice; }
            set { SetProperty(ref selectedDevice, value); }
        }
        

        private List<nurse> avaiableNurses;

        public List<nurse> AvaiableNurses
        {
            get { return avaiableNurses; }
            set { SetProperty(ref avaiableNurses, value); }
        }

        private nurse selectedNurse;

        public nurse SelectedNurse
        {
            get { return selectedNurse; }
            set { SetProperty(ref selectedNurse, value); }
        }
        

        private List<bed> availabeBeds;

        public List<bed> AvailableBeds
        {
            get { return availabeBeds; }
            set { availabeBeds = value; }
        }

        private bed selectedBed;

        public bed SelectedBed
        {
            get { return selectedBed; }
            set { SetProperty(ref selectedBed, value); }
        }

        /// <summary>
        /// Add New Patient
        /// </summary>
        /// 

        public int NewPatientID { get; set; }

        private string newFirstName;

        public string NewFirstName
        {
            get { return newFirstName; }
            set { SetProperty(ref newFirstName, value); }
        }

        private string newLastName;

        public string NewLastName
        {
            get { return newLastName; }
            set { SetProperty(ref newLastName, value); }
        }

        private string newMiddleName;

        public string NewMiddleName
        {
            get { return newMiddleName; }
            set { SetProperty(ref newMiddleName, value); }
        }

        private string newSex;

        public string NewSex
        {
            get { return newSex; }
            set { SetProperty(ref newSex, value); }
        }

        public DelegateCommand AddNewPatient { get; set; }
        private void ExecuteAddNewPatient()
        {
            var context = new SmartivContext();
            var patientRepo = new PatientRepo(context);
            try
            {
                var newPatient = patientRepo.AddPatient(
                    NewFirstName,   
                    NewLastName,
                    NewMiddleName,
                    NewSex,
                    SelectedDevice.deviceMacID
                    );
                NewPatientID = newPatient.patientID;
                var newPatientadmissioninfoRepo = patientadmissioninfoRepo.AddPatientadmissioninfo(
                    NewPatientID,
                    SelectedNurse.nurseId,
                    SelectedBed.bedId
                    );

            }
            catch (Exception e)
            {

                throw e;
            }
        }
        private bool CanExecuteAddNewPatient()
        {
            bool b = !String.IsNullOrWhiteSpace(NewFirstName)
                && !String.IsNullOrWhiteSpace(NewLastName)
                && !String.IsNullOrWhiteSpace(NewSex)
                && (SelectedDevice != null)          
                ;
            return b;
        }
        
        /// <summary>
        /// Add New Device
        /// </summary>

        private string newDeviceMacID;

        public string NewDeviceMacID
        {
            get { return newDeviceMacID; }
            set { SetProperty(ref newDeviceMacID, value); }
        }

        private string newDeviceStatus;

        public string NewDeviceStatus
        {
            get { return newDeviceStatus; }
            set { SetProperty(ref newDeviceStatus, value); }
        }

        private string newDeviceInfo;

        public string NewDeviceInfo
        {
            get { return newDeviceInfo; }
            set { SetProperty(ref newDeviceInfo, value); }
        }

        private string newExtra;

        public string NewExtra
        {
            get { return newExtra; }
            set { SetProperty(ref newExtra, value); }
        }

        public DelegateCommand AddNewDevice { get; set; }


        public HomeViewModel()
        {
            context = new SmartivContext();

            deviceRepo = new DeviceRepo(context);
            availableDevices = deviceRepo.GetAvaiableDevices();
            nurseRepo = new NurseRepo(context);
            avaiableNurses = nurseRepo.GetAvaiableNurses();
            bedRepo = new BedRepo(context);
            availabeBeds = bedRepo.GetAllBeds();
            patientRepo = new PatientRepo(context);
            patientadmissioninfoRepo = new PatientadmissioninfoRepo(context);

            AddNewPatient = new DelegateCommand(ExecuteAddNewPatient, CanExecuteAddNewPatient)
                .ObservesProperty(() => NewFirstName)
                .ObservesProperty(() => NewLastName)
                .ObservesProperty(() => NewSex)
                .ObservesProperty(() => SelectedDevice);
                

            AddNewDevice = new DelegateCommand(Execute, CanExecute)
                .ObservesProperty(() => NewDeviceMacID)
                .ObservesProperty(() => NewDeviceStatus);

        }

        private bool CanExecute()
        {
            return !String.IsNullOrWhiteSpace(NewDeviceMacID)
                && !String.IsNullOrWhiteSpace(NewDeviceStatus);
        }

        private void Execute()
        {
            var context = new SmartivContext();
            var deviceRepo = new DeviceRepo(context);
            try
            {
                var device = deviceRepo.AddDevice(NewDeviceMacID
                , NewDeviceStatus
                , NewDeviceInfo
                , NewExtra);
            }
            catch (Exception e)
            {
                
                throw e;
            }
        }
    }
}
