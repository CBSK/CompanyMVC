using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.Models.Models;
using Company.Repository.IRepository;
using System.Data.Entity.Migrations;
using System.Data.Entity;

namespace Company.Repository.IMP_Repository
{
    public class CompanyConcrete : ICompany

    {
        public OurdbContext _ABIDBContext = null;
        private bool disposed = false;

        public CompanyConcrete(OurdbContext abiDBcontext)
        {
            _ABIDBContext = abiDBcontext;
        }

        public void Add(CompanyTBL companyTBL)
        {
            _ABIDBContext.Add(companyTBL);
            _ABIDBContext.SaveChanges();
        }

        public void Delete(CompanyTBL companyTBL)
        {
            _ABIDBContext.Delete(companyTBL);
            _ABIDBContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        public CompanyTBL Get(Guid id)
        {
            return _ABIDBContext.Company.Where(k => k.id == id).FirstOrDefault();
        }

        public List<CompanyTBL> GetList()
        {
            using (var dbContext = new OurdbContext())
            {
                return dbContext.Company.ToList();
            }
        }

        public bool Update(CompanyTBL companyTBL)
        {
            try
            {
                _ABIDBContext.Update(companyTBL);

                int r = _ABIDBContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

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
    }
}