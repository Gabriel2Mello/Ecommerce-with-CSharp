using Ecommerce.Domain.Entities;

namespace Ecommerce.Domain.Interfaces
{
    public interface IPessoaRepository
    {
        Task AddAsync(Pessoa entity);
    }
}
