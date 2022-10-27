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
    public class FoodCategoryManager : IFoodCategoryService
    {
        IFoodCategoryDal _foodCategory;

        public FoodCategoryManager(IFoodCategoryDal foodCategory)
        {
            _foodCategory = foodCategory;
        }

        public void TAdd(FoodCategory t)
        {
            _foodCategory.Insert(t);
        }

        public void TDelete(FoodCategory t)
        {
            _foodCategory.Delete(t);
        }

        public FoodCategory TGetById(int id)
        {
            return _foodCategory.GetById(id);
        }

        public List<FoodCategory> TGetList()
        {
            return _foodCategory.GetList();
        }

        public void TUpdate(FoodCategory t)
        {
            _foodCategory.Update(t);
        }
    }
}
