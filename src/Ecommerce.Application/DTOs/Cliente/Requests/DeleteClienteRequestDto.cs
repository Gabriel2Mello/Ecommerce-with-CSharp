using Ecommerce.Application.DTOs.Shared;

namespace Ecommerce.Application.DTOs.Cliente.Requests
{
    public record DeleteClienteRequestDto : GuidBaseDto
    {
        public string Celular { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public DeleteClienteRequestDto() { }

        public DeleteClienteRequestDto(Guid guid,
                                       string celular,
                                       string email,
                                       string senha) : base(guid)
        {
            Celular = celular;
            Email = email;
            Senha = senha;
        }
    }
}
