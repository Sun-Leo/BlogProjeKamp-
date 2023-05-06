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
    public class WriterManager : IWriterServices
    {
        private readonly IWriterDal _writerDal;

        public WriterManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }

        public void TAdd(Writer t)
        {
            _writerDal.Add(t);
        }

        public void TDelete(Writer t)
        {
            _writerDal.Delete(t);
        }

        public Writer TGetById(int id)
        {
            return _writerDal.GetById(id);

        }

        public List<Writer> TGetList()
        {
            return _writerDal.GetList();
        }

		public List<Writer> TGetListAll(int id)
		{
            return _writerDal.GetListAll(x => x.WriterID == id);
		}

        public List<Writer> TGetListWriterWithCity()
        {
            return _writerDal.GetListWriterWithCity();
        }

        public void TUpdate(Writer t)
        {
            _writerDal.Update(t);
        }
    }
}
