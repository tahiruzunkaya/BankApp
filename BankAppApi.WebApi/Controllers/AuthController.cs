using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BankAppApi.DataAccess.Abstract;
using BankAppApi.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace BankAppApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IUnitOfWork uow;

        public AuthController(IUnitOfWork _uow)
        {
            uow = _uow;
        }

        [Route("Login")]
        [HttpPost]
        public IActionResult Login([FromBody]LoginModel model)
        {
            var result = uow.Musteriler.Find(i => i.TcKimlikNo == model.TcKimlikNo && i.Sifre == model.Sifre).FirstOrDefault();
            if (result != null)
            {
                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub,model.TcKimlikNo),
                    new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
                };

                var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MySuperSecureKey"));

                var token = new JwtSecurityToken(
                    issuer: "http://cbank.com",
                    audience: "http://cbank.com",
                    expires: DateTime.UtcNow.AddHours(1),
                    claims: claims,
                    signingCredentials: new Microsoft.IdentityModel.Tokens.SigningCredentials(signingKey,SecurityAlgorithms.HmacSha256)
                    
                    );
                return Ok(
                    new
                    {
                        token=new JwtSecurityTokenHandler().WriteToken(token),
                        expiration=token.ValidTo
                    }
                    );
            }
            return Unauthorized();
        }
    }
}