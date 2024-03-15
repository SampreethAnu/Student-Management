using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Student_Management.DataContext;
using Student_Management.Models;

namespace Student_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly StudentDBContext _context;

        public StudentsController(StudentDBContext context)
        {
            _context = context;
        }

        // GET: api/Students
        [HttpGet]
        public IQueryable<Student> GetStudents()
        {
          //List Of Students
          List<Student> listofStudent = new List<Student>
          {
              new Student {Studentid = 1, StudentName ="Sampreet", StudentAge=15, AdmissionDate =DateTime.Now},
              new Student {Studentid = 2, StudentName ="Manju", StudentAge=15, AdmissionDate =DateTime.Now}
          };
          

            return  listofStudent.AsQueryable();
        }

        // GET: api/Students/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
          if (_context.Students == null)
          {
              return NotFound();
          }
            List<Student> listofStudent = new List<Student>
          {
              new Student {Studentid = 1, StudentName ="Sampreet", StudentAge=15, AdmissionDate =DateTime.Now},
              new Student {Studentid = 2, StudentName ="Manju", StudentAge=15, AdmissionDate =DateTime.Now}
          };
            var student = await _context.Students.FindAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            return student;
        }

        // PUT: api/Students/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent(int id, Student student)
        {
            if (id != student.Studentid)
            {
                return BadRequest();
            }

            _context.Entry(student).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
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

        // POST: api/Students
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Student>> PostStudent(Student student)
        {
          if (_context.Students == null)
          {
              return Problem("Entity set 'StudentDBContext.Students'  is null.");
          }
            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudent", new { id = student.Studentid }, student);
        }

        // DELETE: api/Students/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            if (_context.Students == null)
            {
                return NotFound();
            }
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentExists(int id)
        {
            return (_context.Students?.Any(e => e.Studentid == id)).GetValueOrDefault();
        }
    }
}
