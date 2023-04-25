namespace Ecommerce.Application.DTOs.Pessoa.Responses
{
    public struct PutPessoaResponseDto
    {
        public Guid Guid { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }        
        public string Tipo { get; set; }
    }
}
