using Signature_Assessment_Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Text;

namespace Signature_Assessment_Repository.Mappers
{
    public class InfoMapper : EntityTypeConfiguration<Info>
    {
        public InfoMapper()
        {
            ToTable("Info");
            HasKey(E => E.PersonId).Property(x => x.PersonId);
            Property(E => E.PostalAddress1);
            Property(E => E.PostalAddress2);
            Property(E => E.PostalCode);
            Property(E => E.TelNo);
            Property(E => E.AddressCode);
            Property(E => E.AddressLine1);

            Property(E => E.AddressLine2);
            Property(E => E.AddressLine3);
            Property(E => E.CelNo);
        }
    }
}
