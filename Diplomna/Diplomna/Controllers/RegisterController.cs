using Diplomna.DbContexts;
using Diplomna.Dto;
using Diplomna.Entities;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace Diplomna.Controllers
{
    [Route("api/Register")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
 
        private UsersInfoContext _usersInfoContext;

        public RegisterController( UsersInfoContext usersInfoContext)
        {

            _usersInfoContext = usersInfoContext;
            
        }
        private String HashPassword(String password) {
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
        public async  Task<ActionResult<UsersInfoContext>> Register(RegisterDto registerDto) {
            //_register.RegisterUser(registerDto);
            
            Users users = new Users(registerDto.name)
            {
                id = registerDto.id,
                email = registerDto.email,
                password = HashPassword( registerDto.password)


            };
             Roles roles = new Roles("AverageUser", registerDto.id);
            _usersInfoContext.roles.Add(roles);
            _usersInfoContext.users.Add(users);
            await _usersInfoContext.SaveChangesAsync();
            
            return Ok();
        } 

    }
}
 