using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
	public class EFBlogRepository : GenericRepository<Blog>, IBlogDal
	{
		Context c = new Context();


		public List<Blog> BlogTitleListForExcel()
        {
            return c.Blogs.ToList();
        }

        public List<Blog> GetBlogListByWriter(int id)
		{
			return c.Blogs.Include(x=>x.Writer).ToList();
		}

        public int GetCount()
        {
            return c.Blogs.Count();
        }

        public List<Blog> GetLast3Blog()
        {
            return c.Blogs.Take(5).ToList();
        }

        public List<Blog> GetListWithCategory()
		{
			return c.Blogs.Include(x => x.Category).ToList();
		}

        public List<Blog> GetListWithCategoryByWriter(int id)
        {
            return c.Blogs.Include(x=>x.Category).Where(x=>x.WriterID == id).ToList();
        }

        public  int GetWriterBlogCount(int id)
        {

            AppUser appUser = new AppUser();
            var writerId = c.Writers.Where(x => x.WriterMail == appUser.Email).Select(x => x.WriterID).FirstOrDefault();
            return c.Blogs.Where(x => x.WriterID == writerId).Count();
        }

		
	}
}
