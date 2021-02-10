using Collage_ManageMent_System.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Collage_ManageMent_System.Interfaces
{
    public interface IStudentCourseBusiness
    {
        List<StudentCourse> GetByStudentId(int id);
        
        void Insert(StudentCourse studentCourse);
        void Delete(StudentCourse studentCourse);
    }
}
