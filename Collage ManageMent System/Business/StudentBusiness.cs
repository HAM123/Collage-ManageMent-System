using Collage_ManageMent_System.Domain;
using Collage_ManageMent_System.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Collage_ManageMent_System.Business
{
    public class StudentBusiness : IStudentBusiness
    {
        private readonly CollageContext context;

        public StudentBusiness(CollageContext _context)
        {
            context = _context;
        }
        public void Delete(int id)
        {
            Student s = context.Students.FirstOrDefault(s => s.Id == id);
            if (s != null)
            {
                context.Students.Remove(s);
                context.SaveChanges();
            }
        }

        public List<Student> GetAll()
        {
            return context.Students.ToList();
        }

        public Student GetByID(int id)
        {
            return context.Students.FirstOrDefault(s => s.Id == id);
        }

        public void Insert(Student student)
        {
            context.Students.Add(student);
            context.SaveChanges();
        }

        public void Update(Student student)
        {
            context.Update(student);
            context.SaveChanges();
        }
    }
}
