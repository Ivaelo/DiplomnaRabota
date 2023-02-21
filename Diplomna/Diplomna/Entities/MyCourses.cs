using ServiceStack.DataAnnotations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Diplomna.Entities
{
    public class MyCourses
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int coursId { get; set; }
        public float progres { get; set; }
        public string UserName { get; set; }
        public virtual Users User { get; set; }
    }
}
