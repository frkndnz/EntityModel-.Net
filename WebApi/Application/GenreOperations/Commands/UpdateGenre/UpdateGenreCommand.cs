using System;
using System.Linq;
using AutoMapper;
using WebApi.DBoperations;
using WebApi.Entities;

namespace WebApi.Application.GenreOperations.Commands.UpdateGenre
{
    public class UpdateGenreCommand
    {
        public int genreId ;
        public UpdateGenreModel model;
        private readonly BookStoreDbContext _dbcontext;
        private readonly IMapper _mapper;
        public UpdateGenreCommand(BookStoreDbContext dbcontext, IMapper mapper)
        {
            _dbcontext = dbcontext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var genre=_dbcontext.Genres.SingleOrDefault(x => x.Id == genreId);  // http id requestine göre kontrol et
            if(genre is null)
                throw new InvalidOperationException("Bu Id ye sahip tür bulunamadi !") ;

            if(_dbcontext.Genres.Any(x => x.Name.ToLower()== model.Name.ToLower() && x.Id != genreId)) //  verdiğimiz modelin cevaplarını kontrol ediyoruz.
                throw new InvalidOperationException("Ayni isimli kitap türü zaten mevcut !!!");
            
            genre.Name=string.IsNullOrEmpty(model.Name.Trim())  ? genre.Name : model.Name;
            genre.IsActive=model.IsActive;
            _dbcontext.SaveChanges();
        }
    }

    public class UpdateGenreModel
    {
        public string Name {get;set;}
        public bool IsActive { get; set; }
    }
}