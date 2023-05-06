using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class NatificationManager : INatificationServices
    {
        private readonly INatificationDal _natificationDal;

        public NatificationManager(INatificationDal natificationDal)
        {
            _natificationDal = natificationDal;
        }

        public void TAdd(Natification t)
        {
           _natificationDal.Add(t);
        }

        public void TDelete(Natification t)
        {
            _natificationDal.Delete(t);
        }

        public Natification TGetById(int id)
        {
            return _natificationDal.GetById(id);
        }

        public List<Natification> TGetList()
        {
           return _natificationDal.GetList();
        }

        public List<Natification> TGetListAll(int id)
        {
            return _natificationDal.GetListAll(x=>x.NatificationID == id);
        }

        public void TUpdate(Natification t)
        {
            _natificationDal.Update(t);
        }
    }
}
