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
    public class TeachersController : Controller
    {
        private readonly CollageContext _context;

        public TeachersController(CollageContext context)
        {
            _context = context;
        }

        // GET: Teachers
        public IActionResult  Index()
        {
            return View(  _context.Teachers.ToList ());
        }

        // GET: Teachers/Details/5
        public  IActionResult  Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacher =   _context.Teachers
                .FirstOrDefault (m => m.Id == id);
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

        // POST: Teachers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult  Create([Bind("Name,Id,Email,DateOfBrith,Gender,PhotoPath")] Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                teacher.Id = Guid.NewGuid();
                _context.Add(teacher);
                    _context.SaveChanges ();
                return RedirectToAction(nameof(Index));
            }
            return View(teacher);
        }

        // GET: Teachers/Edit/5
        public  IActionResult  Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacher =   _context.Teachers.Find(id);
            if (teacher == null)
            {
                return NotFound();
            }
            return View(teacher);
        }

        // POST: Teachers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult  Edit(Guid id, [Bind("Name,Id,Email,DateOfBrith,Gender,PhotoPath")] Teacher teacher)
        {
            if (id != teacher.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(teacher);
                      _context.SaveChanges ();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeacherExists(teacher.Id))
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
            return View(teacher);
        }

        // GET: Teachers/Delete/5
        public  IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacher = _context.Teachers
                .FirstOrDefault (m => m.Id == id);
            if (teacher == null)
            {
                return NotFound();
            }

            return View(teacher);
        }

        // POST: Teachers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public  IActionResult  DeleteConfirmed(Guid id)
        {
            var teacher =   _context.Teachers.Find(id);
            _context.Teachers.Remove(teacher);
              _context.SaveChanges ();
            return RedirectToAction(nameof(Index));
        }

        private bool TeacherExists(Guid id)
        {
            return _context.Teachers.Any(e => e.Id == id);
        }
    }
}
