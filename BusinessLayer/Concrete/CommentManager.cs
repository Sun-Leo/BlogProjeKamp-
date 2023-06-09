﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CommentManager : ICommentServices
    {
        private readonly ICommentDal _commentDal;

        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public void TAdd(Comment t)
        {
            _commentDal.Add(t);
        }

        public void TDelete(Comment t)
        {
            _commentDal.Delete(t);
        }

        public Comment TGetById(int id)
        {
            return _commentDal.GetById(id);
        }

        public List<Comment> TGetCommentWithBlog()
        {
            return _commentDal.GetCommentWithBlog();
        }

        public List<Comment> TGetList()
        {
            return _commentDal.GetList();
        }

		public List<Comment> TGetListAll(int id)
		{
            return _commentDal.GetListAll(x => x.CommentID == id);
		}

		public void TUpdate(Comment t)
        {
            _commentDal.Update(t);
        }
    }
}
