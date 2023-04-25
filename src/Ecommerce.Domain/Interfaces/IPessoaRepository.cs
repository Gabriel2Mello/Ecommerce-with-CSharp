using Ecommerce.Domain.Entities;

namespace Ecommerce.Domain.Interfaces
{
    public interface IPessoaRepository
    {
        Task<Pessoa> AddAsync(Pessoa entity);

        Task<Pessoa> GetByIdAsync(Guid id);

        Task<Pessoa> GetByIdAsync(int id);

        Task<Pessoa> UpdateAsync(Pessoa entity);
    }
}
