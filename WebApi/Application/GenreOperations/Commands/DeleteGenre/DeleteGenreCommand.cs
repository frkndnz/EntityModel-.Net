using System;
using System.Linq;
using WebApi.DBoperations;

namespace WebApi.Application.GenreOperations.Commands.DeleteGenre
{
    public class DeleteGenreCommand
    {
        public int genreId { get; set; }
        private readonly BookStoreDbContext _dbcontext;
        public DeleteGenreCommand(BookStoreDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public void Handle()
        {
            var genre=_dbcontext.Genres.SingleOrDefault(x => x.Id == genreId);
            if(genre is null)
                throw new InvalidOperationException("Bu Id ye sahip tür bulunamadi !!!") ;
            
            _dbcontext.Genres.Remove(genre);
            _dbcontext.SaveChanges();
        }
    }
}