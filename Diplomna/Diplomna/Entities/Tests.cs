using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Diplomna.Entities
{
    public class Tests
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }
        public int UnitsId { get; set; }
        public virtual Units Units { get; set; }

        public virtual ICollection<Questions> Questions { get; set; }
    }
}
