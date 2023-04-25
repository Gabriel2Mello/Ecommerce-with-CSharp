using Ecommerce.Domain.Base;

namespace Ecommerce.Domain.Entities
{
    public class Cliente : EntityBase
    {
        public Cliente(Guid guid, 
                       int idPessoa, 
                       string numeroIdentidade, 
                       string nome) : base(guid)
        {
            IdPessoa = idPessoa;
            NumeroIdentidade = numeroIdentidade;
            Nome = nome;
        }

        public int IdPessoa { get; private set; }

        public string NumeroIdentidade { get; set; }

        public string Nome { get; set; }

        public Pessoa Pessoa { get; set; }
    }
}
