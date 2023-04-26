using Ecommerce.Application.DTOs.Shared;

namespace Ecommerce.Application.DTOs.Pessoa.Responses
{
    public record UpdatePessoaResponseDto : GuidBaseDto
    {        
        public string Celular { get; set; }
        public string Email { get; set; }        
        public string Tipo { get; set; }

        public UpdatePessoaResponseDto() { }

        public UpdatePessoaResponseDto(Guid guid,
                                    string celular,
                                    string email,
                                    string tipo) : base(guid)
        {
            Celular = celular;
            Email = email;
            Tipo = tipo;
        }

        public void FillObject(Guid guid,
                               string celular,
                               string email,
                               string tipo)
        {
            Guid = guid;
            Celular = celular;
            Email = email;
            Tipo = tipo;
        }
    }
}
