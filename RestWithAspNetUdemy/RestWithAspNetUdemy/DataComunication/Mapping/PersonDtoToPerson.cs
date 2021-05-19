using AutoMapper;
using RestWithAspNetUdemy.Model;

namespace RestWithAspNetUdemy.DataComunication.Mapping
{
    public class PersonDtoToPerson: Profile
    {
        public PersonDtoToPerson()
        {
            CreateMap<PersonDto, Person>();
        }
    }
}
