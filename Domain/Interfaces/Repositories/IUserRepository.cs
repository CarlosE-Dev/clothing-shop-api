using Domain.Models;

namespace Domain.Interfaces.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        User Get(string username, string password);
    }
}
