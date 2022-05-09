using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace aspnet_core.Models
{
    public abstract class BaseSchoolObj
    {
        [Key]
        public string UniqueId { get; set; }
        public string Name { get; set; }

        public BaseSchoolObj()
        {
            UniqueId = Guid.NewGuid().ToString();
            Name = "";
        }

        public override string ToString()
        {
            return $"{Name} , {UniqueId}";
        }
    }
}