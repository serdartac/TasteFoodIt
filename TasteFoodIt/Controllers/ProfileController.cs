using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodIt.Context;
using TasteFoodIt.Entities;

namespace TasteFoodIt.Controllers
{
    public class ProfileController : Controller
    {
        TasteContext context = new TasteContext();
        public ActionResult Index()
        {
            var value = context.Admins.ToList();
            return View(value);
        }
    }
}