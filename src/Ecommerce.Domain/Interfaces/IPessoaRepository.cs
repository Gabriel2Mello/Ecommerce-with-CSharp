using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Shared;

namespace Ecommerce.Domain.Interfaces
{
    public interface IPessoaRepository
    {
        Task<Pessoa> AddAsync(Pessoa entity);

        Task<Pessoa> GetByIdAsync(Guid id);

        Task<Pessoa> GetByIdAsync(int id);

        Task<ReturnChanges<Pessoa>> UpdateAsync(Pessoa entity);
    }
}
