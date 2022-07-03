using AutoMapper;
using WebApi.Applications.BookOperations.Commands.CreateBook;
using WebApi.Applications.BookOperations.Commands.GetBooks;
using WebApi.Applications.BookOperations.Queries.GetBookDetail;
using WebApi.Entities;

namespace WebApi.Common
{
    public class MappingProfilem : Profile 
    {
        public MappingProfilem()
        {
            CreateMap<CreateBookModel, Book>();
            CreateMap<Book, GetBookDetailViewModel>().ForMember(dest=> dest.Genre, opt => opt.MapFrom(src=> ((GenreEnum)src.GenreId).ToString()));
            CreateMap<Book , BooksViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));
        }

    }
}