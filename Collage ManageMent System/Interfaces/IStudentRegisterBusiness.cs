using Collage_ManageMent_System.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Collage_ManageMent_System.Interfaces
{
 public   interface IStudentRegisterBusiness
    {
        public List<Course> GetRegisteredCourses(int studentId);
        public List<Course> getUnRegisteredCourses(int studentId);
        public void AddNewCourse(int CourseId, int StudentId);
        public void DeleteCourse(int CourseId, int StudentId);
    }
}
