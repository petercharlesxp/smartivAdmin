namespace smartivAdmin.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("wimtach.room")]
    public partial class room
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public room()
        {
            beds = new HashSet<bed>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int roomID { get; set; }

        [StringLength(45)]
        public string roomDesc { get; set; }

        [StringLength(45)]
        public string departmentID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<bed> beds { get; set; }

        public virtual department department { get; set; }
    }
}
