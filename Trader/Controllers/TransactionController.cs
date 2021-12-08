using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Trader.Models;
using Trader.Services;
using Trader.Validators;

namespace Trader.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateUserTransaction([FromBody]Transaction transaction)
        {
            var validator = new TransactionValidator();
            var result = await validator.ValidateAsync(transaction);

            if (!result.IsValid) return BadRequest();
            if (await _transactionService.CreateUserTransaction(transaction) > 0)
            {
                return Ok();
            }
            return BadRequest();
        }
        
        [HttpPut("{userId}")]
        public async Task<IActionResult> CancelUserTransaction([FromRoute]string userId)
        {
            await _transactionService.CancelUserTransaction(userId);
            return Ok();
        }
        
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserTransaction([FromRoute]string userId)
        {
            var user = await _transactionService.GetUserTransaction(userId);
            
            if (user == null)
                return NotFound();
            
            return Ok(user);
        }
        
        [HttpGet("{userId}/permissions")]
        public async Task<IActionResult> GetUserTransactionWithPermission([FromRoute]string userId)
        {
            var userTransaction = await _transactionService.GetUserTransactionsWithChannels(userId);
            
            if (userTransaction == null)
                return NotFound();
            
            return Ok(userTransaction);
        }
    }
}