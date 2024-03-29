﻿using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repository
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {

        FirinTakipModel ftm = new FirinTakipModel();
        DbSet<T> _object;

        public GenericRepository()
        {
            _object = ftm.Set<T>();
        }

        public void Delete(T p)
        {
            var deletedEntity = ftm.Entry(p);
            deletedEntity.State = EntityState.Deleted;
            //_object.Remove(p);
            ftm.SaveChanges();
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return _object.SingleOrDefault(filter);
        }

        public void Insert(T p)
        {
            var addedEntry =ftm.Entry(p);
            addedEntry.State = EntityState.Added;
            //_object.Add(p);
            ftm.SaveChanges();
        }

        public List<T> List()
        {
            return _object.ToList();
        }

        public List<T> List(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList();
        }

        public void Update(T p)
        {
            var updatedEntry =ftm.Entry(p);
            updatedEntry.State = EntityState.Modified;
            ftm.SaveChanges();
        }
    }
}
