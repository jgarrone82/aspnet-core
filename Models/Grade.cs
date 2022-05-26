using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace aspnet_core.Models
{
    public class Grade:BaseSchoolObj
    {
        [Required]
        [StringLength(8, ErrorMessage="The max lenght is 8 characters")]
        public override string Name { get; set; } = "";
        public HourTypes HourType { get; set; }
        public List<Course> Courses{ get; set; } = new List<Course>();
        public List<Student> Students{ get; set; } = new List<Student>();

        [Required]
        [MinLength(10)]
        public string Address { get; set; } = "";

        public string SchoolId {get; set;} = "";

        public School School {get; set;} 

    }
}