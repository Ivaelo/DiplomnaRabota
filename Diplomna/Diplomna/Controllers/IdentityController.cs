using Diplomna.DbContexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Diplomna.Controllers
{
    [Route("api/identity")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        UsersInfoContext _usersInfoContext;
        public IdentityController(UsersInfoContext usersInfoContext) {
            _usersInfoContext = usersInfoContext ?? throw new ArgumentNullException(nameof(usersInfoContext));
        }
        [HttpPost]
        public async Task<IActionResult> LogIn(LogInDto logInDto) 
        {
            _usersInfoContext.users.Where(p => p.name.Equals(logInDto.name))
        }
    }
}
