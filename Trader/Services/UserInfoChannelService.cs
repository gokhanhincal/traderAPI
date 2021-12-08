using System.Threading.Tasks;
using Trader.Models;
using Trader.Repositories;

namespace Trader.Services
{
    public class UserInfoChannelService : IUserInfoChannelService
    {
        private readonly IUserInfoChannelRepository _userInfoChannelRepository;
        
        public UserInfoChannelService(IUserInfoChannelRepository userInfoChannelRepository)
        {
            _userInfoChannelRepository = userInfoChannelRepository;
        }
        
        public async Task EditUserInfoChannel(UserInfoChannel userInfoChannel)
        {
            await _userInfoChannelRepository.AddUserInfoChannel(userInfoChannel);
        }
        
        public async Task<UserInfoChannel> GetUserInfoChannelById(string userId)
        {
            var userInfoChannel = await _userInfoChannelRepository.GetUserInfoChannelsById(userId);

            return userInfoChannel;
        }
    }
}