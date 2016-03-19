namespace smartivAdmin.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("wimtach.nurse")]
    public partial class nurse
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public nurse()
        {
            patientadmissioninfoes = new HashSet<patientadmissioninfo>();
        }

        public int nurseId { get; set; }

        [StringLength(45)]
        public string firstName { get; set; }

        [StringLength(45)]
        public string lastName { get; set; }

        [StringLength(45)]
        public string currentShift { get; set; }

        public int userId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<patientadmissioninfo> patientadmissioninfoes { get; set; }

        //public override string ToString()
        //{
        //    return firstName + " " + lastName;
        //}
    }
}
