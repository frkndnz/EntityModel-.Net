using System;
using System.Linq;
using AutoMapper;
using WebApi.DBoperations;
using WebApi.Entities;

namespace WebApi.Application.GenreOperations.Commands.CreateGenre
{
    public class CreateGenreCommand
    {
        public CreateGenreViewModel genreModel;
        private readonly BookStoreDbContext _dbcontext;
        private readonly IMapper _mapper;
        public CreateGenreCommand(BookStoreDbContext dbcontext, IMapper mapper)
        {
            _dbcontext = dbcontext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var genre=_dbcontext.Genres.SingleOrDefault(x => x.Name == genreModel.Name);
            if(genre is not null)
                throw new InvalidOperationException("Bu tür zaten mevcut !!!");
            genre=_mapper.Map<Genre>(genreModel);
            _dbcontext.Add(genre);
            _dbcontext.SaveChanges();
        }
    }

    public class CreateGenreViewModel
    {
        public string Name { get; set; }
    }
}