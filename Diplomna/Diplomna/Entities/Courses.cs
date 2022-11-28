using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Diplomna.Entities
{
    public class Courses
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public String Courseid { get; set; }

        [ForeignKey("Creator")]
        public String Creator { get; set; }
        [Required]
        public String CoursName { get; set; }
        [Required]
        [MaxLength(200)]
        public String Description { get; set; }
        public ICollection<Videos> Videos { get; set; } 
            = new List<Videos>();
        public Courses(string CoursName) { 
            this.CoursName = CoursName;
        }

    }
}
