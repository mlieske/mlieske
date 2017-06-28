using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exercises.Models.Data
{
    public class Major
    {
        [Required(ErrorMessage = "Major Name is Required")]
        public int MajorId { get; set; }

        //[Required(ErrorMessage = "Major Name is Required")]
        public string MajorName { get; set; }
    }
}