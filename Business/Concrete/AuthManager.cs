using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;

        public AuthManager(IUserService userService /*ITokenHelper tokenHelper*/)
        {
            _userService = userService;
        }

        
        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            //byte[] passwordHash, passwordSalt;
            //HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new User
            {
                UserName = userForRegisterDto.UserName,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                //PasswordHash = passwordHash,
                //PasswordSalt = passwordSalt,
            };
            _userService.Add(user);
            return new SuccessDataResult<User>(user, Messages.UserRegistered);
        }

        public IResult UserExists(string userName)
        {
            if (_userService.GetByUserName(userName) != null)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }
            return new SuccessResult();
        }

    }
}
