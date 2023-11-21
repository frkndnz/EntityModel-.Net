
using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.DBoperations
{
    public class BookStoreDbContext :DbContext
    {
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : base(options)
        {
        }
        public DbSet<Book> Books{get;set;} // book database yaratma
        public DbSet<Genre> Genres{get;set;} // genre database yaratma
        public DbSet<Author> Authors{get; set;}
    }
}