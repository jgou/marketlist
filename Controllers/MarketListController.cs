using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarketList.Models;
using MarketList.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MarketList.Controllers
{
    public class MarketListController : Controller
    {
        private readonly IMarketListItemService _marketListItemService;

        public MarketListController(IMarketListItemService marketListItemService)
        {
            _marketListItemService = marketListItemService;
        }

        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            var items = await _marketListItemService.GetPendingItemsAsync();

            var model = new MarketListViewModel
            {
                Items = items
            };

            return View(model);
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddItem(MarketListItem newItem)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            var ok = await _marketListItemService.AddItemAsync(newItem);
            if (!ok) return BadRequest("Could not add the item");

            return RedirectToAction("Index");
        }
    }
}
