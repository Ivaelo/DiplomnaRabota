using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Diplomna.Entities
{
    public class FavouriteCourses
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int CoursesId { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public virtual Users User { get; set; }
    }
}
