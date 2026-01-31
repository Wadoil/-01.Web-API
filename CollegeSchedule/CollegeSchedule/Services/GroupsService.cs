using CollegeSchedule.Data;
using CollegeSchedule.DTO;
using CollegeSchedule.Models;
using Microsoft.EntityFrameworkCore;

namespace CollegeSchedule.Services
{
    public class GroupsService : IGroupsService
    {
        private readonly AppDbContext _db;
        public GroupsService(AppDbContext db)
        {
            _db = db;
        }
        public async Task<List<GroupsDto>> GetGroups(int Course, string Speciality)
        {
            var specialty = await _db.Specialties.FirstOrDefaultAsync(x => x.Name == Speciality);

            var Groups = new List<StudentGroup>();
            if (Course == 0 && specialty == null)
                Groups = _db.StudentGroups.ToList();
            else if (Course == 0)
                Groups = _db.StudentGroups.Where(x => x.SpecialtyId == specialty.Id).ToList();
            else if (specialty == null)
                Groups = _db.StudentGroups.Where(x => x.Course == Course).ToList();
            else Groups = _db.StudentGroups.Where(x => x.Course == Course && x.SpecialtyId == specialty.Id).ToList();

            var result = new List<GroupsDto>();
            for (int i = 0; i != Groups.Count; i++)
            {
                GroupsDto _group = new GroupsDto();
                _group.Speciality = _db.Specialties.FirstOrDefault(x => x.Id == Groups[i].SpecialtyId).Name;
                _group.Course = Groups[i].Course;
                _group.GroupName = Groups[i].GroupName;

                result.Add(_group);
            }
            return result;
        }
    }
}
