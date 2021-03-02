using Signature_Assessment_API.Contracts;
using Signature_Assessment_Models;
using Signature_Assessment_Repository.DAL;
using Signature_Assessment_Repository.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Signature_Assessment_API.Services
{
    public class UserService : IUserService
    {

        private UnitOfWork unitOfWork = new UnitOfWork();
        DBContext adminContext = new DBContext();

        public void Update(int id, Person user)
        {
            bool IsModified = false;
            StringBuilder message = new StringBuilder();
            var User = unitOfWork.UserRepository.GetByID(id);
            adminContext.Entry(User).CurrentValues.SetValues(user);

            foreach (var propertyName in adminContext.Entry(User).OriginalValues.PropertyNames)
            {
                var original = adminContext.Entry(User).OriginalValues.GetValue<object>(propertyName);
                var current = adminContext.Entry(User).CurrentValues.GetValue<object>(propertyName);
                if (!object.Equals(original, current))
                {
                    IsModified = true;
                    message.AppendLine(propertyName + " has changed from " + original.ToString() + " To " + current.ToString());
                }
            }
            if (IsModified)
            {
                unitOfWork.UserRepository.Update(user);
                unitOfWork.Save();

            }
        }
        public Person Login(string username, string password)
        {
            Login user = new Login() { Password = password, Username = username };
            var AdinInDB = unitOfWork.UserRepository.Login(user);
            return AdinInDB;
        }

        public Person GetPersonById(int id)
        {
            var AdinInDB = unitOfWork.UserRepository.GetPersonById(id);
            return AdinInDB;
        }
    }
}
