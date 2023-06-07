using LivrariaApp.Domain.Models.Seed;

namespace LivrariaApp.Domain.Interfaces.Repositories
{
    public interface IRepository<T> where T : Entity
    {
        Task<T> SelectAsync(long id);
        Task<IEnumerable<T>> GetAll();
        Task<T> InsertAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<bool> DeleteAsync(long id);
        Task<int> CountAsync();
    }
}
