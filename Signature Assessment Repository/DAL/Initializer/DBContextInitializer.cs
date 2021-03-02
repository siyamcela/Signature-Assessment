using Signature_Assessment_Models;
using Signature_Assessment_Repository.DAL.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace Signature_Assessment_Repository.DAL.Initializer
{
   public class DBContextInitializer : DropCreateDatabaseIfModelChanges<DBContext>
    {
        protected override void Seed(DBContext context)
        {
            new List<Person>
        {
            new Person {Name ="Siyamcela", Password="Siya",Surname="Madokwe",},
        
        }.ForEach(b => context.Person.Add(b));

            new List<Info>
        {
            new Info { AddressCode= "7100", AddressLine1 = "21 siya street", AddressLine2 = "siya town", AddressLine3 = "Siyas province", PostalAddress1 = "Siya Street", PostalAddress2 ="Siya Town", PostalCode="7140", CelNo = "0781234568", TelNo="01786556665" },
        }.ForEach(b => context.Info.Add(b));

            base.Seed(context);
        }
    }
}
