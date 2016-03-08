using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smartivAdmin
{
    public class Patient
    {
        public string ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Sex {get; set; }
        public string DeviceCurrentWeight { get; set; }
        public string DeviceBattery { get; set; }

    }
}
