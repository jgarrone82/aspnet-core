using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspnet_core.Models
{
    public class Grade:BaseSchoolObj
    {
        public HourTypes HourType { get; set; }
        public List<Course> Courses{ get; set; } = new List<Course>();
        public List<Student> Students{ get; set; } = new List<Student>();
        public string Address { get; set; } = "";

        public string SchoolId {get; set;} = "";

        public School school {get; set;}

    }
}