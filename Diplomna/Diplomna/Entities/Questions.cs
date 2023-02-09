using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Diplomna.Entities
{
    public class Questions
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string RightAnser { get; set; }

        [Required]
        public string A { get; set; }
        [Required]
        
        public string B { get; set; }
        [Required]
        public string C { get; set; }
        public int TestsId { get; set; }
        public virtual Tests Tests { get; set; }

    }
}
