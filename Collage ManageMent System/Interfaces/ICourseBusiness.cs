using Collage_ManageMent_System.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Collage_ManageMent_System.Interfaces
{
   public interface ICourseBusiness
    {
        IEnumerable<Course> GetAll();
        Course GetByID(int id);
        void Insert(Course course);
        void Update(Course course);
        void Delete(int id);
       
    }
}
