using Ecommerce.Domain.Base;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Domain.Log
{
    public class PessoaLog : EntityBase
    {
        protected PessoaLog(Guid guid,
                            Guid guidPessoa,            
                            int idPessoa,
                            int idUsuario,
                            string acao = "",
                            string campo = "") : base(guid)
        {
            DataCadastro = DateTime.Now;
            DataAlteracao = DateTime.Now;
            GuidPessoa = guidPessoa;
            IdPessoa = idPessoa;
            IdUsuario = idUsuario;
            Acao = acao;
            Campo = campo;
        }

        public Guid GuidPessoa { get; private set; }

        public int IdPessoa { get; private set; }

        public int IdUsuario { get; private set; }

        public string Acao { get; set; }

        public string Campo { get; set; }

        public DateTime DataAlteracao { get; private set; }

        public DateTime DataCadastro { get; private set; }

        public Pessoa Pessoa { get; set; }

        public static PessoaLog CreateObject(Guid guidPessoa,
                                             int idPessoa,
                                             int idUsuario,
                                             string acao = "",
                                             string campo = "")
        {
            return new PessoaLog(Guid.NewGuid(), guidPessoa, idPessoa, idUsuario, acao, campo);
        }
    }
}
