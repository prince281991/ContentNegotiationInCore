using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ContentNegotiationInCore.Models
{
    public class Student
    {
        public int ID { get; set; }
        [Required]
        public string FName { get; set; }
        [Required]
        public string LName { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public long Contact { get; set; }
        [Required]
        public long City { get; set; }
    }
}
