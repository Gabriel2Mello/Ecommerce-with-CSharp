using Ecommerce.Domain.Base;
using Ecommerce.Domain.Interfaces;
using Ecommerce.Domain.Shared;
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

        public async Task<int> DeleteAsync(TEntity entity)
        {
            _dbSet.Remove(entity);
            return await _ecommerceContext.SaveChangesAsync();
        }

        public async Task<int> DeleteByIdAsync(Guid guid)
        {
            TEntity entity = await GetByIdAsync(guid);

            _dbSet.Remove(entity);
            return await _ecommerceContext.SaveChangesAsync();
        }

        public async Task<int> DeleteByIdAsync(int id)
        {
            TEntity entity = await GetByIdAsync(id);

            _dbSet.Remove(entity);
            return await _ecommerceContext.SaveChangesAsync();
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
            return await _dbSet.FirstOrDefaultAsync(p => p.Guid.Equals(guid));
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<ReturnChanges<TEntity>> UpdateAsync(TEntity entity)
        {
            _dbSet.Update(entity);
            return await SaveChangesAsync(entity);
        }

        public async Task<ReturnChanges<TEntity>> AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            return await SaveChangesAsync(entity);
        }

        private async Task<ReturnChanges<T>> SaveChangesAsync<T>(T entity) where T : TEntity
        {
            int changes = await _ecommerceContext.SaveChangesAsync();

            if (entity.IdIsNull || entity.GuidIsNull)
                throw new Exception("Database Malfunction");

            return new(entity, changes);
        }
    }
}
