using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.DBOperations
{
        public class BookStoreDbContext : DbContext 
    {
        private Func<DbContextOptions<BookStoreDbContext>> getRequiredService;

        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : base(options)
        {  }

        public BookStoreDbContext(Func<DbContextOptions<BookStoreDbContext>> getRequiredService)
        {
            this.getRequiredService = getRequiredService;
        }

        public DbSet<Book> Books {get; set;} 
        public DbSet<Genre> Genres {get; set;}
    }

    
}