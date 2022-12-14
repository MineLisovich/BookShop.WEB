using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using BookShop.WEB.Service;
using BookShop.WEB.Models;

namespace BookShop.WEB.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;

        }

        // Регистрация на сайте
        [HttpGet]
        [AllowAnonymous] //для всех пользователей (те которые не зареганы и не авторизованы)
        public IActionResult Registration(string returnUrl) // Отобрадаем страничку регистрации на нашем сайте
        {
            ViewBag.returnUrl = returnUrl;
            return View(new RegistrationViewModel());
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Registration(RegistrationViewModel model) //Сам процесс регистрации на сайте
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = new IdentityUser //значения полученные с формы регистрации
                {
                    Email = model.Email,
                    UserName = model.Name,
                    PasswordHash = model.Password
                };
                IdentityUserRole<string> userRole = new IdentityUserRole<string> // при регистрации пользователь будет сразу получать роль USER
                {
                    UserId = user.Id,
                    RoleId = "333"
                };
                // сохранение
                var Result = await userManager.CreateAsync(user, model.Password);
                var ResultAddRole = await userManager.AddToRoleAsync(user, "USER");
                if (Result.Succeeded && ResultAddRole.Succeeded)
                {
                    // установка куки
                    await signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in Result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    foreach (var error in ResultAddRole.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(model);
        }
        //Авторизация на сайте
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string returnUrl)//отображение страницы для авторизации
        {
            ViewBag.returnUrl = returnUrl;
            return View(new LoginViewModel());
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {

                IdentityUser userByName = await userManager.FindByNameAsync(model.UserName);


                if (userByName != null)
                {
                    await signInManager.SignOutAsync();

                    Microsoft.AspNetCore.Identity.SignInResult resultByName = await signInManager.PasswordSignInAsync(userByName.UserName, model.Password, model.RememberMe, false);
                    if (resultByName.Succeeded)
                    {

                        return Redirect(returnUrl ?? "/Home/Index");
                    }
                    ModelState.AddModelError(nameof(LoginViewModel.UserName), "Неверный логин или пароль");
                }
            }
            return View(model);
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword (ForgotPasswordViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = await userManager.FindByEmailAsync(viewModel.Email);
                if (user == null)
                {
                    return View("ForgotPasswordError");
                }
                var code = await userManager.GeneratePasswordResetTokenAsync(user);
                var callbackUrl = Url.Action("ResetPassword", "Account", new {userId = user.Id, code = code}, protocol: HttpContext.Request.Scheme);
                EmailService emailService = new EmailService();
                await emailService.SendEmailAsync(viewModel.Email, "Reset Password", $"Для сброса пароля перейдите по  <a href='{callbackUrl}'>ссылке</a>");
                return View("ForgotPasswordConfirm");
            }
            return View(viewModel);
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult ResetPassword (string code)
        {
            return code == null ? View("Error") : View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword (ResetPasswordViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }    
            IdentityUser user = await userManager.FindByEmailAsync (viewModel.Email);
            if (user == null)
            {
                return View(viewModel);
            }
            var result = await userManager.ResetPasswordAsync(user, viewModel.Code, viewModel.Password);
            if (result.Succeeded)
            {
                return View("ResetPasswordConfirm");
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);  
            }
            return View (viewModel);
        }

        [Authorize]
        public async Task <IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
