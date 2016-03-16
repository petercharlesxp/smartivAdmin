namespace smartivAdmin.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("wimtach.patientadmissioninfo")]
    public partial class patientadmissioninfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int patientID { get; set; }

        public int? nurseID { get; set; }

        public int? bedID { get; set; }

        public virtual bed bed { get; set; }

        public virtual nurse nurse { get; set; }
    }
}
