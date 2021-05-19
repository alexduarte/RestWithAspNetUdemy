using AutoMapper;
using RestWithAspNetUdemy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithAspNetUdemy.DataComunication.Mapping
{
    public class BookToBookDto: Profile
    {
        public BookToBookDto()
        {
            CreateMap<Book, BookDto>();
        }
    }
}
