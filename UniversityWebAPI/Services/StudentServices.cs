using UniversityWebAPI.Models.DataModels;
using UniversityWebAPI.Services.Interfaces;

namespace UniversityWebAPI.Services
{
    public class StudentServices : IStudentServices
    {
        public IEnumerable<Student> GetStudentsWithCourse()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Student> GetStudentsWithNotCourse()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Student> GetStudentWithCourse(Course course, int Id)
        {
            throw new NotImplementedException();
        }
    }
}
