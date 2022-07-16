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
        public List<Fatura> GetList()
        {
            return _faturaDal.List();
        }
    }
}
