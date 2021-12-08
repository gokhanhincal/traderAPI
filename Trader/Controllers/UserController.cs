using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Trader.Models;
using Trader.Services;

namespace Trader.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody]User user)
        {
            var addedUser = await _userService.CreateUser(user);
            return Ok(addedUser);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser([FromRoute]string id)
        {
            var user = await _userService.GetUserById(id);
            
            if (user == null)
                return NotFound();
            
            return Ok(user);
        }
    }
}