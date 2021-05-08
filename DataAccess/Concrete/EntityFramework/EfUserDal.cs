using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, PersonelTakipContext>, IUserDal
    {
        public IDataResult<User> GetByUserName(string userName)
        {
            throw new NotImplementedException();
        }

        public List<UserDetailDto> GetUserDetails()
        {
            using (PersonelTakipContext context = new PersonelTakipContext())
            {
                var result = from u in context.Users
                             select new UserDetailDto { UserId=u.UserId, UserName=u.UserName,FirstName=u.FirstName,LastName=u.LastName,Password=u.Password };
                return result.ToList();
            }
        }
    }
}
