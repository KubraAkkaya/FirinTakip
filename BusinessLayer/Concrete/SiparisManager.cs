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
    public class SiparisManager : ISiparisService
    {
        ISiparisDal _siparisDal;

        public SiparisManager(ISiparisDal siparisDal)
        {
            _siparisDal = siparisDal;
        }

        public Siparisler GetByID(int id)
        {
            return _siparisDal.Get(x => x.ID == id);
        }

        public List<Siparisler> GetList()
        {
            return _siparisDal.List();
        }

        public void SiparisAdd(Siparisler siparis)
        {
            _siparisDal.Insert(siparis);
        }

        public void SiparisDelete(Siparisler siparisler)
        {
            _siparisDal.Delete(siparisler);
        }
    }
}
