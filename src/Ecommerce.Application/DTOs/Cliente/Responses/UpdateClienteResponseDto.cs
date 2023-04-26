using Ecommerce.Application.DTOs.Shared;

namespace Ecommerce.Application.DTOs.Cliente.Responses
{
    public record UpdateClienteResponseDto : GuidBaseDto
    {
        public string NumeroIdentidade { get; set; }
        public string Nome { get; set; }

        public UpdateClienteResponseDto() { }

        public UpdateClienteResponseDto(Guid guid,
                                        string numeroIdentidade,
                                        string nome) : base(guid)
        {
            NumeroIdentidade = numeroIdentidade;
            Nome = nome;
        }

        public void FillObject(Guid guid,
                               string numeroIdentidade,
                               string nome)
        {
            Guid = guid;
            NumeroIdentidade = numeroIdentidade;
            Nome = nome;
        }
    }
}
