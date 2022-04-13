using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YEC_Blog.Controllers
{
    public class DashboardController : Controller
    {
        Context c = new Context();

        public IActionResult Index()
        {
            var userName = User.Identity.Name;
            var userMail = c.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            var writerID = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterID).FirstOrDefault();
            ViewBag.toplamBlogSayisi = c.Blogs.Count();
            ViewBag.writerBlogSayisi = c.Blogs.Where(x => x.WriterID == writerID).Count();
            ViewBag.kategoriSayisi = c.Categories.Count();
            return View();
        }
    }
}
