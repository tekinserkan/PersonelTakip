using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<User> GetByUserName(string userName);
        IDataResult<List<User>> GetAll();
        IDataResult<User> FormLogin(string userName, string password);
        IResult Add(User user);
        IResult Update(User user);
        IResult Delete(User user);
        IResult CheckIfUserNameExits(string userName);
        IDataResult<List<UserDetailDto>> GetUserDetails();
    }
}
