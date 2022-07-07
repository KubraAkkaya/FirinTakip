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
    public class MusteriController : Controller
    {
        MusteriManager mm=new MusteriManager(new EfMusteriDal());
        // GET: Musteri
        public ActionResult Musteri()
        {
            return View();
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
            //mm.MusteriAddBL(p);
            MusteriValidator musteriValidator = new MusteriValidator(); 
            ValidationResult results=musteriValidator.Validate(p);
            if (results.IsValid)
            {
                mm.MusteriAddBL(p);
                return RedirectToAction("GetMusteriList");
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