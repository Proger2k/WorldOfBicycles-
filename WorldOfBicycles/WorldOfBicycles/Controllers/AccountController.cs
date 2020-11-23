using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WorldOfBicycles.Data;
using WorldOfBicycles.Data.Models;
using WorldOfBicycles.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorldOfBicycles.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ShopCart shopCart;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, ShopCart shopCart)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            this.shopCart = shopCart;
        }
        [HttpGet]
        public IActionResult Register()
        {
            ViewBag.ProductCount = shopCart.ProductCount();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User {Name = model.Name, Email = model.Email, UserName = model.Email, Year = model.Year};
                // добавляем пользователя
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    // установка куки
                    await _signInManager.SignInAsync(user, false);
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
            ViewBag.ProductCount = shopCart.ProductCount();
            return View(model);
        }


        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            ViewBag.ProductCount = shopCart.ProductCount();
            return View(new LoginViewModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result =
                await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    // проверяем, принадлежит ли URL приложению
                    if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Неправильный логин и (или) пароль");
                }
            }
            ViewBag.ProductCount = shopCart.ProductCount();
            return View(model);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            // удаляем аутентификационные куки
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
