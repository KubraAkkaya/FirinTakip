﻿using BusinessLayer.Abstract;
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

        public List<Sipari> GetList()
        {
            return _siparisDal.List();
        }

        public void SiparisAdd(Sipari sipari)
        {
            _siparisDal.Insert(sipari);
        }
    }
}
