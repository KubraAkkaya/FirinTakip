using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirinTakip.Controllers
{
    public class MusteriController : Controller
    {
        MusteriManager mm = new MusteriManager(new EfMusteriDal());
        // GET: Musteri
        FirinTakipModel db = new FirinTakipModel();
        [Authorize(Roles ="B")]
        public ActionResult Index()
        {
            //var MusteriValues = mm.GetList();
            var musteriList = db.Musteris.Where(k => k.Aktiflik == true).ToList();
            return View(musteriList);
        }

        [HttpGet]
        public ActionResult AddMusteri()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddMusteri(Musteri p)
        {
            try
            {
                Musteri musteri = new Musteri();
                musteri.Ad = p.Ad;
                musteri.Aktiflik = true;
                musteri.Soyad = p.Soyad;
                musteri.TelefonNo = p.TelefonNo;
                musteri.Mail = p.Mail;
                musteri.Adresi= p.Adresi;

                db.Musteris.Add(musteri);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                MusteriValidator musteriValidator = new MusteriValidator();
                ValidationResult results = musteriValidator.Validate(p);
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            //}
            //else
            //{
            //    foreach (var item in results.Errors)
            //    {
            //        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            //    }
            //}

            return View();
        }

        public ActionResult DeleteMusteri(int id)
        {
            //var musteriValue = mm.GetByID(id);
            //mm.MusteriDelete(musteriValue);
            var silineck = db.Uruns.Where(k => k.ID == id).First();
            silineck.Aktiflik = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateMusteri(int id)
        {
            var musteriValue = mm.GetByID(id);
            return View(musteriValue);
        }
        [HttpPost]
        public ActionResult UpdateMusteri(Musteri p)
        {

            mm.MusteriUpdate(p);
            return RedirectToAction("Index");
        }
    }
}