using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class BlogManager :IBlogServices
    {
        private readonly IBlogDal _blogDal;

        public BlogManager(IBlogDal blogDal)
        {
            _blogDal = blogDal;
        }

        public void TAdd(Blog t)
        {
            _blogDal.Add(t);
        }

        public void TDelete(Blog t)
        {
            _blogDal.Delete(t);
        }

        public Blog TGetById(int id)
        {
            return _blogDal.GetById(id);
        }

        public List<Blog> TGetList()
        {
            return _blogDal.GetList();
        }

		public List<Blog> TGetListAll(int id)
		{
            return _blogDal.GetListAll(x => x.BlogID == id);
		}

		public List<Blog> TGetListWithCategory()
		{
            return _blogDal.GetListWithCategory();
		}

		public void TUpdate(Blog t)
        {
            _blogDal.Update(t);
        }
    }
}
