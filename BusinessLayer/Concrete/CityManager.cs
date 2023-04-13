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
	
	public class CityManager : ICityServices
	{
		private readonly ICityDal _cityDal;

		public CityManager(ICityDal cityDal)
		{
			_cityDal = cityDal;
		}

		public void TAdd(City t)
		{
			_cityDal.Add(t);
		}

		public void TDelete(City t)
		{
			_cityDal.Delete(t);
		}

		public City TGetById(int id)
		{
			return _cityDal.GetById(id);
		}

		public List<City> TGetList()
		{
			return _cityDal.GetList();
		}

		public List<City> TGetListAll(int id)
		{
			return _cityDal.GetListAll(x => x.CityID == id);
		}

		public void TUpdate(City t)
		{
			_cityDal.Update(t);
		}
	}
}
