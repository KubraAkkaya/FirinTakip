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
    public class SiparisController : Controller
    {
        SiparisManager sm = new SiparisManager(new EfSiparisDal());
        public ActionResult Index()
        {
            var siparisValues = sm.GetList();
            return View(siparisValues);
        }
        [HttpGet]
        public ActionResult AddSipari()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddSipari(Sipari p)
        {
            SiparisValidator siparisValidator = new SiparisValidator();
            ValidationResult results = siparisValidator.Validate(p);
            if (results.IsValid)
            {
                sm.SiparisAdd(p);
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