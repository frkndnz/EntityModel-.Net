using System;
using System.IO.Compression;
using System.Linq;
using AutoMapper;
using WebApi.DBoperations;
using WebApi.Entities;

namespace WebApi.Application.AuthorOperations.CreateAuthor
{
    public class CreateAuthorCommand
    {
        public CreateAuthorViewModel model{get;set;}
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public CreateAuthorCommand(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var author=_context.Authors.SingleOrDefault(x=> x.Name == model.Name);
            if(author is not null)
                throw new InvalidOperationException("Bu yazar zaten mevcut !");
            author=_mapper.Map<Author>(model); // gelen yazar modelini maple
            _context.Authors.Add(author);
            _context.SaveChanges();
        }
    }

    public class CreateAuthorViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}