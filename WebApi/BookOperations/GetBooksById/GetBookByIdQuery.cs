using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WebApi.Common;
using WebApi.DBoperations;

namespace WebApi.BookOperations.GetBooksById
{
    public class GetBookByIdQuery
    {
        private readonly BookStoreDbContext _dbcontext;
        public int BookId {get;set;}
        private readonly IMapper _mapper;
        public GetBookByIdQuery(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbcontext = dbContext;
            _mapper = mapper;
        }

        public GetBookByIdModel Handle()
        {
            var book=_dbcontext.Books.Where(x => x.Id==BookId).SingleOrDefault();
            if(book is null)
            {
                throw new InvalidOperationException("bu id'ye sahip kitap bulunamadi");
            }
            
            GetBookByIdModel model=_mapper.Map<GetBookByIdModel>(book); 
            // GetBookByIdModel model = new GetBookByIdModel
            // {
            //     Genre = ((GenreEnum)book.GenreId).ToString(),
            //     PageCount = book.PageCount,
            //     Title = book.Title,
            //     PublishDate = book.PublishDate.Date.ToString("dd/MM/yyy")
            // };

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
