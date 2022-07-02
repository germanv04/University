using Microsoft.EntityFrameworkCore;
using UniversityWebAPI.Models.DataModels;

namespace UniversityWebAPI.DataAccess
{
    public class UniversityContext: DbContext
    {
        public UniversityContext(DbContextOptions<UniversityContext> options): base(options)
        {

        }

        // TODO: Add DbSets (table of our data base)

        public DbSet<User>? Users { get; set; }
        public DbSet<Course>? Courses { get; set; }
        public DbSet<Chapter>? Chapters { get; set; }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Student>? Students { get; set; }
      

    }
}
