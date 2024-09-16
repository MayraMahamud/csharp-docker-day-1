using exercise.wwwapi.Data;
using exercise.wwwapi.DataModels;
using exercise.wwwapi.DTO;
using Microsoft.EntityFrameworkCore;

namespace exercise.wwwapi.Repository
{
    public class Repository : IRepository
    {
        private DataContext _db;
        public Repository(DataContext db)
        {
            _db = db;
        }
        public async Task<IEnumerable<Course>> GetCourses()
        {
            return await _db.Courses.ToListAsync();
        }

        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await _db.Students.ToListAsync();
        }

        public async Task<Student> CreateStudent(Student student)
        {
            _db.Students.Add(student);
            await _db.SaveChangesAsync();
            return new Student { Id = student.Id, FirstName = student.FirstName, LastName = student.LastName, DOB = student.DOB, StartDateForCourse = student.StartDateForCourse, AverageGrade = student.AverageGrade, CourseId= student.CourseId };

        }

        public async Task<Course> CreateCourse(Course course)
        {
            _db.Courses.Add(course);
            await _db.SaveChangesAsync();
            return new Course { Id = course.Id, CourseDescription = course.CourseDescription, CourseTitle = course.CourseTitle};

        }




        public async Task<Student> UpdateStudent(int id, DTOStudent dTOStudent)
        {
            var student = await _db.Students.FindAsync(id);
          

            student.FirstName = dTOStudent.FirstName;
            student.LastName = dTOStudent.LastName;
            student.DOB = dTOStudent.DOB;
            student.AverageGrade = dTOStudent.AverageGrade;
            student.StartDateForCourse = dTOStudent.StartDateForCourse;
            student.Id = dTOStudent.Id;
            student.CourseId = dTOStudent.CourseId;


            await _db.SaveChangesAsync();
            return student;
           
        }

        public async Task<Course> UpdateCourse(int id, DTOCourse dTOCourse)
        {
            var course = await _db.Courses.FindAsync(id);


            course.Id = dTOCourse.Id;
            course.CourseDescription = dTOCourse.CourseDescription;
            course.CourseTitle = dTOCourse.CourseTitle;
         


            await _db.SaveChangesAsync();
            return course;

        }





        public async Task<Student> DeleteStudent(int id)
        {
            var student = await _db.Students.FindAsync(id);
            if (student != null)
            {
                _db.Students.Remove(student);
                _db.SaveChangesAsync();

            }
            return student;

        }


        public async Task<Course> DeleteCourse(int id)
        {
            var course = await _db.Courses.FindAsync(id);
            if (course != null)
            {
                _db.Courses.Remove(course);
                _db.SaveChangesAsync();

            }
            return course;

        }


    }
}
