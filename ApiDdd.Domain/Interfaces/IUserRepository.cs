using ApiDdd.Domain.Entities;
using System.Threading.Tasks;

namespace ApiDdd.Domain.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> Insert(User obj);

        User SelectByUser(User obj);
    }
}
