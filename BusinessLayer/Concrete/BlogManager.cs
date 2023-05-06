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

		public List<Blog> TGetBlogListByWriter(int id)
		{
            return _blogDal.GetListAll(x => x.WriterID == id);
		}

		public Blog TGetById(int id)
        {
            return _blogDal.GetById(id);
        }

        public int TGetCount()
        {
            return _blogDal.GetCount();
        }

        public List<Blog> TGetLast3Blog()
        {
            return _blogDal.GetLast3Blog();
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

        public List<Blog> TGetListWithCategoryByWriter(int id)
        {
            return _blogDal.GetListWithCategoryByWriter(id);
        }

        public int TGetWriterBlogCount(int id)
        {
            return _blogDal.GetWriterBlogCount(id);
        }

        public void TUpdate(Blog t)
        {
            _blogDal.Update(t);
        }
    }
}
