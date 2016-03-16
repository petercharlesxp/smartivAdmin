namespace smartivAdmin.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("wimtach.gauges")]
    public partial class gauge
    {
        public int id { get; set; }

        [Required]
        [StringLength(25)]
        public string partNumber { get; set; }

        [Required]
        [StringLength(25)]
        public string series { get; set; }

        [Required]
        [StringLength(30)]
        public string connectionType { get; set; }

        [Required]
        [StringLength(30)]
        public string dialSize { get; set; }

        [Required]
        [StringLength(100)]
        public string connectionLocation { get; set; }

        [Required]
        [StringLength(25)]
        public string accuracy { get; set; }

        [Required]
        [StringLength(100)]
        public string caseMaterial { get; set; }

        [Required]
        [StringLength(100)]
        public string wettedParts { get; set; }

        [Required]
        [StringLength(30)]
        public string upc { get; set; }

        [Required]
        [StringLength(50)]
        public string productType { get; set; }

        [Required]
        [StringLength(30)]
        public string pressureRange { get; set; }

        [Required]
        [StringLength(30)]
        public string fill { get; set; }

        public int linkToPostID { get; set; }
    }
}
