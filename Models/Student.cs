using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspnet_core.Models
{
    public class Student : BaseSchoolObj
    {
        public List<Exam> Exams { get; set; } = new List<Exam>();

        public string GradeId { get; set; } = "";

        public Grade grade { get; set; }
    }
}