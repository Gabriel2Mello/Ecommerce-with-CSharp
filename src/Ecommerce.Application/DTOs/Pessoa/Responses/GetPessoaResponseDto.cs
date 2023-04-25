using Ecommerce.Application.DTOs.Shared;

namespace Ecommerce.Application.DTOs.Pessoa.Responses
{
    public record GetPessoaResponseDto : GuidBaseDto
    {
        public string Celular { get; set; }
        public string Email { get; set; }
        public string Tipo { get; set; }
    }
}
