using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Collage_ManageMent_System.Domain;
using Collage_ManageMent_System.Business;
using Collage_ManageMent_System.Interfaces;
using Collage_ManageMent_System.Domain.ViewModels.StudentViewModels;
using AutoMapper;

namespace Collage_ManageMent_System.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStudentBusiness Business;
        private readonly IMapper mapper;

        public StudentsController(IStudentBusiness _Business ,IMapper mapper)
        {
            Business = _Business;
            this.mapper = mapper;
        }

        // GET: Students
        public ActionResult  Index()
        {
            List<Student> students = Business.GetAll().ToList();

           List<StudentViewModel>studentViewModels= mapper.Map<List<StudentViewModel>>(students);
            return View(studentViewModels);
        }

        // GET: Students/Details/5
        public   IActionResult  Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = Business.GetByID(int.Parse(id.ToString()));
            if (student == null)
            {
                return NotFound();
            }
            StudentViewModel studentViewModel = mapper.Map<StudentViewModel>(student);
            return View(studentViewModel);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public    IActionResult  Create( StudentViewModel student)
        {
            if (ModelState.IsValid)
            {
                Student s = mapper.Map<Student>(student);
                Business.Insert(s);
                  
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: Students/Edit/5
        public  IActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = Business.GetByID(id);
            if (student == null)
            {
                return NotFound();
            }
            StudentViewModel studentViewModel = mapper.Map<StudentViewModel>(student);
            return View(studentViewModel);
        }

         
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult  Edit(int id, StudentViewModel studentViewModel)
        {
            if (id != studentViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                Student student = mapper.Map<Student>(studentViewModel);
                    Business.Update(student);
                 
                
                return RedirectToAction(nameof(Index));
            }
            return View(studentViewModel);
        }

        // GET: Students/Delete/5
        public  IActionResult  Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var student = Business.GetByID(id.GetValueOrDefault());
            if (student == null)
            {
                return NotFound();
            }
            StudentViewModel studentViewModel = mapper.Map<StudentViewModel>(student);
            return View(studentViewModel);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public  IActionResult  DeleteConfirmed(int id)
        {
            
            Business.Delete(id);
            return RedirectToAction(nameof(Index));
        }
       

    }
}
