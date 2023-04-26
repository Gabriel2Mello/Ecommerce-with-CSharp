using Ecommerce.Application.DTOs.Shared;
using Ecommerce.Domain.Shared.Enums;

namespace Ecommerce.Application.DTOs.Pessoa.Requests
{
    public record UpdatePessoaRequestDto : GuidBaseDto
    {        
        public string Celular { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public EPessoa Tipo { get; set; }

        public UpdatePessoaRequestDto() { }

        public UpdatePessoaRequestDto(Guid guid,
                                   string celular,
                                   string email,
                                   string senha,
                                   EPessoa tipo) : base(guid)
        {
            Celular = celular;
            Email = email;
            Senha = senha;
            Tipo = tipo;
        }
    }
}
