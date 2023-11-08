using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Common;
using WebApi.DBoperations;

namespace WebApi.BookOperations.GetBooks
{
    public class GetBooksQuery
    {
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetBooksQuery(BookStoreDbContext bookStoreDbContext, IMapper mapper) // constructor oluşturma
        {
            _dbContext = bookStoreDbContext;
            _mapper = mapper;
        }

        public List<BooksViewModel> Handle()
        {
            var booklist=_dbContext.Books.OrderBy(x => x.Id).ToList();
            List<BooksViewModel> vm= _mapper.Map<List<BooksViewModel>>(booklist);

            
            // List<BooksViewModel> vm=new List<BooksViewModel>();
            // foreach (var book in booklist)
            // {
            //     vm.Add(new BooksViewModel()
            //     {
            //         Title=book.Title,
            //         PageCount=book.PageCount,
            //         PublishDate=book.PublishDate.Date.ToString("dd/MM/yyy"),
            //         Genre=((GenreEnum)book.GenreId).ToString()
            //     });
            // }
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
