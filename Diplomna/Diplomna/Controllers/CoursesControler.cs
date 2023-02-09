using Diplomna.DbContexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Diplomna.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesControler : ControllerBase
    {

        UsersInfoContext _usersInfoContext;
        public CoursesControler( UsersInfoContext usersInfoContext)
        {
;
            _usersInfoContext = usersInfoContext;
        }
        [HttpGet("GetCourses")]
        public async Task<IActionResult> GerCourser(String UserName) {
            var a =  _usersInfoContext.courses.Where(task => task.UserName.Equals(UserName)).ToList();
            return Ok(a);
        }
        [HttpGet("GetUnits")]
        public async Task<IActionResult> GerUnits(int CoursId)
        {
           var a = _usersInfoContext.units.Where(task => task.CoursesId.Equals(CoursId)).ToList();
            return Ok(a);
        }
        [HttpGet("LoadCourses")]
        public async Task<IActionResult> LoadCourser()
        {
            var a = _usersInfoContext.courses.ToList();
            return Ok(a);
        }
        [HttpGet("SurchCours")]
        public async Task<IActionResult> SurchCourser(String coursName)
        {
            var a = _usersInfoContext.courses.Where(c=>c.CoursName.Equals(coursName)).ToList();
            return Ok(a);
        }

    }
}
