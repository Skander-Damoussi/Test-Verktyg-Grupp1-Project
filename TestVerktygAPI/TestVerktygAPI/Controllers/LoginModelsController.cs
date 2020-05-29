using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    public class LoginModelsController : ControllerBase
    {
        private readonly TestVerktygAPIContext _context;

        public LoginModelsController(TestVerktygAPIContext context)
        {
            _context = context;
        }

        // GET: api/LoginModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LoginModel>>> GetLoginModel()
        {
            return await _context.LoginModel.ToListAsync();
        }

        // GET: api/LoginModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LoginModel>> GetLoginModel(int id)
        {
            var loginModel = await _context.LoginModel.FindAsync(id);

            if (loginModel == null)
            {
                return NotFound();
            }

            return loginModel;
        }

        // PUT: api/LoginModels/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLoginModel(int id, LoginModel loginModel)
        {
            if (id != loginModel.LoginId)
            {
                return BadRequest();
            }

            _context.Entry(loginModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoginModelExists(id))
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

        // POST: api/LoginModels
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<LoginModel>> PostLoginModel(LoginModel loginModel)
        {

           var  student = _context.Student.Where(s => s.Username == loginModel.Username && s.Password == loginModel.Password).FirstOrDefault();
           var  teacher = _context.Teacher.Where(s => s.Username == loginModel.Username && s.Password == loginModel.Password).FirstOrDefault();
                
          
            if (student != null || teacher != null)
            {
                if (student == null)

                {

                   

                            return Content(teacher.TeacherID.ToString());
                       
                    

                }
                else
                {
                    return Content(student.StudentID.ToString());
                }
            }
            else
            {
                return Content("Hittade ingen användare med det lösenordet");
            }

        }

        // DELETE: api/LoginModels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LoginModel>> DeleteLoginModel(int id)
        {
            var loginModel = await _context.LoginModel.FindAsync(id);
            if (loginModel == null)
            {
                return NotFound();
            }

            _context.LoginModel.Remove(loginModel);
            await _context.SaveChangesAsync();

            return loginModel;
        }

        private bool LoginModelExists(int id)
        {
            return _context.LoginModel.Any(e => e.LoginId == id);
        }
    }
}
