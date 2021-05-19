using RestWithAspNetUdemy.DataComunication.Base;

namespace RestWithAspNetUdemy.DataComunication
{
    public class BookDto: BaseDto
    {
        public string Name { get; set; }
        public string Author { get; set; }
    }
}
