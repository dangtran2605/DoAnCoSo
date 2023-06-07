using DatLich.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Razor.Generator;
using System.Web.Security;
using DatLich.Models.Common;
namespace DatLich.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        DataBase db=new DataBase();
        // GET: Admin/Home
        public ActionResult Index()
        {
            if (Session["user"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string user,string pass)
        {
            List<accountAD> accList =db.accountADs.ToList();
            var acc = accList.Find(p=>p.userName==user);
            int check = 0; string isER = "";
            if (acc != null)
            {
                if(acc.isActive ==false)
                {
                    check= -1;//Account chưa được kích hoạt
                }
                else if (acc.passWord != pass)
                {
                    check = -2;//Sai mật khẩu
                }
                else
                {
                    check = 1;//Đăng nhập thành công
                }
            }
            else
            {
                check= 0;//Tài khoản không tồn tại
            }
            if (check == 1)
            {
                ViewBag.id=acc.id;
                Session["user"] = acc.staff.fullName;
                return RedirectToAction("Index");
            }
            else if (check == -2)
            {
                isER="Sai mật khẩu";
            }
            else if (check == -1)
            {
                isER = "Tài khoản chưa được kích hoạt, vui lòng liên hệ Admin";
            }
            else
            {
                isER = "Sai tên đăng nhập hoặt không tồn tại";
            }
            TempData["error"] = isER;
            return View();
           
            
        }
        public ActionResult Logout()
        {
            Session.Remove("user");
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

        
    }
}