using Domain.Models;

namespace Domain.Interfaces.Services
{
    public interface IUserService : IBaseService<User>
    {
        User GetUser(User model);
    }
}
