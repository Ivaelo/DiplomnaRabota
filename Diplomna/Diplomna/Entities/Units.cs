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

        [Required]
        public string test { get; set; }
        public string Courseid { get; set; }

        public ICollection<Videos> Videos { get; set; }
        public Units(string UnitName,string test) {
            this.UnitName = UnitName;
            this.test = test;
        }
    }
}
