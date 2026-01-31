using CollegeSchedule.Data;
using CollegeSchedule.Models;
using CollegeSchedule.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CollegeSchedule.Controllers
{
    [ApiController]
    [Route("api/")]
    public class GroupsController : ControllerBase
    {
        private readonly IGroupsService _service;
        public GroupsController(IGroupsService service, AppDbContext db)
        {
            _service = service;
        }

        // GET: api/groups?speciality=speciality&course=course
        [HttpGet("groups/")]
        public async Task<IActionResult> GetGroups (
            [FromQuery] int course,
            [FromQuery] string? speciality = null)
        {
            var result = await _service.GetGroups(course, speciality);
            return Ok(result);
        }
    }
}
