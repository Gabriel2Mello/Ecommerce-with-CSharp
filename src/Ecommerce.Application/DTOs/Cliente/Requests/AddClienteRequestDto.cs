using Ecommerce.Application.DTOs.Shared;

namespace Ecommerce.Application.DTOs.Cliente.Requests
{
    public record AddClienteRequestDto : GuidBaseDto
    {
        public string NumeroIdentidade { get; set; }
        public string Nome { get; set; }

        public AddClienteRequestDto() { }

        public AddClienteRequestDto(Guid guid,
                                    string numeroIdentidade,
                                    string nome) : base(guid) 
        {
            NumeroIdentidade = numeroIdentidade;
            Nome = nome;
        }
    }
}
