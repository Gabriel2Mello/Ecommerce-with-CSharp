using Ecommerce.Domain.Base;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Domain.Log
{
    public class LogPessoa : EntityBase
    {
        public LogPessoa(Guid guid,
                         int idPessoa,
                         int idUsuario,
                         string acao,
                         string campo) : base(guid)
        {
            DataHora = DateTime.Now;
            IdPessoa = idPessoa;
            IdUsuario = idUsuario;
            Acao = acao;
            Campo = campo;
        }

        public int IdPessoa { get; private set; }

        public int IdUsuario { get; private set; }

        public string Acao { get; set; }

        public string Campo { get; set; }

        public DateTime DataHora { get; private set; }

        public Pessoa Pessoa { get; set; }
    }
}
