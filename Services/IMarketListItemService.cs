using MarketList.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace MarketList.Services
{
    public interface IMarketListItemService
    {
        Task<MarketListItem[]> GetPendingItemsAsync(IdentityUser user);
        Task<bool> AddItemAsync(MarketListItem newItem, IdentityUser user);
        Task<bool> MarkAsBoughtAsync(Guid id, IdentityUser user);
    }
}
