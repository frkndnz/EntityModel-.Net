using System;
using System.Linq;
using AutoMapper;
using WebApi.DBoperations;

namespace WebApi.Application.AuthorOperations.GetAuthors
{
    public class GetAuthorsDetailQuery
    {
        public int AuthorId;
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetAuthorsDetailQuery(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public GetAuthorsQueryDetailViewModel Handle()
        {
            var author=_context.Authors.SingleOrDefault(x=> x.Id == AuthorId);
            if(author is null)
                throw new InvalidOperationException("Böyle bir yazar bulunamadi !");
            
            return _mapper.Map<GetAuthorsQueryDetailViewModel>(author);
        }
        
    }

    public class GetAuthorsQueryDetailViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string DateOfBirth { get; set; }


    }
}