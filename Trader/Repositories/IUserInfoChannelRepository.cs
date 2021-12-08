using System.Threading.Tasks;
using Trader.Models;

namespace Trader.Repositories
{
    public interface IUserInfoChannelRepository
    {
        Task AddUserInfoChannel(UserInfoChannel user);
        
        Task<UserInfoChannel> GetUserInfoChannelsById(string userId);
    }
}