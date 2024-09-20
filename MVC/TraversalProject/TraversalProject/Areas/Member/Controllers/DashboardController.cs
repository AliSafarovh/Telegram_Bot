﻿using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace TraversalProject.Areas.Member.Controllers
{
    [Area("Member")]
    public class DashboardController : Controller
	{
		private readonly UserManager<AppUser> _userManager;
        public DashboardController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IActionResult> IndexAsync()
        {
			var values = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.Username = values.Name + " " + values.Surname;    
            ViewBag.UserImage=values.ImageUrl;
			return View();
        }
    }
}
