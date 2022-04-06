using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace YEC_Blog.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic1 : ViewComponent
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.BlogCount = bm.GetList().Count();
            ViewBag.ContactCount = c.Contacts.Count();
            ViewBag.CommentCount = c.Comments.Count();

            string api = "eedd1e51582340e4eb56f12dcc43e443";
            string connection = "https://api.openweathermap.org/data/2.5/weather?q=istanbul&mode=xml&lang=tr&units=metric&appid=" + api;
            XDocument document = XDocument.Load(connection);
            ViewBag.temp = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            return View();
        }
    }
}
