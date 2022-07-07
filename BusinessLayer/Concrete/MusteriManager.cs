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

        public List<Musteri> GetList()
        {
            return _musteriDal.List(); //GenericRepository i kullanmış oluyoruz
        }

        public void MusteriAddBL(Musteri musteri)
        {
            _musteriDal.Insert(musteri);
        }
    }

}
