using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.BookOperations.GetBooks;
using WebApi.DBoperations;

namespace WebApi.Application.GenreOperations.Queries.GetGenres
{
    public class GetGenreQuery
    {
        private readonly BookStoreDbContext _dbcontext;
        private readonly IMapper _mapper;
        public GetGenreQuery(BookStoreDbContext dbcontext, IMapper mapper)
        {
            _dbcontext = dbcontext;
            _mapper = mapper;
        }

        public List<GenresViewModel> Handle()
        {
            var genreList=_dbcontext.Genres.Where(genre => genre.IsActive).OrderBy(genre=>genre.Id).ToList();
            List<GenresViewModel> modelList= _mapper.Map<List<GenresViewModel>>(genreList);
            return modelList;

        }
    }

    public class GenresViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}