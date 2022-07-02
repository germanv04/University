using UniversityWebAPI.Models.DataModels;

namespace UniversityWebAPI.Services.Interfaces
{
    public interface ICourseServices
    {
        //Obtener todos los Cursos de una categoría concreta
        IEnumerable<Course> getCourseWithCategory(Category category, int Id);
        
        //Obtener Cursos sin temarios
        IEnumerable<Course> getCourseWithoutChapter();

        //Obtener los Cursos de un Alumno
        IEnumerable<Course> getCourseFromStudent(Student student, int Id);
    }
}
