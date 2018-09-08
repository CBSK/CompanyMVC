using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace News.Models.Models
{
    public class SecurityFeeds
    {
        [Key]
        public long SecurityFeedID { get; set; }
        [Required(ErrorMessage = "Enter News Title")]
        public string ContentTitle { get; set; }
        [Required(ErrorMessage = "Enter News Description")]
        public string ContentDescription { get; set; }
        [Required]
        public string ImagePath { get; set; }
        public bool? IsTop { get; set; }
        public bool Status { get; set; }
        public long CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public long? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public DateTime? ExpiryOn { get; set; }

    }
}
