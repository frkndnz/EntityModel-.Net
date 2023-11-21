using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.GenreOperations.Commands.CreateGenre;
using WebApi.Application.GenreOperations.Commands.DeleteGenre;
using WebApi.Application.GenreOperations.Commands.UpdateGenre;
using WebApi.Application.GenreOperations.Queries.GetGenres;
using WebApi.Application.GenreOperations.Queries.GetGenresDetail;
using WebApi.BookOperations.CreateBook;
using WebApi.DBoperations;


namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class GenreController : ControllerBase
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public GenreController(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]

        public ActionResult GetGenres()
        {
            GetGenreQuery query=new GetGenreQuery(_context,_mapper);
            var obj =query.Handle();
            return Ok(obj);
        } 

        [HttpGet("{id}")]

        public ActionResult GetGenreDetail(int id)
        {
            GetGenreDetailQuery query=new GetGenreDetailQuery(_context,_mapper);
            query.genreId=id;
            
            GetGenreDetailQueryValidator validator=new GetGenreDetailQueryValidator();
            validator.ValidateAndThrow(query);

            var obj =query.Handle();
            return Ok(obj);
        } 

        [HttpPost]

        public ActionResult AddGenre([FromBody]CreateGenreViewModel model)
        {
            CreateGenreCommand command = new CreateGenreCommand(_context,_mapper);
            command.genreModel=model;

            CreateGenreCommandValidator validator=new CreateGenreCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }

        [HttpPut("{id}")]

        public ActionResult UpdateGenre([FromBody] UpdateGenreModel model, int id)
        {
            UpdateGenreCommand command=new UpdateGenreCommand(_context,_mapper);
            command.genreId=id;
            command.model=model;

            UpdateGenreCommandValidator validator= new UpdateGenreCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();

            return Ok();
        }

        [HttpDelete("{id}")]

        public ActionResult DeleteGenre(int id)
        {
            DeleteGenreCommand command = new DeleteGenreCommand(_context);
            command.genreId=id;
            
            DeleteGenreCommandValidator validator= new DeleteGenreCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }
    }
}