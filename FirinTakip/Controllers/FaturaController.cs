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
            var list = from m in db.Musteris 
                       join s in db.Siparislers on m.ID equals s.MusteriID
                       join f in db.Faturas.Where(x=>x.Aktiflik==true) on s.ID equals f.ID
                       join u in db.Uruns on s.ID equals u.ID
                       select new FaturaBilgileriDto
                       {
                           MusteriAdi = m.Ad,
                           UrunAdi = u.UrunAdi,
                           OdemeDurumu = f.OdemeDurumu,
                           FaturaTarihi= f.Tarih,
                           ID=f.ID,
                           MusteriId = m.ID,
                           UrunId = u.ID,
                           Aktiflik = f.Aktiflik,
                           SiparisAdeti=s.Adet,
                           UrunFiyat = u.Fiyat,
                           ToplamTutar = u.Fiyat * s.Adet
                       };

            return View(list.ToList());
        }

        public ActionResult Raporlama()
        {
            var values = db.Faturas.Where(k => k.Aktiflik == true).ToList();
            return View(values);
        }

        public ActionResult DeleteFatura(int id)
        {
            var silinecek=db.Faturas.Where(f => f.ID == id).First();
            //db.Faturas.Remove(silinecek);
            //db.SaveChanges();
            silinecek.Aktiflik = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        FaturaBilgileriDto faturaBilgileriDto = new FaturaBilgileriDto();

        [HttpGet]
        public ActionResult UpdateFatura(int id)
        {
            var faturaValue = db.Faturas.Where(f => f.ID == id).First();
            var list = from m in db.Musteris
                                     join s in db.Siparislers on m.ID equals s.MusteriID
                                     join f in db.Faturas.Where(x => x.ID == id) on s.ID equals f.ID
                                     join u in db.Uruns on s.ID equals u.ID
                                     select new FaturaBilgileriDto
                                     {
                                         MusteriAdi = m.Ad,
                                         UrunAdi = u.UrunAdi,
                                         OdemeDurumu = f.OdemeDurumu,
                                         FaturaTarihi = f.Tarih,
                                         ID = f.ID,
                                         MusteriId = m.ID,
                                         UrunId = u.ID,
                                         Aktiflik = f.Aktiflik,
                                         SiparisAdeti = s.Adet,
                                         UrunFiyat = u.Fiyat,
                                         ToplamTutar = u.Fiyat * s.Adet
                                     };
            return View(faturaBilgileriDto);

            //faturaBilgileriDto.FaturaTarihi = faturaValue.Tarih;
            //faturaBilgileriDto.UrunFiyat = 456;
            //faturaBilgileriDto.Aktiflik = true;
            //faturaBilgileriDto.MusteriAdi = "jy";
            ////var faturaValue = fm.GetByID(id);
            //return View(faturaBilgileriDto);
        }
        [HttpPost]
        public ActionResult UpdateFatura(FaturaBilgileriDto p)
        {
            //FaturaBilgileriDto.UrunId = p.UrunId;
            //FaturaBilgileriDto.ID = p.ID;
            //FaturaBilgileriDto.UrunAdi = p.UrunAdi;
            //FaturaBilgileriDto.Aktiflik = p.Aktiflik;
            //FaturaBilgileriDto.MusteriId = p.MusteriId;
            //FaturaBilgileriDto.MusteriAdi = p.MusteriAdi;
            //FaturaBilgileriDto.SiparisAdeti = p.SiparisAdeti;
            //FaturaBilgileriDto.OdemeDurumu= p.OdemeDurumu;
            //FaturaBilgileriDto.FaturaTarihi= p.FaturaTarihi;
            //FaturaBilgileriDto.UrunFiyat= p.UrunFiyat;
            //FaturaBilgileriDto.ToplamTutar = p.ToplamTutar;

            db.SaveChanges();
            //fm.FaturaUpdate(p);
            return RedirectToAction("Index");
        }

    }
}