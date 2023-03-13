using Amazon.S3;
using Amazon.S3.Model;
using Diplomna.DbContexts;
using Diplomna.Dto;
using Diplomna.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Diplomna.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CertificatController : ControllerBase
    {
        private readonly IAmazonS3 _s3Client;
        UsersInfoContext _usersInfoContext;
        private string bucketName = "diplomnarabotavideos";
        public CertificatController(IAmazonS3 s3Client, UsersInfoContext usersInfoContext)
        {
            _s3Client = s3Client;
            _usersInfoContext = usersInfoContext;
        }

        [HttpPost("/UpoladCertificat")]
        public async Task<IActionResult> UpoadCertificat([FromForm] CertificatsDto cDto)
        {
            String prefix = null;
            var BucketName = _s3Client.DoesS3BucketExistAsync(bucketName);
            if (BucketName == null) return BadRequest("There is not such buket");
            var request = new PutObjectRequest()
            {
                BucketName = bucketName,
                Key = string.IsNullOrEmpty(prefix) ? cDto.file.FileName : $"{prefix?.TrimEnd('/')}/{cDto.file.FileName}",
                //kakvo se ima predvid opens the request from the reead streem
                InputStream = cDto.file.OpenReadStream()
            };

             CoursCertificates certificats = new CoursCertificates()
            {
                Name = cDto.Name,
                Path = request.Key,
                CoursesId = cDto.CoursId
            };

            _usersInfoContext.CoursCertificats.Add(certificats);
            await _usersInfoContext.SaveChangesAsync();
            //kakvo tochno e metadatata v amazon s3
            request.Metadata.Add(cDto.file.Name, cDto.file.ContentType);
            await _s3Client.PutObjectAsync(request);

            return Ok();
        }
        [HttpPost("CertificateUser")]
        public async Task<IActionResult> CertificateUser(string UserName) {
            var myCorurses = _usersInfoContext.MyCourses.Where(x => (x.UserName.Equals(UserName)) && (x.progres == 100)).ToList();
            var coursCertificats = _usersInfoContext.CoursCertificats.ToList();
            var myCertificats = _usersInfoContext.Certificats.Where(x => x.UserName.Equals(UserName)).ToList();
            for (int i = 0; i < myCertificats.Count; i++) {
                if (myCorurses[i].coursId == myCertificats[i].coursId) {
                    myCorurses.RemoveAt(i);
                }
            }
            if (myCorurses != null) {
                for (int i = 0; i < myCorurses.Count; i++)
                {
                    if (myCorurses[i].coursId == coursCertificats[i].CoursesId)
                    {
                        Certificates certificats = new Certificates()
                        {
                            Name = coursCertificats[i].Name,
                            Path = coursCertificats[i].Path,
                            coursId = coursCertificats[i].CoursesId,
                            UserName = UserName,
                        };
                        _usersInfoContext.Certificats.Add(certificats);
                        await _usersInfoContext.SaveChangesAsync();
                        Console.WriteLine("Vleze v Cikala");
                    }
                    Console.WriteLine(i);
                }
  
                return Ok(coursCertificats[0].CoursesId);
            }

            return BadRequest("certificat was not created");
        }
        [HttpGet("CertificatsOfUser")]
        public async Task<IActionResult> GetCertificats(string userName) {
            var certificats = _usersInfoContext.Certificats.Where(x => x.UserName.Equals(userName)).ToList();
            return Ok(certificats);
        }
    }
}
