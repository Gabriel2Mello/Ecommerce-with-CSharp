using Ecommerce.Application.DTOs.Shared;
using Ecommerce.Domain.Shared.Enums;

namespace Ecommerce.Application.DTOs.Pessoa.Requests
{
    public record PutPessoaRequestDto : GuidBaseDto
    {        
        public string Celular { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public EPessoa Tipo { get; set; }
    }
}
