using MarketList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketList.Services
{
    public interface IMarketListItemService
    {
        Task<MarketListItem[]> GetPendingItemsAsync(); 
    }
}
