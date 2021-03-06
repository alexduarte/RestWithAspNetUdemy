using RestWithAspNetUdemy.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithAspNetUdemy.Model
{
    [Table("Person")]
    public class Person: BaseEntity
    {               
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
    }
}
