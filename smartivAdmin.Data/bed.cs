namespace smartivAdmin.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("wimtach.bed")]
    public partial class bed
    {
        public bed()
        {
            patientadmissioninfoes = new HashSet<patientadmissioninfo>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int bedId { get; set; }

        [Required]
        [StringLength(45)]
        public string deviceMacID { get; set; }

        public int roomId { get; set; }

        public virtual ICollection<patientadmissioninfo> patientadmissioninfoes { get; set; }

        public virtual room room { get; set; }

        public override string ToString()
        {
            return deviceMacID;
        }
    }
}
