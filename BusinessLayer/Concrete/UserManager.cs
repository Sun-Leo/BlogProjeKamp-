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
	public class UserManager : IUserServices
	{
		private readonly IUserDal _userDal;

		public UserManager(IUserDal userDal)
		{
			_userDal = userDal;
		}

		public void TAdd(AppUser t)
		{
			_userDal.Add(t);
		}

		public void TDelete(AppUser t)
		{
			_userDal.Delete(t);
		}

		public AppUser TGetById(int id)
		{
			return _userDal.GetById(id);
		}

		public List<AppUser> TGetList()
		{
			return _userDal.GetList();
		}

		public List<AppUser> TGetListAll(int id)
		{
			return _userDal.GetListAll(x=>x.Id==id);
		}

		public void TUpdate(AppUser t)
		{
			_userDal.Update(t);
		}
	}
}
