namespace smartivAdmin.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("wimtach.subscription")]
    public partial class subscription
    {
        [Key]
        [StringLength(164)]
        public string deviceId { get; set; }

        public int userId { get; set; }

        [Required]
        [StringLength(10)]
        public string deviceType { get; set; }

        public virtual user user { get; set; }
    }
}
