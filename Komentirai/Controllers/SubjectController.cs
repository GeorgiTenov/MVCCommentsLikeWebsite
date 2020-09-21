using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Komentirai.Models;
using Komentirai.Models.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language;

namespace Komentirai.Controllers
{
    public class SubjectController : Controller
    {
        private readonly Context _context;

        public SubjectController(Context context)
        {
            this._context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            if(HttpContext.Session.GetInt32("userId") == null)
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
        public RedirectToActionResult Add(Subject subject)
        {
            if(HttpContext.Session.GetInt32("userId")!= null)
            {
                var user = _context.GetUserById((int)HttpContext.Session.GetInt32("userId"));
                subject.User = user;
                _context.AddSubject(subject);
                
            }
            return RedirectToAction("Index","Home");
        }
        public IActionResult ShowSubjects()
        {
            var users = _context.GetUsers();
            var subjects = _context.GetSubjects();
           
            return View(subjects);
        }

        public async Task<IActionResult> Details(int id)
        {
            TempData["subjectId"] = id;
            ViewData["Comments"] = _context.GetCommentsBySubjectId(id);
            var users = _context.GetUsers();
            CookieOptions options = new CookieOptions();
            Response.Cookies.Append("detailId", ""+id, options);
            return View(_context.GetSubjectById(id));

        }

     
    }
}