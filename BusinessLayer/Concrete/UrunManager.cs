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
    public class UrunManager : IUrunService
    {
        IUrunDal _urunDal;
        public UrunManager(IUrunDal urunDal)
        {
            _urunDal = urunDal;
        }

        public Urun GetByID(int id)
        {
            return _urunDal.Get(x => x.ID == id);
        }

        public List<Urun> GetList()
        {
            return _urunDal.List(); //GenericRepository i kullanmış oluyoruz
        }

        public void UrunAdd(Urun urun)
        {
           _urunDal.Insert(urun);
        }

        public void UrunDelete(Urun urun)
        {
            _urunDal.Delete(urun);
        }

        public void UrunUpdate(Urun urun)
        {
            _urunDal.Update(urun);
        }
    }
}
