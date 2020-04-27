using FluentValidation;
using MediatR;
using NossoCalendario.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace NossoCalendario.Application.Commands
{
    public class AlterarUsuarioCommand : IRequest<Response>
    {
        public AlterarUsuarioCommand(string nome, string email, string senha, string confirmacaoSenha)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
            ConfirmacaoSenha = confirmacaoSenha;
        }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
        public string ConfirmacaoSenha { get; private set; }
    }

    public class AlterarUsuarioValidator : AbstractValidator<AlterarUsuarioCommand>
    {
        public AlterarUsuarioValidator()
        {
            RuleFor(c => c.Nome).NotEmpty().WithMessage("O nome do usuário deve ser preenchido");
            RuleFor(c => c.Senha).MinimumLength(6).WithMessage("A senha do usuário deve ter no mínimo 6 caracteres");
            RuleFor(c => c.ConfirmacaoSenha).Equal(o => o.Senha).WithMessage("A confirmação de senha deve ter o mesmo conteúdo da senha");
        }
    }


}
