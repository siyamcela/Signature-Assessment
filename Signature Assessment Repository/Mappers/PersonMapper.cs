using Signature_Assessment_Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Text;

namespace Signature_Assessment_Repository.Mappers
{
  public  class PersonMapper : EntityTypeConfiguration<Person>
    {
        public PersonMapper()
        {
            ToTable("Person");
            HasKey(E => E.Id).Property(x => x.Id).
            HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(E => E.Name);
            Property(E => E.Password).IsRequired().HasMaxLength(100);
            Property(E => E.Surname).IsRequired().HasMaxLength(100);
            Property(E => E.LastLogin);
        }
    }
}