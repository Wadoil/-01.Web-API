using CollegeSchedule.DTO;

namespace CollegeSchedule.Services
{
    public interface IGroupsService
    {
        Task<List<GroupsDto>> GetGroups(int course, string? speciality);
    }
}
