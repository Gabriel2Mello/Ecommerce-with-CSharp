using Ecommerce.Application.DTOs.Shared;

namespace Ecommerce.Application.DTOs.Cliente.Responses
{
    public record AddClienteResponseDto : GuidBaseDto
    {        
        public string NumeroIdentidade { get; set; }
        public string Nome { get; set; }

        public AddClienteResponseDto() { }

        public AddClienteResponseDto(Guid guid,
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
