using System.Collections.Generic;
using AutoMapper;
using WebApi.BookOperations.GetBooks;
using WebApi.BookOperations.GetBooksById;
using WebApi.BookOperations.UpdateBook;
using static WebApi.BookOperations.CreateBook.CreateBookCommand;
namespace WebApi.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel,Book>(); // <source,target>  createbookmodel'den book modele dönüşüm yapabilsin. 
            CreateMap<Book,GetBookByIdModel>().ForMember(dest => dest.Genre,opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));
            CreateMap<Book,BooksViewModel>().ForMember(dest => dest.Genre,opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));
            CreateMap<UpdateBookModel,Book>();
        }
    }
}