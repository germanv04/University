using UniversityWebAPI.Models.DataModels;

namespace UniversityWebAPI.Services.Interfaces
{
    public interface IChapterServices
    {
        
        //Obtener temario de un curso concreto
        IEnumerable<Chapter> getCourseChapters(Course course, int Id);
    }
}
