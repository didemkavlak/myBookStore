
using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.DBOperations
{
    public class DataGenerator 
    {
        public static void Initialize(IServiceProvider serviceProvider) // In-memory
        {
            using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                if(context.Books.Any())
                {
                    return;
                }

                context.Genres.AddRange(
                    new Genre{

                        Name = "Personel Growth",

                    },

                    new Genre{
                        Name = "Science Fiction"
                    },

                    new Genre{
                        Name = "Romance"
                    }
                );

                context.Books.AddRange(
                    new Book
                    {
                        Title = "Lean Startup",
                        GenreId = 1, //Personal Growth
                        PageCount = 200,
                        PublishDate = new DateTime(2001,06,02),
                    },
                    new Book
                    {
                        Title = "Herland",
                        GenreId = 2, //Science Fiction
                        PageCount = 250,
                        PublishDate = new DateTime(1999,12,25),
                    },
                    new Book
                    {
                        Title = "Dune",
                        GenreId = 2, //Science Fiction
                        PageCount = 350,
                        PublishDate = new DateTime(1967,02,05),
                    }
                );

                context.SaveChanges();
            }
        }
    }
}