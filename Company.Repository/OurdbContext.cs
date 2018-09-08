using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.ModelConfiguration.Conventions;

using Company.Models.Models;

namespace Company.Repository
{
    public class OurdbContext : DbContext
    {
        public OurdbContext()
            : base("name=Company")
        {
        }

        public virtual DbSet<CompanyTBL> Company { get; set; }
        public virtual DbSet<DeptTBL> Dept { get; set; }
        public virtual DbSet<EmplTBL> Empl { get; set; }

        public void Add(object obj)
        {
            this.Entry(obj).State = EntityState.Added;
        }

        public void Delete(object obj)
        {
            this.Entry(obj).State = EntityState.Deleted;
        }

        public void Update(object obj)
        {
            this.Entry(obj).State = EntityState.Modified;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)

        {
            Database.SetInitializer<DbContext>(null);
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CompanyTBL>()
                    .Property(e => e.CompanyId)
                    .IsFixedLength();

            modelBuilder.Entity<CompanyTBL>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<CompanyTBL>()
                .Property(e => e.CountryCode)
                .IsFixedLength();

            modelBuilder.Entity<CompanyTBL>()
                .Property(e => e.StateCode)
                .IsFixedLength();

            modelBuilder.Entity<CompanyTBL>()
                .Property(e => e.CityCode)
                .IsFixedLength();

            modelBuilder.Entity<CompanyTBL>()
                .Property(e => e.Address)
                .IsFixedLength();

            modelBuilder.Entity<DeptTBL>()
               .Property(e => e.deptName)
               .IsFixedLength();

            modelBuilder.Entity<DeptTBL>()
                .Property(e => e.deptDesc)
                .IsFixedLength();

            modelBuilder.Entity<DeptTBL>()
                .HasMany(e => e.EmplTBLs)
                .WithRequired(e => e.DeptTBL)
                .HasForeignKey(e => e.deptId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EmplTBL>()
                .Property(e => e.emplCode)
                .IsFixedLength();

            modelBuilder.Entity<EmplTBL>()
                .Property(e => e.emplName)
                .IsFixedLength();

            modelBuilder.Entity<EmplTBL>()
                .Property(e => e.designation)
                .IsFixedLength();
        }
    }
}