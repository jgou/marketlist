using System;
using System.Threading.Tasks;
using MarketList.Models;
using MarketList.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MarketList.Controllers
{
    [Authorize]
    public class MarketListController : Controller
    {
        private readonly IMarketListItemService _marketListItemService;
        private readonly UserManager<IdentityUser> _userManager;

        public MarketListController(IMarketListItemService marketListItemService, UserManager<IdentityUser> userManager)
        {
            _marketListItemService = marketListItemService;
            _userManager = userManager;
        }

        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            var currentuser = await _userManager.GetUserAsync(User);
            if (currentuser == null) return Challenge();

            var items = await _marketListItemService.GetPendingItemsAsync(currentuser);

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

            var currentuser = await _userManager.GetUserAsync(User);
            if (currentuser == null) return Challenge();

            var ok = await _marketListItemService.AddItemAsync(newItem, currentuser);
            if (!ok) return BadRequest("Could not add the item");

            return RedirectToAction("Index");
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MarkAsBought(Guid id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var currentuser = await _userManager.GetUserAsync(User);
            if (currentuser == null) return Challenge();

            var ok = await _marketListItemService.MarkAsBoughtAsync(id, currentuser);
            if (!ok) return BadRequest("Could not mark item as bought");

            return RedirectToAction("Index");
        }
    }
}
