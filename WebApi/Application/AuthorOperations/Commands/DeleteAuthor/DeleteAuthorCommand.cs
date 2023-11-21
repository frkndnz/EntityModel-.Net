using System;
using System.Linq;
using WebApi.DBoperations;

namespace WebApi.Application.AuthorOperations.DeleteAuthor
{
    public class DeleteAuthorCommand
    {
        public int AuthorId;
        private readonly BookStoreDbContext _context;
        public DeleteAuthorCommand(BookStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var author=_context.Authors.SingleOrDefault(x=> x.Id == AuthorId);
            if(author is null)
                throw new InvalidOperationException("Böyle bir yazar bulunmamaktadir !");
            var book=_context.Books.SingleOrDefault(x=> x.AuthorId == AuthorId);
            if(book is not null)
                throw new InvalidOperationException("bu yazarin kitabi mevcuttur silinemez!"+ " yazarin kitabi =" + book.Title);
            _context.Remove(author);
            _context.SaveChanges();
        }
    }
}