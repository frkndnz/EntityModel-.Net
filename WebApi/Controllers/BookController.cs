using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using WebApi.BookOperations.CreateBook;
using WebApi.BookOperations.DeleteBook;
using WebApi.BookOperations.GetBooks;
using WebApi.BookOperations.GetBooksById;
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
        private readonly IMapper _mapper;
        public BookController(BookStoreDbContext context,IMapper mapper)
        {
            _context=context;
            _mapper =mapper;
        }
        


        // HTTP Verblerimle işlemleri yapabilirim artık (CRUD)
        //ENDPOINTLER

        [HttpGet] // http verb
        public IActionResult GetBooks()
        { 
            GetBooksQuery query= new GetBooksQuery(_context,_mapper);
            var result =query.Handle();
            return Ok(result); 
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id) // 
        { 
            GetBookByIdQuery command=new GetBookByIdQuery(_context,_mapper);
            command.BookId=id;
            GetBookByIdModel result;
            try
            {
                GetBookByIdValidator validator=new GetBookByIdValidator();
                validator.ValidateAndThrow(command);
                result= command.Handle(); // handle 'a ıd verme ilgili class 'a field oluştur ve atama yap sonra çalıştır !!!
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(result);
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
            CreateBookCommand command= new CreateBookCommand(_context,_mapper);
            try
            {
                command.Model=newBook;
                CreateBookCommandValidator validator=new CreateBookCommandValidator();
                validator.ValidateAndThrow(command);
                command.Handle();
                // ValidationResult result=validator.Validate(command);
                // if(!result.IsValid)
                // {
                //     foreach (var item in result.Errors)
                //     {
                //         Console.WriteLine("Özellik : "+ item.PropertyName + " Error message :"+ item.ErrorMessage);
                //     }
                // }
                // else     
                // {
                //     command.Handle();
                // }
                
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
            UpdateBookCommand command= new UpdateBookCommand(_context,_mapper);
            command.BookId=id;
            try
            {
                command.Model=updatedBook;
                UpdateBookCommandValidator validator=new UpdateBookCommandValidator();
                validator.ValidateAndThrow(command);
                command.Handle();
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
            command.BookId=id;
            try
            {
                DeleteBookCommandValidator validator=new DeleteBookCommandValidator();
                validator.ValidateAndThrow(command);
                command.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }


    }
}