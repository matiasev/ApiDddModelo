using System;
using System.Collections.Generic;
using System.Text;

namespace ApiDdd.Domain.Entities
{
    public class Usuario
    {
        public int UsuarioID { get; private set; }

        public string Nome { get; private set; }

        public string Email { get; private set; }

        public string Password { get; private set; }

        protected Usuario() { }

        public Usuario(string nome, string email, string password)
        {
            Nome = nome;
            Email = email;
            Password = password;
        }
    }
}
