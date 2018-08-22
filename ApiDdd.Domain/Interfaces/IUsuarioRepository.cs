using ApiDdd.Domain.Entities;
using ApiDdd.Domain.Entities.Admin;
using System.Collections.Generic;

namespace ApiDdd.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        void Insert(Usuario obj);

        Usuario SelectByUser(Usuario obj);
    }
}
