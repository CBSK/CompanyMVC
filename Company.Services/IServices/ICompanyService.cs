using Company.Models;
using Company.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Services.IServices
{
    public interface ICompanyService
    {
        void Add(CompanyTBL companyTBL);

        void DeleteCompany(CompanyTBL companyTBL);

        CompanyTBL GetCompany(Guid guid);

        List<CompanyTBL> GetCompanylist();

        List<DeptTBL> GetDeptList(Guid guid);

        bool UpdateCompany(CompanyTBL companyTBL);
    }
}