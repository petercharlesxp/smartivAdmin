using smartivAdmin.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace smartivAdmin.Reop
{
    public class DeviceRepo
    {
        private SmartivContext _context;

        public DeviceRepo(SmartivContext context)
        {
            _context = context;
        }

        public device AddDevice(string deviceMacIDin
            , string deviceStatusin
            , string deviceInfoin
            , string extrain)
        {
            var devin = new device
            {
                deviceMacID = deviceMacIDin
                , deviceStatus = deviceStatusin
                , deviceInfo = deviceInfoin
                , extra = extrain
            };
            _context.devices.Add(devin);
            _context.SaveChanges();

            return devin;

        }

        public List<device> GetAvaiableDevices()
        {
            var query = from d in _context.devices
                        where d.deviceStatus == "ONLINE"
                        orderby d.deviceMacID
                        select d;

            return query.ToList();
        }

        public List<string> GetAvaiableDevicesMac()
        {
            var query = from d in _context.devices
                        where d.deviceStatus == "ONLINE"
                        orderby d.deviceMacID
                        select d.deviceMacID;

            return query.ToList();
        }

        public List<device> GetAllDevices()
        {
            //using (var dbContext = new SmartivContext())
            //{
            //    //return dbContext.devices.ToList();
            //    var query = from d in dbContext.devices
            //                orderby d.deviceMacID
            //                select d;
            //    return query.ToList();
            //}
            var query = from d in _context.devices
                        orderby d.deviceMacID
                        select d;

            return query.ToList();
        }

        public async Task<List<device>> GetAllDevicesAsync()
        {
            var query = from d in _context.devices
                        orderby d.deviceMacID
                        select d;

            return await query.ToListAsync();                         
        }


        //public bool CreateDevice(device dev, out string error)
        //{
        //    error = string.Empty;
        //    try
        //    {
        //        using (var dbContext = new SmartivContext())
        //        {
        //            dbContext.devices.Add(dev);
        //            dbContext.SaveChanges();
        //            return true;
        //        }
        //    }
        //    catch (Exception exception)
        //    {
        //        error = exception.Message;
        //        return false;
        //    }
        //}

        //public bool UpdateDevice(device dev, out string error)
        //{
        //    error = string.Empty;
        //    try
        //    {
        //        using (var dbContext = new SmartivContext())
        //        {
        //            var devToUpdate = dbContext.devices.SingleOrDefault(d => d.deviceID == dev.deviceID);

        //            if (devToUpdate == null)
        //            {
        //                error = "Invalid Device Found";
        //                return false;
        //            }                        
        //            devToUpdate.deviceInfo = dev.deviceInfo;
        //            devToUpdate.deviceMacID = dev.deviceMacID;
        //            devToUpdate.deviceStatus = dev.deviceStatus;
        //            devToUpdate.extra = dev.extra;

        //            dbContext.SaveChanges();
        //            return true;
        //        }
        //    }
        //    catch (Exception exception)
        //    {
        //        error = exception.Message;
        //        return false;
        //    }
        //}

        //public bool SaveDevice(device dev, out string error)
        //{
        //    error = string.Empty;
        //    if (dev.deviceMacID == String.Empty)
        //    {
        //        error = "Device Mac ID Empty";
        //        return false;
        //    }

        //    try
        //    {
        //        if (dev.deviceID > 0)
        //        {
        //            if (!UpdateDevice(dev, out error))
        //            {
        //                return false;
        //            }
        //        }
        //        else
        //        {
        //            if (!CreateDevice(dev, out error))
        //            {
        //                return false;
        //            }
        //        }
        //    }
        //    catch (Exception exception)
        //    {
        //        error = exception.Message;
        //        return false;
        //    }
        //    return true;
        //}


    }
}

