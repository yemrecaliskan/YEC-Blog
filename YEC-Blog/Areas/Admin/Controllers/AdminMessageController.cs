using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YEC_Blog.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminMessageController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        Message2Manager mm = new Message2Manager(new EfMessage2Repository());
        Context c = new Context();

        public AdminMessageController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
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

        [HttpGet]
        public IActionResult ComposeMessage()
        {
            return View(Tuple.Create<Message2, AppUser>(new Message2(), new AppUser()));
        }

        [HttpPost]
        public async Task<IActionResult> ComposeMessage([Bind(Prefix = "Item1")] Message2 message, [Bind(Prefix = "Item2")] AppUser writer)
        {
            var sender = await _userManager.FindByNameAsync(User.Identity.Name);
            var receiver = await _userManager.FindByEmailAsync(writer.Email);
            message.SenderID = sender.Id;
            message.ReceiverID = receiver.Id;
            message.MessageDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            message.MessageStatus = true;
            mm.AddT(message);
            return RedirectToAction("Sendbox");
        }
    }
}
