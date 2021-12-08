using System.Threading.Tasks;
using Trader.Models;

namespace Trader.Repositories
{
        public interface IUserRepository
        {
            Task<User> GetUserById(string id);
            Task<User> AddUser(User user);
        }
}