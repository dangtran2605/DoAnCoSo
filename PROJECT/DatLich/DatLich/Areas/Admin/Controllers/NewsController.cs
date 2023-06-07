using DatLich.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DatLich.Areas.Admin.Controllers
{
    public class NewsController : Controller
    {
        private DataBase db=new DataBase();
        // GET: Admin/News
        
        public ActionResult Index()
        {
            if (Session["user"] != null)
            {
                return View(new DataBase().news.ToList());
            }
            return RedirectToAction("Login", "Home");

        }
        
        public ActionResult Create()
        {
            if (Session["user"] != null)
            {
                return View();
            }
            return RedirectToAction("Login", "Home");
            
        }
        [HttpPost]
        public ActionResult Create(news NewS, HttpPostedFileBase Image,bool IsActive =false) 
        {

            var item = new news();
            item.dateCreate = DateTime.Now;
            List<accountAD> model = db.accountADs.ToList(); 
            foreach (var ad in model)
            {
                if (ad.staff.fullName == Session["user"].ToString())
                {
                    item.createById = ad.id;
                    break;
                }
            }
            item.newsTitle = NewS.newsTitle;
            item.detail = NewS.detail;
            item.description = NewS.description;
            if (Image!=null && Image.ContentLength > 0)
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
            item.isActive = IsActive;
            db.news.Add(item);
            db.SaveChanges();
            return RedirectToAction("Index");


        }
    
        public ActionResult Edit(int id)
        {
            if (Session["user"] != null)
            {
                ViewBag.id = id;
                var item = db.news.FirstOrDefault(p => p.id == id);
                return View(item);
            }
            return RedirectToAction("Login", "Home");

            
        }
        [HttpPost]
        public ActionResult Edit(news NewS, HttpPostedFileBase Image,bool IsActive=false)
        {

            var item = db.news.Find(NewS.id);
            if(item != null)
            {
                item.dateCreate = DateTime.Now;
                List<accountAD> model = db.accountADs.ToList();
                foreach (var ad in model)
                {
                    if (ad.staff.fullName == Session["user"].ToString())
                    {
                        item.createById = ad.id;
                        break;
                    }
                }
                item.newsTitle = NewS.newsTitle;
                item.detail = NewS.detail;
                item.description = NewS.description;
                if (Image != null && Image.ContentLength>0)
                {
                    string location = "/Models/Image/";
                    string rootFolder = Server.MapPath(location);
                    string pathImage = rootFolder + Image.FileName;
                    Image.SaveAs(pathImage);
                    item.image = location + Image.FileName;
                }
                item.isActive = IsActive;
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
                ViewBag.id = id;
                var item = db.news.FirstOrDefault(p => p.id == id);
                return View(item);
            }
            return RedirectToAction("Login", "Home");

        }
        public ActionResult Delete(int id)
        {
            ViewBag.id = id;
            var item = db.news.SingleOrDefault(p => p.id == id);
            db.news.Remove(item);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}