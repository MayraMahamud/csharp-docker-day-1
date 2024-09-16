using exercise.wwwapi.DataModels;
using exercise.wwwapi.DataTransferObjects;
using exercise.wwwapi.DTO;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    /// <summary>
    /// Extension endpoint
    /// </summary>
    public static class CourseEndpoint
    {
        public static void CourseEndpointConfiguration(this WebApplication app)
        {
            var students = app.MapGroup("courses");
            students.MapGet("/", GetCourses);
            students.MapPut("/", UpdateCourse); 
            students.MapPost("/", CreateCourse);
            students.MapDelete("/", DeleteCourse);  
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCourses(IRepository repository)
        {
            var results = await repository.GetCourses();
            var payload = new Payload<IEnumerable<Course>>() { data = results };
            return TypedResults.Ok(payload);
        }


        public static async Task<IResult> CreateCourse(CreateCourseDTO createCourseDTO, IRepository repository)
        {

            if (string.IsNullOrWhiteSpace(createCourseDTO.CourseTitle))
            {
                return Results.BadRequest();
            }

            Course newCourse = new Course
            {
                Id = createCourseDTO.Id,
                CourseTitle = createCourseDTO.CourseTitle,
                CourseDescription = createCourseDTO.CourseDescription
               

            };
            await repository.CreateCourse(newCourse);
            DTOCourse dTOCourse = new DTOCourse()
            {
                Id = newCourse.Id,
                CourseDescription = newCourse.CourseDescription,
                CourseTitle = newCourse.CourseTitle,

            };
            return TypedResults.Ok(dTOCourse);

        }

        public static async Task<IResult> UpdateCourse(IRepository repository, int id, DTOCourse dTOCourse)
        {

            var course = await repository.UpdateCourse(id, dTOCourse);
            {
                if (course != null)
                {
                    return TypedResults.Ok(course);
                }


                return TypedResults.Ok(dTOCourse);
            }
        }

        public static async Task<IResult> DeleteCourse(IRepository repository, int id)
        {

            var course = await repository.DeleteCourse(id);
            if (course == null)
            {
                return TypedResults.Ok(course);
            }


            return TypedResults.Ok(course);
        }






    }
}
