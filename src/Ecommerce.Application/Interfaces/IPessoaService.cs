using Ecommerce.Application.DTOs.Pessoa.Requests;
using Ecommerce.Application.DTOs.Pessoa.Responses;
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Shared;

namespace Ecommerce.Application.Interfaces
{
    public interface IPessoaService
    {
        Task<AddPessoaResponseDto> AddAsync(AddPessoaRequestDto requestDto);

        Task<GetPessoaResponseDto> GetByIdAsync(Guid guid);

        Task<UpdatePessoaResponseDto> UpdateAsync(UpdatePessoaRequestDto requestDto);
    }
}
