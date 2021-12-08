using System;
using System.Threading.Tasks;
using Trader.Models;
using Trader.Repositories;

namespace Trader.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<User> CreateUser(User user)
        {
            var userId = Guid.NewGuid();

            var addedUser = await _userRepository.AddUser(new User
            {
                Id = userId.ToString(),
                FirstName = user.FirstName,
                LastName = user.LastName
            });

            return addedUser;
        }
        
        public async Task<User> GetUserById(string id)
        {
            var user = await _userRepository.GetUserById(id);

            return user;
        }
    }
}