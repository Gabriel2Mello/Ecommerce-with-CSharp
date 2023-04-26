using Ecommerce.Application.DTOs.Cliente.Requests;
using Ecommerce.Application.DTOs.Cliente.Responses;
using Ecommerce.Domain.Entities;
using System.Linq.Expressions;

namespace Ecommerce.Application.Interfaces
{
    public interface IClienteService
    {
        Task<IEnumerable<Cliente>> GetAsync(Expression<Func<Cliente, bool>> filter = null);

        Task<GetClienteResponseDto> GetByIdAsync(Guid guid);

        Task<int> DeleteAsync(DeleteClienteRequestDto requestDto);

        Task<UpdateClienteResponseDto> UpdateAsync(UpdateClienteRequestDto requestDto);

        Task<AddClienteResponseDto> AddAsync(AddClienteRequestDto requestDto);
    }
}
