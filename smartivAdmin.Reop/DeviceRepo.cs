using smartivAdmin.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smartivAdmin.Reop
{
    class DeviceRepo
    {
        public class DeviceReop
        {
            public List<device> GetDevices()
            {
                using (var dbContext = new SmartivContext())
                {
                    return dbContext.devices.ToList();
                }
            }
        }
    }
}
