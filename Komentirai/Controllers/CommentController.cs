using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Komentirai.Models;
using Komentirai.Models.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Komentirai.Controllers
{
    [Route("Subject/[controller]/[action]")]
    public class CommentController : Controller
    {
        private readonly Context _context;

        public CommentController(Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

       
        [HttpGet]
        public IActionResult Add()
        {

            if (HttpContext.Session.GetInt32("userId") == null)
            {
                return RedirectToAction("Login", "User");
            }
            else
            {
                var user = _context.GetUserById((int)HttpContext.Session.GetInt32("userId"));
                if (user.IsLogged)
                {
                    return View();
                }
                return RedirectToAction("Login", "User");

            }
           
        }

       
        [HttpPost]

        public RedirectToActionResult Add(Comment comment)
        {
            Subject subject = null;
            if(TempData["subjectId"] != null)
            {
                int id = (int)TempData["subjectId"];
                subject = _context.GetSubjectById(id);
                comment.Subject = subject;
            }
            User user = null;

            if (HttpContext.Session.GetInt32("userId") != null)
            {
                 user = _context.GetUserById((int)HttpContext.Session.GetInt32("userId"));
            }
         
            comment.User = user;
            _context.AddComment(comment);

            if (subject == null)
            {
                return RedirectToAction("Login", "User");
            }
           
            
            return RedirectToAction("Details","Subject",new { subject.Id });
        }

       
    }
}