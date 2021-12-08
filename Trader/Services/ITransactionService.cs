using System.Threading.Tasks;
using Trader.Models;

namespace Trader.Services
{
    public interface ITransactionService
    {
        Task<int> CreateUserTransaction(Transaction transaction);
        
        Task CancelUserTransaction(string userId);  
        Task<Transaction> GetUserTransaction(string userId);
        Task<TransactionWithChannelInfo> GetUserTransactionsWithChannels(string userId);

    }
}