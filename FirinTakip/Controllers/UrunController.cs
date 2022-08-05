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
        FirinTakipModel db = new FirinTakipModel();
        UrunManager um = new UrunManager(new EfUrunDal());
        public ActionResult Index()
        {
            //var urunValues = um.GetList();
            var urunList = db.Uruns.Where(k => k.Aktiflik == true).ToList();
            return View(urunList);
        }

        [HttpGet]
        public ActionResult AddUrun()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddUrun(Urun p)
        {
            try
            {
                Urun urun = new Urun();
                urun.UrunAdi = p.UrunAdi;
                urun.Aktiflik = true;
                urun.AlmancaAdi = p.AlmancaAdi;
                urun.Fiyat = p.Fiyat;
                urun.TatliMi = p.TatliMi;

                db.Uruns.Add(urun);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                UrunValidator urunValidator = new UrunValidator();
                ValidationResult results = urunValidator.Validate(p);
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            //UrunValidator urunValidator=new UrunValidator();
            //ValidationResult results = urunValidator.Validate(p);
            //if (results.IsValid)
            //{
            //    um.UrunAdd(p);
            //    return RedirectToAction("Index");
            //}
            //else
            //{
            //    foreach (var item in results.Errors)
            ////    {
            //        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            //    }
            //}
            return View();
        }
        public ActionResult DeleteUrun(int id)
        {
            
            var silineck = db.Uruns.Where(k => k.ID == id).First();
            silineck.Aktiflik = false;
            db.SaveChanges();
            //var urunValue = um.GetByID(id);
            //um.UrunDelete(urunValue);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateUrun(int id)
        {
            var urunValue = um.GetByID(id);
            return View(urunValue);
        }
        [HttpPost]
        public ActionResult UpdateUrun(Urun p)
        {

            um.UrunUpdate(p);
            return RedirectToAction("Index");
        }
    }
}