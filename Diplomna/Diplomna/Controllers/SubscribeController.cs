﻿using Diplomna.DbContexts;
using Diplomna.Dto;
using Diplomna.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Diplomna.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscribeController : ControllerBase
    {
        private UsersInfoContext _usersInfoContext;


        public SubscribeController(UsersInfoContext usersInfoContext)
        {

            _usersInfoContext = usersInfoContext; 
          
        }
        [HttpPost]
        public async Task<IActionResult> Subscribe(SubscribeDto subscribeDto) {
            var sub = _usersInfoContext.favCourses.Where(x => x.CoursesId == subscribeDto.coursId && x.UserName.Equals(subscribeDto.name)).FirstOrDefault();
            if (HttpContext.Session.GetString(subscribeDto.name) != "AverageUser")
            {
                return BadRequest("you are not autorized");
            }
            var coursName = _usersInfoContext.courses.Find(subscribeDto.coursId);
            if (sub == null)
            {
                FavouriteCourses favC = new FavouriteCourses()
                {
                    UserName = subscribeDto.name,
                    CoursesId = subscribeDto.coursId,
                    Name = coursName.CoursName,

                };
                _usersInfoContext.favCourses.Add(favC);
                await _usersInfoContext.SaveChangesAsync();
                return Ok("succesfully subbscribed");
            }
            else {
                return BadRequest("You are alredy subscribed");
            }
        }
        [HttpGet("/GetSub")]
        public async Task<IActionResult> getSubedCourses(string userName) {
            var subed = _usersInfoContext.favCourses.Where(x => x.UserName.Equals(userName)).ToList();
            return Ok(subed);
        }
    }
}
