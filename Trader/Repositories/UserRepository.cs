using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Trader.Models;

namespace Trader.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDBContext _userDBContext;
        
        public UserRepository(UserDBContext userDbContext)
        {
            _userDBContext = userDbContext;
        }

        public async Task<User> GetUserById(string id)
        {
            return await _userDBContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<User> AddUser(User user)
        {
            try
            {
                await _userDBContext.Users.AddAsync(user);
                await _userDBContext.SaveChangesAsync();

                return user;
            }
            catch (Exception ex)
            {
                throw new Exception($"User could not be saved: {ex}");
            }
        }
    }
}