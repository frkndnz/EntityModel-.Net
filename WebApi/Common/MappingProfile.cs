using System.Collections.Generic;
using AutoMapper;
using WebApi.Application.AuthorOperations.CreateAuthor;
using WebApi.Application.AuthorOperations.GetAuthors;
using WebApi.Application.AuthorOperations.UpdateAuthor;
using WebApi.Application.GenreOperations.Commands.CreateGenre;
using WebApi.Application.GenreOperations.Commands.UpdateGenre;
using WebApi.Application.GenreOperations.Queries.GetGenres;
using WebApi.Application.GenreOperations.Queries.GetGenresDetail;
using WebApi.BookOperations.GetBooks;
using WebApi.BookOperations.GetBooksById;
using WebApi.BookOperations.UpdateBook;
using WebApi.Entities;
using static WebApi.BookOperations.CreateBook.CreateBookCommand;
namespace WebApi.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //BOOK MAP CONFIG
            CreateMap<CreateBookModel,Book>(); // <source,target>  createbookmodel'den book modele dönüşüm yapabilsin. 
           // CreateMap<Book,GetBookByIdModel>().ForMember(dest => dest.Genre,opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));
            CreateMap<Book,GetBookByIdModel>().ForMember(dest => dest.Genre,opt => opt.MapFrom(src => src.Genre.Name));
            CreateMap<Book,BooksViewModel>().ForMember(dest => dest.Genre,opt => opt.MapFrom(src => src.Genre.Name))
            .ForMember(dest=>dest.Author,opt=> opt.MapFrom(src => src.Author.Name+" "+src.Author.Surname));
            CreateMap<UpdateBookModel,Book>();
            // GENRE MAP CONFIG
            CreateMap<Genre,GenresViewModel>();
            CreateMap<Genre,GenreDetailViewModel>();
            CreateMap<CreateGenreViewModel,Genre>();
            CreateMap<UpdateGenreModel,Genre>();

            // AUTHOR MAP CONFIG
            CreateMap<Author,GetAuthorViewModel>(); // get authors
            CreateMap<Author,GetAuthorsQueryDetailViewModel>(); // get author detail
            CreateMap<CreateAuthorViewModel,Author>(); // create author 
            CreateMap<UpdateAuthorViewModel,Author>(); // update
        }
    }
}