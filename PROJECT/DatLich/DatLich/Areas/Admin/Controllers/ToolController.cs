using DatLich.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DatLich.Areas.Admin.Controllers
{
    public class ToolController : Controller
    {
        private DataBase db=new DataBase();
        // GET: Admin/Tool
        public ActionResult GetCategory()
        {
            return View(new DataBase().categoryServices.ToList());
        }
        public ActionResult GetSale()
        {
            return View(new DataBase().sales.ToList());
        }
        public ActionResult GetServiceByIdBooking(int id)
        {
            List<detailBooking> ListItem = new List<detailBooking>();
            foreach(var item in db.detailBookings) 
            {
                if(item.idBooking==id)
                {
                    ListItem.Add(item);
                }
            }
            return View(ListItem);
        }
        public ActionResult GetStaff()
        {
            return View(new DataBase().staffs.ToList());
        }

    }
}