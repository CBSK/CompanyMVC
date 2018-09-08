namespace Company.Models.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EmplTBL")]
    public partial class EmplTBL
    {
        public Guid deptId { get; set; }

        public virtual DeptTBL DeptTBL { get; set; }

        [StringLength(100)]
        public string designation { get; set; }

        [Required]
        [StringLength(15)]
        public string emplCode { get; set; }

        [Required]
        [StringLength(200)]
        public string emplName { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid id { get; set; }
    }
}