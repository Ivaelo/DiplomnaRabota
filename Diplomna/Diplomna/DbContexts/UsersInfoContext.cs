using Diplomna.Entities;
using Microsoft.EntityFrameworkCore;

namespace Diplomna.DbContexts
{
    public class UsersInfoContext : DbContext
    {
        public DbSet<Users> users { get; set; } = null!;
        public DbSet<Courses> courses { get; set; } = null!;
        public DbSet<Videos> videos { get; set; } = null!;
        public DbSet<Roles> roles { get; set; } = null!;

        public UsersInfoContext(DbContextOptions<UsersInfoContext> option) : base(option)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Users>().HasData(
                new Users("Admin")
                {
                    id = "10",
                    email = "admin@gmail.com",
                    password = "1234",
                    
                    //roles.Add("admin")
                    //zashto ne moga da dam value na roles
                }
                );
            modelBuilder.Entity<Roles>().HasData(
               new Roles("admin") {
                   Id = 1,
             
                   Usersid ="10"

               }) ;

           base.OnModelCreating(modelBuilder);
          

        }
    }

}   
    

