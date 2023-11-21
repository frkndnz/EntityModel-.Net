using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WebApi.DBoperations;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Application.AuthorOperations.GetAuthors
{
    public class GetAuthorsQuery
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetAuthorsQuery(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GetAuthorViewModel> Handle() //  bütün yazarları getireceğiz author dan modele maple
        {
            var authors=_context.Authors.OrderBy(x=> x.Id).ToList();
            List<GetAuthorViewModel> returnobj=_mapper.Map<List<GetAuthorViewModel>>(authors);

            return returnobj;
        }
        
    }
    public class GetAuthorViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string DateOfBirth { get; set; }
        
    }
}