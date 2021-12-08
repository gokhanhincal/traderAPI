using System;
using System.Threading.Tasks;
using Trader.Models;
using Trader.Repositories;

namespace Trader.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IUserInfoChannelRepository _userInfoChannelRepository;
        
        public TransactionService(ITransactionRepository transactionRepository, IUserInfoChannelRepository userInfoChannelRepository)
        {
            _transactionRepository = transactionRepository;
            _userInfoChannelRepository = userInfoChannelRepository;
        }
        public async Task<int> CreateUserTransaction(Transaction transaction)
        {
            return await _transactionRepository.CreateTransaction(new Transaction
            {
                UserId = transaction.UserId,
                Amount = transaction.Amount,
                CreateDate = DateTime.Now, 
                IsActive = transaction.IsActive,
                TransactionDate = transaction.TransactionDate
            });
        }
        
        public async Task CancelUserTransaction(string userId)
        {
            await _transactionRepository.CancelTransaction(userId);
        }
        
        public async Task<Transaction> GetUserTransaction(string id)
        {
            var userTransaction = await _transactionRepository.GetUserTransaction(id);

            return userTransaction;
        }
        
        public async Task<TransactionWithChannelInfo> GetUserTransactionsWithChannels(string userId)
        {
            var userTransaction = await _transactionRepository.GetUserTransaction(userId);
            var userChannels = await _userInfoChannelRepository.GetUserInfoChannelsById(userId);

            var transactionWithChannel = new TransactionWithChannelInfo
            {
                UserTransaction = userTransaction,
                UserInfoChannel = userChannels
            };
            return transactionWithChannel;
        }
    }
}