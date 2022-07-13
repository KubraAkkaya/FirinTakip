using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirinTakip.Controllers
{
    public class AdminController : Controller
    {
        //AdminManager am = new AdminManager(new EfAdminDal);
        public ActionResult Index()
        {
            return View();
        }



    }
}