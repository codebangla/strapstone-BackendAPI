using API.Dtos;
using API.Dtos.WebAPI.Dtos;
using API.Interfaces;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUnitOfWork uow;
        public AccountController(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        // api/account/login
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginReqDto loginReq)
        {
            var user = await uow.UserRepository.Authenticate(loginReq.Username, loginReq.Password);

            if (user == null)
            {
                return Unauthorized();
            }

            var loginResp = new LoginRespDto();
            loginResp.UserName = user.Username;
            loginResp.Token = CreateJWT(user);
            return Ok(loginResp);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(LoginReqDto loginReq)
        {
            if (await uow.UserRepository.UserAlreadyExists(loginReq.Username))
                return BadRequest("User already exists, please try something else");

            uow.UserRepository.Register(loginReq.Username, loginReq.Password);
            await uow.SaveAsync();
            return StatusCode(201);
        }

        private string CreateJWT(User user)
        {
            var secretKey = "secret key is here";
            var key = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(secretKey));

            var claims = new Claim[] {
                new Claim(ClaimTypes.Name,user.Username),
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString())
            };

            var signingCredentials = new SigningCredentials(
                    key, SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(1),
                SigningCredentials = signingCredentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

    }
}

