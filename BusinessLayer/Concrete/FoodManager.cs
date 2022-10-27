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
    public class FoodManager : IFoodService
    {
        IFoodDal _foodDal;

        public FoodManager(IFoodDal foodDal)
        {
            _foodDal = foodDal;
        }

        public List<Food> GetFoodWithFoodCategory()
        {
            return _foodDal.GetFoodWithFoodCategory();
        }

        public void TAdd(Food t)
        {
            _foodDal.Insert(t);
        }

        public void TDelete(Food t)
        {
            _foodDal.Delete(t);
        }

        public Food TGetById(int id)
        {
            return _foodDal.GetById(id);
        }

        public List<Food> TGetList()
        {
            return _foodDal.GetList();
        }

        public void TUpdate(Food t)
        {
            _foodDal.Update(t);
        }
    }
}
