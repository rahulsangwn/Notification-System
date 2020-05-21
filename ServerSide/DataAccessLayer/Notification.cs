namespace DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Notification
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Notification()
        {
            Recipients = new HashSet<Recipient>();
        }

        [Key]
        public int NotifId { get; set; }

        [Required]
        [StringLength(200)]
        public string NotifBody { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ExpiryDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime CreateDate { get; set; }

        public int TypeId { get; set; }

        public virtual NotificationType NotificationType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Recipient> Recipients { get; set; }
    }
}
