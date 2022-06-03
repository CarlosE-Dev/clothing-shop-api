using Domain.Interfaces.Repositories;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Infra.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly ShopDbContext _context;
        private readonly DbSet<User> _dbSet;
        public UserRepository(ShopDbContext context) : base(context)
        {
            _context = context;
            _dbSet = _context.Set<User>();
        }

        public User Get(string username, string password)
        {
            try
            {
                return _dbSet.Where(
                x => x.Username.ToLower() == username.ToLower() && x.Password == password)
                .FirstOrDefault();
            }
            catch (Exception e)
            {
                throw new Exception($"{e}");
            }
        }
    }
}
