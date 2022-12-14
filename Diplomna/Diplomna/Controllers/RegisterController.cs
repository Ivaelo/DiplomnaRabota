using Diplomna.DbContexts;
using Diplomna.Dto;
using Diplomna.Entities;
using Diplomna.Services;
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
        private IdentityInterface _identityService;

        public RegisterController(UsersInfoContext usersInfoContext, IdentityInterface identityService)
        {

            _usersInfoContext = usersInfoContext;
            _identityService = identityService;
        }

        [HttpPost]
        public async Task<ActionResult<UsersInfoContext>> Register(RegisterDto registerDto) {

            await _identityService.RegisterUser(registerDto);
            _identityService.SetRole("AverageUser", registerDto.name);
            await _usersInfoContext.SaveChangesAsync();
            return Ok();
        }
        [HttpPost("/superUser")]
        public async Task<IActionResult> RegisterSuperUser(RegisterDto registerDto) {
            await _identityService.RegisterUser(registerDto);
            return Ok("Your account is weating for aproval");
        }
        [HttpPost("/aproveSuperUser")]
        public async Task<IActionResult> AproveSuperUser(String id,bool isAproved) {
           var mesage =  await _identityService.AproveSuperUser(id,isAproved);
            return Ok(mesage);
        }
    }
}
 