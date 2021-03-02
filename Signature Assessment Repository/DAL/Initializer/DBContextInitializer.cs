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
            new Person {Name ="Siyamcela", Password="Siya",Surname="Madokwe"},
        
        }.ForEach(b => context.Person.Add(b));

            new List<Info>
        {
            new Info { },
        }.ForEach(b => context.Info.Add(b));

            base.Seed(context);
        }
    }
}
