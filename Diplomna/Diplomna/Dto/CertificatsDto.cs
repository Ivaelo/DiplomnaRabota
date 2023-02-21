namespace Diplomna.Dto
{
    public class CertificatsDto
    {
        public string Name { get; set; }
        public int CoursId { get; set; }
        public IFormFile file { get; set; }
    }
}
