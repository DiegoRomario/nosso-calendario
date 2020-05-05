using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NossoCalendario.WebApi.ViewModels
{
    public class UsuarioViewModel
    {
        public UsuarioViewModel(string nome, string email, string senha, string confirmacaoSenha)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
            ConfirmacaoSenha = confirmacaoSenha;
        }
        [Required(ErrorMessage = "O nome do usuário deve ser preenchido")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O login do usuário deve ser preenchido")]
        [EmailAddress(ErrorMessage = "O login deve ser um e-mail válido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "A senha do usuário deve ser preenchida")]
        [MinLength(6, ErrorMessage = "A senha do usuário deve conter pelo menos 6 caracteres")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
        [Required(ErrorMessage = "A confirmação de senha do usuário deve ser preenchida")]
        [DataType(DataType.Password)]
        [Compare("Senha", ErrorMessage = "A confirmação de senha deve ter o mesmo conteúdo da senha")]
        public string ConfirmacaoSenha { get; set; }

    }

}

