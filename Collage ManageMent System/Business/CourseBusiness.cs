using Collage_ManageMent_System.Domain;
using Collage_ManageMent_System.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Collage_ManageMent_System.Business
{
    public class CourseBusiness : ICourseBusiness
    {
        public CourseBusiness(CollageContext _context)
        {
            
            Context = _context;
        }

        public CollageContext Context { get; }

        public void Delete(int id)
        {
            Course c = Context.Courses.FirstOrDefault(s => s.Id == id);
            if (c != null)
            {
                Context.Courses.Remove(c);
                Context.SaveChanges();
            }
        }

        public IEnumerable<Course> GetAll()
        {
            return Context.Courses.Include(c => c.Teacher);
        }

        public Course GetByID(int id)
        {
            return Context.Courses.FirstOrDefault(c => c.Id == id);
        }

        public void Insert(Course course)
        {
            Context.Courses.Add(course);
            Context.SaveChanges();
        }

        public void Update(Course course)
        {
            Context.Update(course);
            Context.SaveChanges();
        }
    }
}
