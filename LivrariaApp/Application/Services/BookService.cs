using LivrariaApp.Domain.Interfaces.Repositories;
using LivrariaApp.Domain.Interfaces.Services;
using LivrariaApp.Domain.Models;

namespace LivrariaApp.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _repository;
        public BookService(IBookRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Book>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<Book> GetById(long id)
        {
            var book = await _repository.SelectAsync(id);
            return book;
        }

        public async Task<Book> Create(Book model)
        {
            var book = await _repository.InsertAsync(model);
            return book;
        }

        public async Task<Book> Update(Book model)
        {
            var book = await _repository.UpdateAsync(model);
            return book;
        }
        public async Task<bool> Delete(long id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
