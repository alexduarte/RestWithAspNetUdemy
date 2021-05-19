using AutoMapper;
using RestWithAspNetUdemy.Model;

namespace RestWithAspNetUdemy.DataComunication.Mapping
{
    public class BookDtoToBook: Profile
    {
        public BookDtoToBook()
        {
            CreateMap<BookDto, Book>();
        }
    }
}
