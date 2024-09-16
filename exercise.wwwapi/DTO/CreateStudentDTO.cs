namespace exercise.wwwapi.DTO
{
    public class CreateStudentDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public DateTime StartDateForCourse { get; set; }

        public int CourseId { get; set; }

        public string AverageGrade { get; set; } 
    }
}
