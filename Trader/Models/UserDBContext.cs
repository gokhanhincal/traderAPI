using Microsoft.EntityFrameworkCore;

namespace Trader.Models
{
    public class UserDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserInfoChannel> UserInfoChannels { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        public UserDBContext(DbContextOptions<UserDBContext> options)
            : base(options)
        {

        }
    }
}