using Blog.Bus;
using Blog.Services;
using Blog.ViewModels;
using Blog.Write.Commands.User;
using Blog.Write.Exceptions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Blog.Controllers
{
    public class AuthController : Controller
    {
        private readonly ICommandBus commandBus;
        private readonly AuthService authService;

        public AuthController(ICommandBus commandBus, AuthService authService)
        {
            this.commandBus = commandBus;
            this.authService = authService;
        }

        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel vm, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var identity = authService.Login(vm.Username, vm.Password);
                    await signIn(identity);
                    if (!string.IsNullOrWhiteSpace(returnUrl) && Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    return RedirectToAction("Index", "Post");
                }
                catch (InvalidLoginException e)
                {
                    ModelState.AddModelError("Summary", "Nie ma takiego użytkownika");
                }
                catch (InvalidPasswordException e)
                {
                    ModelState.AddModelError("Summary", "Złe hasło");
                }
                catch (UserNotActiveException e)
                {
                    ModelState.AddModelError("Summary", "Konto zablokowane");
                }
            }
            return View(vm);
        }

        public IActionResult Register()
        {
            return View(new RegisterViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel vm, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var identity = authService.Register(vm.Username, vm.Password, vm.ConfirmPassword);
                    await signIn(identity);
                    if (!string.IsNullOrWhiteSpace(returnUrl) && Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    return RedirectToAction("Index", "Post");
                }
                catch (UsernameTakenException)
                {
                    ModelState.AddModelError(nameof(vm.Username), "Ten login jest już zajęty");
                }
                catch (PasswordsDontMatchException)
                {
                    ModelState.AddModelError(nameof(vm.ConfirmPassword), "Hasła się nie zgadzają");
                }
            }
            return View(vm);
        }

        private async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Post");
        }

        private async Task signIn(ClaimsIdentity identity)
        {
            await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(identity));
        }
    }
}