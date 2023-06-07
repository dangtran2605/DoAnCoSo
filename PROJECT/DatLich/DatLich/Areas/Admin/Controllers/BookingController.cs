using DatLich.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DatLich.Areas.Admin.Controllers
{
    public class BookingController : Controller
    {
        private DataBase db=new DataBase();
        // GET: Admin/Booking
        public ActionResult Index() // chỉ hiển thị các booking chưa bị disable
        {
            if (Session["user"] != null)
            {
                
                return View(new DataBase().bookings.ToList());
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
            
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            if (Session["user"] != null)
            {
                ViewBag.id = id;
                var item = db.bookings.FirstOrDefault(p => p.id == id);
                return View(item);
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }

        }

        public ActionResult CheckDisable(int id)
        {
            var item = db.bookings.FirstOrDefault(p => p.id == id);
            if (item.isDisable == false || item.isDisable == null)
            {
                item.isDisable = true;
            }
            else
            {
                item.isDisable = false;
            }

            List<accountAD> model = db.accountADs.ToList();
            foreach (var ad in model)
            {
                if (ad.staff.fullName == Session["user"].ToString())
                {
                    item.idStaff = ad.id;
                    break;
                }
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult CheckConfirm(int id)
        {
            var item=db.bookings.FirstOrDefault(p=>p.id==id);
            if (item.isConfirm == false || item.isConfirm == null)
            {
                item.isConfirm = true;
            }
            else
            {
                item.isConfirm = false;
            }
            
            List<accountAD> model = db.accountADs.ToList();
            foreach (var ad in model)
            {
                if (ad.staff.fullName == Session["user"].ToString())
                {
                    item.idStaff = ad.id;
                    break;
                }
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Done(int id)
        {
            var item = db.bookings.FirstOrDefault(p => p.id == id);
            if (item.isDone == false || item.isDone == null)
            {
                item.isDisable = true;
            }
            else
            {
                item.isDisable = false;
            }
            //Check Done không lưu lại id Nhân viên thực hiện Action
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}