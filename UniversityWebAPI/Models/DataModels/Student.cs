using System.ComponentModel.DataAnnotations;

namespace UniversityWebAPI.Models.DataModels
{
    public class Student: BaseEntity
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        public DateTime Dob { get; set; }
        public ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}
