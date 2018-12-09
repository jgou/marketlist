using Microsoft.AspNetCore.Identity;

namespace MarketList.Models
{
    public class UserManagementViewModel
    {
        public IdentityUser[] Administrators { get; set; }
        public IdentityUser[] Everyone { get; set; }
    }
}
