using RestWithAspNetUdemy.DataComunication.Base;

namespace RestWithAspNetUdemy.DataComunication
{
    public class PersonDto: BaseDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
    }
}
