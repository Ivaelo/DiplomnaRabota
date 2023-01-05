using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Diplomna.Entities
{
    public class Courses
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Courseid { get; set; }

        public string UserName { get; set; }
        public virtual Users User { get; set; }

        [Required]
        public String CoursName { get; set; }
        [Required]
        [MaxLength(200)]
        public String Description { get; set; }

        public virtual ICollection<Units> Units { get; set; }
        public Courses(string CoursName) { 
            this.CoursName = CoursName;
        }

    }
}
