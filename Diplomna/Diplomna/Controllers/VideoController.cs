using Amazon.S3;
using Amazon.S3.Model;
using Diplomna.DbContexts;
using Diplomna.Dto;
using Diplomna.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Diplomna.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoController : ControllerBase
    {
        private readonly IAmazonS3 _s3Client;
        UsersInfoContext _usersInfoContext;
        public VideoController(IAmazonS3 s3Client,UsersInfoContext usersInfoContext) {
            _s3Client=s3Client;
            _usersInfoContext=usersInfoContext;
        }
        [HttpPost("/UpoladVideo")]
        public async Task<IActionResult> UpoadVideo(IFormFile file, String bucketName,String? prefix) {
            var BucketName = _s3Client.DoesS3BucketExistAsync(bucketName);
            if (BucketName == null) return BadRequest("There is not such buket");
            var request = new PutObjectRequest()
            {
                BucketName = bucketName,
                Key = string.IsNullOrEmpty(prefix) ? file.FileName : $"{prefix?.TrimEnd('/')}/{file.FileName}",
                //kakvo se ima predvid opens the request from the reead streem
                InputStream = file.OpenReadStream()
            };
            Videos videos = new Videos("Video1", 1, request.FilePath) {
                UnitsId = 1
            };
            _usersInfoContext.videos.Add(videos);
            await _usersInfoContext.SaveChangesAsync();
            //kakvo tochno e metadatata v amazon s3
            request.Metadata.Add("MP4", file.ContentType);
            await _s3Client.PutObjectAsync(request);
            return Ok(); }
        //zashto ako ne e async ne mi dava  da vurna ok()
        [HttpPost("/CreateCourese")]
        public async Task<IActionResult> CreateCourese(CoursDto courseDto) {
            if (HttpContext.Session.GetString(SessionVariables.sessionUserRole) != "SuperUser") {
                return Unauthorized("You need to be supergotin");
            }
            var Course = new Courses(courseDto.CoursName)
            {
                Description = courseDto.Description,
                UserName = HttpContext.Session.GetString(SessionVariables.sessionUserName),
            };
            _usersInfoContext.courses.Add(Course);
            await _usersInfoContext.SaveChangesAsync();
            return Ok();
        }
        [HttpPost("/AddUnit")]
        public async Task<IActionResult> AddUnit(UnitDto unitDto) {
            string userName = HttpContext.Session.GetString(SessionVariables.sessionUserName);
            Console.Write(userName);
            var doesCouresExist =  _usersInfoContext.courses.Where(task => (task.UserName.Equals( userName))&&(task.Courseid.Equals(unitDto.CourseId))).FirstOrDefault();
            Console.WriteLine(doesCouresExist);
            Console.WriteLine(doesCouresExist.ToString);
            if (doesCouresExist != null)
            {
                var unit = new Units(unitDto.UnitName, unitDto.test)
                {
                    CourseId = unitDto.CourseId,

                };
                _usersInfoContext.units.Add(unit);
                await _usersInfoContext.SaveChangesAsync();
                return Ok();
            }
            return BadRequest("You are not a contributer to the coures");
        }
    }
}
