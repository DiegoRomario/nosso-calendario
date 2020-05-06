using NossoCalendario.Domain.Base;
using System;
using System.Collections.Generic;


namespace NossoCalendario.Domain.Entities
{
    public class Usuario : Entity
    {
        public Usuario(string nome, string email, string senha)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
            IncluidoEm = DateTime.Now;
            Agendas = new List<Agenda>() { new Agenda(this) };
        }

        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
        public DateTime IncluidoEm { get; private set; }
        public void CriptografarSenha(string hash)
        {
            Senha = hash;
        }

        public IEnumerable<Agenda> Agendas { get; private set; }


    }
}
