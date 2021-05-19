using Microsoft.EntityFrameworkCore;
using RestWithAspNetUdemy.Model;

namespace RestWithAspNetUdemy.Infra.Context
{
    public class SQLContext: DbContext
    {
        public SQLContext()
        {

        }

        public SQLContext(DbContextOptions<SQLContext> opts): base(opts) { } 
        
        public DbSet<Person> Persons { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}
