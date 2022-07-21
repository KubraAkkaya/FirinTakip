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

        public List<Siparis> GetList()
        {
            return _siparisDal.List();
        }

        public void SiparisAdd(Siparis siparis)
        {
            _siparisDal.Insert(siparis);
        }
    }
}
