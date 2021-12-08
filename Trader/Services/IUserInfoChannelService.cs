using System.Threading.Tasks;
using Trader.Models;

namespace Trader.Services
{
    public interface IUserInfoChannelService
    {
        Task EditUserInfoChannel(UserInfoChannel userInfoChannel);   
        Task<UserInfoChannel> GetUserInfoChannelById(string userId);
    }
}