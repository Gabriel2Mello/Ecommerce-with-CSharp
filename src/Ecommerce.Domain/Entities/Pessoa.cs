using Ecommerce.Domain.Base;
using Ecommerce.Domain.Shared.Enums;

namespace Ecommerce.Domain.Entities
{
    public class Pessoa : EntityBase
    {        
        private Pessoa(Guid guid,
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

        public string Celular { get; private set; }

        public string Email { get; private set; }

        public string Senha { get; private set; }

        public string Tipo { get; private set; }

        public Cliente Cliente { get; set; }

        public void ChangeObject(string celular,
                                 string email,
                                 string senha,
                                 string tipo)
        {
            Celular = celular;
            Email = email;
            Senha = senha;
            Tipo = tipo;
        }

        public static Pessoa CreateObject(Guid guid, 
                                          string celular, 
                                          string email, 
                                          string senha, 
                                          EPessoa tipo)
        {
            return new Pessoa(guid, celular, email, senha, tipo.ToString());
        }

        public Pessoa(Pessoa pessoa) : base(pessoa.Guid)
        {
            Id = pessoa.Id;
            Celular = pessoa.Celular;
            Email = pessoa.Email;
            Senha = pessoa.Senha;
            Tipo = pessoa.Tipo;
        }
    }
}
