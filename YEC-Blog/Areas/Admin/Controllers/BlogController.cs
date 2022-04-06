using ClosedXML.Excel;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using YEC_Blog.Areas.Admin.Models;

namespace YEC_Blog.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        public IActionResult ExportExcelBlogList()
        {
            using (var workBook = new XLWorkbook())
            {
                var workSheet = workBook.Worksheets.Add("Blog Listesi");
                workSheet.Cell(1, 1).Value = "Blog ID";
                workSheet.Cell(1, 2).Value = "Blog Adı";

                int BlogRowCount = 2;
                foreach (var item in GetBlogList())
                {
                    workSheet.Cell(BlogRowCount, 1).Value = item.ID;
                    workSheet.Cell(BlogRowCount, 2).Value = item.BlogName;
                    BlogRowCount++;
                }

                using (var stream = new MemoryStream())
                {
                    workBook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application / vnd.openxmlformats-officedocument.spreadsheetml.sheet", "BlogList.xlsx");
                }
            }
        }

        public List<BlogModel> GetBlogList()
        {
            List<BlogModel> bm = new List<BlogModel>();
            using (var c = new Context())
            {
                bm = c.Blogs.Select(x => new BlogModel
                {
                    ID = x.BlogID,
                    BlogName = x.BlogTitle
                }).ToList();
            }
            return bm;
        }

        public IActionResult BlogListExcel()
        {
            return View();
        }
    }
}
