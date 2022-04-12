using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YEC_Blog.Areas.Admin.Models;

namespace YEC_Blog.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WriterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult WriterList()
        {
            var jsonWriters = JsonConvert.SerializeObject(writers);
            return Json(jsonWriters);
        }

        public IActionResult GetWriterByID(int writerID)
        {
            var findWriter = writers.FirstOrDefault(x => x.ID == writerID);
            var jsonWriters = JsonConvert.SerializeObject(findWriter);
            return Json(jsonWriters);
        }

        [HttpPost]
        public IActionResult AddWriter(WriterModel w)
        {
            writers.Add(w);
            var jsonWriters = JsonConvert.SerializeObject(w);
            return Json(jsonWriters);
        }

        public IActionResult DeleteWriter(int id)
        {
            var writer = writers.FirstOrDefault(x => x.ID == id);
            writers.Remove(writer);
            return Json(writer);
        }

        public IActionResult UpdateWriter(WriterModel w)
        {
            var writer = writers.FirstOrDefault(x => x.ID == w.ID);
            writer.Name = w.Name;
            var jsonWriter = JsonConvert.SerializeObject(w);
            return Json(jsonWriter);
        }

        public static List<WriterModel> writers = new List<WriterModel>
        {
            new WriterModel
            {
                ID=1,
                Name = "Yunus"
            },
            new WriterModel
            {
                ID=2,
                Name = "Emre"
            },
            new WriterModel
            {
                ID=3,
                Name = "Çalışkan"
            }
        };
    }
}
