using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Trader.Models;

namespace Trader.Repositories
{
    public class UserInfoChannelRepository : IUserInfoChannelRepository
    {
        private readonly UserDBContext _userDBContext;
        
        public UserInfoChannelRepository(UserDBContext userDbContext)
        {
            _userDBContext = userDbContext;
        }
        
        public async Task AddUserInfoChannel(UserInfoChannel userInfoChannel)
        {
            try
            {
                var userInfoChannelItem = await _userDBContext.UserInfoChannels.FirstOrDefaultAsync(x => x.UserId == userInfoChannel.UserId);

                if (userInfoChannelItem != null)
                {
                    userInfoChannelItem.EmailActive = userInfoChannel.EmailActive;
                    userInfoChannelItem.PnActive = userInfoChannel.PnActive;
                    userInfoChannelItem.SmsActive = userInfoChannel.SmsActive;
                }
                else
                {
                    await _userDBContext.UserInfoChannels.AddAsync(userInfoChannel);
                }
                await _userDBContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"UserInfoChannel could not be saved: {ex}");
            }
        }
        
        public async Task<UserInfoChannel> GetUserInfoChannelsById(string userId)
        {
            return await _userDBContext.UserInfoChannels.FirstOrDefaultAsync(x => x.UserId == userId);
        }
    }
}