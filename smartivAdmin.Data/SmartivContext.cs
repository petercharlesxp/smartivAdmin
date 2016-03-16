namespace smartivAdmin.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SmartivContext : DbContext
    {
        public SmartivContext()
            : base("name=SmartivContext")
        {
        }

        public virtual DbSet<bed> beds { get; set; }
        public virtual DbSet<department> departments { get; set; }
        public virtual DbSet<device> devices { get; set; }
        public virtual DbSet<floor> floors { get; set; }
        public virtual DbSet<gauge> gauges { get; set; }
        public virtual DbSet<nurse> nurses { get; set; }
        public virtual DbSet<patientadmissioninfo> patientadmissioninfoes { get; set; }
        public virtual DbSet<patientbasicinfo> patientbasicinfoes { get; set; }
        public virtual DbSet<room> rooms { get; set; }
        public virtual DbSet<serverlog> serverlogs { get; set; }
        public virtual DbSet<subscription> subscriptions { get; set; }
        public virtual DbSet<user> users { get; set; }
        public virtual DbSet<devicerecordlog> devicerecordlogs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<bed>()
                .Property(e => e.deviceMacID)
                .IsUnicode(false);

            modelBuilder.Entity<bed>()
                .HasMany(e => e.patientadmissioninfoes)
                .WithOptional(e => e.bed)
                .WillCascadeOnDelete();

            modelBuilder.Entity<department>()
                .Property(e => e.departmentID)
                .IsUnicode(false);

            modelBuilder.Entity<department>()
                .Property(e => e.departmentDesc)
                .IsUnicode(false);

            modelBuilder.Entity<department>()
                .HasMany(e => e.rooms)
                .WithOptional(e => e.department)
                .WillCascadeOnDelete();

            modelBuilder.Entity<device>()
                .Property(e => e.deviceMacID)
                .IsUnicode(false);

            modelBuilder.Entity<device>()
                .Property(e => e.deviceStatus)
                .IsUnicode(false);

            modelBuilder.Entity<device>()
                .Property(e => e.deviceInfo)
                .IsUnicode(false);

            modelBuilder.Entity<device>()
                .Property(e => e.extra)
                .IsUnicode(false);

            modelBuilder.Entity<floor>()
                .Property(e => e.floorDesc)
                .IsUnicode(false);

            modelBuilder.Entity<gauge>()
                .Property(e => e.partNumber)
                .IsUnicode(false);

            modelBuilder.Entity<gauge>()
                .Property(e => e.series)
                .IsUnicode(false);

            modelBuilder.Entity<gauge>()
                .Property(e => e.connectionType)
                .IsUnicode(false);

            modelBuilder.Entity<gauge>()
                .Property(e => e.dialSize)
                .IsUnicode(false);

            modelBuilder.Entity<gauge>()
                .Property(e => e.connectionLocation)
                .IsUnicode(false);

            modelBuilder.Entity<gauge>()
                .Property(e => e.accuracy)
                .IsUnicode(false);

            modelBuilder.Entity<gauge>()
                .Property(e => e.caseMaterial)
                .IsUnicode(false);

            modelBuilder.Entity<gauge>()
                .Property(e => e.wettedParts)
                .IsUnicode(false);

            modelBuilder.Entity<gauge>()
                .Property(e => e.upc)
                .IsUnicode(false);

            modelBuilder.Entity<gauge>()
                .Property(e => e.productType)
                .IsUnicode(false);

            modelBuilder.Entity<gauge>()
                .Property(e => e.pressureRange)
                .IsUnicode(false);

            modelBuilder.Entity<gauge>()
                .Property(e => e.fill)
                .IsUnicode(false);

            modelBuilder.Entity<nurse>()
                .Property(e => e.firstName)
                .IsUnicode(false);

            modelBuilder.Entity<nurse>()
                .Property(e => e.lastName)
                .IsUnicode(false);

            modelBuilder.Entity<nurse>()
                .Property(e => e.currentShift)
                .IsUnicode(false);

            modelBuilder.Entity<nurse>()
                .HasMany(e => e.patientadmissioninfoes)
                .WithOptional(e => e.nurse)
                .WillCascadeOnDelete();

            modelBuilder.Entity<patientbasicinfo>()
                .Property(e => e.firstName)
                .IsUnicode(false);

            modelBuilder.Entity<patientbasicinfo>()
                .Property(e => e.lastName)
                .IsUnicode(false);

            modelBuilder.Entity<patientbasicinfo>()
                .Property(e => e.middleName)
                .IsUnicode(false);

            modelBuilder.Entity<patientbasicinfo>()
                .Property(e => e.sex)
                .IsUnicode(false);

            modelBuilder.Entity<patientbasicinfo>()
                .Property(e => e.deviceMacID)
                .IsUnicode(false);

            modelBuilder.Entity<patientbasicinfo>()
                .Property(e => e.deviceCurrentWeight)
                .IsUnicode(false);

            modelBuilder.Entity<patientbasicinfo>()
                .Property(e => e.deviceTimeStamp)
                .IsUnicode(false);

            modelBuilder.Entity<patientbasicinfo>()
                .Property(e => e.deviceCurrentBattery)
                .IsUnicode(false);

            modelBuilder.Entity<room>()
                .Property(e => e.roomDesc)
                .IsUnicode(false);

            modelBuilder.Entity<room>()
                .Property(e => e.departmentID)
                .IsUnicode(false);

            modelBuilder.Entity<serverlog>()
                .Property(e => e.message)
                .IsUnicode(false);

            modelBuilder.Entity<subscription>()
                .Property(e => e.deviceId)
                .IsUnicode(false);

            modelBuilder.Entity<subscription>()
                .Property(e => e.deviceType)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.userName)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.userType)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.lastLogIn)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.sessionKey)
                .IsUnicode(false);

            modelBuilder.Entity<devicerecordlog>()
                .Property(e => e.deviceMacId)
                .IsUnicode(false);

            modelBuilder.Entity<devicerecordlog>()
                .Property(e => e.deviceCurrentWeight)
                .IsUnicode(false);

            modelBuilder.Entity<devicerecordlog>()
                .Property(e => e.deviceBatteryStatus)
                .IsUnicode(false);

            modelBuilder.Entity<devicerecordlog>()
                .Property(e => e.deviceTimeStamp)
                .IsUnicode(false);
        }
    }
}
