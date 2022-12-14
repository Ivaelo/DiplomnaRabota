using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Diplomna.Entities
{
    
    public class Roles
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public String Role { get; set; }
        [ForeignKey("UsersName")]
        public string UsersName { get; set; }

        public Roles ( string Role,string UsersName)
        {

            this.Role = Role;
            this.UsersName = UsersName;
        }
    }
}
