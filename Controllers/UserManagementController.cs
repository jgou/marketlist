using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarketList.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MarketList.Controllers
{
    [Authorize (Roles = "Administrator")]
    public class UserManagementController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;

        public UserManagementController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var admins = (await _userManager.GetUsersInRoleAsync("Administrator")).ToArray();
            var everyone = await _userManager.Users.ToArrayAsync();

            var model = new UserManagementViewModel
            {
                Administrators = admins,
                Everyone = everyone
            };



            return View();
        }
    }
}