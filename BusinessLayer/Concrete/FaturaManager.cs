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
    public class FaturaManager : IFaturaService
    {
        IFaturaDal _faturaDal;
        public FaturaManager(IFaturaDal faturaDal)
        {
            _faturaDal = faturaDal;
        }

        public void FaturaDelete(Fatura fatura)
        {
            _faturaDal.Delete(fatura);
        }

        public Fatura GetByID(int id)
        {
            return _faturaDal.Get(x => x.ID == id);
        }

        public List<Fatura> GetList()
        {
            return _faturaDal.List();
        }
    }
}
