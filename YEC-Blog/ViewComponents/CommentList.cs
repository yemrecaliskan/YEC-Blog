using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YEC_Blog.Models;

namespace YEC_Blog.ViewComponents
{
    public class CommentList : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var commentValues = new List<UserComment>
            {
                new UserComment
                {
                    ID = 1,
                    Username = "Yunus"
                },
                new UserComment
                {
                    ID =2,
                    Username = "Aslı"
                },
                new UserComment
                {
                    ID =3,
                    Username = "Elif"
                },
            };
            return View(commentValues);
        }
    }
}
