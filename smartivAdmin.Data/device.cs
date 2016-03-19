namespace smartivAdmin.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("wimtach.device")]
    public partial class device
    {
        public int deviceID { get; set; }

        [Required]
        [StringLength(45)]
        public string deviceMacID { get; set; }

        [StringLength(45)]
        public string deviceStatus { get; set; }

        [StringLength(45)]
        public string deviceInfo { get; set; }

        [StringLength(45)]
        public string extra { get; set; }

        //public override string ToString()
        //{
        //    return deviceMacID;
        //}
    }
}
