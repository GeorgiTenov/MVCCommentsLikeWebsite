using Komentirai.Models.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Komentirai.Models.ViewComponents
{
    public class CommentView : ViewComponent
    {
        private readonly Context _context;

        private readonly User _user;
        public CommentView(Context context, User user)
        {
            this._context = context;

            this._user = user;
        }
        public IViewComponentResult Invoke()
        {
            if (HttpContext.Session.GetInt32("userId") != null)
            {
                var user = _context.GetUserById((int)HttpContext.Session.GetInt32("userId"));
                return View(user);
            }
            return View(_user);
        }
    }
}
