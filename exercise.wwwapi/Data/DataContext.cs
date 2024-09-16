using exercise.wwwapi.DataModels;
using Microsoft.EntityFrameworkCore;

namespace exercise.wwwapi.Data
{
    public class DataContext : DbContext
    {
        private string _connectionString;

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            _connectionString = configuration.GetValue<string>("ConnectionStrings:DockerPostgres")!;

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Student>().HasMany(k => k.Students);

            modelBuilder.Entity<Student>().HasData(
              new { Id = 1, FirstName = "Mayra", LastName = "Mahamud", DOB = DateTime.UtcNow, CourseId = 1, StartDateForCourse = DateTime.UtcNow, AverageGrade = "A"}
           );

            modelBuilder.Entity<Course>().HasData(
             new { Id = 1, CourseTitle = "English", CourseDescription = "Easy Course" }
          );

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}
