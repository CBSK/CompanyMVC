using Company.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Repository.IRepository
{
    public interface ICompany : IDisposable

    {
        void Add(CompanyTBL companyTBL);

        void Delete(CompanyTBL companyTBL);

        CompanyTBL Get(Guid id);

        List<CompanyTBL> GetList();

        bool Update(CompanyTBL companyTBL);
    }
}