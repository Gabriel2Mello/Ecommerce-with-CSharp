using Ecommerce.Domain.Base;

namespace Ecommerce.Domain.Entities
{
    public class Pessoa : EntityBase
    {
        public Pessoa(Guid guid,
                      string celular, 
                      string email, 
                      string senha, 
                      string tipo) : base(guid)
        {
            Celular = celular;
            Email = email;
            Senha = senha;
            Tipo = tipo;
        }


        public string Celular { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

        public string Tipo { get; set; }
    }
}
