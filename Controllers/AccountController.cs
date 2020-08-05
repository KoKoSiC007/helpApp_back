using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SupService.Managers.Stuff;

namespace SupService.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AccountController : Controller
    {
        private IStuffManager _manager;
        public AccountController(IStuffManager manager)
        {
            _manager = manager;
        }
        
        [HttpPost]
        public async Task<IActionResult> Token(string email, string password)
        {   
            var identity = await GetIdentity(email, password);
            if (identity == null)
            {
                return BadRequest(new { errorText = "Invalid username or password." });
            }
 
            var now = DateTime.UtcNow;
            
            var jwt = new JwtSecurityToken(
                issuer: AuthOptions.ISSUER,
                audience: AuthOptions.AUDIENCE,
                notBefore: now,
                claims: identity.Claims,
                expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
 
            var response = new
            {
                access_token = encodedJwt,
                name = identity.Name
            };
 
            return Json(response);
        }
        private async Task<ClaimsIdentity> GetIdentity(string email, string password)
        {
            var person = await _manager.Get(email, password);
            if (person == null) return null;
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, person.Email),
                new Claim(ClaimsIdentity.DefaultNameClaimType, person.Phone)
            };
            var claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultNameClaimType);
            return claimsIdentity;
        }
    }
}