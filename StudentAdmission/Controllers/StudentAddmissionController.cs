using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StudentAdmission.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentAddmissionController : ControllerBase
    {

        private readonly DataContext _context;
        public StudentAddmissionController(DataContext context)
        {
            _context = context; 
        }


        [HttpGet]
        public async Task<ActionResult<List<StudentAddmission>>> Get()
        {
          
            return Ok(await _context.StudentAddmissions.ToListAsync());

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<StudentAddmission>>> Get(int id)
        {
            var student = await _context.StudentAddmissions.FindAsync(id);
            if (student == null)
                return BadRequest("Student not found with this Id.try different id.");

            return Ok(student);

        }

        [HttpPost]
        public async Task<ActionResult<List<StudentAddmission>>> AddStudent(StudentAddmission studentAddmission)
        {
            _context.StudentAddmissions.Add(studentAddmission);
            await _context.SaveChangesAsync();  
            return Ok(await _context.StudentAddmissions.ToListAsync());

        }
        [HttpPut]
        public async Task<ActionResult<List<StudentAddmission>>> UpdateStudent(StudentAddmission ST)
        {
            var dbstudent = await _context.StudentAddmissions.FindAsync(ST.ID);
            if (dbstudent == null)
                return BadRequest("Student not found with this Id.This id not exist");

            dbstudent.FirstName= ST.FirstName;    
            dbstudent.LastName= ST.LastName;
            dbstudent.Address= ST.Address;
            dbstudent.Age= ST.Age;
            if (dbstudent.Age < 18)
                return BadRequest("Student must be over 18");
            await _context.SaveChangesAsync();

            return Ok(await _context.StudentAddmissions.ToListAsync());

        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<StudentAddmission>>> DeleteStudent(int id)
        {
            var dbstudent = await _context.StudentAddmissions.FindAsync(id);
            if (dbstudent == null)
                return BadRequest("There is no student with this id.");

            _context.StudentAddmissions.Remove(dbstudent);
            await _context.SaveChangesAsync();  
            return Ok(await _context.StudentAddmissions.ToListAsync());

        }

    }
}
