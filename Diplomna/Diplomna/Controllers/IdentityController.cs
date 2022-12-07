using Diplomna.DbContexts;
using Diplomna.Dto;
using Diplomna.Services;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;

namespace Diplomna.Controllers
{
    [Route("api/identity")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        UsersInfoContext _usersInfoContext;
        private readonly IdentityInterface _identityService;

        public IdentityController(UsersInfoContext usersInfoContext,IdentityInterface identityService) {
            _usersInfoContext = usersInfoContext ?? throw new ArgumentNullException(nameof(usersInfoContext));
            _identityService = identityService;
        }
        private String HashPassword(String password)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(128 / 8);
            Console.WriteLine($"Salt: {Convert.ToBase64String(salt)}");


            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password!,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));

            return hashed;
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(LogInDto logInDto) 
        {

            var a =  _usersInfoContext.users.Where(p => (p.name.Equals(logInDto.name)) && (p.password.Equals(_identityService.HashPassword( logInDto.password)))).First();
            if (a.name == null) 
            {
                return NotFound();
            }
            var role = _usersInfoContext.roles.Where(p=> p.Usersid.Equals(a.id)).FirstOrDefault();
            if (string.IsNullOrWhiteSpace(HttpContext.Session.GetString(SessionVariables.sessionUserId))) {
                HttpContext.Session.SetString(SessionVariables.sessionUserId, a.id);
                HttpContext.Session.SetString(SessionVariables.sessionUserRole,role.Role);
            }
            

            return Ok();
        }
    }
}
