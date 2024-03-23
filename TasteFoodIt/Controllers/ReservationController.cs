using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodIt.Context;
using TasteFoodIt.Entities;

namespace TasteFoodIt.Controllers
{
    
    public class ReservationController : Controller
    {
        TasteContext context = new TasteContext();

        public ActionResult ReservationList()
        {
            var values = context.Reservations.ToList();
            return View(values);
        }
        [HttpPost]
        public JsonResult CreateReservation(Reservation reservation)
        {
            reservation.ReservationStatus = "beklemede";
            context.Reservations.Add(reservation);
            context.SaveChanges();

            return Json(reservation, JsonRequestBehavior.AllowGet);
        }
        public ActionResult AcceptReservation(int id)
        {
            var reservation = context.Reservations.Find(id);
            reservation.ReservationStatus = "onaylandi";
            context.SaveChanges();
            return RedirectToAction("ReservationList");
        }
        public ActionResult WaitReservation(int id)
        {
            var reservation = context.Reservations.Find(id);
            reservation.ReservationStatus = "beklemede";

            context.SaveChanges();
            return RedirectToAction("ReservationList");
        }
        public ActionResult CancelReservation(int id)
        {
            var reservation = context.Reservations.Find(id);
            reservation.ReservationStatus = "iptal";

            context.SaveChanges();
            return RedirectToAction("ReservationList");
        }


        public ActionResult DeleteReservation(int id)
        {
            var Reservation = context.Reservations.Find(id);

            context.Reservations.Remove(Reservation);
            context.SaveChanges();
            return RedirectToAction("ReservationList");
        }
    }
}