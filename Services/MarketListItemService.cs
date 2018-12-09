using MarketList.Data;
using MarketList.Models;
using Microsoft.AspNetCore.Identity;
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

        public async Task<bool> AddItemAsync(MarketListItem newItem, IdentityUser user)
        {
            newItem.Id = new Guid();
            newItem.isBought = false;
            newItem.UserId = user.Id;
            _context.Items.Add(newItem);

            var result = await _context.SaveChangesAsync();
            return result == 1;
        }

        public async Task<MarketListItem[]> GetPendingItemsAsync(IdentityUser user)
        {
            return await _context.Items.Where(x => x.isBought == false && x.UserId == user.Id).ToArrayAsync();
        }

        public async Task<bool> MarkAsBoughtAsync(Guid id, IdentityUser user)
        {
            var item = await _context.Items.Where(x => x.Id == id && x.UserId == user.Id).SingleOrDefaultAsync();
            if (item == null) return false;

            item.isBought = true;

            var result = await _context.SaveChangesAsync();
            return result == 1;
        }
    }
}
