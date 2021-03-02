using Signature_Assessment_Repository.DAL.Context;
using Signature_Assessment_Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Signature_Assessment_Repository.DAL
{
    public class UnitOfWork  : IDisposable
    {
        private DBContext context = new DBContext();

        UserRepository normalRepository;

        public UserRepository UserRepository
        {
            get
            {
                if (this.normalRepository == null)
                {
                    this.normalRepository = new UserRepository(context);
                }
                return normalRepository;
            }
        }
        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
