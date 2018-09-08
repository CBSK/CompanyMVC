using Company.Models.Models;
using Company.Repository.IRepository;
using Company.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Services.IMP_Services
{
    public class CompanyServiceConcrete : ICompanyService
    {
        private ICompany _compRespository;
        private IDept _deptRepo;

        public CompanyServiceConcrete(ICompany comp, IDept dept)
        {
            _compRespository = comp;
            _deptRepo = dept;
        }

        public void Add(CompanyTBL companyTBL)
        {
            _compRespository.Add(companyTBL);
        }

        public void DeleteCompany(CompanyTBL companyTBL)
        {
            _compRespository.Delete(companyTBL);
        }

        public CompanyTBL GetCompany(Guid guid)
        {
            return _compRespository.Get(guid);
        }

        public List<CompanyTBL> GetCompanylist()
        {
            return _compRespository.GetList();
        }

        public List<DeptTBL> GetDeptList(Guid guid)
        {
            return _deptRepo.GetList(guid);
        }

        public bool UpdateCompany(CompanyTBL companyTBL)
        {
            return _compRespository.Update(companyTBL);
        }
    }
}