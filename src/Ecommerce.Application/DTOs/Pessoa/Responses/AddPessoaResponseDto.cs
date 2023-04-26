using Ecommerce.Application.DTOs.Shared;

namespace Ecommerce.Application.DTOs.Pessoa.Responses
{
    public record AddPessoaResponseDto : GuidBaseDto
    {
        public string Celular { get; set; }
        public string Email { get; set; }
        public string Tipo { get; set; }

        public AddPessoaResponseDto(Guid guid,
                                    string celular,
                                    string email,
                                    string tipo) : base(guid)
        {
            Celular = celular;
            Email = email;
            Tipo = tipo;
        }
    }
}
