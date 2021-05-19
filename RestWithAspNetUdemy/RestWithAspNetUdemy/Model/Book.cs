using RestWithAspNetUdemy.Model.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithAspNetUdemy.Model
{
    [Table("Book")]
    public class Book: BaseEntity
    {        
        public string Name { get; set; }
        public string Author { get; set; }
    }
}
