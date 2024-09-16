using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.wwwapi.DTO
{
    public class DTOCourse
    {
        public int Id { get; set; }
       

        public string CourseTitle { get; set; }
       

        public string CourseDescription { get; set; }
    }
}
