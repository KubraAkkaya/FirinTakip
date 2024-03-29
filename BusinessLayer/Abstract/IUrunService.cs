﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IUrunService
    {
        List<Urun> GetList();
        void UrunAdd(Urun urun);

        Urun GetByID(int id);
        void UrunDelete(Urun urun);
        void UrunUpdate(Urun urun);
    }
}
