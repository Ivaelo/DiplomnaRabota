using Diplomna.DbContexts;
using Diplomna.Dto;
using Diplomna.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Diplomna.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        UsersInfoContext _usersInfoContext;
        public TestController(UsersInfoContext usersInfoContext)
        {
            ;
            _usersInfoContext = usersInfoContext;
        }
        [HttpPost("CreateTest")]
        public async Task<IActionResult> CreateTest(TestDto testDto)
        {
            Tests test = new Tests()
            {
                UnitsId = testDto.UnitId
                

            };


            _usersInfoContext.tests.Add(test);
            await _usersInfoContext.SaveChangesAsync();
            return Ok();
        }
    }
}