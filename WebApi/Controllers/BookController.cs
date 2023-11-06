using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApi.BookOperations.CreateBook;
using WebApi.BookOperations.DeleteBook;
using WebApi.BookOperations.GetBooks;
using WebApi.BookOperations.UpdateBook;
using WebApi.DBoperations;
using static WebApi.BookOperations.CreateBook.CreateBookCommand;

namespace WebApi.AddControllers
{
    [ApiController]
    [Route("[controller]s")]
    public class BookController : ControllerBase
    {
        private readonly BookStoreDbContext _context;
        public BookController(BookStoreDbContext context)
        {
            _context=context;
        }
        


        // HTTP Verblerimle işlemleri yapabilirim artık (CRUD)
        //ENDPOINTLER

        [HttpGet] // http verb
        public IActionResult GetBooks()
        { 
            GetBooksQuery query= new GetBooksQuery(_context);
            var result =query.Handle();
            return Ok(result); 
        }
        [HttpGet("{id}")]
        public Book GetById(int id)
        { 
            var book=_context.Books.Where(x => x.Id==id).SingleOrDefault();
            return book;
        }

        // [HttpGet]
        // public Book Get([FromQuery] string id)
        // { 
        //     var book=BookList.Where(x => x.Id==Convert.ToInt32(id)).SingleOrDefault();
        //     return book;
        // }

        //POST - Veri ekleme işlemi
        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel newBook)
        {
            CreateBookCommand command= new CreateBookCommand(_context);
            try
            {
                command.Model=newBook;
                command.Handle();
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                
            }
            return Ok();
        }

        //PUT

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id,[FromBody] UpdateBookModel updatedBook)
        {
            UpdateBookCommand command= new UpdateBookCommand(_context);
            try
            {
                command.Model=updatedBook;
                command.Handle(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }
        // DELETE

        [HttpDelete("{id}")]

        public IActionResult DeleteBook(int id)
        {
            DeleteBookQuery command=new DeleteBookQuery(_context);
            try
            {
                command.Handle(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }


    }
}