using System.Threading.Tasks;
using Trader.Models;

namespace Trader.Services
{
    public interface IUserService
    {
        Task<User> GetUserById(string id);
        Task<User> CreateUser(User user);
    }
}