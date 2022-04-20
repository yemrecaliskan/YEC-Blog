using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YEC_Blog.Controllers
{
    public class MessageController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        Message2Manager mm = new Message2Manager(new EfMessage2Repository());
        Context c = new Context();

        public MessageController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<List<AppUser>> GetUsersAsync()
        {
            using (var context = new Context())
            {
                return await context.Users.ToListAsync();
            }
        }

        public async Task<IActionResult> Inbox()
        {
            var user = await _userManager.GetUserAsync(User);
            int userId = user.Id;
            var values = mm.GetInboxListByWriter(userId);
            return View(values);
        }

        public async Task<IActionResult> Sendbox()
        {
            var user = await _userManager.GetUserAsync(User);
            int userId = user.Id;
            var values = mm.GetSendboxListByWriter(userId);
            return View(values);
        }

        public IActionResult MessageDetails(int id)
        {
            var value = mm.TGetById(id);
            return View(value);
        }

        [HttpGet]
        public async Task<IActionResult> SendMessage()
        {
            List<SelectListItem> recieverUsers = (from x in await GetUsersAsync()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.Email.ToString(),
                                                      Value = x.Id.ToString()
                                                  }).ToList();
            //Burası Yukarıda Çektiğimiz Verileri Front-End Tarafına Taşıyoruz.
            ViewBag.RecieverUser = recieverUsers;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(Message2 p)
        {
            var user = await _userManager.GetUserAsync(User);
            int userId = user.Id;
            p.SenderID = userId;
            p.ReceiverID = 2;
            p.MessageStatus = true;
            p.MessageDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            mm.AddT(p);
            return RedirectToAction("Inbox");
        }
    }
}
