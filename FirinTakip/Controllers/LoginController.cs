using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace FirinTakip.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin p)
        {
            FirinTakipModel f = new FirinTakipModel();
            var adminUserInfo=f.Admins.FirstOrDefault(
                x => x.UserName == p.UserName && x.Password == p.Password);
            if (adminUserInfo != null)
            {
                FormsAuthentication.SetAuthCookie(adminUserInfo.UserName,false);
                Session["UserName"]=adminUserInfo.UserName;
                return RedirectToAction("Index" , "Musteri");
            }
            else
             {
                return RedirectToAction("Index");
             }
            return View();
        }
    }
}