using Marketplace.Core.Domain;
using Marketplace.WebApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marketplace.WebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;

        private readonly UserManager<ApplicationUser> _userManager;

        public AccountController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View(new LoginVM());
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (!ModelState.IsValid)
            {
                return View(loginVM);
            }

            var user = await _userManager.FindByEmailAsync(loginVM.UserName);

            if (user != null)
            {
                //logowanie
                var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            ModelState.AddModelError("", "Niepoprawna nazwa użytkownika lub hasło...");

            return View(loginVM);
        }

        [HttpPost]
        public async Task<IActionResult> Register(LoginVM loginVM)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser()
                {
                    Email = loginVM.UserName,
                    UserName = loginVM.UserName
                };

                Console.WriteLine("Register");

                var result = await _userManager.CreateAsync(user, loginVM.Password);

                if (result.Succeeded)
                {
                    //TempData["RegisterMessage"] = "Success";
                    var resultLogin = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);

                    if (resultLogin.Succeeded)
                    {
                        return RedirectToAction("Create", "Profiles");
                    }

                    else
                    {
                        return RedirectToAction("Login", "Account");
                    }
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(loginVM);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
