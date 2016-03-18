namespace smartivAdmin.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("wimtach.patientbasicinfo")]
    public partial class patientbasicinfo
    {
        [Key]
        public int patientID { get; set; }

        [Required]
        [StringLength(45)]
        public string firstName { get; set; }

        [Required]
        [StringLength(45)]
        public string lastName { get; set; }

        [StringLength(45)]
        public string middleName { get; set; }

        [Required]
        [StringLength(45)]
        public string sex { get; set; }

        [Required]
        [StringLength(45)]
        public string deviceMacID { get; set; }

        [StringLength(45)]
        public string deviceCurrentWeight { get; set; }

        [StringLength(45)]
        public string deviceTimeStamp { get; set; }

        [StringLength(45)]
        public string deviceCurrentBattery { get; set; }
    }
}
