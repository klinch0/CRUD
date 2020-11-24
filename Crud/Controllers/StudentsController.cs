using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Crud.Models;
using Crud.DTOs;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Crud.Controllers
{
    public class StudentsController : ControllerBase
    {
        private readonly SchoolContext _context;

        public StudentsController(SchoolContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return Ok(await _context.Students.ToListAsync());
        }
        public async Task<IActionResult> StudentsByValue(string? firstMidName)
        {
            return Ok(await _context.Students.Where(x=>x.FirstMidName.Contains(firstMidName)).ToListAsync());
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .FirstOrDefaultAsync(m => m.ID == id);
            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        public IActionResult Create()
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] StudentDto student)
        {
            if (ModelState.IsValid)
            {
                _context.Add(new Student() { Age=student.Age, LastName=student.LastName, FirstMidName=student.FirstMidName});
                await _context.SaveChangesAsync();
                return Ok();
            }
            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromBody] Student student)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var studentEdited = _context.Students.First(x => x.ID == student.ID);
                    studentEdited.FirstMidName = student.FirstMidName;
                    studentEdited.Age = student.Age;
                    studentEdited.LastName = student.LastName;
                    _context.Update(studentEdited);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .FirstOrDefaultAsync(m => m.ID == id);
           
            if (student == null)
            {
                return NotFound();
            }
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return Ok();
        }


        private bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.ID == id);
        }
    }
}
