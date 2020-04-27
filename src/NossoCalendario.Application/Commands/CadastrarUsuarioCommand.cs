using FluentValidation;
using MediatR;
using NossoCalendario.Application.Base;
using NossoCalendario.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace NossoCalendario.Application.Commands
{
    public class CadastrarUsuarioCommand : IRequest<Response>
    {
        public CadastrarUsuarioCommand(string nome, string email, string senha, string confirmacaoSenha)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
            ConfirmacaoSenha = confirmacaoSenha;
        }

        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string ConfirmacaoSenha { get; set; }
    }


}
