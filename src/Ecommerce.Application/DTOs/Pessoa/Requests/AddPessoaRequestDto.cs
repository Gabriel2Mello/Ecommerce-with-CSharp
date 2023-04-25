using Ecommerce.Domain.Shared.Enums;

namespace Ecommerce.Application.DTOs.Pessoa.Requests
{
    public struct AddPessoaRequestDto
    {
        public string Celular { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public EPessoa Tipo { get; set; }
    }
}
