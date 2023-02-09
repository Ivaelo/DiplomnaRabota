using System.ComponentModel.DataAnnotations;

namespace Diplomna.Dto
{
    public class VideoDto
    {
        [Required]
        public String Title { get; set; }
        [Required]
        public int UnitsId { get; set; }
        [Required]
        public IFormFile file { get; set; }
    }
}
