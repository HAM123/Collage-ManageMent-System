using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Collage_ManageMent_System.Domain;

namespace Collage_ManageMent_System.Controllers
{
    public class CoursesController : Controller
    {
        private readonly CollageContext _context;

        public CoursesController(CollageContext context)
        {
            _context = context;
        }

        // GET: Courses
        public  IActionResult  Index()
        {
            return View(  _context.Courses.ToList());
        }

        // GET: Courses/Details/5
        public IActionResult  Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course =   _context.Courses
                .FirstOrDefault (m => m.Id == id);
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
        public  IActionResult  Create([Bind("Id,Name,Description")] Course course)
        {
            if (ModelState.IsValid)
            {
                course.Id = Guid.NewGuid();
                _context.Add(course);
                  _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(course);
        }

        // GET: Courses/Edit/5
        public  IActionResult  Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course =   _context.Courses.Find (id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, [Bind("Id,Name,Description")] Course course)
        {
            if (id != course.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(course);
                      _context.SaveChanges ();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseExists(course.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(course);
        }

        // GET: Courses/Delete/5
        public  IActionResult  Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course =   _context.Courses
                .FirstOrDefault (m => m.Id == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public  IActionResult DeleteConfirmed(Guid id)
        {
            var course =   _context.Courses.Find (id);
            _context.Courses.Remove(course);
              _context.SaveChanges ();
            return RedirectToAction(nameof(Index));
        }

        private bool CourseExists(Guid id)
        {
            return _context.Courses.Any(e => e.Id == id);
        }
    }
}
