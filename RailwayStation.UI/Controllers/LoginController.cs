﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RailwayStation.DTO.DTOs.Users;
using RailwayStation.Entity.Modals;

namespace RailwayStation.UI.Controllers
{
    public class LoginController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(UserRegisterDTO p)
        {
            AppUser appUser = new AppUser()
            {
                NameSurname = p.Name + ' ' + p.Surname,
                Email = p.Mail,
                UserName = p.Username
            };
            if (p.Password == p.ConfirmPassword)
            {
                var result = await _userManager.CreateAsync(appUser, p.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("SignIn");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(p);
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(UserSignInDTO p)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(p.username, p.password, false, true);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToAction("SignIn", "Login");
                }
            }
            return View();
        }


    }
}