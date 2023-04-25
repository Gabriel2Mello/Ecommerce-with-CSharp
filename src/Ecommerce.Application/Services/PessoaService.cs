using Ecommerce.Application.DTOs.Pessoa.Requests;
using Ecommerce.Application.DTOs.Pessoa.Responses;
using Ecommerce.Application.Interfaces;
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Interfaces;

namespace Ecommerce.Application.Services
{
    public class PessoaService : IPessoaService
    {
        private readonly IPessoaRepository _pessoaRepository;

        public PessoaService(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }

        public async Task<AddPessoaResponseDto> AddAsync(AddPessoaRequestDto requestDto)
        {
            Pessoa pessoa = Pessoa.CreateObject(guid: Guid.NewGuid(),
                                                celular: requestDto.Celular,
                                                email: requestDto.Email,
                                                senha: requestDto.Senha,
                                                tipo: requestDto.Tipo);

            await _pessoaRepository.AddAsync(pessoa);                

            AddPessoaResponseDto responseDto = new() 
            {
                Guid = pessoa.Guid,
                Celular = pessoa.Celular,
                Email = pessoa.Email,
                Tipo = pessoa.Tipo
            };

            return responseDto;
        }

        public async Task<GetPessoaResponseDto> GetByIdAsync(Guid guid)
        {
            Pessoa pessoa = await _pessoaRepository.GetByIdAsync(guid);

            GetPessoaResponseDto responseDto = new();
            if (pessoa == null)
                return responseDto;
            
            responseDto.Guid = pessoa.Guid;
            responseDto.Celular = pessoa.Celular;
            responseDto.Email = pessoa.Email;
            responseDto.Tipo = pessoa.Tipo;            

            return responseDto;
        }

        public async Task<PutPessoaResponseDto> UpdateAsync(PutPessoaRequestDto requestDto)
        {            
            Pessoa pessoa = await _pessoaRepository.GetByIdAsync(requestDto.Guid);

            PutPessoaResponseDto responseDto = new();
            if (pessoa == null)
                return responseDto;

            pessoa.ChangeObject(requestDto.Celular,
                                requestDto.Email,
                                requestDto.Senha,
                                requestDto.Tipo.ToString());

            await _pessoaRepository.UpdateAsync(pessoa);

            responseDto.Guid = pessoa.Guid;
            responseDto.Celular = pessoa.Celular;
            responseDto.Email = pessoa.Email;
            responseDto.Tipo= pessoa.Tipo;

            return responseDto;
        }
    }
}
