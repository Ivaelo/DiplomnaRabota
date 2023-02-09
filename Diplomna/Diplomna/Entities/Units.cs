using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Diplomna.Entities
{
    public class Units
    {
       
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Unitid { get; set; }
        [Required]
        public string UnitName { get; set; }

        public string test { get; set; }

        public int CoursesId { get; set; }
        public virtual Courses Course { get; set; }

        public virtual ICollection<Videos> Videos { get; set; }
        public virtual ICollection<Tests> Tests { get; set; }
        public Units(string UnitName,string test) {
            this.UnitName = UnitName;
            this.test = test;
        }
    }
}
