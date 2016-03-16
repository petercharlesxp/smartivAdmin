namespace smartivAdmin.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("wimtach.floor")]
    public partial class floor
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int floorId { get; set; }

        [StringLength(45)]
        public string floorDesc { get; set; }
    }
}
