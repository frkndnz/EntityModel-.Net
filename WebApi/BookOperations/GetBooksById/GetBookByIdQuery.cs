using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApi.Common;
using WebApi.DBoperations;

namespace WebApi.BookOperations.GetBooksById
{
    public class GetBookByIdQuery
    {
        private readonly BookStoreDbContext _dbcontext;
        public GetBookByIdQuery(BookStoreDbContext dbContext)
        {
            _dbcontext=dbContext;
        }

        public GetBookByIdModel Handle(int id)
        {
            var book=_dbcontext.Books.Where(x => x.Id==id).SingleOrDefault();
            if(book is null)
            {
                throw new InvalidOperationException("bu id'ye sahip kitap bulunamadi");
            }

            GetBookByIdModel model = new GetBookByIdModel
            {
                Genre = ((GenreEnum)book.GenreId).ToString(),
                PageCount = book.PageCount,
                Title = book.Title,
                PublishDate = book.PublishDate.Date.ToString("dd/MM/yyy")
            };

            return model;
        }


    }
    public class GetBookByIdModel
    {
        public string Title { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
        public string Genre { get; set; }
    }
}
