using Ecommerce.Domain.Base;

namespace Ecommerce.Domain.Entities
{
    public class Cliente : EntityBase
    {
        private Cliente(Guid guid, 
                        int idPessoa, 
                        string numeroIdentidade, 
                        string nome) : base(guid)
        {
            IdPessoa = idPessoa;
            NumeroIdentidade = numeroIdentidade;
            Nome = nome;
        }

        public int IdPessoa { get; private set; }

        public string NumeroIdentidade { get; private set; }

        public string Nome { get; private set; }

        public Pessoa Pessoa { get; set; }

        public void ChangeObject(string numeroIdentidade,
                                 string nome)
        {
            NumeroIdentidade = numeroIdentidade;
            Nome = nome;
        }

        public static Cliente CreateObject(Guid guid,
                                           int idPessoa,
                                           string numeroIdentidade,
                                           string nome)
        {
            return new Cliente(guid, idPessoa, numeroIdentidade, nome);
        }
    }
}
