using smartivAdmin.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smartivAdmin.Reop
{
    public class DeviceRepo
    {
        public List<device> GetAllDevices()
        {
            using (var dbContext = new SmartivContext())
            {
                return dbContext.devices.ToList();
            }
        }
    }
}

