using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Update.Internal;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var result = _userService.GetById(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            else 
            {
                return BadRequest(result.Message);
            }
        }
        [HttpGet("GetByMail")]
        public IActionResult GetByMail(string email)
        {
            var result = _userService.GetByMail(email);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }
        [HttpPut("Update")]
        public IActionResult Update (UpdateUserDto updateUserDto)
        {
            var result = _userService.Update(updateUserDto);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
        [HttpDelete("Delete")]
        public IActionResult Delete(int userId)
        {
            var result = _userService.Delete(userId);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
        [HttpPut("UpdatePassword")]
        public IActionResult UpdatePasswod(PasswordUpdateDto passwordUpdateDto)
        {
            var result = _userService.UpdatePassword(passwordUpdateDto);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
        [HttpPut("Login")]
        public ActionResult Login(UserForLoginDto userForLoginDto)
        {
            var userToLogin = _userService.Login(userForLoginDto);
            if (!userToLogin.Success)
            {
                return BadRequest(userToLogin.Message);
            }
            var result = _userService.CreateAccessToken(userToLogin.Data);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("Register")]
        public ActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            var userExists = _userService.UserExists(userForRegisterDto.Email);
            if (!userExists.Success)
            {
                return BadRequest(userExists.Message);
            }
            var registerResult = _userService.Register(userForRegisterDto, userForRegisterDto.Password);
            var result = _userService.CreateAccessToken(registerResult.Data);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

    }
}
