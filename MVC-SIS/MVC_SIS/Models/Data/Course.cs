using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exercises.Models.Data
{
    public class Course
    {   
        [Required(ErrorMessage ="Course name is required.")]
        public string CourseName { get; set; }
        [Required(ErrorMessage = "Course Name is Required")]
        public int CourseId { get; set; }

    }
}