using Company.Models.Models;

using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Models.EntityConfiguration
{
    public class CompanyTBLConfiguration : EntityTypeConfiguration<CompanyTBL>
    {
        public CompanyTBLConfiguration()
        {
            ToTable("CompanyTBL");
            HasKey(x => x.CompanyId);
        }
    }
}