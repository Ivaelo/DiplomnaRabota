using Diplomna.DbContexts;
using Diplomna.Dto;
using Diplomna.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

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
        public async Task<IActionResult> CreateTest([FromForm]TestDto testDto)
        {
            Tests test = new Tests()
            {
                UnitsId = testDto.UnitId,
                Name = testDto.Name,
               

            };


            _usersInfoContext.tests.Add(test);
            await _usersInfoContext.SaveChangesAsync();
            return Ok();
        }
        [HttpPost("AddQuestion")]
        public async Task<IActionResult> AddQuestion([FromForm]QuestionDto questionDto)
        {
            Questions question = new Questions()
            {
              TestsId = questionDto.TestsId,
              A = questionDto.A,
              B = questionDto.B,
              C = questionDto.C,
              RightAnser = questionDto.RightAnser,
              question = questionDto.question


            };


            _usersInfoContext.questions.Add(question);
            await _usersInfoContext.SaveChangesAsync();
            return Ok();
        }
        [HttpPost("SolvTest")]
        public async Task<IActionResult> SolveTest(SolvTestDto solvTestDto) {
            var Test = _usersInfoContext.questions.Where(q => q.TestsId.Equals(solvTestDto.TestId)).ToList();

            List<string> RightAnsers = new List<string>();
            List<string> CorectAnsers = new List<string>();
            Test.ForEach(q =>  RightAnsers.Add(q.RightAnser));
            for (int i = 0; i < RightAnsers.Count; i++) {
                if (solvTestDto.ansers[i].Equals(RightAnsers[i]) ) { CorectAnsers.Add(solvTestDto.ansers[i]); }
            }
            var procentige = (CorectAnsers.Count / RightAnsers.Count) * 100;
            if (procentige >= 50) {
                MyTests myTests = new MyTests()
                {
                    Score = procentige,
                    TestId = solvTestDto.TestId,
                    coursId = solvTestDto.CoursId,
                    UserName = solvTestDto.userName

                };

                _usersInfoContext.MyTests.Add(myTests);
                _usersInfoContext.SaveChanges();
                return Ok();
            }
            return BadRequest(RightAnsers);
        }
        [HttpPost("myCourses")]
        public async Task<IActionResult> MyCourses(TestScourDto testScourDto) {
            var coursExist = _usersInfoContext.MyCourses.Where(x => (x.coursId == testScourDto.coursId) &&(x.UserName.Equals(testScourDto.UserName))).FirstOrDefault();
            if (coursExist != null) Ok("This Cours awredy exists");
            MyCourses course = new MyCourses() {
                coursId= testScourDto.coursId,
                UserName= testScourDto.UserName,
                progres = 0
                
            };
            _usersInfoContext.MyCourses.Add(course);
            await _usersInfoContext.SaveChangesAsync();
            return Ok();
        }
        [HttpPut("score")]
        public async Task<IActionResult> UpdateProgres(TestScourDto testScourDto) {
            var myCours = _usersInfoContext.MyCourses.Where(x => (x.coursId == testScourDto.coursId) && (x.UserName.Equals(testScourDto.UserName))).FirstOrDefault();
            var Tests = _usersInfoContext.MyTests.Where(x=> (x.coursId == testScourDto.coursId)&&(x.UserName.Equals(testScourDto.UserName))).Count();
            var AllTests = _usersInfoContext.units.Where(x => x.CoursesId.Equals(testScourDto.coursId)).Count();
            if (myCours != null) {
                myCours.progres = myCours.progres + ((Tests/AllTests)*100);
                _usersInfoContext.MyCourses.Update(myCours);
                _usersInfoContext.SaveChanges();
            }

            return Ok();
        }
        [HttpGet("GetTest")]
        public async Task<IActionResult> GetTest(int unitId) {
            var a = _usersInfoContext.tests.Where(x => x.UnitsId == unitId).ToList();
            return Ok(a);
        }
        [HttpGet("Questions")]
        public async Task<IActionResult> GetQuestions(int testId) {
            var Questions = _usersInfoContext.questions.Where(x=> x.TestsId == testId).ToList();
            return Ok(Questions);
        }
        [HttpGet("Testid")]
        public async Task<IActionResult> GetTestId(int unitId) {
            var test = _usersInfoContext.tests.Where(x=> x.UnitsId == unitId).FirstOrDefault();
            return Ok(test);
        }
        [HttpGet("GetMyCour")]
        public async Task<IActionResult> GetMyCourses(string usersName)
        {
            var a = _usersInfoContext.MyCourses.Where(x => x.UserName.Equals(usersName)).ToList();
            return Ok(a);
        }

    }
}