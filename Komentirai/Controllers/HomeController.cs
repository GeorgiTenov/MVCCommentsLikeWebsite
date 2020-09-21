using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Komentirai.Models;
using Komentirai.Models.Data;
using Komentirai.Models.Enums;

namespace Komentirai.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly Context _context;
        

        public HomeController(ILogger<HomeController> logger,Context context)
        {
            _logger = logger;

            _context = context;
            
        }

        public IActionResult Index()
        {
            var names = Enum.GetNames(typeof(Category)).ToList();
            ViewData["names"] = names;
            foreach(var name in names)
            {
               int count =  _context.SubjectCount(name);
            }
            return View(_context);
        }

     

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
