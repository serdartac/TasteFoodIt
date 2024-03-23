using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodIt.Context;
using TasteFoodIt.Entities;

namespace TasteFoodIt.Controllers
{
    public class ChefController : Controller
    {
        TasteContext context = new TasteContext();
        public ActionResult ChefList()
        {
            var value = context.Chefs.ToList();
            return View(value);
        }
        [HttpGet]
        public ActionResult CreateChef()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateChef(Chef p)
        {
            context.Chefs.Add(p);
            context.SaveChanges();
            return RedirectToAction("ChefList");
        }
        public ActionResult DeleteChef(int id)
        {
            var value = context.Chefs.Find(id);
            context.Chefs.Remove(value);
            context.SaveChanges();
            return RedirectToAction("ChefList");
        }
        [HttpGet]
        public ActionResult UpdateChef(int id)
        {
            var value = context.Chefs.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateChef(Chef p)
        {
            var value = context.Chefs.Find(p.ChefId);
            value.NameSurname = p.NameSurname;
            value.Title = p.Title;
            value.Description = p.Description;
            value.ImageUrl = p.ImageUrl;
            context.SaveChanges();
            return RedirectToAction("ChefList");
        }
    }
}