using System;
using System.Linq;
using AutoMapper;
using WebApi.DBoperations;
using WebApi.Entities;

namespace WebApi.Application.AuthorOperations.UpdateAuthor
{
    public  class UpdateAuthorCommand
    {
        public int AuthorId;
        public UpdateAuthorViewModel model;
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public UpdateAuthorCommand(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var author=_context.Authors.SingleOrDefault(x=> x.Id == AuthorId);
            if(author is null)
                throw new InvalidOperationException("Böyle bir yazar mevcut değildir !");
            author.Name= string.IsNullOrEmpty(model.Name) ? author.Name : model.Name;
            author.Surname=string.IsNullOrEmpty(model.Surname) ? author.Surname : model.Surname;
            author.DateOfBirth= model.DateOfBirth == default ? author.DateOfBirth : model.DateOfBirth;

            author= _mapper.Map<Author>(model);
            
            _context.SaveChanges();
        }
    }

    public class UpdateAuthorViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }


    }
}