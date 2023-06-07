using DatLich.Models;
using DatLich.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DatLich.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        private DataBase db=new DataBase();
        // GET: Admin/Account
        public ActionResult Index()
        {
            if (Session["user"] != null)
            {
                foreach (var item in db.staffs)
                {
                    if (item.fullName == Session["user"].ToString() && item.idPosition == 3)
                    {
                        return View(new DataBase().accountADs.ToList());
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
        public ActionResult Create(VMaccount acc, bool IsActive = false)
        {
            if (acc.passWord == acc.confirmPassword)
            {
                var item = new accountAD();
                item.userName = acc.userName;
                item.passWord = acc.passWord;
                if (acc.idStaff != 0)
                {
                    item.idStaff = acc.idStaff;
                }
                item.isActive = IsActive;
                db.accountADs.Add(item);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                TempData["error"] = "Confirm Password not icored password";
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
                        var acc = db.accountADs.FirstOrDefault(p => p.id == id);
                        return View(acc);
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
        public ActionResult Edit(VMaccount acc, bool IsActive = false)
        {
            if (acc.passWord=="")
            {
                TempData["error"] = "Password not be required";
                return View();
            }
            else
            {
                if (acc.passWord == acc.confirmPassword)
                {

                    var item = db.accountADs.Find(acc.id);
                    item.userName = acc.userName;
                    item.passWord = acc.passWord;
                    if (acc.idStaff != 0)
                    {
                        item.idStaff = acc.idStaff;
                    }
                    item.isActive = IsActive;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["error"] = "Password and confirm password not match ";
                }
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
                        var acc = db.accountADs.FirstOrDefault(p => p.id == id);
                        return View(acc);
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
            var item = db.accountADs.SingleOrDefault(p => p.id == id);
            db.accountADs.Remove(item);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}