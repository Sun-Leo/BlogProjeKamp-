﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IBlogServices: IGenericServices<Blog>
    {
		List<Blog> TGetListWithCategory();
		List<Blog> TGetBlogListByWriter(int id);
        List<Blog> TGetLast3Blog();
        List<Blog> BlogTitleListForExcel();
        List<Blog> TGetListWithCategoryByWriter(int id);
        int TGetCount();
        int TGetWriterBlogCount(int id);



    }
}
