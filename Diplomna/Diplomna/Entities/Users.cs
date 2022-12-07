using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Diplomna.Entities
{
    public class Users
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public String id { get; set; }
        [Required]
        public String name { get; set; }
        public String email { get; set; }
        public String password { get; set; }
        


        public ICollection<Courses> Corses { get; set; }
        public ICollection<Roles> Roles { get; set; }

        public Users(String name) {

            this.name = name;
        }

        public Users()
        {
        }
    }
}
