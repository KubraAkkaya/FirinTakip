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

        List<Sipari> GetList();
        void SiparisAdd(Sipari sipari);
    }
}
