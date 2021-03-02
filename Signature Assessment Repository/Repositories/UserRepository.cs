using Signature_Assessment_Models;
using Signature_Assessment_Repository.DAL;
using Signature_Assessment_Repository.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Signature_Assessment_Repository.Repositories
{
   public class UserRepository : GenericRepository<Person>
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        public UserRepository(DBContext context)
        : base(context)
        {
        }

        public Person Login(Login user)
        {
            return context.Person.FirstOrDefault(users => users.Name == user.Username && users.Password == user.Password);
        }
        public Person GetPersonById(int id)
        {
            var results = context.Person.FirstOrDefault(person => person.Id == id);
            results.PersonInfo = context.Info.FirstOrDefault(info => info.PersonId == id);
            return results;
        }
    }

}