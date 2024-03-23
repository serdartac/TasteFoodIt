using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodIt.Context;
using TasteFoodIt.Entities;

namespace TasteFoodIt.Controllers
{
    public class AddressController : Controller
    {
        TasteContext context = new TasteContext();
        [HttpGet]
        public ActionResult AddressList()
        {
            var value = context.Addresses.FirstOrDefault();
            return View(value);
        }
        [HttpPost]
        public ActionResult AddressList(Address p)
        {
            var value = context.Addresses.Find(p.AddressId);
            value.Phone = p.Phone;
            value.Email = p.Email;
            value.Description = p.Description;
            context.SaveChanges();
            return RedirectToAction("AddressList");
        }
    }
}