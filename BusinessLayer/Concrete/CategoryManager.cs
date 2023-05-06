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
    public class CategoryManager : ICategoryServices
    {
        private readonly ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void TAdd(Category t)
        {
            _categoryDal.Add(t);
        }

        public void TDelete(Category t)
        {
            _categoryDal.Delete(t);
        }

        public Category TGetById(int id)
        {
            return _categoryDal.GetById(id);
        }

        public int TGetCount()
        {
            return _categoryDal.GetCount();
        }

        public List<Category> TGetList()
        {
            return _categoryDal.GetList();
        }

		public List<Category> TGetListAll(int id)
		{
            return _categoryDal.GetListAll(x => x.CategoryID == id);
		}

		public void TUpdate(Category t)
        {
            _categoryDal.Update(t);
        }
    }
}
