using FluentValidation;
namespace NossoCalendario.Application.Commands.Validators
{

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
