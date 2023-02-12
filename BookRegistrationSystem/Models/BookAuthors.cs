using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookRegistrationSystem.Models
{
    public class BookAuthors:Base
    {
        [Required]
        [DisplayName("Kitab id")]
        public string BookId { get; set; }
        [Required]
        [DisplayName("Yazıçı id")]
        public string AuthorId { get; set; }
       
    }
}
