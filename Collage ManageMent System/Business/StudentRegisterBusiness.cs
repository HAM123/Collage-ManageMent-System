using Collage_ManageMent_System.Domain;
using Collage_ManageMent_System.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Collage_ManageMent_System.Business
{
    public class StudentRegisterBusiness : IStudentRegisterBusiness
    {
        private readonly CollageContext context;
        private readonly IStudentCourseBusiness studentCourseBusiness;

        public StudentRegisterBusiness(CollageContext context,IStudentCourseBusiness studentCourseBusiness)
        {
            this.context = context;
            this.studentCourseBusiness = studentCourseBusiness;
        }
        public List<Course> GetRegisteredCourses(int studentId)
        {
           
                List<StudentCourse> studentCourses = context.StudentCourse.Where(sc => sc.StudentId == studentId)
                    .Include(d => d.Course).ThenInclude(c => c.Teacher).ToList();
                List<Course> courses = new List<Course>();
                foreach (StudentCourse sc in studentCourses)
                {
                    courses.Add(sc.Course);
                }
                return courses;
           
        }

        public List<Course> getUnRegisteredCourses(int studentId)
        {
            List<Course> registeredCourses = GetRegisteredCourses(studentId);
            List<Course> courses = context.Courses.ToList();
            foreach (Course rc in registeredCourses)
            {
                for (int i = 0; i < courses.Count; i++)
                {
                    if (rc.Id.Equals(courses[i].Id))
                    {
                        courses.Remove(courses[i]);
                    }
                }
            }
            return courses;
        }
        public void AddNewCourse(int CourseId,int StudentId)
        {
            StudentCourse sc = new StudentCourse();
            sc.CourseId = CourseId;
            sc.StudentId = StudentId;
            studentCourseBusiness.Insert(sc);
        }

        public void DeleteCourse(int CourseId, int StudentId)
        {
            StudentCourse sc = new StudentCourse();
            sc.CourseId = CourseId;
            sc.StudentId = StudentId;
            studentCourseBusiness.Delete(sc);
        }
    }
}
