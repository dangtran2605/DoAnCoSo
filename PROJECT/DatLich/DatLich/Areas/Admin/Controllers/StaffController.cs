using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DatLich.Models;
namespace DatLich.Areas.Admin.Controllers
{
    public class StaffController : Controller
    {
        private DataBase db = new DataBase();
        // GET: Admin/Staff
       
        public ActionResult Index()
        {
            if (Session["user"] != null)
            {
                foreach (var item in db.staffs)
                {
                    if (item.fullName == Session["user"].ToString() && item.idPosition == 3)
                    {
                        return View(new DataBase().staffs.ToList());
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            return RedirectToAction("Login", "Home");
        }
        public ActionResult Create()
        {
            if (Session["user"] != null)
            {
                foreach (var item in db.staffs)
                {
                    if (item.fullName == Session["user"].ToString() && item.idPosition == 3)
                    {
                        return View();
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            return RedirectToAction("Login", "Home");
        }
        [HttpPost]
        public ActionResult Create(staff model)
        {
            if (Session["user"] != null)
            {
                foreach (var st in db.staffs)
                {
                    if (st.fullName == Session["user"].ToString() && st.idPosition == 3)
                    {
                        var item = new staff();
                        item.fullName = model.fullName;
                        item.address = model.address;
                        item.detail = model.detail;
                        item.phone = model.phone;
                        item.email = model.email;
                        if (model.idPosition != null&& model.idPosition != 0)
                        {
                            item.idPosition = model.idPosition;
                        }

                        if (model.born != null)
                        {
                            item.born = model.born;
                        }
                        db.staffs.Add(item);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
            return View();
            
        }

        public ActionResult Edit(int id)
        {
            if (Session["user"] != null)
            {
                foreach (var item in db.staffs)
                {
                    if (item.fullName == Session["user"].ToString() && item.idPosition == 3)
                    {
                        ViewBag.id = id;
                        var st = db.staffs.FirstOrDefault(p => p.id == id);
                        return View(st);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            return RedirectToAction("Login", "Home");
            
        }
        [HttpPost]
        public ActionResult Edit(staff model)
        {
            var item = db.staffs.Find(model.id);
            if (item != null)
            {
                item.fullName = model.fullName;
                item.address = model.address;
                item.detail = model.detail;
                item.phone = model.phone;
                item.email = model.email;
                if (model.idPosition != 0 && model.idPosition != 0)
                {
                    item.idPosition = model.idPosition;
                }
                
                if (model.born != null)
                {
                    item.born = model.born;
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public ActionResult Detail(int id)
        {
            if (Session["user"] != null)
            {
                foreach (var item in db.staffs)
                {
                    if (item.fullName == Session["user"].ToString() && item.idPosition == 3)
                    {
                        ViewBag.id = id;
                        var st = db.staffs.FirstOrDefault(p => p.id == id);
                        return View(st);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            return RedirectToAction("Login", "Home");
        }
        public ActionResult Delete(int id)
        {
            ViewBag.id = id;
            var st = db.staffs.SingleOrDefault(p => p.id == id);
            db.staffs.Remove(st);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}