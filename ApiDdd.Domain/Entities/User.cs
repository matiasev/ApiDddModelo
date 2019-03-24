using System;
using System.Collections.Generic;
using System.Text;

namespace ApiDdd.Domain.Entities
{
    public class User
    {
        public int ID { get; private set; }

        public string Name { get; private set; }

        public string Email { get; private set; }

        public string Password { get; private set; }

        protected User() { }

        public User(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
        }
    }
}
