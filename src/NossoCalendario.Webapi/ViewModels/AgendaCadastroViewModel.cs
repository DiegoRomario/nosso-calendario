using System;
using System.ComponentModel.DataAnnotations;

namespace NossoCalendario.WebApi.ViewModels
{
    public class AgendaCadastroViewModel
    {
        public AgendaCadastroViewModel(string nome, string descricao, Guid usuarioId)
        {
            Nome = nome;
            Descricao = descricao;
            UsuarioId = usuarioId;
        }
        [MinLength(1, ErrorMessage = "O nome da agenda deve ser preenchido")]
        public string Nome { get; private set; }
        [MinLength(1, ErrorMessage = "A descrição da agenda deve ser preenchido")]
        [MaxLength(250, ErrorMessage = "A descrição da agenda de ter no máximo {0} caracteres")]
        public string Descricao { get; private set; }
        [Required(ErrorMessage = "O usuário da agenda deve ser preenchido")]
        public Guid UsuarioId { get; private set; }
    }
}
