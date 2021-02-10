using Collage_ManageMent_System.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Collage_ManageMent_System.Interfaces
{
   public interface ITeacherBusiness
    {
        IEnumerable<Teacher> GetAll();
        Teacher GetByID(int id);
        void Insert(Teacher teacher);
        void Update(Teacher teacher);
        void Delete(int id);
    }
}
