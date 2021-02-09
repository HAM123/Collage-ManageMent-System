using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Collage_ManageMent_System.Domain
{
    public class Teacher
    {
        public String Name { get; set; }
        public Guid Id { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBrith { get; set; }
        public string Gender { get; set; }
        public string PhotoPath { get; set; }
        public IList<Course> TeacherCourses { get; set; }
    }
}
