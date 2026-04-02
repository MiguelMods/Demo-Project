using demo.project.site.Models.ViewModels;
using demo.proyect.application.Services.Contract;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace demo.project.site.Controllers
{
    [AllowAnonymous]
    public class AccountController(IUserService userService) : Controller
    {
        private readonly IUserService userService = userService;

        public IActionResult Index(string returnUrl = "")
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = "")
        {
            if(!ModelState.IsValid)
                return View("index", model);

            var result = await userService.SiginAsync(model.UserName, model.Password);

            if (!result.IsSuccess) 
            {
                ModelState.AddModelError("", result.Message);
                return View("index", model);
            }

            var properties = new AuthenticationProperties
            {
                IsPersistent = model.RememberMe,
                ExpiresUtc = DateTime.UtcNow.AddDays(7),
                AllowRefresh = true
            };

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, result.Data, properties);

            if (!string.IsNullOrEmpty(returnUrl))
               return Redirect(returnUrl);

            return Redirect("/home/index");
        }

        public async Task<IActionResult> AccessDenied() 
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("index");
        }
    }
}
