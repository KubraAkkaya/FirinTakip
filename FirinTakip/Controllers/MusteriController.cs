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
        public ActionResult Index()
        {
            var MusteriValues = mm.GetList();
            return View(MusteriValues);
        }

        public ActionResult GetMusteriList()
        {
            var musteriValues = mm.GetList();
            return View(musteriValues);
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
                musteri.Ad = "Gülşah";
                musteri.Aktiflik = true;
                musteri.Soyad = "TAN";
                musteri.TelefonNo = "1111";
                musteri.Mail = "dd@gmail.com";

                //MusteriValidator musteriValidator = new MusteriValidator(); 
                //ValidationResult results=musteriValidator.Validate(p);

                db.Musteris.Add(musteri);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                throw;
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
            var musteriValue = mm.GetByID(id);
            mm.MusteriDelete(musteriValue);
            return RedirectToAction("Index");
        }
    }
}