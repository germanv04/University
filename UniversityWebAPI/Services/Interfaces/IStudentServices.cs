using UniversityWebAPI.Models.DataModels;

namespace UniversityWebAPI.Services.Interfaces
{
    public interface IStudentServices
    {

        IEnumerable<Student> GetStudentsWithCourse();

        //Obtener alumnos de un Curso concreto
        IEnumerable<Student> GetStudentWithCourse(Course course, int Id);

        IEnumerable<Student> GetStudentsWithNotCourse();

    }
}
