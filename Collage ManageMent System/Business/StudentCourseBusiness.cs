using Collage_ManageMent_System.Domain;
using Collage_ManageMent_System.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Collage_ManageMent_System.Business
{
    public class StudentCourseBusiness : IStudentCourseBusiness
    {
        private readonly CollageContext context;

        public StudentCourseBusiness(CollageContext context)
        {
            this.context = context;
        }

        public void Delete(StudentCourse studentCourse)
        {
            context.StudentCourse.Remove(studentCourse);
            context.SaveChanges();
        }

        public List<StudentCourse> GetByStudentId(int id)
        {
        return    context.StudentCourse.Where(sc => sc.StudentId == id).Include(d => d.Course).ThenInclude(a => a.Teacher).ToList();

        }

       

        public void Insert(StudentCourse studentCourse)
        {
            context.StudentCourse.Add(studentCourse);
            context.SaveChanges();
        }
    }
}
