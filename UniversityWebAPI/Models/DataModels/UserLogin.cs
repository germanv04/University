using System.ComponentModel.DataAnnotations;

namespace UniversityWebAPI.Models.DataModels
{
    public class UserLogin
    {
        [Required]
        public string UserName { get; set; } = String.Empty;
        [Required]
        public string Password { get; set; } = String.Empty;
    }
}
