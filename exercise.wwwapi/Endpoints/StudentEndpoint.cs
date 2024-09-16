using exercise.wwwapi.DataModels;
using exercise.wwwapi.DataTransferObjects;
using exercise.wwwapi.DTO;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    /// <summary>
    /// Core Endpoint
    /// </summary>
    public static class StudentEndpoint
    {
        public static void StudentEndpointConfiguration(this WebApplication app)
        {
            var students = app.MapGroup("students");
            students.MapGet("/", GetStudents);
            students.MapPost("/", CreateStudent);
            students.MapPut("/", UpdateStudent);
            students.MapDelete("/", DeleteStudent);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudents(IRepository repository)
        {
            var results = await repository.GetStudents();
            var payload = new Payload<IEnumerable<Student>>() { data = results };
            return TypedResults.Ok(payload);
        }

        public static async Task<IResult> CreateStudent(CreateStudentDTO createStudentDTO, IRepository repository)
        {

            if (string.IsNullOrWhiteSpace(createStudentDTO.FirstName))
            {
                return Results.BadRequest();
            }

            Student newStudent = new Student
            {
                FirstName = createStudentDTO.FirstName,
                Id = createStudentDTO.Id,
                LastName = createStudentDTO.LastName,
                DOB = createStudentDTO.DOB,
                AverageGrade = createStudentDTO.AverageGrade,
                StartDateForCourse = createStudentDTO.StartDateForCourse,
                CourseId = createStudentDTO.CourseId,

            };
            await repository.CreateStudent(newStudent);
            DTOStudent dTOStudent = new DTOStudent()
            {
                FirstName = newStudent.FirstName,
                LastName = newStudent.LastName,
                DOB = newStudent.DOB,
                AverageGrade = newStudent.AverageGrade,
                StartDateForCourse = newStudent.StartDateForCourse,
                Id = newStudent.Id,
                CourseId = newStudent.CourseId,




            };
            return TypedResults.Ok(dTOStudent);

        }

        public static async Task<IResult> UpdateStudent(IRepository repository, int id, DTOStudent dTOStudent)
        {
           
            var student = await repository.UpdateStudent(id, dTOStudent);
            {
                if (student != null)
                {
                    return TypedResults.Ok(student);
                }
               
               
                return TypedResults.Ok(dTOStudent);
            }
        }

        public static async Task<IResult> DeleteStudent(IRepository repository, int id)
        {
          
            var student = await repository.DeleteStudent(id);
            if (student == null)
            {
                return TypedResults.Ok(student);
            }
           
           
            return TypedResults.Ok(student);
        }






    }


}
