using System;
using System.Linq;
using AutoMapper;
using WebApi.DBoperations;

namespace WebApi.Application.GenreOperations.Queries.GetGenresDetail
{
    public class GetGenreDetailQuery
    {
        public int genreId{get;set;}
        private readonly BookStoreDbContext _dbcontext;
        private readonly IMapper _mapper;
        public GetGenreDetailQuery(BookStoreDbContext dbcontext, IMapper mapper)
        {
            _dbcontext = dbcontext;
            _mapper = mapper;
        }

        public GenreDetailViewModel Handle()
        {
            var genre=_dbcontext.Genres.SingleOrDefault(x => x.Id == genreId && x.IsActive);
            if(genre is null)
                throw new InvalidOperationException("Kitap türü bulunamadi !!!"); 
            GenreDetailViewModel model=_mapper.Map<GenreDetailViewModel>(genre);
            return model;
        }
    }
    
    public class GenreDetailViewModel
    {
        public string Name { get; set; }
    }
}