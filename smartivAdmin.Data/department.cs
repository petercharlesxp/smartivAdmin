namespace smartivAdmin.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("wimtach.department")]
    public partial class department
    {
        public department()
        {
            rooms = new HashSet<room>();
        }

        [StringLength(45)]
        public string departmentID { get; set; }

        [StringLength(45)]
        public string departmentDesc { get; set; }

        public virtual ICollection<room> rooms { get; set; }
    }
}
