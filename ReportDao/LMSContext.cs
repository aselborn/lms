
using ReportDao.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportDao
{
    public class LMSContext : DbContext
    {
        private static string m_connection = @"Server=D18SE-C0485NPQ\SQLEXPRESS;Database=LMS;Trusted_Connection=True";
        public LMSContext() : base(m_connection)
        {
           
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<LMSContext>(null);
            base.OnModelCreating(modelBuilder);
        }


        public DbSet<EventType> DbEventType { get; set; }
        public DbSet<EventLog> DbEventLog { get; set; }
        public DbSet<Test> DbTest { get; set; }
        public DbSet<TestBed> DbTestBed { get; set; }
        public DbSet<TestObject> DbTestObject { get; set; }
        public DbSet<TestModule> DbTestModule { get; set; }
        public DbSet<Device> DbDevice { get; set; }
        public DbSet<ItemGroup> DbItemGroup { get; set; }
        public DbSet<Item> DbItem { get; set; }
        public DbSet<UserObject> DbUserObject { get; set; }
        public DbSet<ReportType> DbReportType { get; set; }

    }

    
}
