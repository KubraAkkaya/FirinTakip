using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FirinTakip.Dto;
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
        FirinTakipModel db = new FirinTakipModel();

        public ActionResult Index()
        {
            //var list = db.Musteris.Include(x => x.).Include(b => b. ).Select(k => new FaturaBilgileriDto
            //{
            //    FaturaTarihi = k.
            //});
            var list = from m in db.Musteris 
                       join s in db.Siparislers on m.ID equals s.MusteriID
                       join f in db.Faturas on s.ID equals f.ID
                       join u in db.Uruns on s.ID equals u.ID
                       select new FaturaBilgileriDto
                       {
                           MusteriAdi = m.Ad,
                           UrunAdi = u.UrunAdi,
                           OdemeDurumu = f.OdemeDurumu,
                           FaturaTarihi= f.Tarih,
                           ID=f.ID
                       };
            //FaturaBilgileriDto dto = new FaturaBilgileriDto
            //{
            //    FaturaTarihi = DateTime.Now,
            //    MusteriAdi = "gülşah",
            //    OdemeDurumu = "ödendi",
            //    UrunAdi = "bilgisayar"
            //};

            //var values = fm.GetList();
            return View(list.ToList());
        }

        public ActionResult DeleteFatura(int id)
        {
            var silinecek=db.Faturas.Where(f => f.ID == id).First();
            //var faturaValue = fm.GetByID(id);
            db.Faturas.Remove(silinecek);
            db.SaveChanges();
            //fm.FaturaDelete(silinecek);
            return RedirectToAction("Index");
        }
    }
}