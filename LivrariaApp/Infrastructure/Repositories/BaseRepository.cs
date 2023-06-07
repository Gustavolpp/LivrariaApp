using LivrariaApp.Domain.Interfaces.Repositories;
using LivrariaApp.Domain.Models.Seed;
using LivrariaApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LivrariaApp.Infrastructure.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : Entity
    {
        private readonly MySqlDbContext _context;
        protected DbSet<T> _dataSet;

        public BaseRepository(MySqlDbContext context)
        {
            _context = context;
            _dataSet = context.Set<T>();
        }

        public virtual async Task<T> SelectAsync(long id)
        {
            try
            {
                return await _dataSet.SingleOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            try
            {
                return await _dataSet.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<T> InsertAsync(T entity)
        {
            try
            {
                _dataSet.Add(entity);

                await _context.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<T> UpdateAsync(T entity)
        {
            try
            {
                var result = await _dataSet.SingleOrDefaultAsync(x => x.Id == entity.Id);
                if (result is null)
                    return null;

                _context.Entry(result).CurrentValues.SetValues(entity);
                await _context.SaveChangesAsync();

                return entity;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> DeleteAsync(long id)
        {
            try
            {
                var result = await _dataSet.SingleOrDefaultAsync(x => x.Id == id);
                if (result is null)
                    return false;

                _dataSet.Remove(result);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> CountAsync()
        {
            try
            {
                return await _dataSet.CountAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
