using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ISiparisService
    {

        List<Siparisler> GetList();
        void SiparisAdd(Siparisler siparisler);

        Siparisler GetByID(int id);
        void SiparisDelete(Siparisler siparisler);
        void SiparisUpdate(Siparisler siparisler);

    }
}
