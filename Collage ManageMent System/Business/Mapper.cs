using AutoMapper;
using Collage_ManageMent_System.Domain;
using Collage_ManageMent_System.Domain.ViewModels.StudentViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Collage_ManageMent_System.Business
{
    public class Mapper:Profile
    {
       public Mapper()
        {
            CreateMap<StudentViewModel, Student>();
            CreateMap< Student, StudentViewModel>();
        }
    }
}
