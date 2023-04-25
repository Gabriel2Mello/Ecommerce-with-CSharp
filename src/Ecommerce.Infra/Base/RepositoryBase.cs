using Ecommerce.Domain.Base;
using Ecommerce.Domain.Interfaces;
using Ecommerce.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Ecommerce.Infra.Base
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : EntityBase
    {
        private readonly DbSet<TEntity> _dbSet;
        private readonly EcommerceContext _ecommerceContext;

        public RepositoryBase(EcommerceContext ecommerceContext)
        {
            _dbSet = ecommerceContext.Set<TEntity>();
            _ecommerceContext = ecommerceContext;
        }

        public async Task DeleteAsync(TEntity entity)
        {
            _dbSet.Remove(entity);
            await _ecommerceContext.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(Guid guid)
        {
            TEntity entity = await GetByIdAsync(guid);

            _dbSet.Remove(entity);
            await _ecommerceContext.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            TEntity entity = await GetByIdAsync(id);

            _dbSet.Remove(entity);
            await _ecommerceContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            var query = _dbSet.AsQueryable();

            if (filter != null)
                query = query.Where(filter)
                             .AsNoTracking();

            return await query.ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(Guid guid)
        {          
            return await _dbSet.FirstAsync(p => p.Guid.Equals(guid));
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _dbSet.Update(entity);
            await _ecommerceContext.SaveChangesAsync();
        }

        public async Task AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            await _ecommerceContext.SaveChangesAsync();
        }
    }
}
