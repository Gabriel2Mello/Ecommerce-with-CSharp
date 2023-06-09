﻿using Ecommerce.Domain.Shared.Enums;

namespace Ecommerce.Application.DTOs.Pessoa.Requests
{
    public struct AddPessoaRequestDto
    {
        public string Celular { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public EPessoa Tipo { get; set; }

        public AddPessoaRequestDto() { }

        public AddPessoaRequestDto(string celular,
                                   string email,
                                   string senha,
                                   EPessoa tipo)
        {
            Celular = celular;
            Email = email;
            Senha = senha;
            Tipo = tipo;
        }
    }
}
