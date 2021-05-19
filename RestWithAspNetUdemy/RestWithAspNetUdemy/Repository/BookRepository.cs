using Microsoft.Extensions.Logging;
using RestWithAspNetUdemy.Infra.Context;
using RestWithAspNetUdemy.Model;
using RestWithAspNetUdemy.Repository.Base;
using RestWithAspNetUdemy.Repository.Interfaces;

namespace RestWithAspNetUdemy.Repository
{
    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
        public BookRepository(SQLContext context, ILogger<Book> logger) : base(context, logger)
        {
        }
    }
}
