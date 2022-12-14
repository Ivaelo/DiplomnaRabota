using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Diplomna.Entities
{
    public class Users
    {

        [Key]
        public String name { get; set; }
        [Required]
        public String email { get; set; }
        [Required]
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
