﻿using BusinessLayer.Concrete;
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
        FirinTakipModel db = new FirinTakipModel();
        SiparisManager sm = new SiparisManager(new EfSiparisDal());
        public ActionResult Index()
        {
            //var siparisValues = sm.GetList();
            var siparisList = db.Siparislers.Where(k => k.Aktiflik == true).ToList();

            return View(siparisList);
        }
        [HttpGet]
        public ActionResult AddSiparisler()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddSiparisler(Siparisler p)
        {
            try
            {
                Siparisler siparis = new Siparisler();
                siparis.UrunID = p.UrunID;
                siparis.Aktiflik = true;
                siparis.MusteriID = p.MusteriID;
                siparis.Adet= p.Adet;
                siparis.OdemeSekli= p.OdemeSekli;
                siparis.Tarih = p.Tarih;

                db.Siparislers.Add(siparis);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                SiparisValidator siparisValidator = new SiparisValidator();
                ValidationResult results = siparisValidator.Validate(p);
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            //SiparisValidator siparisValidator = new SiparisValidator();
            //ValidationResult results = siparisValidator.Validate(p);
            //if (results.IsValid)
            //{
            //    sm.SiparisAdd(p);
            //    return RedirectToAction("Index");
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
        public ActionResult DeleteSiparisler(int id)
        {
            //var siparisValue = sm.GetByID(id);
            //sm.SiparisDelete(siparisValue);
            var silineck = db.Siparislers.Where(k => k.ID == id).First();
            silineck.Aktiflik = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateSiparisler(int id)
        {
            //var siparisValue = sm.GetByID(id);
            var sip = db.Siparislers.Find(id);
            return View(sip);
        }

        [HttpPost]
        public ActionResult UpdateSiparisler(Siparisler p)
        {
            var sip = db.Siparislers.Find(p.ID);
            if (sip != null)
            {
                sip.UrunID = p.UrunID;
                sip.Aktiflik = true;
                sip.MusteriID = p.MusteriID;
                sip.Adet = p.Adet;
                sip.OdemeSekli = p.OdemeSekli;
                sip.Tarih = p.Tarih;
            }
            db.SaveChanges();
            //sm.SiparisUpdate(p);
            return RedirectToAction("Index");
        }

    }
}