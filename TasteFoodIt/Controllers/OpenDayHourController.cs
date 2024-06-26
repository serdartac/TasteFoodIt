﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodIt.Context;
using TasteFoodIt.Entities;

namespace TasteFoodIt.Controllers
{
    public class OpenDayHourController : Controller
    {
        TasteContext context = new TasteContext();
        public ActionResult OpenDayHourList()
        {
            var value = context.OpenDayHours.ToList();
            return View(value);
        }
        [HttpGet]
        public ActionResult CreateOpenDayHour()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateOpenDayHour(OpenDayHour p)
        {
            context.OpenDayHours.Add(p);
            context.SaveChanges();
            return RedirectToAction("OpenDayHourList");
        }
        public ActionResult DeleteOpenDayHour(int id)
        {
            var value = context.OpenDayHours.Find(id);
            context.OpenDayHours.Remove(value);
            context.SaveChanges();
            return RedirectToAction("OpenDayHourList");
        }
        [HttpGet]
        public ActionResult UpdateOpenDayHour(int id)
        {
            var value = context.OpenDayHours.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateOpenDayHour(OpenDayHour p)
        {
            var value = context.OpenDayHours.Find(p.OpenDayHourId);
            value.DayName = p.DayName;
            value.OpenHourRange = p.OpenHourRange;
            context.SaveChanges();
            return RedirectToAction("OpenDayHourList");
        }
    }
}