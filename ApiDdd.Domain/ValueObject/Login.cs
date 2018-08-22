using System;
using System.Collections.Generic;
using System.Text;

namespace ApiDdd.Domain.Entities.Admin
{
    public class Login
    {
        public Login(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public string Email { get; set; }

        public string Password { get; set; }

        //protected Login()
        //{

        //}

        //public Login(string email, string password)
        //{
        //    Email = email;
        //    Password = password;
        //}
    }
}
