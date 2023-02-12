using BookRegistrationSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookRegistrationSystem.Data
{
    public class BookDbContext : DbContext
    {
        public BookDbContext(DbContextOptions<BookDbContext> options) : base(options)
        {

        }
        public DbSet<Book> Books { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<AuthorContact> AuthorContacts { get; set; }

        public DbSet<BookAuthors> BookAuthorss { get; set; }

        public DbSet<BookCategory> BookCategorys { get; set; }

        public DbSet<Publisher> Publishers { get; set; }
    
    }
}
