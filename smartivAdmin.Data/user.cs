namespace smartivAdmin.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("wimtach.user")]
    public partial class user
    {
        public user()
        {
            subscriptions = new HashSet<subscription>();
        }

        public int userId { get; set; }

        [Required]
        [StringLength(45)]
        public string userName { get; set; }

        [StringLength(45)]
        public string userType { get; set; }

        [Required]
        [StringLength(45)]
        public string password { get; set; }

        [StringLength(45)]
        public string lastLogIn { get; set; }

        [StringLength(45)]
        public string sessionKey { get; set; }

        public virtual ICollection<subscription> subscriptions { get; set; }
    }
}
