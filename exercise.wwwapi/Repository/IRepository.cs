using exercise.wwwapi.DataModels;
using exercise.wwwapi.DTO;

namespace exercise.wwwapi.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<Student>> GetStudents();
       
        Task<Student> CreateStudent(Student student);
        Task<Student> UpdateStudent(int id, DTOStudent dTOStudent);
        Task <Student> DeleteStudent(int id);




        Task<IEnumerable<Course>> GetCourses();
        Task<Course> CreateCourse(Course course);
        Task<Course> UpdateCourse(int id, DTOCourse dTOCourse);
        Task<Course> DeleteCourse(int id);


    }

}
