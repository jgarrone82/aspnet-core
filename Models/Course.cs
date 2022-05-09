using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspnet_core.Models
{
    public class Course : BaseSchoolObj
    {
        public string GradeId { get; set; } = "";

        public Grade grade { get; set; }

        public List<Exam> Exams { get; set; } = new List<Exam>();
    }

}