using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Trader.Models;

namespace Trader.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly UserDBContext _userDBContext;
        
        public TransactionRepository(UserDBContext userDbContext)
        {
            _userDBContext = userDbContext;
        }

        public async Task<int> CreateTransaction(Transaction transaction)
        {
            try
            {
                var userTransactionItem = await _userDBContext.Transactions.FirstOrDefaultAsync(x => x.UserId == transaction.UserId && x.IsActive == true);

                if (userTransactionItem == null)
                {
                    await _userDBContext.Transactions.AddAsync(transaction);
                    return await _userDBContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Transaction create could not be saved: {ex}");
            }

            return 0;
        }
        
        public async Task CancelTransaction(string userId)
        {
            try
            {
                var userTransactionItem = await _userDBContext.Transactions.FirstOrDefaultAsync(x => x.UserId == userId && x.IsActive == true);

                if (userTransactionItem != null)
                {
                    userTransactionItem.IsActive = false;
                    await _userDBContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Transaction cancel could not be saved: {ex}");
            }
        }
        
        public async Task<Transaction> GetUserTransaction(string userId)
        {
            return await _userDBContext.Transactions.FirstOrDefaultAsync(x => x.UserId == userId && x.IsActive == true);
        }
    }
}