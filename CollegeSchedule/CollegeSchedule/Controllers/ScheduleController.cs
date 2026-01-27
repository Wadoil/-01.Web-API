using CollegeSchedule.Data;
using CollegeSchedule.Models;
using CollegeSchedule.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace CollegeSchedule.Controllers
{
    [ApiController]
    [Route("api/schedule")]
    public class ScheduleController : ControllerBase
    {
        private readonly IScheduleService _service;
        public ScheduleController(IScheduleService service, AppDbContext db)
        {
            _service = service;
        }

        // GET: api/schedule/group/{groupName}?start=start.Date&end=end.Date
        [HttpGet("group/{GroupName}")]
        public async Task<IActionResult> GetSchedule(string groupName, DateTime start, DateTime end)
        {
            // вызываем логику из сервиса
            var result = await _service.GetScheduleForGroup(groupName, start.Date, end.Date);
            return Ok(result);
        }
    }
}
