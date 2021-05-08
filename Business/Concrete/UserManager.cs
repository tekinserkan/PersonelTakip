using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }


        public IResult Add(User user)
        {
            IResult result = BusinessRules.Run(CheckIfUserNameExits(user.UserName));

            if (result != null)
            {
                return result;
            }
            _userDal.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }

        public IResult CheckIfUserNameExits(string userName)
        {
            
                var result = _userDal.GetAll(u => u.UserName == userName).Any();
                if (result == true)
                {
                    return new ErrorResult(Messages.UserNameAlreadyExits);
                }
                return new SuccessResult();
            
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.UserDeleted);
        }

        public IDataResult<User> FormLogin(string userName, string password)
        {            
            if (CheckIfUserNameExits(userName)!=null)
            {
                var userToCheck = _userDal.Get(u => u.UserName == userName && u.Password == password);
                if (userToCheck == null)
                {
                    return new ErrorDataResult<User>(Messages.UserPasswordError);
                }
                return new SuccessDataResult<User>(Messages.SuccessfulLogin);
            }
            return new SuccessDataResult<User>(Messages.UserNameError);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.UserListed);
        }

        public IDataResult<User> GetByUserName(string userName)
        {
            return new SuccessDataResult<User>(_userDal.Get(p => p.UserName == userName));
        }

        public IDataResult<List<UserDetailDto>> GetUserDetails()
        {
            return new SuccessDataResult<List<UserDetailDto>>(_userDal.GetUserDetails());
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.UserUpdated);

        }


            public IResult UserExists(string userName)
        {
            var result = _userDal.GetByUserName(userName);
            if (result != null)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }
            return new SuccessResult();
        }



        //public IDataResult<User> FormLogin(string userName, string password)
        //{

        //    if (_userService.GetByUserName(userName) != null)
        //    {

        //        var result = _userService.GetAll(u => u.UserName == userName).Any();
        //        if (result == true)
        //        {
        //            return new ErrorResult(Messages.UserNameAlreadyExits);
        //        }
        //        return new SuccessResult();
        //    }
        //    return new SuccessResult();
        //}


    }
}
