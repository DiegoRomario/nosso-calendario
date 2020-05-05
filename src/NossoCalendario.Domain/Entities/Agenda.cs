using NossoCalendario.Domain.Base;
using System;

namespace NossoCalendario.Domain.Entities
{
    public class Agenda : Entity
    {
        public Agenda(string nome, string descricao, Guid usuarioId)
        {
            Nome = nome;
            Descricao = descricao;
            UsuarioId = usuarioId;
        }

        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public Guid UsuarioId { get; private set; }
        public Usuario Usuario { get; set; }
    }
}
