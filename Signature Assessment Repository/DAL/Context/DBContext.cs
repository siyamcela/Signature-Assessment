using Signature_Assessment_Models;
using Signature_Assessment_Repository.DAL.Initializer;
using Signature_Assessment_Repository.Mappers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace Signature_Assessment_Repository.DAL.Context
{
   public class DBContext : DbContext
    {
        public DBContext()
            : base("Name=DefaultConnection")
        {
            Database.SetInitializer(new DBContextInitializer());
        }
        public DbSet<Person> Person { get; set; }
        public DbSet<Info> Info { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().Ignore(e => e.PersonInfo);
            modelBuilder.Configurations.Add(new InfoMapper());
            modelBuilder.Configurations.Add(new PersonMapper());        
        }
        private void FixEfProviderServicesProblem()
        {
            var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }
    }
}

