namespace smartivAdmin.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("wimtach.devicerecordlogs")]
    public partial class devicerecordlog
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(45)]
        public string deviceMacId { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(45)]
        public string deviceCurrentWeight { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(45)]
        public string deviceBatteryStatus { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(45)]
        public string deviceTimeStamp { get; set; }

        [Key]
        [Column(Order = 4, TypeName = "timestamp")]
        public DateTime ServerTimeStamp { get; set; }
    }
}
