using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookRegistrationSystem.Models
{
    public class Author:Base
    {
        [Required]
        [DisplayName("Yazıçı adı")]
        public string  Name { get; set; }
   
    }
}
