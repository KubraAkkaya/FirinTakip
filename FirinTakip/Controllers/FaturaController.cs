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
            //var values = db.Faturas.Where(k => k.Aktiflik == true).ToList();
            var values = from m in db.Musteris
                       join s in db.Siparislers on m.ID equals s.MusteriID
                       join f in db.Faturas.Where(k => k.Aktiflik == true) on s.ID equals f.ID
                       join u in db.Uruns on s.ID equals u.ID
                       select new FaturaBilgileriDto
                       {
                           MusteriAdi = m.Ad,
                           UrunAdi = u.UrunAdi,
                           OdemeDurumu = f.OdemeDurumu,
                           FaturaTarihi = f.Tarih,
                           ID= f.ID,
                           MusteriId = m.ID,
                           UrunId = u.ID,
                           Aktiflik = f.Aktiflik,
                           SiparisAdeti = s.Adet,
                           UrunFiyat = u.Fiyat,
                           ToplamTutar = u.Fiyat * s.Adet
                       }; 
            return View(values.ToList());
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
            
            var values = from m in db.Musteris
                         join s in db.Siparislers on m.ID equals s.MusteriID
            join f in db.Faturas.Where(k => k.Aktiflik == true) on s.ID equals f.ID
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
            var list = values.Where(k => k.ID == id).First();
            FaturaBilgileriDto list2= new FaturaBilgileriDto();
            list2.MusteriAdi = list.MusteriAdi;
                list2.UrunAdi = list.UrunAdi;
            list2.OdemeDurumu = list.OdemeDurumu;
            list2.FaturaTarihi = list.FaturaTarihi;
            list2.ID = list.ID;
            list2.MusteriId = list.MusteriId;
            list2.UrunId = list.UrunId;
            list2.Aktiflik = list.Aktiflik;
            list2.SiparisAdeti = list.SiparisAdeti;
            list2.UrunFiyat = list.UrunFiyat;
            list2.ToplamTutar = list.ToplamTutar;

            return View(list2);
        }
        [HttpPost]
        public ActionResult UpdateFatura(FaturaBilgileriDto p)
        {

            faturaBilgileriDto.UrunId = p.UrunId;
            faturaBilgileriDto.ID = p.ID;
            faturaBilgileriDto.UrunAdi = p.UrunAdi;
            faturaBilgileriDto.Aktiflik = p.Aktiflik;
            faturaBilgileriDto.MusteriId = p.MusteriId;
            faturaBilgileriDto.MusteriAdi = p.MusteriAdi;
            faturaBilgileriDto.SiparisAdeti = p.SiparisAdeti;
            faturaBilgileriDto.OdemeDurumu = p.OdemeDurumu;
            faturaBilgileriDto.FaturaTarihi = p.FaturaTarihi;
            faturaBilgileriDto.UrunFiyat = p.UrunFiyat;
            faturaBilgileriDto.ToplamTutar = p.ToplamTutar;

            db.SaveChanges();
            //fm.FaturaUpdate(p);
            return RedirectToAction("Index");
        }

    }
}