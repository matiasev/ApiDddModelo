using ApiDdd.Domain.Entities;
using ApiDdd.Domain.Interfaces;
using ApiDdd.Infra.Data.Context;
using System.Linq;
using System.Threading.Tasks;

namespace ApiDdd.Infra.Data.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private ApiDddContext context = new ApiDddContext();

        public virtual async Task<User> Insert(User obj)
        {
            var res = await context.Set<User>().AddAsync(obj);
            context.SaveChanges();
            return res.Entity ;
        }

        public virtual User SelectByUser(User obj)
        {
            return context.Set<User>().FirstOrDefault(e => e.Email == obj.Email && e.Password == obj.Password);

        }
    }
}
