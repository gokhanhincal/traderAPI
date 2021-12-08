using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trader.Models
{
    public class Transaction
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int TransactionId { get; set; }
        public string UserId { get; set; }
        public double Amount { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime TransactionDate { get; set; }
    }
    
    public class TransactionWithChannelInfo
    {
        public Transaction UserTransaction { get; set; }
        public UserInfoChannel UserInfoChannel { get; set; }
    }
}