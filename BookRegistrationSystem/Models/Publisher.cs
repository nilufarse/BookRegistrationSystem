using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookRegistrationSystem.Models
{
    public class Publisher:Base
    {
        [Required]
        [DisplayName("Nəşr adı")]
        public string Name { get; set; }
       
    }
}
