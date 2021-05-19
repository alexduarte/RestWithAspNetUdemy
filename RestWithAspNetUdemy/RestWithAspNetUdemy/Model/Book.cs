using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithAspNetUdemy.Model
{
    [Table("Book")]
    public class Book
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
    }
}
