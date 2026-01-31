namespace CollegeSchedule.DTO
{
    public class ScheduleByDateDto
    {
        public DateOnly LessonDate { get; set; }
        public string Weekday { get; set; } = null!;
        public List<LessonDto> Lessons { get; set; } = new();
    }
}