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
        public DbSet<Units> units { get; set; } = null!;
        public DbSet<Tests> tests { get; set; } = null!;
        public DbSet<Questions> questions { get; set; } = null!;

        public UsersInfoContext(DbContextOptions<UsersInfoContext> option) : base(option)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Users>().HasData(
                new Users("Admin")
                {
                    email = "admin@gmail.com",
                    password = BCrypt.Net.BCrypt.HashPassword("1234"),
                    
                    //roles.Add("admin")
                    //zashto ne moga da dam value na roles
                }
                );
            modelBuilder.Entity<Roles>().HasData(
               new Roles("admin","Admin") {
                    Id = 1,
               }) ;

           base.OnModelCreating(modelBuilder);
          

        }
    }

}   
    

