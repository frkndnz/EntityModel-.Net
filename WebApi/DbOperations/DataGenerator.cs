using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApi.Entities;

namespace WebApi.DBoperations
{
    public class DataGenerator
    {
        
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using(var context=new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                if(context.Books.Any())
                {
                    return;
                }

                context.Books.AddRange(
                    new Book
                    {
                       // Id=1,
                        Title="Lean Startup",
                        GenreId=1, 
                        PageCount=200,
                        AuthorId=1,
                        PublishDate=new DateTime(2001,06,12)
                    },
                    new Book
                    {
                        //Id=2,
                        Title="Herland",
                        GenreId=2, 
                        PageCount=250,
                        AuthorId=2,
                        PublishDate=new DateTime(2010,05,23)
                    },
                    new Book
                    {
                       // Id=3,
                        Title="Dune",
                        GenreId=2, 
                        PageCount=540,
                        AuthorId=3,
                        PublishDate=new DateTime(2001,12,21)
                    }
                );

                context.Genres.AddRange(
                    new Genre
                    {
                        Name="Personal Growth",
                    },
                    new Genre
                    {
                        Name="Science Fiction",
                    },
                    new Genre
                    {
                        Name="Romance",
                    }
                );

                context.Authors.AddRange(
                
                    new Author{
                        Name="Furkan",
                        Surname="Deniz",
                        DateOfBirth=new DateTime(1996,07,04)
                    },
                    new Author{
                        Name="Melahat",
                        Surname="Akin",
                        DateOfBirth=new DateTime(1996,03,11)
                    },
                    new Author{
                        Name="testAuthorName",
                        Surname="testAuthorSurname",
                        DateOfBirth=new DateTime(1977,05,22)
                    }
                );
            

                context.SaveChanges();
            }
        }
    }
}