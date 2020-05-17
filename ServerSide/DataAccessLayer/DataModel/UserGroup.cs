namespace DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class UserGroup
    {
        [Key]
        public int GroupId { get; set; }

        public int UserId { get; set; }

        public int TypeId { get; set; }

        public int CommModes { get; set; }

        public virtual CommunicationMode CommunicationMode { get; set; }

        public virtual CommunicationMode CommunicationMode1 { get; set; }

        public virtual User User { get; set; }
    }
}
