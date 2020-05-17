namespace DataAccessLayer
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class NotificationContext : DbContext
    {
        public NotificationContext()
            : base("name=NotificationContext")
        {
        }

        public virtual DbSet<CommunicationMode> CommunicationModes { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<NotificationType> NotificationTypes { get; set; }
        public virtual DbSet<Recipient> Recipients { get; set; }
        public virtual DbSet<UserGroup> UserGroups { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CommunicationMode>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<CommunicationMode>()
                .HasMany(e => e.Recipients)
                .WithRequired(e => e.CommunicationMode)
                .HasForeignKey(e => e.ClearedModes)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CommunicationMode>()
                .HasMany(e => e.Recipients1)
                .WithRequired(e => e.CommunicationMode1)
                .HasForeignKey(e => e.ReceivedModes)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CommunicationMode>()
                .HasMany(e => e.Recipients2)
                .WithRequired(e => e.CommunicationMode2)
                .HasForeignKey(e => e.CommModes)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CommunicationMode>()
                .HasMany(e => e.UserGroups)
                .WithRequired(e => e.CommunicationMode)
                .HasForeignKey(e => e.CommModes)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CommunicationMode>()
                .HasMany(e => e.UserGroups1)
                .WithRequired(e => e.CommunicationMode1)
                .HasForeignKey(e => e.CommModes)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Notification>()
                .HasMany(e => e.Recipients)
                .WithRequired(e => e.Notification)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NotificationType>()
                .HasMany(e => e.Notifications)
                .WithRequired(e => e.NotificationType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Recipients)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.UserGroups)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);
        }
    }
}
