using Collage_ManageMent_System.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Collage_ManageMent_System.Interfaces
{
 public   interface IStudentBusiness
    {
        List<Student>  GetAll();
        Student GetByID(int id);
        void Insert(Student student);
        void Update(Student student);
        void Delete(int id);
        
    }
}
