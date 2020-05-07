using NossoCalendario.Domain.Base;
using System;

namespace NossoCalendario.Domain.Entities
{
    public class Agenda : Entity
    {
        [Obsolete("Construtor utilizado apenas para mapeamento do EF", true)]
        private Agenda(){}
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
