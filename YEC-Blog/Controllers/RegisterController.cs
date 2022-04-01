using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YEC_Blog.Controllers
{
    public class RegisterController : Controller
    {
        WriterManager wm = new WriterManager(new EfWriterRepository());

        [HttpGet]
        public IActionResult Index()
        {
            List<Sehir> Sehirler = new List<Sehir>
            {
                new Sehir { ID = 1, Adi = "İstanbul"},
                new Sehir { ID = 2, Adi = "Ankara"},
                new Sehir { ID = 3, Adi = "İzmir"},
                new Sehir { ID = 4, Adi = "Ordu"}
            };
            ViewBag.Sehirler = new SelectList(Sehirler, "ID", "Adi");
            return View();
        }
        [HttpPost]
        public IActionResult Index(Writer p)
        {
            WriterValidator wv = new WriterValidator();
            ValidationResult results = wv.Validate(p);
            if(results.IsValid)
            {
                p.WriterStatus = true;
                p.WriterAbout = "Deneme";
                wm.AddT(p);
                return RedirectToAction("Index", "Blog");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
            
        }
    }
    class Sehir
    {
        public int ID { get; set; }
        public string Adi { get; set; }
    }
}
