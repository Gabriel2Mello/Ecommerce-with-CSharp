using Ecommerce.Application.DTOs.Pessoa.Requests;
using Ecommerce.Application.DTOs.Pessoa.Responses;
using Ecommerce.Application.Interfaces;
using Ecommerce.Application.Services.Log;
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Interfaces;
using Ecommerce.Domain.Utility;

namespace Ecommerce.Application.Services
{
    public class PessoaService : IPessoaService
    {
        private readonly IPessoaRepository _pessoaRepository;
        private readonly PessoaLogService _pessoaLogService;

        public PessoaService(
            IPessoaRepository pessoaRepository, 
            PessoaLogService pessoaLogService)
        {
            _pessoaRepository = pessoaRepository;
            _pessoaLogService = pessoaLogService;
        }

        public async Task<AddPessoaResponseDto> AddAsync(AddPessoaRequestDto requestDto)
        {            
            Pessoa pessoa = await _pessoaRepository.AddAsync(
                Pessoa.CreateObject(guid: Guid.NewGuid(),
                                    celular: requestDto.Celular,
                                    email: requestDto.Email,
                                    senha: requestDto.Senha,
                                    tipo: requestDto.Tipo));

            AddPessoaResponseDto responseDto = new(guid: pessoa.Guid,
                                                   celular:pessoa.Celular,
                                                   email: pessoa.Email,
                                                   tipo: pessoa.Tipo);

            return responseDto;
        }

        public async Task<GetPessoaResponseDto> GetByIdAsync(Guid guid)
        {
            GetPessoaResponseDto responseDto = new();

            if (GuidUtility.IsNull(guid)) return responseDto;

            Pessoa pessoa = await _pessoaRepository.GetByIdAsync(guid);            

            if (pessoa == null) return responseDto;

            responseDto.FillObject(guid: pessoa.Guid,
                                   celular: pessoa.Celular,
                                   email: pessoa.Email,
                                   tipo: pessoa.Tipo);

            return responseDto;
        }

        public async Task<UpdatePessoaResponseDto> UpdateAsync(UpdatePessoaRequestDto requestDto)
        {
            UpdatePessoaResponseDto responseDto = new();

            if (requestDto.GuidIsNull) return responseDto;

            Pessoa pessoa = await _pessoaRepository.GetByIdAsync(requestDto.Guid);            
            
            if (pessoa == null) return responseDto;

            _pessoaLogService.AddObject(pessoa);

            pessoa.ChangeObject(celular: requestDto.Celular,
                                email: requestDto.Email,
                                senha: requestDto.Senha,
                                tipo: requestDto.Tipo.ToString());

            if (_pessoaRepository.UpdateAsync(pessoa).Result.Changes == 0) return responseDto;

            _pessoaLogService.MakeLog();

            responseDto.FillObject(guid: pessoa.Guid,
                                   celular: pessoa.Celular,
                                   email: pessoa.Email,
                                   tipo: pessoa.Tipo);            

            return responseDto;
        }
    }
}
