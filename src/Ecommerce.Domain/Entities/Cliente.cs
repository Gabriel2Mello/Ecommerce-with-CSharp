using Ecommerce.Domain.Base;

namespace Ecommerce.Domain.Entities
{
    public class Cliente : BaseEntity
    {
        public Cliente(int idPessoa, 
                       string numeroIdentidade, 
                       string nome, 
                       string razaoSocial, 
                       string inscricaoEstadual) : base()
        {
            IdPessoa = idPessoa;
            NumeroIdentidade = numeroIdentidade;
            Nome = nome;
            RazaoSocial = razaoSocial;
            InscricaoEstadual = inscricaoEstadual;
        }

        public int IdPessoa { get; private set; }

        public string NumeroIdentidade { get; set; }

        public string Nome { get; set; }

        public string RazaoSocial { get; set; }

        public string InscricaoEstadual { get; set; }

        public Pessoa Pessoa { get; set; }
    }
}
