using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public void AddT(AppUser t)
        {
            throw new NotImplementedException();
        }

        public void DeleteT(AppUser t)
        {
            throw new NotImplementedException();
        }

        public List<AppUser> GetList()
        {
            throw new NotImplementedException();
        }

        public AppUser TGetById(int id)
        {
            return _userDal.GetById(id);
        }

        public void UpdateT(AppUser t)
        {
            _userDal.Update(t);
        }
    }
}
