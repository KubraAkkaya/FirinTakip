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

        public List<Urun> GetList()
        {
            return _urunDal.List(); //GenericRepository i kullanmış oluyoruz
        }

        public void UrunAdd(Urun urun)
        {
           _urunDal.Insert(urun);
        }
    }
}
