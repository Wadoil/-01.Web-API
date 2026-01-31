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
        [HttpGet("group/{groupName}")]
        public async Task<IActionResult> GetSchedule(
            [FromRoute] string groupName,
            [FromQuery] DateTime start,
            [FromQuery] DateTime end)
        {
            // вызываем логику из сервиса
            // если поля даты не заполнены, выводи расписание на неделю, начиная с сегодня
            if (start == DateTime.MinValue && end == DateTime.MinValue) 
            {
                start = DateTime.Now.Date;
                end = DateTime.Now.Date.AddDays(6);
            }
            // если начало не указано, выводит расписание на указанную дату
            else if (start == DateTime.MinValue && end.Date != DateTime.MinValue) start = end.Date;
            // если конец не указан, выводит расписание на указанную дату и следующую неделю
            else if (end == DateTime.MinValue && start.Date != DateTime.MinValue) end = start.Date.AddDays(6); 

            var result = await _service.GetScheduleForGroup(groupName, start.Date, end.Date);
            return Ok(result);
        }
    }
}
