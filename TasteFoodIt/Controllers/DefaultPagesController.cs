using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodIt.Entities;
using TasteFoodIt.Context;

namespace TasteFoodIt.Controllers
{
    [AllowAnonymous]
    public class DefaultPagesController : Controller
    {
        TasteContext context = new TasteContext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult About()
        {
            ViewBag.pageName = "HAKKIMIZDA";
            ViewBag.reservationCount = context.Reservations.Count();
            ViewBag.chefCount = context.Chefs.Count();
            ViewBag.productCount = context.Products.Count();
            ViewBag.categoryCount = context.Categories.Count();
            return View();
        }
        public ActionResult Chef()
        {
            ViewBag.pageName = "ŞEFLERIMIZ";
            var values = context.Chefs.ToList();
            return View(values);
        }
        public ActionResult Menu()
        {
            ViewBag.pageName = "MENÜ";
            var values = context.Products.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult Contact()
        {
            ViewBag.pageName = "İLETİŞİM";
            return View();
        }
        [HttpPost]
        public ActionResult Contact(Contact p)
        {
            ViewBag.pageName = "İLETİŞİM";
            p.SendDate = DateTime.Now;
            context.Contacts.Add(p);
            context.SaveChanges();
            ModelState.Clear();
            return View();
        }
        public ActionResult Reservation()
        {
            ViewBag.pageName = "REZERVASYON";
            return View();
        }
    }
}