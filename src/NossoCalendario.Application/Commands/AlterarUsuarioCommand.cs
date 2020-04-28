using FluentValidation;
using MediatR;
using NossoCalendario.Domain.Base;
using System;


namespace NossoCalendario.Application.Commands
{
    public class AlterarUsuarioCommand : IRequest<Response>
    {

        public AlterarUsuarioCommand(Guid id, string nome, string email, string senha, string confirmacaoSenha)
        {
            Id = id;
            Nome = nome;
            Senha = senha;
            ConfirmacaoSenha = confirmacaoSenha;
            Email = email;
        }
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string ConfirmacaoSenha { get; set; }
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
