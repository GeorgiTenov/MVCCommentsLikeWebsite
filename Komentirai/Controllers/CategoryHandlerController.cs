using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Komentirai.Models.Data;
using Komentirai.Models.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Komentirai.Controllers
{
    public class CategoryHandlerController : Controller
    {
        private readonly Context _context;

        public CategoryHandlerController(Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
       
        public IActionResult HandleCategories(string item)
        {
           var users = _context.GetUsers();
           var subs =  _context.GetSubjectsByCategoryName(item);
            return View(subs);
        }

        public IActionResult SearchSubjects(string title)
        {
            var subjects =  _context.GetSubjectsByTitle(title);
            var users = _context.GetUsers();
            return View(subjects);
        }
    }
}