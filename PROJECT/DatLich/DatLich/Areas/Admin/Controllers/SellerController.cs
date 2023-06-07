using DatLich.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DatLich.Areas.Admin.Controllers
{
    public class SellerController : Controller
    {
        private DataBase db=new DataBase();
        // GET: Admin/Seller
        public ActionResult Index()
        {
            if (Session["user"] != null)
            {
                foreach (var item in db.staffs)
                {
                    if (item.fullName == Session["user"].ToString() && item.idPosition >= 2)
                    {
                        return View(new DataBase().sales.ToList());
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
                    if (item.fullName == Session["user"].ToString() && item.idPosition >= 2)
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
        public ActionResult Create(sale Sale, HttpPostedFileBase Image, bool Status=false)
        {
            if (Sale != null)
            {
                var item = new sale();
                item.isNumble=Sale.isNumble;
                item.discount= "Giảm giá "+item.isNumble.ToString()+"%";
                if (Image != null && Image.ContentLength > 0)
                {
                    string location = "/Models/Image/";
                    string rootFolder = Server.MapPath(location);
                    string pathImage = rootFolder + Image.FileName;
                    Image.SaveAs(pathImage);
                    item.image = location + Image.FileName;
                }
                item.status = Status;
                db.sales.Add(item);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            if (Session["user"] != null)
            {
                foreach (var item in db.staffs)
                {
                    if (item.fullName == Session["user"].ToString() && item.idPosition >= 2)
                    {
                        var sv = db.sales.FirstOrDefault(p => p.id == id);
                        return View(sv);
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
        public ActionResult Edit(sale Sale, HttpPostedFileBase Image, bool Status = false)
        {
            if (Sale != null)
            {
                var item = db.sales.Find(Sale.id);
                if (Sale.isNumble != null)
                {
                    item.isNumble = Sale.isNumble;
                    item.discount = "Giảm giá " + item.isNumble.ToString() + "%";
                }
                if (Image != null && Image.ContentLength > 0)
                {
                    string location = "/Models/Image/";
                    string rootFolder = Server.MapPath(location);
                    string pathImage = rootFolder + Image.FileName;
                    Image.SaveAs(pathImage);
                    item.image = location + Image.FileName;
                }
                item.status = Status;
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
                    if (item.fullName == Session["user"].ToString() && item.idPosition >= 2)
                    {
                        var sv = db.sales.FirstOrDefault(p => p.id == id);
                        return View(sv);
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
            var item = db.sales.FirstOrDefault(p => p.id == id);
            db.sales.Remove(item);
            return RedirectToAction("Index");
        }

    }
}