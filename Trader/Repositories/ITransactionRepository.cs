using System.Threading.Tasks;
using Trader.Models;

namespace Trader.Repositories
{
    public interface ITransactionRepository
    {
        Task<int> CreateTransaction(Transaction transaction);
        
        Task CancelTransaction(string userId);
        
        Task<Transaction> GetUserTransaction(string userId);
    }
}