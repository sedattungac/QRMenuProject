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
    public class ApplicationManager : IApplicationService
    {
        IApplicationDal _applicationDal;
        public void TAdd(Application t)
        {
            _applicationDal.Insert(t);
        }

        public void TDelete(Application t)
        {
            _applicationDal.Delete(t);
        }

        public Application TGetById(int id)
        {
            return _applicationDal.GetById(id);
        }

        public List<Application> TGetList()
        {
            return _applicationDal.GetList();
        }

        public void TUpdate(Application t)
        {
            _applicationDal.Update(t);
        }
    }
}
