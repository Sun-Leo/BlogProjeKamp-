﻿using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T>where T: class
    {
        Context c=new Context();

        public void Add(T t)
        {
            c.Add(t);
            c.SaveChanges();
        }

        public void Delete(T t)
        {
            c.Remove(t);
            c.SaveChanges();
        }

        public T GetById(int id)
        {
            return c.Set<T>().Find(id);
            
        }

        public List<T> GetList()
        {
            return c.Set<T>().ToList();
        }


        public void Update(T t)
        {
            c.Update(t);
            c.SaveChanges();
        }
    }
}
