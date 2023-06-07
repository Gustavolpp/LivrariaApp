using LivrariaApp.Domain.Interfaces.Repositories;
using LivrariaApp.Domain.Models;
using LivrariaApp.Infrastructure.Data;

namespace LivrariaApp.Infrastructure.Repositories
{
    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
        public BookRepository(MySqlDbContext context) : base(context)
        {
        }
    }
}
