namespace Company.Models.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<DeptTBL> DeptTBLs { get; set; }
        public virtual DbSet<EmplTBL> EmplTBLs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
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
