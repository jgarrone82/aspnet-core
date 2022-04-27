using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspnet_core.Models
{
    public class School
    {
        public string SchoolId { get; set; } = "";
        public string Name { get; set; } = "";
        public int YearOfCreation { get; set; }
    }
}