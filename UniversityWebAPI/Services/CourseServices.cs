using UniversityWebAPI.Models.DataModels;
using UniversityWebAPI.Services.Interfaces;

namespace UniversityWebAPI.Services
{
    public class CourseServices : ICourseServices
    {
        public IEnumerable<Course> getCourseFromStudent(Student student, int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Course> getCourseWithCategory(Category category, int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Course> getCourseWithoutChapter(Chapter chapter)
        {
            throw new NotImplementedException();
        }
    }
}
