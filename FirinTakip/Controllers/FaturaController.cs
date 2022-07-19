using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirinTakip.Controllers
{
    public class FaturaController : Controller
    {
        FaturaManager fm = new FaturaManager(new EfFaturaDal());
        public class FaturaBilgileri
        {
            public DateTime FaturaTarihi { get; set; }
            public string MusteriAdi { get; set; }
        }
        public ActionResult Index()
        {
            var faturaValues = fm.GetList();
            return View(faturaValues);
        }
    }
}