using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Collage_ManageMent_System.Domain
{
    public class Course
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
         public IList<StudentCourse> StudentCourses { get; set; }
        public Teacher Teacher { get; set; }
    }
}
