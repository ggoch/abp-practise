using AutoMapper;
using Acme.BookStore.Books;
using Acme.BookStore.Authors;
using Acme.BookStore.Users;

namespace Acme.BookStore;

public class BookStoreApplicationAutoMapperProfile : Profile
{
    public BookStoreApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<Book, BookDto>();
        CreateMap<CreateUpdateBookDto, Book>();
        CreateMap<BookUser, BookUserDto>();
        CreateMap<CreateUpdateBookUserDto, BookUserDto>();
        CreateMap<Author, AuthorDto>();
    }
}
