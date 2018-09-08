namespace Company.Models.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DeptTBL")]
    public partial class DeptTBL
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DeptTBL()
        {
            EmplTBLs = new HashSet<EmplTBL>();
        }

        public Guid compId { get; set; }

        [Required]
        [StringLength(250)]
        public string deptDesc { get; set; }

        [Required]
        [StringLength(25)]
        public string deptName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EmplTBL> EmplTBLs { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid id { get; set; }
    }
}