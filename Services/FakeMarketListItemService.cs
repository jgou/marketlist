using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarketList.Models;

namespace MarketList.Services
{
    public class FakeMarketListItemService : IMarketListItemService
    {
        public Task<MarketListItem[]> GetPendingItemsAsync()
        {
            var item1 = new MarketListItem
            {
                Name = "Milk",
                Quantity = 6
            };

            var item2 = new MarketListItem
            {
                Name = "Eggs",
                Quantity = 12
            };

            return Task.FromResult(new[] { item1, item2 });
        }
    }
}
