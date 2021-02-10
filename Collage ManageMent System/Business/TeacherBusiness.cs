using Collage_ManageMent_System.Domain;
using Collage_ManageMent_System.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Collage_ManageMent_System.Business
{
    public class TeacherBusinesss : ITeacherBusiness
    {
        private readonly CollageContext context;

        public TeacherBusinesss(CollageContext _context)
        {
            context = _context;
        }
        public void Delete(int id)
        {
            Teacher t = context.Teachers.FirstOrDefault(s => s.Id == id);
            if (t != null)
            {
                context.Teachers.Remove(t);
                context.SaveChanges();
            }
        }

        public IEnumerable<Teacher> GetAll()
        {
            return context.Teachers.ToList();
        }

        public Teacher GetByID(int id)
        {
            return context.Teachers.FirstOrDefault(t => t.Id == id);
        }

        public void Insert(Teacher teacher)
        {
            context.Teachers.Add(teacher);
            context.SaveChanges();
        }

        public void Update(Teacher teacher)
        {
            context.Update(teacher);
            context.SaveChanges();
        }
    }
}
