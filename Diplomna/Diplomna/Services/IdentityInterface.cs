using Diplomna.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Diplomna.Services
{
    public interface IdentityInterface
    {
        public  Task<bool> LogIn(LogInDto logInDto);

        public Task<bool> RegisterUser(RegisterDto registerDto);
        public  Task<bool> SetRole(String Role, String userId);
        public Task<String> AproveSuperUser(String id,Boolean isAproved);
    } 
}
