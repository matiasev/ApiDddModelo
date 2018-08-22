using ApiDdd.Domain.Entities;
using ApiDdd.Domain.Interfaces;
using ApiDdd.Infra.Data.Context;
using System.Linq;

namespace ApiDdd.Infra.Data.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private ApiDddContext context = new ApiDddContext();

        public void Insert(Usuario obj)
        {
            context.Set<Usuario>().Add(obj);
            context.SaveChanges();
        }

        public Usuario SelectByUser(Usuario obj)
        {
            return context.Set<Usuario>().SingleOrDefault(e => e.Email == obj.Email && e.Password == obj.Password);

        }
    }
}
