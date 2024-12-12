using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserService : IUserService
    {
        private IUserDal _userDal;
        private ITokenHelper _tokenHelper;

        public UserService(IUserDal userDal,ITokenHelper tokenHelper)
        {
            _userDal = userDal;
            _tokenHelper = tokenHelper;
        }

        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult();
        }

        public IResult Delete(int userId)
        {
            User user = _userDal.Get(u => u.Id == userId);
            _userDal.Delete(user);
            return new SuccessResult(Messages.UserDeleted);
        }

        public IDataResult<List<User>> GetAll()
        {
           return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.UserListed);
        }

        public IDataResult<User> GetById(int id)
        {
            return new SuccessDataResult<User>(_userDal.Get(u =>u.Id == id));
        }

        public IDataResult<User> GetByMail(string email)
        {
            var user = _userDal.Get(u=> u.Email == email);
            if (user is null)
            {
                return new ErrorDataResult<User>(Messages.MailNoFound);
            }
            return new SuccessDataResult<User>(user);
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user));
        }

        public IResult Update(UpdateUserDto user)
        {
            User entity = _userDal.Get(e=> e.Email == user.Email);
            if (entity is null)
            {
                return new ErrorResult(Messages.UserNotFound);
            }
            entity.FirstName = user.FirstName;
            entity.LastName = user.LastName;
            entity.Email = user.Email;
            _userDal.Update(entity);
            return new SuccessResult();
        }

        public IResult UpdatePassword(PasswordUpdateDto password)
        {
            var userToCheck = GetByMail(password.Email);
            if (userToCheck is null)
            {
                return new ErrorResult(Messages.UserNotFound);
            }
            if(!HashingHelper.VerifyPasswordHash(password.OldPassword,userToCheck.Data.PasswordHash,userToCheck.Data.PasswordSalt))
            {
                return new ErrorResult();
            }
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password.NewPassword, out passwordHash, out passwordSalt);
            userToCheck.Data.PasswordHash = passwordHash;
            userToCheck.Data.PasswordSalt = passwordSalt;
            _userDal.Update(userToCheck.Data);
            return new SuccessResult();
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
           var claims =GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims.Data);
            return new SuccessDataResult<AccessToken>(accessToken,Messages.AccessTokenCreated);
        }

        public IDataResult<User> Login(UserForLoginDto request)
        {
           var userToCheck = GetByMail(request.Email);
            if (userToCheck.Success == false)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }
            if (!HashingHelper.VerifyPasswordHash(request.Password, userToCheck.Data.PasswordHash, userToCheck.Data.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.PasswordError);
            }
            return new SuccessDataResult<User>(userToCheck.Data,Messages.SuccessfulLogin);
        }

        public IDataResult<User> Register(UserForRegisterDto request, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password,out passwordHash, out passwordSalt);
            var user = new User
            {
                Email = request.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true,
                FirstName = request.FirstName,
                LastName = request.LastName,
            };
            Add(user);
            return new SuccessDataResult<User>(user,Messages.UserRegistered);
        }

        public IResult UserExists(string email)
        {
            var user = _userDal.Get(u => u.Email == email);
            if (user is null)
            {
                return new SuccessResult();
            }

            return new ErrorDataResult<User>(Messages.UserAlreadyExists);
        }
    }
}
