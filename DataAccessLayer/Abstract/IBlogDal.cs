using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IBlogDal: IGenericDal<Blog>
    {
        List<Blog> GetListWithCategory();
        List<Blog> GetBlogListByWriter(int id);
        List<Blog> GetLast3Blog();
        List<Blog> GetListWithCategoryByWriter(int id);
        int GetCount();
        int GetWriterBlogCount(int id);


    }
}
