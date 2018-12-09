using MarketList.Data;
using MarketList.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MarketList.Services
{
    public class MarketListItemService : IMarketListItemService
    {
        private readonly ApplicationDbContext _context;

        public MarketListItemService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddItemAsync(MarketListItem newItem)
        {
            newItem.Id = new Guid();
            newItem.isBought = false;
            _context.Items.Add(newItem);

            var result = await _context.SaveChangesAsync();
            return result == 1;
        }

        public async Task<MarketListItem[]> GetPendingItemsAsync()
        {
            return await _context.Items.Where(x => x.isBought == false).ToArrayAsync();
        }

        public async Task<bool> MarkAsBoughtAsync(Guid id)
        {
            var item = await _context.Items.Where(x => x.Id == id).SingleOrDefaultAsync();
            if (item == null) return false;

            item.isBought = true;

            var result = await _context.SaveChangesAsync();
            return result == 1;
        }
    }
}
