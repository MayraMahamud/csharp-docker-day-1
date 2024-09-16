using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.wwwapi.DataModels
{
    [Table("Student")]
    public class Student
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("firstname")]

        public string FirstName { get; set; }
        [Column("lastname")]

        public string LastName { get; set; }
        [Column("dob")]

        public DateTime DOB { get; set; }
        

        //public Course Course { get; set; }
       

        [Column("courseid")] 
        [ForeignKey("Course")]

        public int  CourseId { get; set; }
       

        public DateTime  StartDateForCourse { get; set; }
        [Column("averagegrade")]

        public string AverageGrade { get; set; }

    }
}
