using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlazorAppExam.Data;
using BlazorAppExam.Models;

namespace BlazorAppExam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly StudentsDb _context;

        public StudentsController(StudentsDb context)
        {
            _context = context;
        }

        // GET: api/Students
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Students>>> GetStudents()
        {
            return await _context.Students.Include(c => c.studentsMarks).ToListAsync();
        }

        // GET: api/Students/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Students>> GetStudents(int id)
        {
            var students = await _context.Students.Include(c => c.studentsMarks).FirstOrDefaultAsync(c => c.StudentId == id);

            if (students == null)
            {
                return NotFound();
            }

            return students;
        }

        // PUT: api/Students/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudents(int id, Students students)
        {
            if (id != students.StudentId)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(students);

                    var itemsIdList = students.studentsMarks.Select(i => i.ID).ToList();

                    var delItems = await _context.StudentsMarks.Where(i => i.StudentId == id).Where(i => !itemsIdList.Contains(i.ID)).ToListAsync();

                    _context.StudentsMarks.RemoveRange(delItems);


                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentsExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return NoContent();
            }
            return BadRequest(ModelState);
        }
        // POST: api/Students
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Students>> PostStudents(Students students)
        {
            _context.Students.Add(students);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudents", new { id = students.StudentId }, students);
        }


        // DELETE: api/Students/5
        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteStudents(int id)
        {
            var students = await _context.Students.Include(c => c.studentsMarks).FirstOrDefaultAsync(c => c.StudentId == id);
            if (students == null)
            {
                return NotFound();
            }




            _context.Students.Remove(students);
            await _context.SaveChangesAsync();

            return NoContent();
        }




        private bool StudentsExists(int id)
        {
            return _context.Students.Any(e => e.StudentId == id);
        }
    }
}

