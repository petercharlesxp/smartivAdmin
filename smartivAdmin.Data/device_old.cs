namespace smartivAdmin.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("wimtach.device_old")]
    public partial class device_old
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public device_old()
        {
            beds = new HashSet<bed>();
        }

        [Key]
        [StringLength(45)]
        public string deviceID { get; set; }

        [Required]
        [StringLength(45)]
        public string deviceMacID { get; set; }

        [StringLength(45)]
        public string deviceStatus { get; set; }

        [StringLength(45)]
        public string deviceInfo { get; set; }

        [StringLength(45)]
        public string extra { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<bed> beds { get; set; }
    }
}
