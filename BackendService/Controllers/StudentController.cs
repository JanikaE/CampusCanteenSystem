using Common.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BackendService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly CustomContext dbContext;

        public StudentController(CustomContext dbContext)
        {
            this.dbContext = dbContext;

            dbContext.Database.EnsureCreated();
        }

        [HttpGet]
        [Route("/Student/GetStudentByCardID")]
        public async Task<Student?> GetStudentByCardID([Required]string cardId)
        {
            try
            {
                Student student = await dbContext.Students.FirstAsync(n => n.CardId == cardId);
                return student;
            }
            catch
            {
                return Student.None;
            }
        }
    }
}
