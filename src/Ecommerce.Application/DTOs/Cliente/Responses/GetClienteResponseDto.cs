using Ecommerce.Application.DTOs.Shared;

namespace Ecommerce.Application.DTOs.Cliente.Responses
{
    public record GetClienteResponseDto : GuidBaseDto
    {
        public Guid GuidPessoa { get; set; }
        public string NumeroIdentidade { get; set; }
        public string Nome { get; set; }

        public GetClienteResponseDto() { }

        public GetClienteResponseDto(Guid guid,
                                     string numeroIdentidade,
                                     string nome) : base(guid)
        {
            NumeroIdentidade = numeroIdentidade;
            Nome = nome;
        }

        public void FillObject(Guid guid,
                               Guid guidPessoa,
                               string numeroIdentidade,
                               string nome)
        {
            Guid = guid;
            GuidPessoa = guidPessoa;
            NumeroIdentidade = numeroIdentidade;
            Nome = nome;
        }
    }
}
