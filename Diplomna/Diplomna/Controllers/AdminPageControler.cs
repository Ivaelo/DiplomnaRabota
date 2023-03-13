using Diplomna.DbContexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Diplomna.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminPageControler : ControllerBase
    {
        UsersInfoContext _usersInfoContext;

        public AdminPageControler(UsersInfoContext usersInfoContext)
        {
            _usersInfoContext = usersInfoContext ?? throw new ArgumentNullException(nameof(usersInfoContext));
           
        }
        [HttpGet]
        public async Task<IActionResult> GetAllPendingUsers() {
            var a = _usersInfoContext.roles.Where(u=>u.Role.Equals("NotAccepted")).ToList();
            return Ok(a);
        }
    }
}
