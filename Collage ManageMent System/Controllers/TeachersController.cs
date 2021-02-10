using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Collage_ManageMent_System.Domain;
using Collage_ManageMent_System.Interfaces;

namespace Collage_ManageMent_System.Controllers
{
    public class TeachersController : Controller
    {
        private readonly ITeacherBusiness teacherBusiness;

        public TeachersController(ITeacherBusiness teacherBusiness)
        {
            this.teacherBusiness = teacherBusiness;
        }

        // GET: Teachers
        public IActionResult  Index()
        {
            return View(  teacherBusiness.GetAll());
        }

        // GET: Teachers/Details/5
        public  IActionResult  Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacher = teacherBusiness.GetByID(id.GetValueOrDefault());
            if (teacher == null)
            {
                return NotFound();
            }

            return View(teacher);
        }

        // GET: Teachers/Create
        public IActionResult Create()
        {
            return View();
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult  Create(  Teacher teacher)
        {
            if (ModelState.IsValid)
            {

                teacherBusiness.Insert(teacher);
                return RedirectToAction(nameof(Index));
            }
            return View(teacher);
        }

        // GET: Teachers/Edit/5
        public  IActionResult  Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacher =  teacherBusiness.GetByID(id.GetValueOrDefault());
            if (teacher == null)
            {
                return NotFound();
            }
            return View(teacher);
        }
 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult  Edit(int id,  Teacher teacher)
        {
            if (id != teacher.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                
                    teacherBusiness.Update(teacher);
                     
               
                 
                return RedirectToAction(nameof(Index));
            }
            return View(teacher);
        }

        // GET: Teachers/Delete/5
        public  IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacher = teacherBusiness.GetByID(id.GetValueOrDefault());
            if (teacher == null)
            {
                return NotFound();
            }

            return View(teacher);
        }

        // POST: Teachers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public  IActionResult  DeleteConfirmed(int id)
        {
            teacherBusiness.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        
    }
}
