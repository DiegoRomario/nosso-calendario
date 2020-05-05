using NossoCalendario.Domain.Base;
using System;

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
        }

        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
        public DateTime IncluidoEm { get; private set; }
        public void CriptografarSenha(string hash)
        {
            Senha = hash;
        }



    }
}
