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

    public class CadastrarUsuarioValidator : AbstractValidator<CadastrarUsuarioCommand>
    {
        public CadastrarUsuarioValidator()
        {
            RuleFor(c => c.Email).EmailAddress().WithMessage("O login do usuário deve ser um e-mail válido");
            RuleFor(c => c.Nome).NotEmpty().WithMessage("O nome do usuário deve ser preenchido");
            RuleFor(c => c.Senha).MinimumLength(6).WithMessage("A senha do usuário deve ter no mínimo 6 caracteres");
            RuleFor(c => c.ConfirmacaoSenha).Equal(o => o.Senha).WithMessage("A confirmação de senha deve ter o mesmo conteúdo da senha");
        }
    }


}
