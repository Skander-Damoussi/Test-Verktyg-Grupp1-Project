using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestVerktygAPI.Data;
using TestVerktygAPI.Models;

namespace TestVerktygAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentExamsController : ControllerBase
    {
        private readonly TestVerktygAPIContext _context;

        public StudentExamsController(TestVerktygAPIContext context)
        {
            _context = context;
        }

        // GET: api/StudentExams
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentExam>>> GetStudentExam()
        {
            return await _context.StudentExam.ToListAsync();
        }

        // GET: api/StudentExams/5
        [HttpGet("{id}")]
        public async Task<ActionResult<List<StudentExam>>> GetStudentExam(int id)
        {
            var studentExam = await _context.StudentExam.Where(x => x.StudentID == id).ToListAsync();

            if (studentExam == null)
            {
                return Ok();
            }

            return studentExam;
        }

        // PUT: api/StudentExams/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudentExam(int id, StudentExam studentExam)
        {
            if (id != studentExam.StudentID)
            {
                return BadRequest();
            }

            _context.Entry(studentExam).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExamExists(id))
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

        // POST: api/StudentExams
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<StudentExam>> PostStudentExam(StudentExam studentExam)
        {
            _context.StudentExam.Add(studentExam);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (StudentExamExists(studentExam.StudentID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetStudentExam", new { id = studentExam.StudentID }, studentExam);
        }

        // DELETE: api/StudentExams/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<StudentExam>> DeleteStudentExam(int id)
        {
            var studentExam = await _context.StudentExam.FindAsync(id);
            if (studentExam == null)
            {
                return NotFound();
            }

            _context.StudentExam.Remove(studentExam);
            await _context.SaveChangesAsync();

            return studentExam;
        }

        private bool StudentExamExists(int id)
        {
            return _context.StudentExam.Any(e => e.StudentID == id);
        }
    }
}
