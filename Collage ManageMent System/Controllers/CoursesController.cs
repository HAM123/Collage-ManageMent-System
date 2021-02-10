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
    public class CoursesController : Controller
    {
     
        private readonly ICourseBusiness courseBusiness;

        public CoursesController(ICourseBusiness courseBusiness)
        {
             
            this.courseBusiness = courseBusiness;
        }

        // GET: Courses
        public  IActionResult  Index()
        {
            return View( courseBusiness.GetAll());
        }

        // GET: Courses/Details/5
        public IActionResult  Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = courseBusiness.GetByID(id.GetValueOrDefault());
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // GET: Courses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Courses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult  Create(  Course course)
        {
            if (ModelState.IsValid)
            {

                courseBusiness.Insert(course);
                return RedirectToAction(nameof(Index));
            }
            return View(course);
        }

        // GET: Courses/Edit/5
        public  IActionResult  Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course =   courseBusiness.GetByID( id.GetValueOrDefault());
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }

         
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id,   Course course)
        {
            if (id != course.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                
                    courseBusiness.Update(course);
                
                    return RedirectToAction(nameof(Index));
            }
            return View(course);
        }

        // GET: Courses/Delete/5
        public  IActionResult  Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = courseBusiness.GetByID(id.GetValueOrDefault());
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public  IActionResult DeleteConfirmed(int id)
        {
           
            courseBusiness.Delete(id);
            return RedirectToAction(nameof(Index));
        }

         
    }
}
