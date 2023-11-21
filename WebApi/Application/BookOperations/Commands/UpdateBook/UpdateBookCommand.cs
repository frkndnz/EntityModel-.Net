using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Common;
using WebApi.DBoperations;

namespace WebApi.BookOperations.UpdateBook
{
    public class UpdateBookCommand
    {
        public UpdateBookModel Model{get;set;}
        public int BookId {get;set;}
        private readonly BookStoreDbContext _dbcontext;
        private readonly IMapper _mapper;
        public UpdateBookCommand(BookStoreDbContext dbContext, IMapper mapper) // constructor
        {
            _dbcontext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var book=_dbcontext.Books.SingleOrDefault(x=> x.Id==BookId);

            if(book is null)
                throw new InvalidOperationException("Böyle bir kitap bulunamadi !!!");
            
            book.GenreId=Model.GenreId !=default ? Model.GenreId : book.GenreId ;
            book.PageCount=Model.PageCount !=default ? Model.PageCount : book.PageCount;
            book.PublishDate=Model.PublishDate !=default ? Model.PublishDate : book.PublishDate;
            book.Title=Model.Title !=default ? Model.Title : book.Title ;

            _dbcontext.SaveChanges();
           
        }
    }

    public class UpdateBookModel
    {
        public string Title { get; set; }
        public int PageCount { get; set; }
        public DateTime PublishDate { get; set; }
        public int GenreId { get; set; }
    }
}
