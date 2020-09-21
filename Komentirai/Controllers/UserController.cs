using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Komentirai.Models;
using Komentirai.Models.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Komentirai.Controllers
{
    public class UserController : Controller
    {
        private readonly Context _context;

        private readonly IWebHostEnvironment _host;
        public UserController(Context context,IWebHostEnvironment host)
        {
            this._context = context;

            this._host = host;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username,string password)
        {
            var user = _context.GetUserByUsernameAndPassword(username,password);
            if(user != null)
            {
                HttpContext.Session.SetInt32("userId", user.Id);
                user.LogIn();
                return RedirectToAction("Index","Home");
            }
           
            return View();
        }

        public RedirectToActionResult LogOut()
        {
            int id = (int)HttpContext.Session.GetInt32("userId");
            var user = _context.GetUserById(id);
            user.LogOut();
            return RedirectToAction("LogIn");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user,string confirmPassword)
        {
           var userExist = _context.GetUsers().FirstOrDefault(u => 
                                                u.Username.Equals(user.Username) 
                                                && u.Email.Equals(user.Email));
            
            if(userExist == null && user.CheckUsername() && user.CheckPassword())
            {
                if (user.Password.Equals(confirmPassword))
                {
                    user.SaveProfilePicture(user.ProfilePicture, _host);
                    user.Context = _context;


                    _context.AddUser(user);
                }
               
               
            }
            else
            {
                return View("Views/User/UserAlreadyExist.cshtml");
            }
           
            return RedirectToAction("Login");
        }

        public async Task<IActionResult> ShowSubjects()
        {
            if (HttpContext.Session.GetInt32("userId") != null)
            {
                var user = _context
                    .GetUserById((int)HttpContext.Session.GetInt32("userId"));

                user.Context = _context;

                var subjects =await user.GetSubjects();
                return View(subjects);
            }
            return View();
        }
    }
}