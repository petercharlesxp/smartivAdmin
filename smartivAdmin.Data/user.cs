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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<subscription> subscriptions { get; set; }
    }
}
