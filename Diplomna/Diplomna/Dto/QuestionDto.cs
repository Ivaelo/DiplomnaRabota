using System.ComponentModel.DataAnnotations;

namespace Diplomna.Dto
{
    public class QuestionDto
    {
        [Required]
        public string RightAnser { get; set; }

        [Required]
        public string A { get; set; }
        [Required]

        public string B { get; set; }
        [Required]
        public string C { get; set; }
        [Required]
        public string question { get; set; }
        public int TestsId { get; set; }
    }
}
