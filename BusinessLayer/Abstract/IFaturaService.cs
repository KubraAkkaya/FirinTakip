using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IFaturaService
    {
        List<Fatura> GetList();
        Fatura GetByID(int id);
        void FaturaDelete(Fatura fatura);
        void FaturaUpdate(Fatura fatura);
    }
}
