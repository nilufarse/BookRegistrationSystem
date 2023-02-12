using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookRegistrationSystem.Models
{
    public class AuthorContact:Base
    {
        [Required]
        [DisplayName("Telefon nömrəsi")]
        public string ContactNumber { get; set; }
        [Required]
        [DisplayName("Ünvanı")]
        public string Address { get; set; }
        [Required]
        [DisplayName("Yazıçı id")]
        public string AuthorId { get; set; }
     
    }
}
