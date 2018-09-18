using ReportDao.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportDao
{
    public class ContextManager : DbContext
    {
        //private static string m_connection = ConfigurationManager.AppSettings["Connection"];
        private static string m_connection = @"Server=ZL4054GBG1SE\SQLEXPRESS;Database=RatDB;Trusted_Connection=True";
        public ContextManager() : base(m_connection)
        {
            
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            //Database.SetInitializer<ContextManager>(null);
            base.OnModelCreating(modelBuilder);
        }


        public DbSet<Rig> Rig { get; set; }
        public DbSet<RigRecord> RigRecord { get; set; }
        public DbSet<RigUse> RigUse { get; set; }
        public DbSet<RigTime> RigTime { get; set; }
        public DbSet<Category> Category { get; set;}
    }
}
