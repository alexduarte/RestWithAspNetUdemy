using AutoMapper;
using RestWithAspNetUdemy.Model;

namespace RestWithAspNetUdemy.DataComunication.Mapping
{
    public class PersonToPersonDto: Profile
    {
        public PersonToPersonDto()
        {
            CreateMap<Person, PersonDto>();
        }
    }
}
