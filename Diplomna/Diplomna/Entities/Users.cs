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
        


        public virtual ICollection<Courses> Corses { get; set; }
        public ICollection<Roles> Roles { get; set; }
        public virtual ICollection<MyCourses> MyCorses { get; set; }
        public virtual ICollection<MyTests> MyTests { get; set; }
        public virtual ICollection<Certificates> Certificats { get; set; }
        public virtual ICollection<FavouriteCourses> FavouriteCorses { get; set; }

        public Users(String name) {

            this.name = name;
        }

        public Users()
        {
        }
    }
}
