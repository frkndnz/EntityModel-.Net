using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApi.Common;
using WebApi.DBoperations;

namespace WebApi.BookOperations.DeleteBook
{
    public class DeleteBookQuery
    {
        private readonly BookStoreDbContext _dbcontext;
        public DeleteBookQuery(BookStoreDbContext dbContext)
        {
            _dbcontext=dbContext;
        }

        public void Handle(int id)
        {
            var book= _dbcontext.Books.SingleOrDefault(x => x.Id==id);
            if(book is null)
                throw new InvalidOperationException("Bu Id ye sahip kitap bulunamadı !!!") ;

            _dbcontext.Books.Remove(book);
            _dbcontext.SaveChanges();
            
        }
    }
}