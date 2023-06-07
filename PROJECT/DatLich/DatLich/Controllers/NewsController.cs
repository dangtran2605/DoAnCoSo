using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DatLich.Models;
namespace DatLich.Controllers
{
    public class NewsController : Controller
    {
        private DataBase db=new DataBase();
        // GET: News
        public ActionResult Index()
        {
            return View(new DataBase().news.ToList());
        }
        [HttpGet]
        public ActionResult Detail(int id)
        {
            ViewBag.id = id;
            var item = db.news.FirstOrDefault(p => p.id == id);
            return View(item);
        }
    }
}