using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookRegistrationSystem.Models
{
    public class Book:Base
    {
        [Required]
        [DisplayName("Əsərin adı")]
        public string Title { get; set; }
        [Required]
        [DisplayName("Növü")]
        public int CategoryId { get; set; }
        public BookCategory Category { get; set; }
        [Required]
        [DisplayName("Nəşri")]
        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }
        [Required]
        [DisplayName("Yazıçı")]
        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
