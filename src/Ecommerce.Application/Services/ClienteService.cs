using Ecommerce.Application.DTOs.Cliente.Requests;
using Ecommerce.Application.DTOs.Cliente.Responses;
using Ecommerce.Application.Interfaces;
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Interfaces;
using Ecommerce.Domain.Shared;
using Ecommerce.Domain.Utility;
using System.Linq.Expressions;

namespace Ecommerce.Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IPessoaRepository _pessoaRepository;

        public ClienteService(
            IClienteRepository clienteRepository, 
            IPessoaRepository pessoaRepository)
        {
            _clienteRepository = clienteRepository;
            _pessoaRepository = pessoaRepository;
        }

        public async Task<AddClienteResponseDto> AddAsync(AddClienteRequestDto requestDto)
        {
            AddClienteResponseDto responseDto = new();

            if (requestDto.GuidIsNull) return responseDto;

            Pessoa pessoa = await _pessoaRepository.GetByIdAsync(requestDto.Guid);

            if (pessoa == null) return responseDto;

            Cliente cliente = Cliente.CreateObject(guid: Guid.NewGuid(),
                                                   idPessoa: pessoa.Id,
                                                   numeroIdentidade: requestDto.NumeroIdentidade,
                                                   nome: requestDto.Nome);

            await _clienteRepository.AddAsync(cliente);

            responseDto.FillObject(guid: cliente.Guid,
                                   numeroIdentidade: cliente.NumeroIdentidade,
                                   nome: cliente.Nome);            
            
            return responseDto;
        }

        public async Task<int> DeleteAsync(DeleteClienteRequestDto requestDto)
        {
            if (requestDto.GuidIsNull) return 0;

            Cliente cliente = await _clienteRepository.GetByIdAsync(requestDto.Guid);

            if (cliente == null) return 0;

            int changes = await _clienteRepository.DeleteAsync(cliente);

            if (changes == 0) return 0;
            
            Pessoa pessoa = await _pessoaRepository.GetByIdAsync(cliente.Id);

            pessoa.ChangeObject(celular: pessoa.Celular,
                                email: pessoa.Email,
                                senha: string.Empty,
                                tipo: pessoa.Tipo);

            await _pessoaRepository.UpdateAsync(pessoa);

            return changes;
        }       

        public async Task<IEnumerable<Cliente>> GetAsync(Expression<Func<Cliente, bool>> filter = null)
        {
            return await _clienteRepository.GetAsync(filter);
        }

        public async Task<GetClienteResponseDto> GetByIdAsync(Guid guid)
        {
            GetClienteResponseDto responseDto = new();

            if (GuidUtility.IsNull(guid)) return responseDto;

            Cliente cliente = await _clienteRepository.GetByIdAsync(guid);

            if (cliente == null) return responseDto;

            responseDto.FillObject(guid: cliente.Guid,
                                   guidPessoa: cliente.Pessoa.Guid,
                                   nome: cliente.Nome,
                                   numeroIdentidade: cliente.NumeroIdentidade);

            return responseDto;
        }

        public async Task<UpdateClienteResponseDto> UpdateAsync(UpdateClienteRequestDto requestDto)
        {
            UpdateClienteResponseDto responseDto = new();

            if (requestDto.GuidIsNull) return responseDto;

            Cliente cliente = await _clienteRepository.GetByIdAsync(requestDto.Guid);

            if (cliente == null) return responseDto;

            cliente.ChangeObject(numeroIdentidade: requestDto.NumeroIdentidade,
                                 nome: requestDto.Nome);

            if(_clienteRepository.UpdateAsync(cliente).Result.Changes == 0) return responseDto;

            responseDto.FillObject(guid: cliente.Guid,
                                   numeroIdentidade: cliente.NumeroIdentidade,
                                   nome: cliente.Nome);

            return responseDto;
        }
    }
}
