using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Trader.Models;
using Trader.Services;

namespace Trader.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserInfoChannelController : ControllerBase
    {
        private readonly IUserInfoChannelService _userInfoChannelService;

        public UserInfoChannelController(IUserInfoChannelService userInfoChannelService)
        {
            _userInfoChannelService = userInfoChannelService;
        }
        
        [HttpPost]
        public async Task<IActionResult> EditUserChannel([FromBody]UserInfoChannel userInfoChannel)
        {
            await _userInfoChannelService.EditUserInfoChannel(userInfoChannel);

            return Ok();
        }   
        
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserInfoChannels([FromRoute]string userId)
        {
            var user = await _userInfoChannelService.GetUserInfoChannelById(userId);
            
            if (user == null)
                return NotFound();
            
            return Ok(user);
        }
    }
}