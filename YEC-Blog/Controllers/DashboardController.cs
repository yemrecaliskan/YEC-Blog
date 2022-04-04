﻿using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YEC_Blog.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            Context c = new Context();
            ViewBag.toplamBlogSayisi = c.Blogs.Count();
            ViewBag.writerBlogSayisi = c.Blogs.Where(x => x.WriterID == 1).Count();
            ViewBag.kategoriSayisi = c.Categories.Count();
            return View();
        }
    }
}
