using Ecommerce.Domain.Base;
using Ecommerce.Domain.Shared;
using System.Linq.Expressions;

namespace Ecommerce.Domain.Interfaces
{
    public interface IRepositoryBase<TEntity> where TEntity : EntityBase
    {
        Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null);
        Task<TEntity> GetByIdAsync(Guid guid);
        Task<TEntity> GetByIdAsync(int id);

        Task<int> DeleteAsync(TEntity entity);
        Task<int> DeleteByIdAsync(Guid guid);
        Task<int> DeleteByIdAsync(int id);

        Task<ReturnChanges<TEntity>> UpdateAsync(TEntity entity);

        Task<ReturnChanges<TEntity>> AddAsync(TEntity entity);
    }
}
