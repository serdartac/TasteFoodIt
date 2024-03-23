using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodIt.Context;
using TasteFoodIt.Entities;

namespace TasteFoodIt.Controllers
{
    public class ContactController : Controller
    {
        TasteContext context = new TasteContext();
        public ActionResult MessageList()
        {
            var values = context.Contacts.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult ReadMessage(int id)
        {
            var values = context.Contacts.Find(id);
            context.SaveChanges();
            return View(values);
        }
        public ActionResult SendMessage(Contact p)
        {
            p.SendDate = DateTime.Now;
            context.Contacts.Add(p);
            context.SaveChanges();
            return RedirectToAction("Index", "Default");
        }

        [AllowAnonymous]
        [HttpPost]
        public JsonResult AddMailList(Mail mail)
        {
            System.Threading.Thread.Sleep(500);
           
            context.Mails.Add(mail);
            context.SaveChanges();
        
            return Json("başarılı", JsonRequestBehavior.AllowGet);
        }
    }
}