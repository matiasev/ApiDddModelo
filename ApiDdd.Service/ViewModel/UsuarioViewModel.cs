using ApiDdd.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiDdd.Application.ViewModel
{
    public class UsuarioViewModel
    {
        public int UsuarioID { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

    }
}