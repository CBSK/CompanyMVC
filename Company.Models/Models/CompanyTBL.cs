using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace Company.Models.Models
{
    public class CompanyTBL
    {
        [Required(ErrorMessage = "Please Enter the Address")]
        [StringLength(250)]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please Enter Code for City")]
        [StringLength(25)]
        public string CityCode { get; set; }

        [Required(ErrorMessage = "Please Enter Company Code")]
        [StringLength(20)]
        public string CompanyId { get; set; }

        [Required(ErrorMessage = "Please Enter Country Code")]
        [StringLength(25)]
        public string CountryCode { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid id { get; set; }

        [Required(ErrorMessage = "Enter Company Name")]
        [StringLength(60)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Enter Code for the State")]
        [StringLength(25)]
        public string StateCode { get; set; }
    }
}