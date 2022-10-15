using Microsoft.AspNetCore.Mvc;
using BookShop.WEB.Service;
using BookShop.WEB.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace BookShop.WEB.Areas.Admin.Controllers
{
    [Area("admin")]
    public class UsersController : Controller
    {
        UserManager<IdentityUser> _userManager;
        public UsersController (UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }
        public IActionResult Add() => View();

        [HttpPost]
        public async Task<IActionResult> Add (AddUserViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = new IdentityUser 
                { 
                    UserName = viewModel.Name,
                    Email = viewModel.Email,
                    PasswordHash= viewModel.Password
                };
                IdentityUserRole<string> userRole = new IdentityUserRole<string>
                {
                    UserId = user.Id,
                    RoleId = viewModel.RoleID
                };
                var result = await _userManager.CreateAsync(user, viewModel.Password);
                var resultAddRole = await _userManager.AddToRoleAsync(user, viewModel.Role);
                if (result.Succeeded && resultAddRole.Succeeded)
                {
                    return RedirectToAction(nameof(HomeController.Users), nameof(HomeController).CutController());
                }
                else 
                { 
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(viewModel);
        }
        public async Task<IActionResult> Edit (string Id)
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
        public async Task<IActionResult> Edit (EditUserViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = await _userManager.FindByIdAsync(viewModel.Id);
                if (user !=null)
                {
                    user.UserName = viewModel.Name;
                    user.Email = viewModel.Email;
                    var result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        return RedirectToAction(nameof(HomeController.Users), nameof(HomeController).CutController());
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
        [HttpPost]
        public async Task<IActionResult> Delete(string Id)
        {
            IdentityUser user = await _userManager.FindByIdAsync(Id);
            if (user !=null)
            {
                IdentityResult result = await _userManager.DeleteAsync(user);
            }
            return RedirectToAction(nameof(HomeController.Users), nameof(HomeController).CutController());
        }
    }
}
