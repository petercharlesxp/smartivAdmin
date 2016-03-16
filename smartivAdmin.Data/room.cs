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

        public virtual ICollection<bed> beds { get; set; }

        public virtual department department { get; set; }
    }
}
