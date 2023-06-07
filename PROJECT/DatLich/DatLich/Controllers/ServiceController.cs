using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DatLich.Models;
namespace DatLich.Controllers
{
    public class ServiceController : Controller
    {   
        private DataBase db=new DataBase();
        // GET: Service
        public ActionResult Index()
        {
            return View(new DataBase().services.ToList());
        }
        [HttpGet]
        public ActionResult Detail(int id)
        {
            ViewBag.id = id;
            var item = db.services.FirstOrDefault(p => p.id == id);
            return View(item);
        }
        
    }
}