using Microsoft.AspNetCore.Mvc;
using BookShop.WEB.Service;
using BookShop.WEB.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;


namespace BookShop.WEB.Areas.User.Controllers
{
    [Area("user")]
    public class UserController : Controller
    {
        UserManager<IdentityUser> _userManager;
        public UserController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IActionResult> Edit(string Id)
        {
            IdentityUser currentUser = await _userManager.FindByIdAsync(Id);
            if (currentUser == null)
            {
                return NotFound();
            }
            EditUserViewModel viewModel = new EditUserViewModel
            {
                Id = Id,
                Name = currentUser.UserName,
                Email = currentUser.Email,
            };
            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EditUserViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = await _userManager.FindByIdAsync(viewModel.Id);
                if (user != null)
                {
                    user.UserName = viewModel.Name;
                    user.Email = viewModel.Email;
                    var result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                }
            }
            return View(viewModel);
        }
    }
}
