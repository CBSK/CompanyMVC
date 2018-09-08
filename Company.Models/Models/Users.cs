using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace News.Models.Models
{
    public class Users
    {
        
        [Key]
        public long UserID { get; set; }
       
        public string UserName { get; set; }
        [Required(ErrorMessage = "Enter User Password")]
        [DataType(DataType.Password)]
        public string UserPassword { get; set; }
        [Required(ErrorMessage = "Enter User Email")]
        [EmailAddress]
        public string UserEmail { get; set; }
        public bool Status { get; set; }

    }
}
