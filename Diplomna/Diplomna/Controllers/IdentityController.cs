using Diplomna.DbContexts;
using Diplomna.Dto;
using Diplomna.Services;
using Microsoft.AspNetCore.Mvc;


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


        [HttpPost]
        public async Task<IActionResult> LogIn(LogInDto logInDto) 
        {

           if (await _identityService.LogIn(logInDto) == true) {
                return Ok(HttpContext.Session.GetString(SessionVariables.sessionUserRole));
            }

            throw new Exception("User not found");
            
            
            
        }
    }
}
