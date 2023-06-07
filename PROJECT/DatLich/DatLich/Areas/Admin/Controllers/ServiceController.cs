using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DatLich.Models;
namespace DatLich.Areas.Admin.Controllers
{
    public class ServiceController : Controller
    {
        private DataBase db = new DataBase();
        // GET: Admin/Service
        
        public ActionResult Index()
        {
            if (Session["user"] != null)
            {
                foreach (var item in db.staffs)
                {
                    if (item.fullName == Session["user"].ToString() && item.idPosition >= 2)
                    {
                        return View(new DataBase().services.ToList());
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
        public ActionResult Create(service model, HttpPostedFileBase Image, bool IsActive = false)
        {
            if(model!=null)
            {
                var item = new service();
                item.serviceName = model.serviceName;
                item.price = model.price;
                item.detail = model.detail;
                if (Image != null && Image.ContentLength > 0)
                {
                    string location = "/Models/Image/";
                    string rootFolder = Server.MapPath(location);
                    string pathImage = rootFolder + Image.FileName;
                    Image.SaveAs(pathImage);
                    item.image = location + Image.FileName;
                }
                else
                {
                    item.image = null;
                }
                if (model.idSale != null && model.idSale != 0)
                {
                    item.idSale = model.idSale;
                    var SEL =db.sales.ToList();
                    foreach(var empty in SEL)
                    {
                        if (empty.id == item.idSale)
                        {
                            item.priceSale = item.price - (empty.isNumble / 100 * item.price);
                            break;
                        }
                    }
                    
                }
                else
                {
                    item.priceSale = item.price;
                }
                if (model.idCategory != null && model.idCategory != 0)
                {
                    item.idCategory = model.idCategory;
                }
                item.isActive = IsActive;
                db.services.Add(item);
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
                        ViewBag.id = id;
                        var sv = db.services.FirstOrDefault(p => p.id == id);
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
        public ActionResult Edit(service model, HttpPostedFileBase Image, bool IsActive = false)
        {
            
            var item = db.services.Find(model.id);
            if (item != null) 
            {
                if (model != null)
                {
                    item.serviceName = model.serviceName;
                    item.price = model.price;
                   
                    item.detail = model.detail;
                    if (Image != null && Image.ContentLength > 0)
                    {
                        string location = "/Models/Image/";
                        string rootFolder = Server.MapPath(location);
                        string pathImage = rootFolder + Image.FileName;
                        Image.SaveAs(pathImage);
                        item.image = location + Image.FileName;
                    }
                    if (model.idCategory != null && model.idCategory != 0)
                    {
                        item.idCategory = model.idCategory;
                    }
                    if (model.idSale != null && model.idSale != 0)
                    {
                        item.idSale = model.idSale;
                        var SEL = db.sales.ToList();
                        foreach (var empty in SEL)
                        {
                            if (empty.id == item.idSale)
                            {
                                item.priceSale = item.price - (empty.isNumble / 100 * item.price);
                                break;
                            }
                        }


                    }
                    else
                    {
                        item.priceSale = item.price;
                    }
                    
                    item.isActive = IsActive;
                    db.SaveChanges();
                    if(item.sale!= null)
                    {
                        item.priceSale = item.price - (item.sale.isNumble / 100 * item.price);
                    }
                    db.SaveChanges();
                    return RedirectToAction("Index");
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
                    if (item.fullName == Session["user"].ToString() && item.idPosition >= 2)
                    {
                        ViewBag.id = id;
                        var st = db.services.FirstOrDefault(p => p.id == id);
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
            var item = db.services.FirstOrDefault(p => p.id == id);
            db.services.Remove(item);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}