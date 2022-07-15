using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirinTakip.Controllers
{
    public class UrunController : Controller
    {
        UrunManager um = new UrunManager(new EfUrunDal());
        public ActionResult Index()
        {
            var urunValues = um.GetList();
            return View(urunValues);
        }

        [HttpGet]
        public ActionResult AddSipari()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSipari(Urun p)
        {
            UrunValidator urunValidator=new UrunValidator();
            ValidationResult results = urunValidator.Validate(p);
            if (results.IsValid)
            {
                um.UrunAdd(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}