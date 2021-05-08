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
        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.UserDeleted);
        }
        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.UserUpdated);

        }
        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.UserListed);
        }

        public IDataResult<User> GetByUserName(string userName)
        {
            return new SuccessDataResult<User>(_userDal.Get(p => p.UserName == userName));
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

        public IDataResult<List<UserDetailDto>> GetUserDetails()
        {
            return new SuccessDataResult<List<UserDetailDto>>(_userDal.GetUserDetails());
        }

        public IDataResult<User> GetByUserId(int id)
        {
            return new SuccessDataResult<User>(_userDal.Get(p => p.UserId == id));
        }

        public IResult CheckIfUserNameExits(string userName)
        {              
                var result = _userDal.GetAll(u => u.UserName == userName).Any();
                if (result == true)
                {
                    return new ErrorResult(Messages.UserNameAlreadyExits);
                }
                return new SuccessResult(Messages.UserNameError);
        }
        public IDataResult<User> FormLogin(string userName, string password)
        {
            var result = _userDal.GetAll(u => u.UserName == userName).Any();
            if (result == true)
            {
                var user = _userDal.Get(u => u.UserName == userName && u.Password == password);
                if (user != null)
                {
                    return new SuccessDataResult<User>(user,Messages.SuccessfulLogin);
                }
                return new ErrorDataResult<User>(Messages.UserPasswordError);
            }
            return new ErrorDataResult<User>(Messages.UserNameError); 
        }




        //public IDataResult<User> FormLogin(string userName, string password)
        //{
        //    var user = _userDal.Get(u => u.UserName == userName && u.Password == password);// aslında usercheck ismi yanlış sen user donduruyorsun.
        //    if (user == null)
        //    {
        //        return new ErrorDataResult<User>(Messages.UserPasswordError);
        //    }
        //    return new SuccessDataResult<User>(user, Messages.SuccessfulLogin);
        //}       
        // usercheck niye yazdın bu araya? boyle olmalı
        // var user veya başka birşey tanımlamada fark ediyor mu? literatür mü diyelim. farkketmez ama kafan karşmasın diye düzelttm ..   tamam abi standarttan gideyim oturuyor yavaş yavaş yanlış ilerlemesin
        //hata mesajları olayını bilmiyordum iyi oldu mesala, burda user yazarak veriyi geri dondurduk buraya yazmayınca null olur data
        // succeslerde user vb yazılacak yani kısaca doğru mu anladım. cektiğin veriyi işleyeceksen yazmalısın Idataresult yazmamızın amacı o zaten yoksa Iresult yapardık.
        //son bişey daha srayım o zaman abi..
        //IDataResult<User>          tek kayıt donecekse
        //IDataResult<List<User>>    kayıt donuyorsa list

        //arasındaki fark liste çekmesi mi  evet aynen tek kayıt donecekse ustteki cok kayıt donuyorsa list teşekkürler :)
        //ben kaçar ali oyun istiyor.
        //çok sağol abi baya iyi oldu.
        //iyi tatiller eyvallah sana da
        //}
        //return new ErrorDataResult<User>(Messages.UserNameError);
        //burdan donen mesaajlar gorunur









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

        // burdan açğırıp form 1 de çalıştırmayı denedim//- açıp dene bakalım bidaha ne olyor
        //sorun şurda abi form1 de 
    }
}
