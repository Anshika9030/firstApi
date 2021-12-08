using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Contract.Request;
using WebAPI.Contract.Response;
using WebAPI.Models;
using WebAPI.Respository;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IConfiguration _config;

        public IUsers Users { get; }
        public AccountController(IUsers users, IConfiguration configuration)
        {
            Users = users;
            this._config = configuration;
        }

        [HttpPost]
        [Route("authenticate")]
        public IActionResult SignIn(LoginModel login)
        {
            var user=Users.Authenticate(login);
            if (user != null)
            {
                return Ok(new ApiResponse() { Data = user, Message = "login successfull !", StatusCode = 200, Token=GenerateJSONWebToken() });
            }
            else
            {
                return Ok(new ApiResponse() { Data = null, Message = "login failed !", StatusCode = 404 });
            }
        }

        [HttpPost]
        [Route("signup")]
        public IActionResult SignUp(Users user)
        {
            var uu= Users.SignUp(user);
            if (uu != null)
            {
                return Ok(new ApiResponse() { Data = user, Message = "user created successfully !", StatusCode = 200 });
            }
            else
            {
                return Ok(new ApiResponse() { Data = null, Message = "user not created !", StatusCode = 500 });
            }
        }

        private string GenerateJSONWebToken()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              null,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}














