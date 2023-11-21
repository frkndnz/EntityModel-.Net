using System.Collections.Generic;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.AuthorOperations.CreateAuthor;
using WebApi.Application.AuthorOperations.DeleteAuthor;
using WebApi.Application.AuthorOperations.GetAuthors;
using WebApi.Application.AuthorOperations.UpdateAuthor;
using WebApi.DBoperations;

namespace WebApi.Controllers
{
        [ApiController]
        [Route("[controller]s")]
    public class AuthorController:ControllerBase
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public AuthorController(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]

        public IActionResult GetAuthors()
        {
            GetAuthorsQuery query = new GetAuthorsQuery(_context,_mapper);
            var result=query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]

        public ActionResult GetAuthors(int id)
        {
            GetAuthorsDetailQuery query = new GetAuthorsDetailQuery(_context,_mapper);
            query.AuthorId=id;
            GetAuthorsDetailQueryValidator validator=new GetAuthorsDetailQueryValidator();
            validator.ValidateAndThrow(query);

            return Ok(query.Handle());
        }

        [HttpPost]

        public ActionResult CreateAuthor([FromBody]CreateAuthorViewModel model)
        {
            CreateAuthorCommand command = new CreateAuthorCommand(_context,_mapper);
            command.model=model;

            CreateAuthorCommandValidator validator= new CreateAuthorCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            
            return Ok();
        }

        [HttpPut("{id}")]

        public ActionResult UpdateAuthor([FromBody]UpdateAuthorViewModel model,int id)
        {
            UpdateAuthorCommand command = new UpdateAuthorCommand(_context,_mapper);
            command.model=model;
            command.AuthorId=id;
            UpdateAuthorCommandValidator validator= new UpdateAuthorCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            
            return Ok();
        }


        [HttpDelete("{id}")]

        public ActionResult DeleteAuthor(int id)
        {
            DeleteAuthorCommand command = new DeleteAuthorCommand(_context);
            command.AuthorId=id;

            command.Handle();

            return Ok();
        }
    }
}