namespace DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Recipient
    {
        [Key]
        public int RecipId { get; set; }

        public int NotifId { get; set; }

        public int ReceivedModes { get; set; }

        public int ClearedModes { get; set; }

        public int CommModes { get; set; }

        public int UserId { get; set; }

        public virtual CommunicationMode CommunicationMode { get; set; }

        public virtual CommunicationMode CommunicationMode1 { get; set; }

        public virtual CommunicationMode CommunicationMode2 { get; set; }

        public virtual Notification Notification { get; set; }

        public virtual User User { get; set; }
    }
}
