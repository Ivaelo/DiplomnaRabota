using Diplomna.DbContexts;
using Diplomna.Dto;
using Diplomna.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Diplomna.Services
{
    public class IdentityService : IdentityInterface
    {
        UsersInfoContext _usersInfoContext;
        private IHttpContextAccessor _accessor;

        

        public IdentityService(UsersInfoContext usersInfoContext, IHttpContextAccessor accessor)
        {
            _usersInfoContext = usersInfoContext ?? throw new ArgumentNullException(nameof(usersInfoContext));
            _accessor = accessor;
            
        }


        public async Task<bool> SetRole(String Role,String userName ) {
            Roles roles = new Roles(Role, userName);
            _usersInfoContext.roles.Add(roles);
           // await _usersInfoContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> UpdateRole(String Role, String userName,int RoleId)
        {
            Roles roles = new Roles(Role, userName) {
                Id = RoleId,
            };
            _usersInfoContext.roles.Update(roles);
            await _usersInfoContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> LogIn(LogInDto logInDto)
        {
            var context = _accessor.HttpContext;
            var a = _usersInfoContext.users.Where(p => (p.name.Equals(logInDto.name))).FirstOrDefault();
            if (a == null) {
                return false;
            }
            if (BCrypt.Net.BCrypt.Verify(logInDto.password, a.password) == true)
            {
                var role = _usersInfoContext.roles.Where(p => p.UsersName.Equals(a.name)).FirstOrDefault();
                if (string.IsNullOrWhiteSpace(context.Session.GetString(SessionVariables.sessionUserName)))
                {
                    context.Session.SetString(SessionVariables.sessionUserName, a.name);
                    context.Session.SetString(SessionVariables.sessionUserRole, role.Role);
                }
               
            }
            else
            {
                throw new Exception("user not found");
            }
            
            return true;
        }

        public async Task<bool> RegisterUser(RegisterDto registerDto)
        {
            String pass = BCrypt.Net.BCrypt.HashPassword(registerDto.password);
            Users users = new Users(registerDto.name)
            {
               
                email = registerDto.email,
                password = pass

            };

            
            _usersInfoContext.users.Add(users);
            await _usersInfoContext.SaveChangesAsync();
            return true;
        }

        public async Task<String> AproveSuperUser(string name, bool isAproved, int roleId)
        {
            if (isAproved == true)
            {
                UpdateRole("SuperUser", name, roleId);

                
                return "aproved";
            }
            
            throw new Exception("User is not validated");
            
        }


    }
}
