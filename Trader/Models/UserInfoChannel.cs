using System.ComponentModel.DataAnnotations;

namespace Trader.Models
{
    public class UserInfoChannel
    {
        [Key]
        public string UserId { get; set; }
        public bool SmsActive { get; set; }
        public bool EmailActive { get; set; }
        public bool PnActive { get; set; }
    }
}