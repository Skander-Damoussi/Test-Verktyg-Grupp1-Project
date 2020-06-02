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
    public class ExamsController : ControllerBase
    {
        private readonly TestVerktygAPIContext _context;

        public ExamsController(TestVerktygAPIContext context)
        {
            _context = context;
        }

        // GET: api/Exams
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Exam>>> GetExam()
        {
            var exams = await _context.Exam
                .Include(e => e.Questions)
                .ToListAsync();
            return Ok(exams);
        }

        // GET: api/Exams/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Exam>> GetExam(int id)
        {
            var exam = await _context.Exam.FindAsync(id);

            if (exam == null)
            {
                return NotFound();
            }

            return exam;
        }

        // PUT: api/Exams/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExam(int id, Exam exam)
        {
            if (id != exam.ExamID)
            {
                return BadRequest();
            }

            _context.Entry(exam).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExamExists(id))
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

        // POST: api/Exams
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Exam>> PostExam(Exam exam)
        {
            exam.IsActive = true;

            _context.Exam.Add(exam);
            await _context.SaveChangesAsync();

            var students = await _context.Student.ToListAsync();

            foreach (Student student in students)
            {
                _context.StudentExam.Add(new StudentExam
                {
                    Exam = exam,
                    ExamID = exam.ExamID,
                    Student = student,
                    StudentID = student.StudentID
                });
            }

            await _context.SaveChangesAsync();
            return CreatedAtAction("GetExam", new { id = exam.ExamID }, exam);
        }

        // DELETE: api/Exams/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Exam>> DeleteExam(int id)
        {
            var exam = await _context.Exam.FindAsync(id);
            if (exam == null)
            {
                return NotFound();
            }

            _context.Exam.Remove(exam);
            await _context.SaveChangesAsync();

            return exam;
        }

        private bool ExamExists(int id)
        {
            return _context.Exam.Any(e => e.ExamID == id);
        }
    }
}
