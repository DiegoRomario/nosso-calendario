using NossoCalendario.Domain.Base;
using System;

namespace NossoCalendario.Domain.Entities
{
    public class Agenda : Entity
    {
        private Agenda(){}
        public Agenda(string nome, string descricao, Usuario usuario)
        {
            Nome = nome;
            Descricao = descricao;
            Usuario = usuario;
        }
        public Agenda(Usuario usuario)
        {
            Nome = usuario.Nome;
            Descricao = $"Agenda {usuario.Nome}";
            Usuario = usuario;
        }

        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public Guid UsuarioId { get; private set; }
        public Usuario Usuario { get; private set; }
    }
}
