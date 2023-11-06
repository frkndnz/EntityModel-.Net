using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApi.Common;
using WebApi.DBoperations;

namespace WebApi.BookOperations.GetBooks
{
    public class GetBooksQuery
    {
        private readonly BookStoreDbContext _dbContext;
        public GetBooksQuery(BookStoreDbContext bookStoreDbContext) // constructor oluşturma
        {
            _dbContext=bookStoreDbContext;
        }

        public List<BooksViewModel> Handle()
        {
            var booklist=_dbContext.Books.OrderBy(x => x.Id).ToList();
            List<BooksViewModel> vm=new List<BooksViewModel>();
            foreach (var book in booklist)
            {
                vm.Add(new BooksViewModel()
                {
                    Title=book.Title,
                    PageCount=book.PageCount,
                    PublishDate=book.PublishDate.Date.ToString("dd/MM/yyy"),
                    Genre=((GenreEnum)book.GenreId).ToString()
                });
            }
            return vm;
        }
    }

    public class BooksViewModel // UI için
    {
        public string Title { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
        public string Genre { get; set; }
    }
}
