using Collage_ManageMent_System.Domain;
using Collage_ManageMent_System.Domain.ViewModels.StudentViewModels;
using Collage_ManageMent_System.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Collage_ManageMent_System.Controllers
{
    public class StudentRegisterController : Controller
    {
        public IStudentRegisterBusiness studentRegisterBusiness;
        public IStudentBusiness StudentBusiness;
        public   ICourseBusiness courseBusiness;

       public StudentRegisterController(IStudentRegisterBusiness studentRegisterBusiness,
            IStudentBusiness StudentBusiness,ICourseBusiness courseBusiness)
        {
            this.studentRegisterBusiness = studentRegisterBusiness;
            this.StudentBusiness = StudentBusiness;
            this.courseBusiness = courseBusiness;
        }
         
        public IActionResult Courses(int id)
        {
            List<Course> list = studentRegisterBusiness.GetRegisteredCourses(id);
            ViewBag.StudentId = id;
            return View(list);

        }

        public IActionResult AddNewCourse(int id)
        {
            StudentRegister sr = new StudentRegister();
            sr.student = StudentBusiness.GetByID(id);          
            sr.UnRegisteredCourses = studentRegisterBusiness.getUnRegisteredCourses(id);
            return View(sr);
        }

        [HttpPost]
        public IActionResult AddCourse(int StudentId,int CourseId)
        {
            studentRegisterBusiness.AddNewCourse(CourseId, StudentId);
            return RedirectToAction(nameof(Courses), new { id=StudentId});
        }

        [HttpPost]
        public IActionResult DeleteCourse(int StudentId, int CourseId)
        {
            studentRegisterBusiness.DeleteCourse(CourseId, StudentId);
            return RedirectToAction(nameof(Courses), new { id = StudentId });
        }
    }
}
