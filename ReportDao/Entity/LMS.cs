namespace ReportDao.Entity
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class LMS : DbContext
    {
        public LMS()
            : base("LMS")
        {
        }

        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Device> Device { get; set; }
        public virtual DbSet<EventLog> EventLog { get; set; }
        public virtual DbSet<EventType> EventType { get; set; }
        public virtual DbSet<Test> Test { get; set; }
        public virtual DbSet<TestBed> TestBed { get; set; }
        public virtual DbSet<TestObject> TestObject { get; set; }
        public virtual DbSet<UserObject> UserObject { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .Property(e => e.CustomerName)
                .IsFixedLength();

            modelBuilder.Entity<Device>()
                .Property(e => e.DeviceName)
                .IsFixedLength();

            modelBuilder.Entity<EventLog>()
                .Property(e => e.EventLogUserId)
                .IsFixedLength();

            modelBuilder.Entity<EventType>()
                .Property(e => e.EventTypeDescription)
                .IsFixedLength();

            modelBuilder.Entity<EventType>()
                .HasMany(e => e.EventLog)
                .WithRequired(e => e.EventType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Test>()
                .Property(e => e.TestName)
                .IsFixedLength();

            modelBuilder.Entity<TestBed>()
                .Property(e => e.TestBedName)
                .IsFixedLength();

            modelBuilder.Entity<TestObject>()
                .Property(e => e.TestObjectIdName)
                .IsFixedLength();

            modelBuilder.Entity<UserObject>()
                .Property(e => e.UserObjectName)
                .IsUnicode(false);
        }
    }
}
