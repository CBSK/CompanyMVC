using Company.Models.Models;
using Company.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Repository.IMP_Repository
{
    public class DeptConcrete : IDept
    {
        public List<DeptTBL> GetList(Guid guid)
        {
            return new OurdbContext().Dept.Where(k => k.compId == guid).ToList();
        }
    }
}