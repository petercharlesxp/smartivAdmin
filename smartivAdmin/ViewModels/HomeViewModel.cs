﻿using Prism.Mvvm;
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

        private List<device> availableDevices;

        public List<device> AvailableDevices
        {
            get { return availableDevices; }
            set { SetProperty(ref availableDevices, value); }
        }

        private List<nurse> avaiableNurses;

        public List<nurse> AvaiableNurses
        {
            get { return avaiableNurses; }
            set { SetProperty(ref avaiableNurses, value); }
        }

        private List<bed> availabeBeds;

        public List<bed> AvailableBeds
        {
            get { return availabeBeds; }
            set { availabeBeds = value; }
        }
        

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

            AddNewDevice = new DelegateCommand(Execute, CanExecute)
                .ObservesProperty(() => NewDeviceMacID)
                .ObservesProperty(() => NewDeviceStatus);

        }

        private bool CanExecute()
        {
            return !String.IsNullOrWhiteSpace(NewDeviceMacID) && !String.IsNullOrWhiteSpace(NewDeviceStatus);
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