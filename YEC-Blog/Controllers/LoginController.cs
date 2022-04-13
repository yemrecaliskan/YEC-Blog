﻿using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using YEC_Blog.Models;

namespace YEC_Blog.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserSignInViewModel p)
        {
            if(ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(p.UserName, p.Password, false, true);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    return RedirectToAction("Index", "Login");
                }
            }
            return View();
           
        }
        //[HttpPost]
        //public async Task<IActionResult> Index(Writer p)
        //{
        //    Context c = new Context();
        //    var dataValue = c.Writers.FirstOrDefault(x => x.WriterMail == p.WriterMail && x.WriterPassword == p.WriterPassword);
        //    if(dataValue != null)
        //    {
        //        var claims = new List<Claim>
        //        {
        //            new Claim(ClaimTypes.Name,p.WriterMail)
        //        };
        //        var userIdentity = new ClaimsIdentity(claims,"a");
        //        ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
        //        await HttpContext.SignInAsync(principal);
        //        return RedirectToAction("Index", "Dashboard");
        //    }
        //    else
        //    {
        //        return View();
        //    }
        //}
    }
}