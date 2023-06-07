using LivrariaApp.Domain.Models;

namespace LivrariaApp.Domain.Interfaces.Services
{
    public interface IBookService
    {
        Task<Book> GetById(long id);
        Task<IEnumerable<Book>> GetAll();
        Task<Book> Create(Book model);
        Task<Book> Update(Book model);
        Task<bool> Delete(long id);
    }
}
