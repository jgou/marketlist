using MarketList.Data;
using MarketList.Models;
using Microsoft.EntityFrameworkCore;
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

        public async Task<MarketListItem[]> GetPendingItemsAsync()
        {
            return await _context.Items.Where(x => x.isBought == false).ToArrayAsync();
        }
    }
}
