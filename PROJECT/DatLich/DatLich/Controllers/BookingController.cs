using DatLich.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DatLich.Controllers
{
    public class BookingController : Controller
    {
        private DataBase db = new DataBase();
        // GET: Booking
        public ActionResult Service()
        {
            var ser = db.services.ToList();
            return View(ser);
        }

        public ActionResult ListServiceByIdBooking(int id)
        {
            List<detailBooking> sv= new List<detailBooking> ();
            foreach(var item in db.detailBookings)
            {
                if(item.idBooking == id)
                {
                    sv.Add(item);
                }
            }
            return View(sv);
        }
        public ActionResult CreateAppointment()
        {
            var ser = db.services.ToList();
            ViewBag.Service = ser;
            return View(new booking());
        }

        [HttpPost]
        public ActionResult CreateAppointment(booking appointment, List<int> ServiceID)
        {
            if (ModelState.IsValid)
            {
                db.bookings.Add(appointment);
                db.SaveChanges();
                int ID = appointment.id;

                if (ServiceID != null)
                {
                    foreach (var id in ServiceID)
                    {
                        var dBKing = new detailBooking();
                        dBKing.idService = id;
                        dBKing.idBooking = ID;
                        db.detailBookings.Add(dBKing);
                        db.SaveChanges();
                    }
                }
   
                return RedirectToAction("AppointmentDetails", new { id = appointment.id });
            }
            else
            {
                var ser = db.services.ToList();
                ViewBag.Service = ser;
                return View();
            }
        }
        [HttpGet]
        public ActionResult AppointmentDetails(int id)
        {
            var appointment = db.bookings.FirstOrDefault(p=>p.id==id);
            return View(appointment);
        }

        
        [HttpPost]
        public ActionResult AppointmentDetailsByPhone(string phone)
        {
            List<booking> item = new List<booking>();
            foreach(var employ in db.bookings)
            {
                if(employ.phone == phone)
                {
                    item.Add(employ);
                }
            }
            ViewBag.PhoneNumber = phone;
            return View(item);
        }

    }
}