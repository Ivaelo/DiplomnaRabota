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
        private string bucketName = "diplomnarabotavideos";
        public VideoController(IAmazonS3 s3Client,UsersInfoContext usersInfoContext) {
            _s3Client=s3Client;
            _usersInfoContext=usersInfoContext;
        }
       
        [HttpPost("/UpoladVideo")]
        public async Task<IActionResult> UpoadVideo([FromForm] VideoDto videoDto) {          
            String prefix = null;
            var BucketName = _s3Client.DoesS3BucketExistAsync(bucketName);
            if (BucketName == null) return BadRequest("There is not such buket");
            var request = new PutObjectRequest()
            {
                BucketName = bucketName,
                Key = string.IsNullOrEmpty(prefix) ? videoDto.file.FileName : $"{prefix?.TrimEnd('/')}/{videoDto.file.FileName}",
                //kakvo se ima predvid opens the request from the reead streem
                InputStream = videoDto.file.OpenReadStream()
            };

            Videos videos = new Videos(videoDto.Title, request.Key) {
                UnitsId = videoDto.UnitsId,
            };

            _usersInfoContext.videos.Add(videos);
            await _usersInfoContext.SaveChangesAsync();
            //kakvo tochno e metadatata v amazon s3
            request.Metadata.Add("MP4", videoDto.file.ContentType);
            await _s3Client.PutObjectAsync(request);

            return Ok(); }
        //zashto ako ne e async ne mi dava  da vurna ok()
        [HttpPost("/CreateCourese")]
        public async Task<IActionResult> CreateCourese([FromForm]CoursDto courseDto) {
            if (HttpContext.Session.GetString(SessionVariables.sessionUserRole) != "SuperUser") {
                return Unauthorized("You need to be supergotin");
            }
            String prefix = null;
            var BucketName = _s3Client.DoesS3BucketExistAsync(bucketName);
            if (BucketName == null) return BadRequest("There is not such buket");
            var request = new PutObjectRequest()
            {
                BucketName = bucketName,
                Key = string.IsNullOrEmpty(prefix) ? courseDto.file.FileName : $"{prefix?.TrimEnd('/')}/{courseDto.file.FileName}",
                //kakvo se ima predvid opens the request from the reead streem
                InputStream = courseDto.file.OpenReadStream()
            };
            request.Metadata.Add("MP4", courseDto.file.ContentType);
            await _s3Client.PutObjectAsync(request);
            var Course = new Courses(courseDto.CoursName)
            {
                Description = courseDto.Description,
                UserName = HttpContext.Session.GetString(SessionVariables.sessionUserName),
                Picture = request.Key,
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

            if (doesCouresExist != null)
            {
                var unit = new Units(unitDto.UnitName, unitDto.test)
                {
                    CoursesId = unitDto.CourseId,

                };
                _usersInfoContext.units.Add(unit);
                await _usersInfoContext.SaveChangesAsync();
                return Ok();
            }
            return BadRequest("You are not a contributer to the coures");
        }
        [HttpDelete("DeletVideo")]
        public async Task<IActionResult> DeleteVideo(DeleteVideoDto videoDto)
        {
            var bucketExists = await _s3Client.DoesS3BucketExistAsync(bucketName);
            if (!bucketExists) return NotFound($"Bucket {bucketName} does not exist");
            await _s3Client.DeleteObjectAsync(bucketName, videoDto.path);
            var videos = _usersInfoContext.videos.Find(videoDto.Id);
            _usersInfoContext.videos.Remove(videos);
            _usersInfoContext.SaveChanges();

            return Ok();
        }
    }
}
