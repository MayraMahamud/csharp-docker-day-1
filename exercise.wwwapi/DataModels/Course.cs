﻿using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.wwwapi.DataModels
{
    [Table("course")]

    public class Course
    {
        [Column("id")]

        public int Id { get; set; }
        [Column("coursetitle")]

        public string CourseTitle { get; set; }
        [Column("coursedescription")]

        public string CourseDescription { get; set; }

    }
}
