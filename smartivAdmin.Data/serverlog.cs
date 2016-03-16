namespace smartivAdmin.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("wimtach.serverlogs")]
    public partial class serverlog
    {
        [Key]
        public int logID { get; set; }

        [StringLength(200)]
        public string message { get; set; }

        [Column(TypeName = "timestamp")]
        public DateTime? timeStamp { get; set; }
    }
}
