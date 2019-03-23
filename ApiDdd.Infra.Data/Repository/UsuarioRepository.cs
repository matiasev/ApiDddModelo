using ApiDdd.Domain.Entities;
using ApiDdd.Domain.Interfaces;
using ApiDdd.Infra.Data.Context;
using System.Linq;
using System.Threading.Tasks;

namespace ApiDdd.Infra.Data.Repository
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        private ApiDddContext context = new ApiDddContext();

        public virtual async Task<Usuario> Insert(Usuario obj)
        {
            var res = await context.Set<Usuario>().AddAsync(obj);
            context.SaveChanges();
            return res.Entity ;
        }

        public virtual Usuario SelectByUser(Usuario obj)
        {
            return context.Set<Usuario>().FirstOrDefault(e => e.Email == obj.Email && e.Password == obj.Password);

        }
    }
}
