using Ecommerce.Domain.Base;
using System.Linq.Expressions;

namespace Ecommerce.Domain.Interfaces
{
    public interface IRepositoryBase<TEntity> where TEntity : EntityBase
    {
        Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null);
        Task<TEntity> GetByIdAsync(Guid guid);
        Task<TEntity> GetByIdAsync(int id);

        Task DeleteAsync(TEntity entity);
        Task DeleteByIdAsync(Guid guid);        
        Task DeleteByIdAsync(int id);

        Task UpdateAsync(TEntity entity);

        Task AddAsync(TEntity entity);
    }
}
