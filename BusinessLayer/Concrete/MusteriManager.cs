using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class MusteriManager : IMusteriService
    {
        IMusteriDal _musteriDal;

        public MusteriManager(IMusteriDal musteriDal)
        {
            _musteriDal = musteriDal;
        }

        public Musteri GetByID(int id)
        {
            return _musteriDal.Get(x => x.ID == id);
        }

        public List<Musteri> GetList()
        {
            return _musteriDal.List(); //GenericRepository i kullanmış oluyoruz
        }

        public void MusteriAdd(Musteri musteri)
        {
            _musteriDal.Insert(musteri);
        }

        public void MusteriDelete(Musteri musteri)
        {
            _musteriDal.Delete(musteri);
        }

        public void MusteriUpdate(Musteri musteri)
        {
            _musteriDal.Update(musteri);
        }
    }

}
