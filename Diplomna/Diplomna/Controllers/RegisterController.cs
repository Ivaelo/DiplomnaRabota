using Diplomna.DbContexts;
using Diplomna.Dto;
using Diplomna.Entities;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost]
        public   ActionResult<UsersInfoContext> Register(RegisterDto registerDto) {
            //_register.RegisterUser(registerDto);          
            Users users = new Users(registerDto.name)
            {
                id = registerDto.id,
                email = registerDto.email,
                password = registerDto.password


            };
            _usersInfoContext.users.Add(users);
          
            _usersInfoContext.SaveChangesAsync();

            return Ok();
        } 

    }
}
