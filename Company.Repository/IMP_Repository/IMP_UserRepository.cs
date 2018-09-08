using News.Models.Models;
using News.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace News.Repository.IMP_Repository
{
    public class IMP_UserRepository:IRepository_User, IDisposable
    {
        public APIdbContext _ABIDBContext = null;
        public IMP_UserRepository(APIdbContext abiDBcontext)
        {
            _ABIDBContext = abiDBcontext;
        }
        public List<Users> Getuserlist()
        {
            using (var dbContext = new APIdbContext())
            {
                return dbContext.Users.ToList();
            }
        }

        public Users GetuserlistByID(int UserId)
        {
            
                try
            {
                using (var dbContext = new APIdbContext())
                {
                    return dbContext.Users.Find(UserId);
                }
            }
            catch (Exception ex) { throw ex; }
        }


        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {

            if (!this.disposed)
            {

                if (disposing)
                {

                    _ABIDBContext.Dispose();

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
